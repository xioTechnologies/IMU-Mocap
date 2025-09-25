using System;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

namespace Viewer.Runtime.Json
{
    public static class Parsing
    {
        private const int KeySize = 64;
        private const int TypeSize = 16;

        public static JsonResult ProcessPacket(Plotter plotter, UdpReceiveResult udpResult)
        {
            Span<char> charBuffer = stackalloc char[udpResult.Buffer.Length];

            int charCount = Encoding.ASCII.GetChars(udpResult.Buffer, charBuffer);

            ReadOnlySpan<char> jsonSpan = charBuffer.Slice(0, charCount);

            int position = 0;

            JsonResult result = Json99.ParseObjectStart(jsonSpan, ref position);
            if (result != JsonResult.Ok) return result;

            result = Json99.ParseObjectEnd(jsonSpan, ref position);
            if (result == JsonResult.Ok) return JsonResult.Ok;

            Span<char> keyBuffer = stackalloc char[KeySize];

            while (true)
            {
                // Parse key
                result = Json99.ParseKey(jsonSpan, ref position, keyBuffer, out int keyLength);
                if (result != JsonResult.Ok) return result;

                ReadOnlySpan<char> key = keyBuffer.Slice(0, keyLength);

                if (IsKey(key, "frame"))
                {
                    result = Frame(plotter, jsonSpan, ref position);
                    if (result != JsonResult.Ok) return result;
                }
                else if (IsKey(key, "text"))
                {
                    result = Text(plotter, jsonSpan, ref position);
                    if (result != JsonResult.Ok) return result;
                }
                else
                {
                    result = Json99.Parse(jsonSpan, ref position);
                    if (result != JsonResult.Ok) return result;
                }

                // Parse comma
                result = Json99.ParseComma(jsonSpan, ref position);
                if (result == JsonResult.Ok) continue;

                // Parse object end
                result = Json99.ParseObjectEnd(jsonSpan, ref position);
                if (result != JsonResult.Ok) return result;

                break;
            }

            return JsonResult.Ok;
        }

        private struct TextProperties : IMapper
        {
            public static readonly IMapper Mapper = new TextProperties();

            public const int String = 0;
            public const int Time = 1;

            public int Map(ReadOnlySpan<char> key)
            {
                if (IsKey(key, "string")) return String;
                if (IsKey(key, "time")) return Time;
                return -1;
            }
        }

        private static JsonResult Text(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            JsonResult result = Json99.ParseObjectStart(jsonSpan, ref position);
            if (result != JsonResult.Ok) return result;

            result = Json99.ParseObjectEnd(jsonSpan, ref position);
            if (result == JsonResult.Ok) return JsonResult.Ok;

            Span<int> propertyValues = stackalloc int[2] { -1, -1 };

            result = MapProperties(jsonSpan, ref position, propertyValues, TextProperties.Mapper);
            if (result != JsonResult.Ok) return result;

            result = Required(jsonSpan, propertyValues[TextProperties.String], out string value);
            if (result != JsonResult.Ok) return result;

            result = Optional(jsonSpan, propertyValues[TextProperties.Time], out float time, 0.0f);
            if (result != JsonResult.Ok) return result;

            plotter.Text(value, time);

            return JsonResult.Ok;
        }

        private struct FrameProperties : IMapper
        {
            public static readonly IMapper Mapper = new FrameProperties();

            public const int Primitives = 0;
            public const int Layer = 1;

            public int Map(ReadOnlySpan<char> key)
            {
                if (IsKey(key, "primitives")) return Primitives;
                if (IsKey(key, "layer")) return Layer;
                return -1;
            }
        }

        private static JsonResult Frame(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            JsonResult result = Json99.ParseObjectStart(jsonSpan, ref position);
            if (result != JsonResult.Ok) return result;

            plotter.Clear();

            result = Json99.ParseObjectEnd(jsonSpan, ref position);
            if (result == JsonResult.Ok) return JsonResult.Ok;

            Span<int> propertyValues = stackalloc int[2] { -1, -1 };

            result = MapProperties(jsonSpan, ref position, propertyValues, FrameProperties.Mapper);
            if (result != JsonResult.Ok) return result;

            result = Optional(jsonSpan, propertyValues[FrameProperties.Layer], out int layer, 0);
            if (result != JsonResult.Ok) return result;

            if (propertyValues[FrameProperties.Primitives] < 0) return JsonResult.MissingKey;

            return Primitives(plotter, layer, jsonSpan, propertyValues[FrameProperties.Primitives]);
        }

