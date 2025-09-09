using System;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

namespace Viewer.Runtime.Json
{
    public static class Parsing
    {
        private const int KeySize = 32;

        public static JsonResult ProcessPacket(Plotter plotter, UdpReceiveResult udpResult)
        {
            Span<char> charBuffer = stackalloc char[udpResult.Buffer.Length];

            int charCount = Encoding.ASCII.GetChars(udpResult.Buffer, charBuffer);

            ReadOnlySpan<char> jsonSpan = charBuffer.Slice(0, charCount);

            int position = 0;

            if (Json99.ParseObjectStart(jsonSpan, ref position) != JsonResult.Ok)
            {
                return JsonResult.UnexpectedType;
            }

            Span<char> keyBuffer = stackalloc char[KeySize];

            bool first = true;

            while (true)
            {
                var propertySetupResult = TryBeginProperty(jsonSpan, ref position, first, keyBuffer, out int keyLength);
                if (propertySetupResult == null) break;
                if (propertySetupResult.Value != JsonResult.Ok) return propertySetupResult.Value;
                first = false;

                ReadOnlySpan<char> key = keyBuffer.Slice(0, keyLength);

                if (IsKey(key, "frame"))
                {
                    JsonResult result = Frame(plotter, jsonSpan, ref position);

                    if (result != JsonResult.Ok) return result;

                    continue;
                }

                if (IsKey(key, "text"))
                {
                    JsonResult result = Text(plotter, jsonSpan, ref position);

                    if (result != JsonResult.Ok) return result;

                    continue;
                }

                Json99.Parse(jsonSpan, ref position);
            }

            return JsonResult.Ok;
        }

        private static JsonResult Frame(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            JsonResult result = Json99.ParseObjectStart(jsonSpan, ref position);

            if (result != JsonResult.Ok) return result;

            plotter.Clear();

            Span<char> keyBuffer = stackalloc char[KeySize];

            int layer = 0;
            bool first = true;

            while (true)
            {
                var propertySetupResult = TryBeginProperty(jsonSpan, ref position, first, keyBuffer, out int keyLength);
                if (propertySetupResult == null) break;
                if (propertySetupResult.Value != JsonResult.Ok) return propertySetupResult.Value;
                first = false;

                ReadOnlySpan<char> key = keyBuffer.Slice(0, keyLength);

                // layer must come first 
                if (IsKey(key, "layer"))
                {
                    result = Json99.ParseNumber(jsonSpan, ref position, out float layerNumber);

                    if (result != JsonResult.Ok) return result;

                    layer = (int)layerNumber;

                    continue;
                }

                if (IsKey(key, "primitives"))
                {
                    result = Primitives(plotter, layer, jsonSpan, ref position);

                    if (result != JsonResult.Ok) return result;

                    continue;
                }

                Json99.Parse(jsonSpan, ref position);
            }

            return JsonResult.Ok;
        }

