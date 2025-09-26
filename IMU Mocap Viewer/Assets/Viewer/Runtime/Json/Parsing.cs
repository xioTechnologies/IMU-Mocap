using System;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using Unity.Profiling;
using UnityEngine;

namespace Viewer.Runtime.Json
{
    public static class Parsing
    {
        private static ProfilerMarker FrameMarker = new(nameof(Parsing) + ".Frame");
        private static ProfilerMarker PrimitiveMarker = new(nameof(Parsing) + ".Primitive");
        private static ProfilerMarker LineMarker = new(nameof(Parsing) + ".Line");
        private static ProfilerMarker CircleMarker = new(nameof(Parsing) + ".Circle");
        private static ProfilerMarker DotMarker = new(nameof(Parsing) + ".Dot");
        private static ProfilerMarker AxesMarker = new(nameof(Parsing) + ".Axes");
        private static ProfilerMarker LabelMarker = new(nameof(Parsing) + ".Label");
        private static ProfilerMarker AnglesMarker = new(nameof(Parsing) + ".Angles");
        private static ProfilerMarker AngleMarker = new(nameof(Parsing) + ".Angle");
        private static ProfilerMarker PedestalMarker = new(nameof(Parsing) + ".Pedestal");

        private const int TypeSize = 16;

        public static JsonResult ProcessPacket(Plotter plotter, UdpReceiveResult udpResult)
        {
            Span<char> charBuffer = stackalloc char[udpResult.Buffer.Length];

            int charCount = Encoding.ASCII.GetChars(udpResult.Buffer, charBuffer);

            ReadOnlySpan<char> jsonSpan = charBuffer.Slice(0, charCount);

            int position = 0;

            JsonResult result = JsonZero.ParseObjectStart(jsonSpan, ref position);
            if (result != JsonResult.Ok) return result;

            result = JsonZero.ParseObjectEnd(jsonSpan, ref position);
            if (result == JsonResult.Ok) return JsonResult.Ok;

            Span<char> keyBuffer = stackalloc char[JsonProperties.KeySize];

            while (true)
            {
                // Parse key
                result = JsonZero.ParseKey(jsonSpan, ref position, keyBuffer, out int keyLength);
                if (result != JsonResult.Ok) return result;

                ReadOnlySpan<char> key = keyBuffer.Slice(0, keyLength);

                if (JsonProperties.IsKey(key, "frame"))
                {
                    using (FrameMarker.Auto())
                    {
                        result = Frame(plotter, jsonSpan, ref position);
                        if (result != JsonResult.Ok) return result;
                    }
                }
                else if (JsonProperties.IsKey(key, "text"))
                {
                    result = Text(plotter, jsonSpan, ref position);
                    if (result != JsonResult.Ok) return result;
                }
                else
                {
                    result = JsonZero.Parse(jsonSpan, ref position);
                    if (result != JsonResult.Ok) return result;
                }

                // Parse comma
                result = JsonZero.ParseComma(jsonSpan, ref position);
                if (result == JsonResult.Ok) continue;

                // Parse object end
                result = JsonZero.ParseObjectEnd(jsonSpan, ref position);
                if (result != JsonResult.Ok) return result;

                break;
            }

            return JsonResult.Ok;
        }

        private struct TextProperties : IPropertyParser
        {
            public static TextProperties Parser = new();

            public const int String = 0;
            public const int Time = 1;

            public int Map(ReadOnlySpan<char> key)
            {
                if (JsonProperties.IsKey(key, "string")) return String;
                if (JsonProperties.IsKey(key, "time")) return Time;
                return -1;
            }
        }

        private static JsonResult Text(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            JsonResult result = JsonZero.ParseObjectStart(jsonSpan, ref position);
            if (result != JsonResult.Ok) return result;

            result = JsonZero.ParseObjectEnd(jsonSpan, ref position);
            if (result == JsonResult.Ok) return JsonResult.Ok;

            Span<int> propertyValues = stackalloc int[2] { -1, -1 };

            result = JsonProperties.MapProperties(jsonSpan, ref position, propertyValues, ref TextProperties.Parser);
            if (result != JsonResult.Ok) return result;

            result = JsonProperties.Required(jsonSpan, propertyValues[TextProperties.String], out string value);
            if (result != JsonResult.Ok) return result;

            result = JsonProperties.Optional(jsonSpan, propertyValues[TextProperties.Time], out float time, 0.0f);
            if (result != JsonResult.Ok) return result;

            plotter.Text(value, time);

            return JsonResult.Ok;
        }

