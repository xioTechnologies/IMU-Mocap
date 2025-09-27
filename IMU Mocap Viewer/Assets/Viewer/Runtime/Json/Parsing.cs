using System;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

namespace Viewer.Runtime.Json
{
    public static class Parsing
    {
        public static JsonResult ProcessPacket(Plotter plotter, UdpReceiveResult udpResult)
        {
            Span<char> charBuffer = stackalloc char[udpResult.Buffer.Length];

            int charCount = Encoding.UTF8.GetChars(udpResult.Buffer, charBuffer);

            ReadOnlySpan<char> jsonSpan = charBuffer.Slice(0, charCount);

            int position = 0;

            Packet properties = new() { Plotter = plotter };

            return JsonZero.ParseObject(jsonSpan, ref position, ref properties);
        }

        private struct Packet : IJsonObjectParser
        {
            public Plotter Plotter;

            public JsonResult Peep(ReadOnlySpan<char> jsonSpan, int position) => JsonResult.Ok;

            public JsonResult Parse(ReadOnlySpan<char> key, ReadOnlySpan<char> jsonSpan, ref int position)
            {
                if (JsonZero.IsKey(key, "frame"))
                {
                    Frame parser = new() { Plotter = Plotter };

                    return JsonZero.ParseObject(jsonSpan, ref position, ref parser);
                }

                if (JsonZero.IsKey(key, "text"))
                {
                    Text parser = new() { Plotter = Plotter };

                    return JsonZero.ParseObject(jsonSpan, ref position, ref parser);
                }


                return JsonZero.Parse(jsonSpan, ref position);
            }

            public JsonResult Finish() => JsonResult.Ok;
        }

        private struct Text : IJsonObjectParser
        {
            public Plotter Plotter;

            private string @string;
            private float time;

            public JsonResult Peep(ReadOnlySpan<char> jsonSpan, int position) => JsonResult.Ok;

            public JsonResult Parse(ReadOnlySpan<char> key, ReadOnlySpan<char> jsonSpan, ref int position)
            {
                if (JsonZero.IsKey(key, "string")) return JsonZero.ParseDynamicString(jsonSpan, ref position, out @string);
                if (JsonZero.IsKey(key, "time")) return JsonZero.Parse(jsonSpan, ref position, out time);

                return JsonZero.Parse(jsonSpan, ref position);
            }

            public JsonResult Finish()
            {
                if (@string == null) return JsonResult.MissingKey;

                Plotter.Text(@string, time);

                return JsonResult.Ok;
            }
        }

        private struct Frame : IJsonObjectParser
        {
            public Plotter Plotter;

            private int layer;

            public JsonResult Peep(ReadOnlySpan<char> jsonSpan, int position)
            {
                Plotter.Clear();

                JsonResult result = JsonZero.PeepProperty(jsonSpan, position, "layer", out int layerPosition);

                if (result == JsonResult.MissingKey) return JsonResult.Ok;

                if (result != JsonResult.Ok) return result;

                return JsonZero.Parse(jsonSpan, ref layerPosition, out layer, 0);
            }

            public JsonResult Parse(ReadOnlySpan<char> key, ReadOnlySpan<char> jsonSpan, ref int position)
            {
                if (JsonZero.IsKey(key, "primitives"))
                {
                    Primitives parser = new() { Plotter = Plotter, Layer = layer };

                    return JsonZero.ParseDiscriminatedArray(jsonSpan, ref position, ref parser);
                }

                return JsonZero.Parse(jsonSpan, ref position);
            }

            public JsonResult Finish() => JsonResult.Ok;
        }

        private struct Primitives : IJsonTypeDiscriminatingParser
        {
            public Plotter Plotter;
            public int Layer;