        private static JsonResult Primitives(Plotter plotter, int layer, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            JsonResult result = JsonResult.Ok;

            result = Json99.ParseArrayStart(jsonSpan, ref position);
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

        private static JsonResult Primitive(Plotter plotter, int layer, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            // Ensure we are at the start of an object for this primitive
            JsonResult result = Json99.ParseObjectStart(jsonSpan, ref position);

            if (result != JsonResult.Ok) return result;

            Span<char> keyBuffer = stackalloc char[KeySize];

            JsonResult? propertySetupResult = TryBeginProperty(jsonSpan, ref position, true, keyBuffer, out int keyLength);
            if (propertySetupResult == null) return JsonResult.InvalidSyntax;
            if (propertySetupResult.Value != JsonResult.Ok) return propertySetupResult.Value;

            ReadOnlySpan<char> key = keyBuffer.Slice(0, keyLength);

            if (key.SequenceEqual("type".AsSpan()) == false) return JsonResult.InvalidSyntax; // First key should always be type

            Span<char> typeBuffer = stackalloc char[16];

            result = Json99.ParseString(jsonSpan, ref position, typeBuffer, out int typeLength);

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

            Debug.LogError($"Unknown primitive type: {type.ToString()}");

            return SkipRemainder(jsonSpan, ref position);
        }

        private static JsonResult Text(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            JsonResult result = Json99.ParseObjectStart(jsonSpan, ref position);

            if (result != JsonResult.Ok) return result;

            Span<char> keyBuffer = stackalloc char[KeySize];

            string value = null;
            float time = 0;
            bool first = true;

            while (true)
            {
                var propertySetupResult = TryBeginProperty(jsonSpan, ref position, first, keyBuffer, out int keyLength);
                if (propertySetupResult == null) break;
                if (propertySetupResult.Value != JsonResult.Ok) return propertySetupResult.Value;
                first = false;

                ReadOnlySpan<char> key = keyBuffer.Slice(0, keyLength);

                if (IsKey(key, "text"))
                {
                    result = ParseDynamicString(jsonSpan, ref position, out value);

                    if (result != JsonResult.Ok) return result;

                    continue;
                }

                if (IsKey(key, "seconds"))
                {
                    result = Json99.ParseNumber(jsonSpan, ref position, out time);

                    if (result != JsonResult.Ok) return result;

                    continue;
                }

                Json99.Parse(jsonSpan, ref position);
            }

            if (value != null) plotter.Text(value, time);

            return JsonResult.Ok;
        }

        static JsonResult Line(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            Span<float> start = stackalloc float[3];
            Span<float> end = stackalloc float[3];
            Span<char> keyBuffer = stackalloc char[KeySize];
            bool hasStart = false, hasEnd = false;

            while (true)
            {
                var propertySetupResult = TryBeginProperty(jsonSpan, ref position, false, keyBuffer, out int keyLength);
                if (propertySetupResult == null) break;
                if (propertySetupResult.Value != JsonResult.Ok) return propertySetupResult.Value;

                ReadOnlySpan<char> key = keyBuffer.Slice(0, keyLength);

                if (IsKey(key, "start"))
                {
                    var result = ParseNumberArrayProperty(jsonSpan, ref position, start, 3);

                    if (result != JsonResult.Ok) return result;

                    hasStart = true;

                    continue;
                }

                if (IsKey(key, "end"))
                {
                    var result = ParseNumberArrayProperty(jsonSpan, ref position, end, 3);

                    if (result != JsonResult.Ok) return result;

                    hasEnd = true;

                    continue;
                }

                Json99.Parse(jsonSpan, ref position); // Skip unknown field
            }

            if (hasStart && hasEnd) plotter.Line(SwizzleFromSpan3(start), SwizzleFromSpan3(end));

            return JsonResult.Ok;
        }

        private static JsonResult Dot(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            Span<float> xyz = stackalloc float[3];
            Span<char> keyBuffer = stackalloc char[KeySize];
            float size = 0;
            bool hasXyz = false, hasSize = false;

            while (true)
            {
                var propertySetupResult = TryBeginProperty(jsonSpan, ref position, false, keyBuffer, out int keyLength);
                if (propertySetupResult == null) break;
                if (propertySetupResult.Value != JsonResult.Ok) return propertySetupResult.Value;

                ReadOnlySpan<char> key = keyBuffer.Slice(0, keyLength);

                if (IsKey(key, "xyz"))
                {
                    JsonResult result = ParseNumberArrayProperty(jsonSpan, ref position, xyz, 3);

                    if (result != JsonResult.Ok) return result;

                    hasXyz = true;

                    continue;
                }

                if (IsKey(key, "size"))
                {
                    JsonResult result = Json99.ParseNumber(jsonSpan, ref position, out size);

                    if (result != JsonResult.Ok) return result;

                    hasSize = true;

                    continue;
                }

                Json99.Parse(jsonSpan, ref position); // Skip unknown field
            }

            if (hasXyz && hasSize) plotter.Dot(SwizzleFromSpan3(xyz), size);

            return JsonResult.Ok;
        }

        private static JsonResult Pedestal(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            Span<float> xyz = stackalloc float[3];
            Span<char> keyBuffer = stackalloc char[KeySize];
            bool hasXyz = false;

            while (true)
            {
                var propertySetupResult = TryBeginProperty(jsonSpan, ref position, false, keyBuffer, out int keyLength);
                if (propertySetupResult == null) break;
                if (propertySetupResult.Value != JsonResult.Ok) return propertySetupResult.Value;

                ReadOnlySpan<char> key = keyBuffer.Slice(0, keyLength);

                if (IsKey(key, "xyz"))
                {
                    JsonResult result = ParseNumberArrayProperty(jsonSpan, ref position, xyz, 3);

                    if (result != JsonResult.Ok) return result;

                    hasXyz = true;

                    continue;
                }

                Json99.Parse(jsonSpan, ref position); // Skip unknown field
            }

            if (hasXyz) plotter.Pedestal(SwizzleFromSpan3(xyz));

            return JsonResult.Ok;
        }

        private static JsonResult Circle(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            Span<float> xyz = stackalloc float[3];
            Span<float> axis = stackalloc float[3];
            Span<char> keyBuffer = stackalloc char[KeySize];
            float radius = 0;
            bool hasXyz = false, hasAxis = false, hasRadius = false;

            while (true)
            {
                var propertySetupResult = TryBeginProperty(jsonSpan, ref position, false, keyBuffer, out int keyLength);
                if (propertySetupResult == null) break;
                if (propertySetupResult.Value != JsonResult.Ok) return propertySetupResult.Value;

                ReadOnlySpan<char> key = keyBuffer.Slice(0, keyLength);

                if (IsKey(key, "xyz"))
                {
                    JsonResult result = ParseNumberArrayProperty(jsonSpan, ref position, xyz, 3);

                    if (result != JsonResult.Ok) return result;

                    hasXyz = true;

                    continue;
                }

                if (IsKey(key, "axis"))
                {
                    JsonResult result = ParseNumberArrayProperty(jsonSpan, ref position, axis, 3);

                    if (result != JsonResult.Ok) return result;

                    hasAxis = true;

                    continue;
                }

                if (IsKey(key, "radius"))
                {
                    JsonResult result = Json99.ParseNumber(jsonSpan, ref position, out radius);

                    if (result != JsonResult.Ok) return result;

                    hasRadius = true;

                    continue;
                }

                Json99.Parse(jsonSpan, ref position); // Skip unknown field
            }

            // Call plotter if we have required fields
            if (hasXyz && hasAxis && hasRadius) plotter.Circle(SwizzleFromSpan3(xyz), SwizzleFromSpan3(axis), radius);

            return JsonResult.Ok;
        }

        private static JsonResult Axes(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            Span<float> xyz = stackalloc float[3];
            Span<float> quaternion = stackalloc float[4];
            Span<char> keyBuffer = stackalloc char[KeySize];
            float scale = 0;
            bool hasXyz = false, hasQuaternion = false, hasScale = false;

            while (true)
            {
                var propertySetupResult = TryBeginProperty(jsonSpan, ref position, false, keyBuffer, out int keyLength);
                if (propertySetupResult == null) break;
                if (propertySetupResult.Value != JsonResult.Ok) return propertySetupResult.Value;

                ReadOnlySpan<char> key = keyBuffer.Slice(0, keyLength);

                if (IsKey(key, "xyz"))
                {
                    JsonResult result = ParseNumberArrayProperty(jsonSpan, ref position, xyz, 3);

                    if (result != JsonResult.Ok) return result;

                    hasXyz = true;

                    continue;
                }

                if (IsKey(key, "quaternion"))
                {
                    JsonResult result = ParseNumberArrayProperty(jsonSpan, ref position, quaternion, 4);

                    if (result != JsonResult.Ok) return result;

                    hasQuaternion = true;

                    continue;
                }

                if (IsKey(key, "scale"))
                {
                    JsonResult result = Json99.ParseNumber(jsonSpan, ref position, out scale);

                    if (result != JsonResult.Ok) return result;

                    hasScale = true;

                    continue;
                }

                Json99.Parse(jsonSpan, ref position); // Skip unknown field
            }

            // Call plotter if we have required fields
            if (hasXyz && hasQuaternion && hasScale) plotter.Axes(SwizzleFromSpan3(xyz), SwizzleFromSpan4(quaternion), scale);

            return JsonResult.Ok;
        }

        private static JsonResult Label(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            Span<float> xyz = stackalloc float[3];
            Span<char> textBuffer = stackalloc char[128];
            Span<char> keyBuffer = stackalloc char[KeySize];
            bool hasXyz = false, hasText = false;
            int textLength = 0;

            while (true)
            {
                var propertySetupResult = TryBeginProperty(jsonSpan, ref position, false, keyBuffer, out int keyLength);
                if (propertySetupResult == null) break;
                if (propertySetupResult.Value != JsonResult.Ok) return propertySetupResult.Value;

                ReadOnlySpan<char> key = keyBuffer.Slice(0, keyLength);

                if (IsKey(key, "xyz"))
                {
                    JsonResult result = ParseNumberArrayProperty(jsonSpan, ref position, xyz, 3);

                    if (result != JsonResult.Ok) return result;

                    hasXyz = true;

                    continue;
                }

                if (IsKey(key, "text"))
                {
                    JsonResult result = Json99.ParseString(jsonSpan, ref position, textBuffer, out textLength);

                    if (result != JsonResult.Ok) return result;

                    hasText = true;

                    continue;
                }

                Json99.Parse(jsonSpan, ref position); // Skip unknown field
            }

            if (hasXyz && hasText) plotter.Label(SwizzleFromSpan3(xyz), textBuffer.Slice(0, textLength));

            return JsonResult.Ok;
        }

        private static JsonResult Angle(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            Span<float> xyz = stackalloc float[3];
            Span<float> quaternion = stackalloc float[4];
            Span<char> keyBuffer = stackalloc char[KeySize];
            float angle = 0, scale = 0;
            bool hasXyz = false, hasQuaternion = false, hasAngle = false, hasScale = false;

            while (true)
            {
                var propertySetupResult = TryBeginProperty(jsonSpan, ref position, false, keyBuffer, out int keyLength);
                if (propertySetupResult == null) break;
                if (propertySetupResult.Value != JsonResult.Ok) return propertySetupResult.Value;

                ReadOnlySpan<char> key = keyBuffer.Slice(0, keyLength);

                if (IsKey(key, "xyz"))
                {
                    JsonResult result = ParseNumberArrayProperty(jsonSpan, ref position, xyz, 3);

                    if (result != JsonResult.Ok) return result;

                    hasXyz = true;

                    continue;
                }

                if (IsKey(key, "quaternion"))
                {
                    JsonResult result = ParseNumberArrayProperty(jsonSpan, ref position, quaternion, 4);

                    if (result != JsonResult.Ok) return result;

                    hasQuaternion = true;

                    continue;
                }

                if (IsKey(key, "angle"))
                {
                    JsonResult result = Json99.ParseNumber(jsonSpan, ref position, out angle);

                    if (result != JsonResult.Ok) return result;

                    hasAngle = true;

                    continue;
                }

                if (IsKey(key, "scale"))
                {
                    JsonResult result = Json99.ParseNumber(jsonSpan, ref position, out scale);

                    if (result != JsonResult.Ok) return result;

                    hasScale = true;

                    continue;
                }

                Json99.Parse(jsonSpan, ref position); // Skip unknown field
            }

            if (hasXyz && hasQuaternion && hasAngle && hasScale) plotter.Angle(SwizzleFromSpan3(xyz), SwizzleFromSpan4(quaternion), angle, scale);

            return JsonResult.Ok;
        }

        private static JsonResult Angles(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            Span<float> xyz = stackalloc float[3];
            Span<float> quaternion = stackalloc float[4];
            Span<float> alphaLimit = stackalloc float[2];
            Span<float> betaLimit = stackalloc float[2];
            Span<float> gammaLimit = stackalloc float[2];
            Span<char> keyBuffer = stackalloc char[KeySize];
            float? alpha = null, beta = null, gamma = null;
            float scale = 1;
            bool mirror = false;
            bool hasXyz = false, hasQuaternion = false, hasScale = false;
            bool hasAlphaLimit = false, hasBetaLimit = false, hasGammaLimit = false;

            while (true)
            {
                var propertySetupResult = TryBeginProperty(jsonSpan, ref position, false, keyBuffer, out int keyLength);
                if (propertySetupResult == null) break;
                if (propertySetupResult.Value != JsonResult.Ok) return propertySetupResult.Value;

                ReadOnlySpan<char> key = keyBuffer.Slice(0, keyLength);

                if (IsKey(key, "xyz"))
                {
                    JsonResult result = ParseNumberArrayProperty(jsonSpan, ref position, xyz, 3);

                    if (result != JsonResult.Ok) return result;

                    hasXyz = true;

                    continue;
                }

                if (IsKey(key, "quaternion"))
                {
                    JsonResult result = ParseNumberArrayProperty(jsonSpan, ref position, quaternion, 4);

                    if (result != JsonResult.Ok) return result;

                    hasQuaternion = true;

                    continue;
                }

                if (IsKey(key, "alpha"))
                {
                    JsonResult result = ParseNullableNumber(jsonSpan, ref position, ref alpha);

                    if (result != JsonResult.Ok) return result;

                    continue;
                }

                if (IsKey(key, "beta"))
                {
                    JsonResult result = ParseNullableNumber(jsonSpan, ref position, ref beta);

                    if (result != JsonResult.Ok) return result;

                    continue;
                }

                if (IsKey(key, "gamma"))
                {
                    JsonResult result = ParseNullableNumber(jsonSpan, ref position, ref gamma);

                    if (result != JsonResult.Ok) return result;

                    continue;
                }

                if (IsKey(key, "alpha_limit"))
                {
                    JsonResult result = ParseNumberArrayProperty(jsonSpan, ref position, alphaLimit, 2);

                    if (result != JsonResult.Ok) return result;

                    hasAlphaLimit = true;

                    continue;
                }

                if (IsKey(key, "beta_limit"))
                {
                    JsonResult result = ParseNumberArrayProperty(jsonSpan, ref position, betaLimit, 2);

                    if (result != JsonResult.Ok) return result;

                    hasBetaLimit = true;

                    continue;
                }

                if (IsKey(key, "gamma_limit"))
                {
                    JsonResult result = ParseNumberArrayProperty(jsonSpan, ref position, gammaLimit, 2);

                    if (result != JsonResult.Ok) return result;

                    hasGammaLimit = true;

                    continue;
                }

                if (IsKey(key, "scale"))
                {
                    JsonResult result = Json99.ParseNumber(jsonSpan, ref position, out scale);

                    if (result != JsonResult.Ok) return result;

                    hasScale = true;

                    continue;
                }

                if (IsKey(key, "mirror"))
                {
                    JsonResult result = Json99.ParseBoolean(jsonSpan, ref position, out mirror);

                    if (result != JsonResult.Ok) return result;

                    continue;
                }

                Json99.Parse(jsonSpan, ref position); // Skip unknown field
            }

            // Call plotter if we have required fields
            if (hasXyz && hasQuaternion && hasScale)
                plotter.Angles(
                    SwizzleFromSpan3(xyz),
                    SwizzleFromSpan4(quaternion),
                    AngleAndLimitFromSpan(alpha, alphaLimit, hasAlphaLimit),
                    AngleAndLimitFromSpan(beta, betaLimit, hasBetaLimit),
                    AngleAndLimitFromSpan(gamma, gammaLimit, hasGammaLimit),
                    scale,
                    mirror
                );

            return JsonResult.Ok;
        }


        private static bool IsKey(ReadOnlySpan<char> buffer, string literal)
        {
            return buffer.SequenceEqual(literal.AsSpan());
        }

        private static JsonResult SkipRemainder(ReadOnlySpan<char> jsonSpan, ref int position)
        {
            Span<char> keyBuffer = stackalloc char[KeySize];

            while (true)
            {
                var propertySetupResult = TryBeginProperty(jsonSpan, ref position, false, keyBuffer, out _);

                if (propertySetupResult == null) return JsonResult.Ok;

                if (propertySetupResult.Value != JsonResult.Ok) return propertySetupResult.Value;

                // Skip value
                Json99.Parse(jsonSpan, ref position);
            }
        }

        private static Vector3 SwizzleFromSpan3(ReadOnlySpan<float> span)
        {
            if (span.Length != 3) return Vector3.zero;

            return new Vector3(span[0], span[2], span[1]); // swizzle! 
        }

        private static Quaternion SwizzleFromSpan4(ReadOnlySpan<float> span)
        {
            if (span.Length != 4) return Quaternion.identity;

            return new Quaternion(-span[1], -span[3], -span[2], span[0]).normalized; // swizzle! 
        }

        private static AngleAndLimit? AngleAndLimitFromSpan(float? angle, ReadOnlySpan<float> limitSpan, bool hasLimit)
        {
            if (angle.HasValue == false) return null;

            if (hasLimit == false || limitSpan.Length != 2) return new AngleAndLimit(angle.Value, null);

            return new AngleAndLimit(angle.Value, (limitSpan[0], limitSpan[1]));
        }

        private static JsonResult? TryBeginProperty(ReadOnlySpan<char> jsonSpan, ref int position, bool firstProperty, Span<char> keyBuffer, out int keyLength)
        {
            keyLength = 0;

            if (Json99.ParseObjectEnd(jsonSpan, ref position) == JsonResult.Ok) return null;

            if (firstProperty == false && Json99.ParseComma(jsonSpan, ref position) != JsonResult.Ok) return JsonResult.MissingComma;

            if (Json99.ParseKey(jsonSpan, ref position, keyBuffer, out keyLength) != JsonResult.Ok) return JsonResult.MissingKey;

            return JsonResult.Ok;
        }

        private static JsonResult ParseNumberArrayProperty(ReadOnlySpan<char> jsonSpan, ref int position, Span<float> destination, int expectedLength)
        {
            var result = Json99.ParseNumberArray(jsonSpan, ref position, destination, out int length);

            if (result != JsonResult.Ok) return result;

            if (length != expectedLength) return JsonResult.UnexpectedType;

            return JsonResult.Ok;
        }

        private static JsonResult ParseNullableNumber(ReadOnlySpan<char> jsonSpan, ref int position, ref float? value)
        {
            if (Json99.ParseNull(jsonSpan, ref position) == JsonResult.Ok)
            {
                value = null;
                return JsonResult.Ok;
            }

            var result = Json99.ParseNumber(jsonSpan, ref position, out float number);

            if (result == JsonResult.Ok) value = number;

            return result;
        }

        private static JsonResult ParseDynamicString(ReadOnlySpan<char> jsonSpan, ref int position, out string value)
        {
            value = null;

            int start = position;

            var result = Json99.ParseString(jsonSpan, ref position, Span<char>.Empty, out int len);

            if (result != JsonResult.Ok) return result;

            char[] buf = new char[len];

            position = start;

            result = Json99.ParseString(jsonSpan, ref position, buf.AsSpan(0, len), out int written);

            if (result != JsonResult.Ok) return result;

            value = new string(buf, 0, written);

            return JsonResult.Ok;
        }
    }
}