        private struct FrameProperties : IPropertyParser
        {
            public static FrameProperties Parser = new();

            public const int Primitives = 0;
            public const int Layer = 1;

            public int Map(ReadOnlySpan<char> key)
            {
                if (JsonProperties.IsKey(key, "primitives")) return Primitives;
                if (JsonProperties.IsKey(key, "layer")) return Layer;
                return -1;
            }
        }

        private static JsonResult Frame(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            JsonResult result = JsonZero.ParseObjectStart(jsonSpan, ref position);
            if (result != JsonResult.Ok) return result;

            plotter.Clear();

            result = JsonZero.ParseObjectEnd(jsonSpan, ref position);
            if (result == JsonResult.Ok) return JsonResult.Ok;

            Span<int> propertyValues = stackalloc int[2] { -1, -1 };
            
            // primitives property is likely to be very large so we really don't want to have to parse it twice 
            
            result = JsonProperties.GetSingleProperty(jsonSpan, position, "layer", out int layerPosition);
            if (result != JsonResult.Ok && result != JsonResult.MissingKey) return result;
            
            result = JsonProperties.Optional(jsonSpan, layerPosition, out int layer, 0);
            if (result != JsonResult.Ok) return result;
            
            result = JsonProperties.GetSingleProperty(jsonSpan, position, "primitives", out int primitivesPosition);
            if (result != JsonResult.Ok) return result;

            position = primitivesPosition; 
            
            result = Primitives(plotter, layer, jsonSpan, ref position);
            if (result != JsonResult.Ok) return result;

            return SkipRemainder(jsonSpan, ref position);
        }