            public JsonResult Parse(ReadOnlySpan<char> type, ReadOnlySpan<char> jsonSpan, ref int position)
            {
                if (JsonZero.IsKey(type, "line"))
                {
                    Line parser = new() { Plotter = Plotter, Layer = Layer };

                    return JsonZero.ParseObject(jsonSpan, ref position, ref parser);
                }

                if (JsonZero.IsKey(type, "circle"))
                {
                    Circle parser = new() { Plotter = Plotter, Layer = Layer };

                    return JsonZero.ParseObject(jsonSpan, ref position, ref parser);
                }

                if (JsonZero.IsKey(type, "dot"))
                {
                    Dot parser = new() { Plotter = Plotter, Layer = Layer };

                    return JsonZero.ParseObject(jsonSpan, ref position, ref parser);
                }

                if (JsonZero.IsKey(type, "axes"))
                {
                    Axes parser = new() { Plotter = Plotter, Layer = Layer };

                    return JsonZero.ParseObject(jsonSpan, ref position, ref parser);
                }

                if (JsonZero.IsKey(type, "label"))
                {
                    Label parser = new() { Plotter = Plotter, Layer = Layer };

                    return JsonZero.ParseObject(jsonSpan, ref position, ref parser);
                }

                if (JsonZero.IsKey(type, "angles"))
                {
                    Angles parser = new() { Plotter = Plotter, Layer = Layer };

                    return JsonZero.ParseObject(jsonSpan, ref position, ref parser);
                }

                if (JsonZero.IsKey(type, "angle"))
                {
                    Angle parser = new() { Plotter = Plotter, Layer = Layer };

                    return JsonZero.ParseObject(jsonSpan, ref position, ref parser);
                }

                if (JsonZero.IsKey(type, "pedestal"))
                {
                    Pedestal parser = new() { Plotter = Plotter, Layer = Layer };

                    return JsonZero.ParseObject(jsonSpan, ref position, ref parser);
                }

                return JsonZero.Parse(jsonSpan, ref position);
            }
        }

        private struct Line : IJsonObjectParser
        {
            public Plotter Plotter;
            public int Layer;

            private Vector3? start;
            private Vector3? end;

            public JsonResult Peep(ReadOnlySpan<char> jsonSpan, int position) => JsonResult.Ok;

            public JsonResult Parse(ReadOnlySpan<char> key, ReadOnlySpan<char> jsonSpan, ref int position)
            {
                if (JsonZero.IsKey(key, "start")) return JsonZero.Parse(jsonSpan, ref position, out start);
                if (JsonZero.IsKey(key, "end")) return JsonZero.Parse(jsonSpan, ref position, out end);

                return JsonZero.Parse(jsonSpan, ref position);
            }

            public JsonResult Finish()
            {
                if (start == null) return JsonResult.MissingKey;

                if (end == null) return JsonResult.MissingKey;

                Plotter.Line(start.Value, end.Value);

                return JsonResult.Ok;
            }
        }

        private struct Dot : IJsonObjectParser
        {
            public Plotter Plotter;
            public int Layer;

            private Vector3? xyz;
            private float? size;

            public JsonResult Peep(ReadOnlySpan<char> jsonSpan, int position) => JsonResult.Ok;

            public JsonResult Parse(ReadOnlySpan<char> key, ReadOnlySpan<char> jsonSpan, ref int position)
            {
                if (JsonZero.IsKey(key, "xyz")) return JsonZero.Parse(jsonSpan, ref position, out xyz);
                if (JsonZero.IsKey(key, "size")) return JsonZero.Parse(jsonSpan, ref position, out size);

                return JsonZero.Parse(jsonSpan, ref position);
            }

            public JsonResult Finish()
            {
                if (xyz == null) return JsonResult.MissingKey;

                if (size == null) return JsonResult.MissingKey;

                Plotter.Dot(xyz.Value, size.Value);

                return JsonResult.Ok;
            }
        }

        private struct Pedestal : IJsonObjectParser
        {
            public Plotter Plotter;
            public int Layer;

            private Vector3? xyz;

            public JsonResult Peep(ReadOnlySpan<char> jsonSpan, int position) => JsonResult.Ok;

            public JsonResult Parse(ReadOnlySpan<char> key, ReadOnlySpan<char> jsonSpan, ref int position)
            {
                if (JsonZero.IsKey(key, "xyz")) return JsonZero.Parse(jsonSpan, ref position, out xyz);

                return JsonZero.Parse(jsonSpan, ref position);
            }