        private static JsonResult Primitives(Plotter plotter, int layer, ReadOnlySpan<char> jsonSpan, int position)
        {
            JsonResult result = Json99.ParseArrayStart(jsonSpan, ref position);
            if (result != JsonResult.Ok) return result;

            result = Json99.ParseArrayEnd(jsonSpan, ref position);
            if (result == JsonResult.Ok) return result;

            while (true)
            {
                result = Primitive(plotter, layer, jsonSpan, ref position);
                if (result != JsonResult.Ok) return result;

                result = Json99.ParseComma(jsonSpan, ref position);
                if (result == JsonResult.Ok) continue;

                result = Json99.ParseArrayEnd(jsonSpan, ref position);
                if (result == JsonResult.Ok) return JsonResult.Ok;
            }

            return JsonResult.Ok;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonResult Primitive(Plotter plotter, int layer, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            JsonResult result = Json99.ParseObjectStart(jsonSpan, ref position);
            if (result != JsonResult.Ok) return result;

            result = Json99.ParseObjectEnd(jsonSpan, ref position);
            if (result == JsonResult.Ok) return JsonResult.Ok;

            result = GetSingleProperty(jsonSpan, position, "type", out int typePosition);
            if (result != JsonResult.Ok) return result;

            Span<char> typeBuffer = stackalloc char[TypeSize];
            result = Json99.ParseString(jsonSpan, ref typePosition, typeBuffer, out int typeLength);
            if (result != JsonResult.Ok) return result;

            ReadOnlySpan<char> type = typeBuffer.Slice(0, typeLength);

            if (IsKey(type, "line")) return Line(plotter, jsonSpan, ref position);

            if (IsKey(type, "circle")) return Circle(plotter, jsonSpan, ref position);

            if (IsKey(type, "dot")) return Dot(plotter, jsonSpan, ref position);

            if (IsKey(type, "axes")) return Axes(plotter, jsonSpan, ref position);

            if (IsKey(type, "label")) return Label(plotter, jsonSpan, ref position);

            if (IsKey(type, "angles")) return Angles(plotter, jsonSpan, ref position);

            if (IsKey(type, "angle")) return Angle(plotter, jsonSpan, ref position);

            if (IsKey(type, "pedestal")) return Pedestal(plotter, jsonSpan, ref position);

            return SkipRemainder(jsonSpan, ref position);
        }

        private struct LineProperties : IMapper
        {
            public static readonly IMapper Mapper = new LineProperties();

            public const int Start = 0;
            public const int End = 1;

            public int Map(ReadOnlySpan<char> key)
            {
                if (IsKey(key, "start")) return Start;
                if (IsKey(key, "end")) return End;
                return -1;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static JsonResult Line(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            Span<int> propertyValues = stackalloc int[2] { -1, -1 };

            JsonResult result = MapProperties(jsonSpan, ref position, propertyValues, LineProperties.Mapper);
            if (result != JsonResult.Ok) return result;
            
            result = Required(jsonSpan, propertyValues[LineProperties.Start], out Vector3 start);
            if (result != JsonResult.Ok) return result;
            
            result = Required(jsonSpan, propertyValues[LineProperties.End], out Vector3 end);
            if (result != JsonResult.Ok) return result;

            plotter.Line(start, end);

            return JsonResult.Ok;
        }

        private struct DotProperties : IMapper
        {
            public static readonly IMapper Mapper = new DotProperties();

            public const int Xyz = 0;
            public const int Size = 1;

            public int Map(ReadOnlySpan<char> key)
            {
                if (IsKey(key, "xyz")) return Xyz;
                if (IsKey(key, "size")) return Size;
                return -1;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonResult Dot(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            Span<int> propertyValues = stackalloc int[2] { -1, -1 };

            JsonResult result = MapProperties(jsonSpan, ref position, propertyValues, DotProperties.Mapper);
            if (result != JsonResult.Ok) return result;
            
            result = Required(jsonSpan, propertyValues[DotProperties.Xyz], out Vector3 xyz);
            if (result != JsonResult.Ok) return result;

            result = Required(jsonSpan, propertyValues[DotProperties.Size], out float size);
            if (result != JsonResult.Ok) return result;

            plotter.Dot(xyz, size);

            return JsonResult.Ok;
        }

        private struct PedestalProperties : IMapper
        {
            public static readonly IMapper Mapper = new PedestalProperties();

            public const int Xyz = 0;

            public int Map(ReadOnlySpan<char> key)
            {
                if (IsKey(key, "xyz")) return Xyz;
                return -1;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonResult Pedestal(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            Span<int> propertyValues = stackalloc int[1] { -1 };

            JsonResult result = MapProperties(jsonSpan, ref position, propertyValues, PedestalProperties.Mapper);
            if (result != JsonResult.Ok) return result;

            result = Required(jsonSpan, propertyValues[PedestalProperties.Xyz], out Vector3 xyz);
            if (result != JsonResult.Ok) return result;

            plotter.Pedestal(xyz);

            return JsonResult.Ok;
        }

        private struct CircleProperties : IMapper
        {
            public static readonly IMapper Mapper = new CircleProperties();

            public const int Xyz = 0;
            public const int Axis = 1;
            public const int Radius = 2;

            public int Map(ReadOnlySpan<char> key)
            {
                if (IsKey(key, "xyz")) return Xyz;
                if (IsKey(key, "axis")) return Axis;
                if (IsKey(key, "radius")) return Radius;
                return -1;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonResult Circle(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            Span<int> propertyValues = stackalloc int[3] { -1, -1, -1 };

            JsonResult result = MapProperties(jsonSpan, ref position, propertyValues, CircleProperties.Mapper);
            if (result != JsonResult.Ok) return result;

            result = Required(jsonSpan, propertyValues[CircleProperties.Xyz], out Vector3 xyz);
            if (result != JsonResult.Ok) return result;

            result = Required(jsonSpan, propertyValues[CircleProperties.Axis], out Vector3 axis);
            if (result != JsonResult.Ok) return result;

            result = Required(jsonSpan, propertyValues[CircleProperties.Radius], out float radius);
            if (result != JsonResult.Ok) return result;

            plotter.Circle(xyz, axis, radius);

            return JsonResult.Ok;
        }

        private struct AxesProperties : IMapper
        {
            public static readonly IMapper Mapper = new AxesProperties();

            public const int Xyz = 0;
            public const int Quaternion = 1;
            public const int Scale = 2;

            public int Map(ReadOnlySpan<char> key)
            {
                if (IsKey(key, "xyz")) return Xyz;
                if (IsKey(key, "quaternion")) return Quaternion;
                if (IsKey(key, "scale")) return Scale;
                return -1;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonResult Axes(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            Span<int> propertyValues = stackalloc int[3] { -1, -1, -1 };

            JsonResult result = MapProperties(jsonSpan, ref position, propertyValues, AxesProperties.Mapper);
            if (result != JsonResult.Ok) return result;

            result = Required(jsonSpan, propertyValues[AxesProperties.Xyz], out Vector3 xyz);
            if (result != JsonResult.Ok) return result;
            
            result = Required(jsonSpan, propertyValues[AxesProperties.Quaternion], out Quaternion quaternion);
            if (result != JsonResult.Ok) return result;

            result = Required(jsonSpan, propertyValues[AxesProperties.Scale], out float scale);
            if (result != JsonResult.Ok) return result;

            plotter.Axes(xyz, quaternion, scale);

            return JsonResult.Ok;
        }

        private struct LabelProperties : IMapper
        {
            public static readonly IMapper Mapper = new LabelProperties();

            public const int Xyz = 0;
            public const int Text = 1;

            public int Map(ReadOnlySpan<char> key)
            {
                if (IsKey(key, "xyz")) return Xyz;
                if (IsKey(key, "text")) return Text;
                return -1;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonResult Label(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            Span<int> propertyValues = stackalloc int[2] { -1, -1 };

            JsonResult result = MapProperties(jsonSpan, ref position, propertyValues, LabelProperties.Mapper);
            if (result != JsonResult.Ok) return result;

            result = Required(jsonSpan, propertyValues[LabelProperties.Xyz], out Vector3 xyz);
            if (result != JsonResult.Ok) return result;

            Span<char> textBuffer = stackalloc char[128];
            result = Required(jsonSpan, propertyValues[LabelProperties.Text], textBuffer, out int textLength);
            if (result != JsonResult.Ok) return result;

            plotter.Label(xyz, textBuffer.Slice(0, textLength));

            return JsonResult.Ok;
        }

        private struct AngleProperties : IMapper
        {
            public static readonly IMapper Mapper = new AngleProperties();

            public const int Xyz = 0;
            public const int Quaternion = 1;
            public const int Angle = 2;
            public const int Scale = 3;

            public int Map(ReadOnlySpan<char> key)
            {
                if (IsKey(key, "xyz")) return Xyz;
                if (IsKey(key, "quaternion")) return Quaternion;
                if (IsKey(key, "angle")) return Angle;
                if (IsKey(key, "scale")) return Scale;
                return -1;
            }
        }

        private static JsonResult Angle(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            Span<int> propertyValues = stackalloc int[4] { -1, -1, -1, -1 };

            JsonResult result = MapProperties(jsonSpan, ref position, propertyValues, AngleProperties.Mapper);
            if (result != JsonResult.Ok) return result;

            result = Required(jsonSpan, propertyValues[AngleProperties.Xyz], out Vector3 xyz);
            if (result != JsonResult.Ok) return result;

            result = Required(jsonSpan, propertyValues[AngleProperties.Quaternion], out Quaternion quaternion);
            if (result != JsonResult.Ok) return result;

            result = Required(jsonSpan, propertyValues[AngleProperties.Angle], out float angle);
            if (result != JsonResult.Ok) return result;

            result = Required(jsonSpan, propertyValues[AngleProperties.Scale], out float scale);
            if (result != JsonResult.Ok) return result;

            plotter.Angle(xyz, quaternion, angle, scale);

            return JsonResult.Ok;
        }

        private struct AnglesProperties : IMapper
        {
            public static readonly IMapper Mapper = new AnglesProperties();

            public const int Xyz = 0;
            public const int Quaternion = 1;
            public const int Alpha = 2;
            public const int Beta = 3;
            public const int Gamma = 4;
            public const int AlphaLimit = 5;
            public const int BetaLimit = 6;
            public const int GammaLimit = 7;
            public const int Scale = 8;
            public const int Mirror = 9;

            public int Map(ReadOnlySpan<char> key)
            {
                if (IsKey(key, "xyz")) return Xyz;
                if (IsKey(key, "quaternion")) return Quaternion;
                if (IsKey(key, "alpha")) return Alpha;
                if (IsKey(key, "beta")) return Beta;
                if (IsKey(key, "gamma")) return Gamma;
                if (IsKey(key, "alpha_limit")) return AlphaLimit;
                if (IsKey(key, "beta_limit")) return BetaLimit;
                if (IsKey(key, "gamma_limit")) return GammaLimit;
                if (IsKey(key, "scale")) return Scale;
                if (IsKey(key, "mirror")) return Mirror;
                return -1;
            }
        }

        private static JsonResult Angles(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            Span<int> propertyValues = stackalloc int[10] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };

            JsonResult result = MapProperties(jsonSpan, ref position, propertyValues, AnglesProperties.Mapper);
            if (result != JsonResult.Ok) return result;
            
            result = Required(jsonSpan, propertyValues[AnglesProperties.Xyz], out Vector3 xyz);
            if (result != JsonResult.Ok) return result;
            
            result = Required(jsonSpan, propertyValues[AnglesProperties.Quaternion], out Quaternion quaternion);
            if (result != JsonResult.Ok) return result;

            result = Optional(jsonSpan, propertyValues[AnglesProperties.Alpha], out float? alpha);
            if (result != JsonResult.Ok) return result;

            result = Optional(jsonSpan, propertyValues[AnglesProperties.Beta], out float? beta);
            if (result != JsonResult.Ok) return result;

            result = Optional(jsonSpan, propertyValues[AnglesProperties.Gamma], out float? gamma);
            if (result != JsonResult.Ok) return result;

            result = Optional(jsonSpan, propertyValues[AnglesProperties.AlphaLimit], out (float min, float max)? alphaLimit);
            if (result != JsonResult.Ok) return result;

            result = Optional(jsonSpan, propertyValues[AnglesProperties.BetaLimit], out (float min, float max)? betaLimit);
            if (result != JsonResult.Ok) return result;

            result = Optional(jsonSpan, propertyValues[AnglesProperties.GammaLimit], out (float min, float max)? gammaLimit);
            if (result != JsonResult.Ok) return result;

            result = Required(jsonSpan, propertyValues[AnglesProperties.Scale], out float scale);
            if (result != JsonResult.Ok) return result;

            result = Optional(jsonSpan, propertyValues[AnglesProperties.Mirror], out bool mirror);
            if (result != JsonResult.Ok) return result;

            plotter.Angles(
                xyz,
                quaternion,
                AngleAndLimit(alpha, alphaLimit),
                AngleAndLimit(beta, betaLimit),
                AngleAndLimit(gamma, gammaLimit),
                scale,
                mirror
            );

            return JsonResult.Ok;
        }

        private interface IMapper
        {
            int Map(ReadOnlySpan<char> key);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonResult GetSingleProperty(ReadOnlySpan<char> jsonSpan, int position, string key, out int valuePosition)
        {
            valuePosition = -1;

            Span<char> keyBuffer = stackalloc char[KeySize];

            ReadOnlySpan<char> matcher = key.AsSpan();

            while (true)
            {
                JsonResult result = Json99.ParseKey(jsonSpan, ref position, keyBuffer, out int keyLength);
                if (result != JsonResult.Ok) return result;

                ReadOnlySpan<char> propertyKey = keyBuffer.Slice(0, keyLength);

                if (matcher.SequenceEqual(propertyKey) == true)
                {
                    valuePosition = position;

                    return JsonResult.Ok;
                }

                result = Json99.Parse(jsonSpan, ref position);
                if (result != JsonResult.Ok) return result;

                result = Json99.ParseComma(jsonSpan, ref position);
                if (result == JsonResult.Ok) continue;

                result = Json99.ParseObjectEnd(jsonSpan, ref position);
                if (result != JsonResult.Ok) return result;

                break;
            }

            return JsonResult.MissingKey;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonResult MapProperties(ReadOnlySpan<char> jsonSpan, ref int position, Span<int> positions, IMapper mapper)
        {
            Span<char> keyBuffer = stackalloc char[KeySize];

            while (true)
            {
                JsonResult result = Json99.ParseKey(jsonSpan, ref position, keyBuffer, out int keyLength);
                if (result != JsonResult.Ok) return result;

                ReadOnlySpan<char> key = keyBuffer.Slice(0, keyLength);

                int index = mapper.Map(key);

                if (index >= 0) positions[index] = position;

                result = Json99.Parse(jsonSpan, ref position);
                if (result != JsonResult.Ok) return result;

                result = Json99.ParseComma(jsonSpan, ref position);
                if (result == JsonResult.Ok) continue;

                result = Json99.ParseObjectEnd(jsonSpan, ref position);
                if (result != JsonResult.Ok) return result;

                break;
            }

            return JsonResult.Ok;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsKey(ReadOnlySpan<char> buffer, string literal) => buffer.SequenceEqual(literal.AsSpan());

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonResult SkipRemainder(ReadOnlySpan<char> jsonSpan, ref int position)
        {
            Span<char> keyBuffer = stackalloc char[KeySize];

            while (true)
            {
                JsonResult result = Json99.ParseKey(jsonSpan, ref position, keyBuffer, out int keyLength);
                if (result != JsonResult.Ok) return result;

                result = Json99.Parse(jsonSpan, ref position);
                if (result != JsonResult.Ok) return result;

                result = Json99.ParseComma(jsonSpan, ref position);
                if (result == JsonResult.Ok) continue;

                result = Json99.ParseObjectEnd(jsonSpan, ref position);
                if (result != JsonResult.Ok) return result;

                break;
            }

            return JsonResult.Ok;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static AngleAndLimit? AngleAndLimit(float? angle, (float min, float max)? limits)
        {
            if (angle.HasValue == false) return null;

            return new AngleAndLimit(angle.Value, limits);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonResult Required(ReadOnlySpan<char> jsonSpan, int position, out float value)
        {
            value = 0;

            if (position < 0) return JsonResult.MissingKey;

            return Json99.ParseNumber(jsonSpan, ref position, out value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonResult Required(ReadOnlySpan<char> jsonSpan, int position, Span<char> destination, out int length)
        {
            length = 0;

            if (position < 0) return JsonResult.MissingKey;

            return Json99.ParseString(jsonSpan, ref position, destination, out length);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonResult Required(ReadOnlySpan<char> jsonSpan, int position, out Vector3 xyz)
        {
            xyz = Vector3.zero;
            
            if (position < 0) return JsonResult.MissingKey;

            Span<float> destination = stackalloc float[3];
            JsonResult result = Json99.ParseNumberArray(jsonSpan, ref position, destination, out int parsedLength);

            if (parsedLength != 3) return JsonResult.InvalidNumberFormat;

            xyz = new Vector3(destination[0], destination[2], destination[1]); // swizzle! 
            
            return result;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonResult Required(ReadOnlySpan<char> jsonSpan, int position, out Quaternion quaternion)
        {
            quaternion = Quaternion.identity;
            
            if (position < 0) return JsonResult.MissingKey;

            Span<float> destination = stackalloc float[4];
            JsonResult result = Json99.ParseNumberArray(jsonSpan, ref position, destination, out int parsedLength);

            if (parsedLength != 4) return JsonResult.InvalidNumberFormat;
            
            quaternion = new Quaternion(-destination[1], -destination[3], -destination[2], destination[0]).normalized; // swizzle! 
            
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonResult Required(ReadOnlySpan<char> jsonSpan, int position, Span<float> destination, int length)
        {
            if (position < 0) return JsonResult.MissingKey;

            JsonResult result = Json99.ParseNumberArray(jsonSpan, ref position, destination, out int parsedLength);

            if (parsedLength != length) return JsonResult.InvalidNumberFormat;

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonResult Required(ReadOnlySpan<char> jsonSpan, int position, out string value)
        {
            value = null;

            if (position < 0) return JsonResult.MissingKey;

            int start = position;

            var result = Json99.ParseString(jsonSpan, ref position, Span<char>.Empty, out int len);
            if (result != JsonResult.Ok) return result;

            char[] buf = new char[len];
            
            position = start;

            result = Json99.ParseString(jsonSpan, ref position, buf.AsSpan(0, len), out int written);

            if (result != JsonResult.Ok) return result;

            value = new string(buf, 0, written); // can this come from a pool or something? is buffer owned by string at this point? 

            return JsonResult.Ok;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonResult Optional(ReadOnlySpan<char> jsonSpan, int position, out float value, float @default = 0)
        {
            value = @default;

            if (position < 0) return JsonResult.Ok;

            return Json99.ParseNumber(jsonSpan, ref position, out value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonResult Optional(ReadOnlySpan<char> jsonSpan, int position, out int value, int @default = 0)
        {
            value = @default;

            if (position < 0) return JsonResult.Ok;

            JsonResult result = Json99.ParseNumber(jsonSpan, ref position, out float floatValue);

            if (result != JsonResult.Ok) return result;

            value = (int)floatValue;

            return JsonResult.Ok;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonResult Optional(ReadOnlySpan<char> jsonSpan, int position, out float? value)
        {
            value = null;

            if (position < 0) return JsonResult.Ok;

            var result = Json99.ParseNumber(jsonSpan, ref position, out float floatValue);

            if (result != JsonResult.Ok) return result;

            value = floatValue;

            return JsonResult.Ok;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonResult Optional(ReadOnlySpan<char> jsonSpan, int position, out bool value, bool @default = false)
        {
            value = @default;

            if (position < 0) return JsonResult.Ok;

            return Json99.ParseBoolean(jsonSpan, ref position, out value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonResult Optional(ReadOnlySpan<char> jsonSpan, int position, out (float min, float max)? value)
        {
            value = null;

            if (position < 0) return JsonResult.Ok;

            Span<float> values = stackalloc float[2];

            JsonResult result = Required(jsonSpan, position, values, 2);

            if (result != JsonResult.Ok) return result;

            value = (values[0], values[1]);

            return JsonResult.Ok;
        }
    }
}