        private static JsonResult Primitives(Plotter plotter, int layer, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            JsonResult result = JsonZero.ParseArrayStart(jsonSpan, ref position);
            if (result != JsonResult.Ok) return result;

            result = JsonZero.ParseArrayEnd(jsonSpan, ref position);
            if (result == JsonResult.Ok) return result;

            while (true)
            {
                using (PrimitiveMarker.Auto())
                {
                    result = Primitive(plotter, layer, jsonSpan, ref position);
                    if (result != JsonResult.Ok) return result;
                }

                result = JsonZero.ParseComma(jsonSpan, ref position);
                if (result == JsonResult.Ok) continue;

                result = JsonZero.ParseArrayEnd(jsonSpan, ref position);
                if (result == JsonResult.Ok) return JsonResult.Ok;
            }

            return JsonResult.Ok;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonResult Primitive(Plotter plotter, int layer, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            JsonResult result = JsonZero.ParseObjectStart(jsonSpan, ref position);
            if (result != JsonResult.Ok) return result;

            result = JsonZero.ParseObjectEnd(jsonSpan, ref position);
            if (result == JsonResult.Ok) return JsonResult.Ok;

            result = JsonProperties.GetSingleProperty(jsonSpan, position, "type", out int typePosition);
            if (result != JsonResult.Ok) return result;

            Span<char> typeBuffer = stackalloc char[TypeSize];
            result = JsonZero.ParseString(jsonSpan, ref typePosition, typeBuffer, out int typeLength);
            if (result != JsonResult.Ok) return result;

            ReadOnlySpan<char> type = typeBuffer.Slice(0, typeLength);

            if (JsonProperties.IsKey(type, "line")) return Line(plotter, jsonSpan, ref position);

            if (JsonProperties.IsKey(type, "circle")) return Circle(plotter, jsonSpan, ref position);

            if (JsonProperties.IsKey(type, "dot")) return Dot(plotter, jsonSpan, ref position);

            if (JsonProperties.IsKey(type, "axes")) return Axes(plotter, jsonSpan, ref position);

            if (JsonProperties.IsKey(type, "label")) return Label(plotter, jsonSpan, ref position);

            if (JsonProperties.IsKey(type, "angles")) return Angles(plotter, jsonSpan, ref position);

            if (JsonProperties.IsKey(type, "angle")) return Angle(plotter, jsonSpan, ref position);

            if (JsonProperties.IsKey(type, "pedestal")) return Pedestal(plotter, jsonSpan, ref position);

            return SkipRemainder(jsonSpan, ref position);
        }

        private struct LineProperties : IPropertyParser
        {
            public static LineProperties Parser = new();

            public const int Start = 0;
            public const int End = 1;

            public int Map(ReadOnlySpan<char> key)
            {
                if (JsonProperties.IsKey(key, "start")) return Start;
                if (JsonProperties.IsKey(key, "end")) return End;
                return -1;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static JsonResult Line(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            using (LineMarker.Auto())
            {
                Span<int> propertyValues = stackalloc int[2] { -1, -1 };

                JsonResult result = JsonProperties.MapProperties(jsonSpan, ref position, propertyValues, ref LineProperties.Parser);
                if (result != JsonResult.Ok) return result;

                result = JsonProperties.Required(jsonSpan, propertyValues[LineProperties.Start], out Vector3 start);
                if (result != JsonResult.Ok) return result;

                result = JsonProperties.Required(jsonSpan, propertyValues[LineProperties.End], out Vector3 end);
                if (result != JsonResult.Ok) return result;

                plotter.Line(start, end);

                return JsonResult.Ok;
            }
        }

        private struct DotProperties : IPropertyParser
        {
            public static DotProperties Parser = new();

            public const int Xyz = 0;
            public const int Size = 1;

            public int Map(ReadOnlySpan<char> key)
            {
                if (JsonProperties.IsKey(key, "xyz")) return Xyz;
                if (JsonProperties.IsKey(key, "size")) return Size;
                return -1;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonResult Dot(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            using (DotMarker.Auto())
            {
                Span<int> propertyValues = stackalloc int[2] { -1, -1 };

                JsonResult result = JsonProperties.MapProperties(jsonSpan, ref position, propertyValues, ref DotProperties.Parser);
                if (result != JsonResult.Ok) return result;

                result = JsonProperties.Required(jsonSpan, propertyValues[DotProperties.Xyz], out Vector3 xyz);
                if (result != JsonResult.Ok) return result;

                result = JsonProperties.Required(jsonSpan, propertyValues[DotProperties.Size], out float size);
                if (result != JsonResult.Ok) return result;

                plotter.Dot(xyz, size);

                return JsonResult.Ok;
            }
        }

        private struct PedestalProperties : IPropertyParser
        {
            public static PedestalProperties Parser = new();

            public const int Xyz = 0;

            public int Map(ReadOnlySpan<char> key)
            {
                if (JsonProperties.IsKey(key, "xyz")) return Xyz;
                return -1;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonResult Pedestal(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            using (PedestalMarker.Auto())
            {
                Span<int> propertyValues = stackalloc int[1] { -1 };

                JsonResult result = JsonProperties.MapProperties(jsonSpan, ref position, propertyValues, ref PedestalProperties.Parser);
                if (result != JsonResult.Ok) return result;

                result = JsonProperties.Required(jsonSpan, propertyValues[PedestalProperties.Xyz], out Vector3 xyz);
                if (result != JsonResult.Ok) return result;

                plotter.Pedestal(xyz);

                return JsonResult.Ok;
            }
        }

        private struct CircleProperties : IPropertyParser
        {
            public static CircleProperties Parser = new();

            public const int Xyz = 0;
            public const int Axis = 1;
            public const int Radius = 2;

            public int Map(ReadOnlySpan<char> key)
            {
                if (JsonProperties.IsKey(key, "xyz")) return Xyz;
                if (JsonProperties.IsKey(key, "axis")) return Axis;
                if (JsonProperties.IsKey(key, "radius")) return Radius;
                return -1;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonResult Circle(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            using (CircleMarker.Auto())
            {
                Span<int> propertyValues = stackalloc int[3] { -1, -1, -1 };

                JsonResult result = JsonProperties.MapProperties(jsonSpan, ref position, propertyValues, ref CircleProperties.Parser);
                if (result != JsonResult.Ok) return result;

                result = JsonProperties.Required(jsonSpan, propertyValues[CircleProperties.Xyz], out Vector3 xyz);
                if (result != JsonResult.Ok) return result;

                result = JsonProperties.Required(jsonSpan, propertyValues[CircleProperties.Axis], out Vector3 axis);
                if (result != JsonResult.Ok) return result;

                result = JsonProperties.Required(jsonSpan, propertyValues[CircleProperties.Radius], out float radius);
                if (result != JsonResult.Ok) return result;

                plotter.Circle(xyz, axis, radius);

                return JsonResult.Ok;
            }
        }

        private struct AxesProperties : IPropertyParser
        {
            public static AxesProperties Parser = new();

            public const int Xyz = 0;
            public const int Quaternion = 1;
            public const int Scale = 2;

            public int Map(ReadOnlySpan<char> key)
            {
                if (JsonProperties.IsKey(key, "xyz")) return Xyz;
                if (JsonProperties.IsKey(key, "quaternion")) return Quaternion;
                if (JsonProperties.IsKey(key, "scale")) return Scale;
                return -1;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonResult Axes(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            using (AxesMarker.Auto())
            {
                Span<int> propertyValues = stackalloc int[3] { -1, -1, -1 };

                JsonResult result = JsonProperties.MapProperties(jsonSpan, ref position, propertyValues, ref AxesProperties.Parser);
                if (result != JsonResult.Ok) return result;

                result = JsonProperties.Required(jsonSpan, propertyValues[AxesProperties.Xyz], out Vector3 xyz);
                if (result != JsonResult.Ok) return result;

                result = JsonProperties.Required(jsonSpan, propertyValues[AxesProperties.Quaternion], out Quaternion quaternion);
                if (result != JsonResult.Ok) return result;

                result = JsonProperties.Required(jsonSpan, propertyValues[AxesProperties.Scale], out float scale);
                if (result != JsonResult.Ok) return result;

                plotter.Axes(xyz, quaternion, scale);

                return JsonResult.Ok;
            }
        }

        private struct LabelProperties : IPropertyParser
        {
            public static LabelProperties Parser = new();

            public const int Xyz = 0;
            public const int Text = 1;

            public int Map(ReadOnlySpan<char> key)
            {
                if (JsonProperties.IsKey(key, "xyz")) return Xyz;
                if (JsonProperties.IsKey(key, "text")) return Text;
                return -1;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonResult Label(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            using (LabelMarker.Auto())
            {
                Span<int> propertyValues = stackalloc int[2] { -1, -1 };

                JsonResult result = JsonProperties.MapProperties(jsonSpan, ref position, propertyValues, ref LabelProperties.Parser);
                if (result != JsonResult.Ok) return result;

                result = JsonProperties.Required(jsonSpan, propertyValues[LabelProperties.Xyz], out Vector3 xyz);
                if (result != JsonResult.Ok) return result;

                Span<char> textBuffer = stackalloc char[128];
                result = JsonProperties.Required(jsonSpan, propertyValues[LabelProperties.Text], textBuffer, out int textLength);
                if (result != JsonResult.Ok) return result;

                plotter.Label(xyz, textBuffer.Slice(0, textLength));

                return JsonResult.Ok;
            }
        }

        private struct AngleProperties : IPropertyParser
        {
            public static AngleProperties Parser = new();

            public const int Xyz = 0;
            public const int Quaternion = 1;
            public const int Angle = 2;
            public const int Scale = 3;

            public int Map(ReadOnlySpan<char> key)
            {
                if (JsonProperties.IsKey(key, "xyz")) return Xyz;
                if (JsonProperties.IsKey(key, "quaternion")) return Quaternion;
                if (JsonProperties.IsKey(key, "angle")) return Angle;
                if (JsonProperties.IsKey(key, "scale")) return Scale;
                return -1;
            }
        }

        private static JsonResult Angle(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            using (AngleMarker.Auto())
            {
                Span<int> propertyValues = stackalloc int[4] { -1, -1, -1, -1 };

                JsonResult result = JsonProperties.MapProperties(jsonSpan, ref position, propertyValues, ref AngleProperties.Parser);
                if (result != JsonResult.Ok) return result;

                result = JsonProperties.Required(jsonSpan, propertyValues[AngleProperties.Xyz], out Vector3 xyz);
                if (result != JsonResult.Ok) return result;

                result = JsonProperties.Required(jsonSpan, propertyValues[AngleProperties.Quaternion], out Quaternion quaternion);
                if (result != JsonResult.Ok) return result;

                result = JsonProperties.Required(jsonSpan, propertyValues[AngleProperties.Angle], out float angle);
                if (result != JsonResult.Ok) return result;

                result = JsonProperties.Required(jsonSpan, propertyValues[AngleProperties.Scale], out float scale);
                if (result != JsonResult.Ok) return result;

                plotter.Angle(xyz, quaternion, angle, scale);

                return JsonResult.Ok;
            }
        }

        private struct AnglesProperties : IPropertyParser
        {
            public static AnglesProperties Parser = new();

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
                if (JsonProperties.IsKey(key, "xyz")) return Xyz;
                if (JsonProperties.IsKey(key, "quaternion")) return Quaternion;
                if (JsonProperties.IsKey(key, "alpha")) return Alpha;
                if (JsonProperties.IsKey(key, "beta")) return Beta;
                if (JsonProperties.IsKey(key, "gamma")) return Gamma;
                if (JsonProperties.IsKey(key, "alpha_limit")) return AlphaLimit;
                if (JsonProperties.IsKey(key, "beta_limit")) return BetaLimit;
                if (JsonProperties.IsKey(key, "gamma_limit")) return GammaLimit;
                if (JsonProperties.IsKey(key, "scale")) return Scale;
                if (JsonProperties.IsKey(key, "mirror")) return Mirror;
                return -1;
            }
        }

        private static JsonResult Angles(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            using (AnglesMarker.Auto())
            {
                Span<int> propertyValues = stackalloc int[10] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };

                JsonResult result = JsonProperties.MapProperties(jsonSpan, ref position, propertyValues, ref AnglesProperties.Parser);
                if (result != JsonResult.Ok) return result;

                result = JsonProperties.Required(jsonSpan, propertyValues[AnglesProperties.Xyz], out Vector3 xyz);
                if (result != JsonResult.Ok) return result;

                result = JsonProperties.Required(jsonSpan, propertyValues[AnglesProperties.Quaternion], out Quaternion quaternion);
                if (result != JsonResult.Ok) return result;

                result = JsonProperties.Optional(jsonSpan, propertyValues[AnglesProperties.Alpha], out float? alpha);
                if (result != JsonResult.Ok) return result;

                result = JsonProperties.Optional(jsonSpan, propertyValues[AnglesProperties.Beta], out float? beta);
                if (result != JsonResult.Ok) return result;

                result = JsonProperties.Optional(jsonSpan, propertyValues[AnglesProperties.Gamma], out float? gamma);
                if (result != JsonResult.Ok) return result;

                result = JsonProperties.Optional(jsonSpan, propertyValues[AnglesProperties.AlphaLimit], out (float min, float max)? alphaLimit);
                if (result != JsonResult.Ok) return result;

                result = JsonProperties.Optional(jsonSpan, propertyValues[AnglesProperties.BetaLimit], out (float min, float max)? betaLimit);
                if (result != JsonResult.Ok) return result;

                result = JsonProperties.Optional(jsonSpan, propertyValues[AnglesProperties.GammaLimit], out (float min, float max)? gammaLimit);
                if (result != JsonResult.Ok) return result;

                result = JsonProperties.Required(jsonSpan, propertyValues[AnglesProperties.Scale], out float scale);
                if (result != JsonResult.Ok) return result;

                result = JsonProperties.Optional(jsonSpan, propertyValues[AnglesProperties.Mirror], out bool mirror);
                if (result != JsonResult.Ok) return result;

                AngleAndLimit? alphaAngleLimit = AngleAndLimit(alpha, alphaLimit);
                AngleAndLimit? betaAngleLimit = AngleAndLimit(beta, betaLimit);
                AngleAndLimit? gammaAngleLimit = AngleAndLimit(gamma, gammaLimit);
                
                plotter.Angles(
                    xyz,
                    quaternion,
                    alphaAngleLimit,
                    betaAngleLimit,
                    gammaAngleLimit,
                    scale,
                    mirror
                );

                return JsonResult.Ok;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonResult SkipRemainder(ReadOnlySpan<char> jsonSpan, ref int position)
        {
            Span<char> keyBuffer = stackalloc char[JsonProperties.KeySize];

            while (true)
            {
                JsonResult result = JsonZero.ParseKey(jsonSpan, ref position, keyBuffer, out int keyLength);
                if (result != JsonResult.Ok) return result;

                result = JsonZero.Parse(jsonSpan, ref position);
                if (result != JsonResult.Ok) return result;

                result = JsonZero.ParseComma(jsonSpan, ref position);
                if (result == JsonResult.Ok) continue;

                result = JsonZero.ParseObjectEnd(jsonSpan, ref position);
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
    }
}