            public JsonResult Finish()
            {
                if (xyz == null) return JsonResult.MissingKey;

                Plotter.Pedestal(xyz.Value);

                return JsonResult.Ok;
            }
        }

        private struct Circle : IJsonObjectParser
        {
            public Plotter Plotter;
            public int Layer;

            private Vector3? xyz;
            private Vector3? axis;
            private float? radius;

            public JsonResult Peep(ReadOnlySpan<char> jsonSpan, int position) => JsonResult.Ok;

            public JsonResult Parse(ReadOnlySpan<char> key, ReadOnlySpan<char> jsonSpan, ref int position)
            {
                if (JsonZero.IsKey(key, "xyz")) return JsonZero.Parse(jsonSpan, ref position, out xyz);
                if (JsonZero.IsKey(key, "axis")) return JsonZero.Parse(jsonSpan, ref position, out axis);
                if (JsonZero.IsKey(key, "radius")) return JsonZero.Parse(jsonSpan, ref position, out radius);

                return JsonZero.Parse(jsonSpan, ref position);
            }

            public JsonResult Finish()
            {
                if (xyz == null) return JsonResult.MissingKey;
                if (axis == null) return JsonResult.MissingKey;
                if (radius == null) return JsonResult.MissingKey;

                Plotter.Circle(xyz.Value, axis.Value, radius.Value);

                return JsonResult.Ok;
            }
        }

        private struct Axes : IJsonObjectParser
        {
            public Plotter Plotter;
            public int Layer;

            private Vector3? xyz;
            private Quaternion? quaternion;
            private float? scale;

            public JsonResult Peep(ReadOnlySpan<char> jsonSpan, int position) => JsonResult.Ok;

            public JsonResult Parse(ReadOnlySpan<char> key, ReadOnlySpan<char> jsonSpan, ref int position)
            {
                if (JsonZero.IsKey(key, "xyz")) return JsonZero.Parse(jsonSpan, ref position, out xyz);
                if (JsonZero.IsKey(key, "quaternion")) return JsonZero.Parse(jsonSpan, ref position, out quaternion);
                if (JsonZero.IsKey(key, "scale")) return JsonZero.Parse(jsonSpan, ref position, out scale);

                return JsonZero.Parse(jsonSpan, ref position);
            }

            public JsonResult Finish()
            {
                if (xyz == null) return JsonResult.MissingKey;
                if (quaternion == null) return JsonResult.MissingKey;
                if (scale == null) return JsonResult.MissingKey;

                Plotter.Axes(xyz.Value, quaternion.Value, scale.Value);

                return JsonResult.Ok;
            }
        }

        private struct Label : IJsonObjectParser
        {
            public const int MaxLabelLength = 128;
            
            private unsafe fixed char textBuffer[MaxLabelLength];
            private int? textLength;

            public Plotter Plotter;
            public int Layer;

            private Vector3? xyz;

            public JsonResult Peep(ReadOnlySpan<char> jsonSpan, int position) => JsonResult.Ok;

            public JsonResult Parse(ReadOnlySpan<char> key, ReadOnlySpan<char> jsonSpan, ref int position)
            {
                if (JsonZero.IsKey(key, "xyz")) return JsonZero.Parse(jsonSpan, ref position, out xyz);
                if (JsonZero.IsKey(key, "text"))
                {
                    unsafe
                    {
                        fixed (char* ptr = textBuffer)
                        {
                            Span<char> span = new Span<char>(ptr, MaxLabelLength);

                            JsonResult result = JsonZero.Parse(jsonSpan, ref position, span, out int length);

                            if (result != JsonResult.Ok) return result;

                            textLength = length;

                            return JsonResult.Ok;
                        }
                    }
                }

                return JsonZero.Parse(jsonSpan, ref position);
            }

            public JsonResult Finish()
            {
                if (xyz == null) return JsonResult.MissingKey;
                if (textLength == null) return JsonResult.MissingKey;

                unsafe
                {
                    fixed (char* ptr = textBuffer)
                    {
                        Plotter.Label(xyz.Value, new ReadOnlySpan<char>(ptr, textLength.Value));
                    }
                }

                return JsonResult.Ok;
            }
        }

        private struct Angle : IJsonObjectParser
        {
            public Plotter Plotter;
            public int Layer;

            private Vector3? xyz;
            private Quaternion? quaternion;
            private float? angle;
            private float? scale;

            public JsonResult Peep(ReadOnlySpan<char> jsonSpan, int position) => JsonResult.Ok;

            public JsonResult Parse(ReadOnlySpan<char> key, ReadOnlySpan<char> jsonSpan, ref int position)
            {
                if (JsonZero.IsKey(key, "xyz")) return JsonZero.Parse(jsonSpan, ref position, out xyz);
                if (JsonZero.IsKey(key, "quaternion")) return JsonZero.Parse(jsonSpan, ref position, out quaternion);
                if (JsonZero.IsKey(key, "angle")) return JsonZero.Parse(jsonSpan, ref position, out angle);
                if (JsonZero.IsKey(key, "scale")) return JsonZero.Parse(jsonSpan, ref position, out scale);

                return JsonZero.Parse(jsonSpan, ref position);
            }

            public JsonResult Finish()
            {
                if (xyz == null) return JsonResult.MissingKey;
                if (quaternion == null) return JsonResult.MissingKey;
                if (angle == null) return JsonResult.MissingKey;
                if (scale == null) return JsonResult.MissingKey;

                Plotter.Angle(xyz.Value, quaternion.Value, angle.Value, scale.Value);

                return JsonResult.Ok;
            }
        }

        private struct Angles : IJsonObjectParser
        {
            public Plotter Plotter;
            public int Layer;

            private Vector3? xyz;
            private Quaternion? quaternion;

            private float? alpha;
            private float? beta;
            private float? gamma;

            private (float min, float max)? alphaLimit;
            private (float min, float max)? betaLimit;
            private (float min, float max)? gammaLimit;

            private float scale;
            private bool mirror;

            public JsonResult Peep(ReadOnlySpan<char> jsonSpan, int position)
            {
                scale = 1; // set default scale  

                return JsonResult.Ok;
            }

            public JsonResult Parse(ReadOnlySpan<char> key, ReadOnlySpan<char> jsonSpan, ref int position)
            {
                if (JsonZero.IsKey(key, "xyz")) return JsonZero.Parse(jsonSpan, ref position, out xyz);
                if (JsonZero.IsKey(key, "quaternion")) return JsonZero.Parse(jsonSpan, ref position, out quaternion);
                if (JsonZero.IsKey(key, "alpha")) return JsonZero.Parse(jsonSpan, ref position, out alpha);
                if (JsonZero.IsKey(key, "beta")) return JsonZero.Parse(jsonSpan, ref position, out beta);
                if (JsonZero.IsKey(key, "gamma")) return JsonZero.Parse(jsonSpan, ref position, out gamma);
                if (JsonZero.IsKey(key, "alpha_limit")) return JsonZero.Parse(jsonSpan, ref position, out alphaLimit);
                if (JsonZero.IsKey(key, "beta_limit")) return JsonZero.Parse(jsonSpan, ref position, out betaLimit);
                if (JsonZero.IsKey(key, "gamma_limit")) return JsonZero.Parse(jsonSpan, ref position, out gammaLimit);
                if (JsonZero.IsKey(key, "mirror")) return JsonZero.Parse(jsonSpan, ref position, out mirror, false);
                if (JsonZero.IsKey(key, "scale")) return JsonZero.Parse(jsonSpan, ref position, out scale, 1f);

                return JsonZero.Parse(jsonSpan, ref position);
            }

            public JsonResult Finish()
            {
                if (xyz == null) return JsonResult.MissingKey;
                if (quaternion == null) return JsonResult.MissingKey;

                AngleAndLimit? alphaAngleLimit = AngleAndLimit(alpha, alphaLimit);
                AngleAndLimit? betaAngleLimit = AngleAndLimit(beta, betaLimit);
                AngleAndLimit? gammaAngleLimit = AngleAndLimit(gamma, gammaLimit);

                Plotter.Angles(
                    xyz.Value,
                    quaternion.Value,
                    alphaAngleLimit,
                    betaAngleLimit,
                    gammaAngleLimit,
                    scale,
                    mirror
                );

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
}