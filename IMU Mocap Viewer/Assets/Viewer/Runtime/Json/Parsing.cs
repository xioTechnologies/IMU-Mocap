using System;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

namespace Viewer.Runtime.Json
{
    public static class Parsing
    {
        public static void ProcessPacket(Plotter plotter, UdpReceiveResult udpResult)
        {
            Span<char> charBuffer = stackalloc char[udpResult.Buffer.Length];

            int charCount = Encoding.ASCII.GetChars(udpResult.Buffer, charBuffer);

            ReadOnlySpan<char> jsonSpan = charBuffer.Slice(0, charCount);

            int position = 0;

            plotter.Clear();

            if (Json99.ParseArrayStart(jsonSpan, ref position) != JsonResult.Ok)
            {
                Debug.LogError("JSON parsing failed: Invalid array start");
                return;
            }

            if (Json99.ParseArrayEnd(jsonSpan, ref position) == JsonResult.Ok) return; // Empty array, nothing to plot

            while (true)
            {
                JsonResult result = ParseAndPlotObject(plotter, jsonSpan, ref position);

                if (result != JsonResult.Ok)
                {
                    Debug.LogError($"JSON parsing failed: {result}");
                    break;
                }

                // Try to parse comma (continue) or array end (break)
                if (Json99.ParseComma(jsonSpan, ref position) == JsonResult.Ok) continue;

                if (Json99.ParseArrayEnd(jsonSpan, ref position) == JsonResult.Ok) break;

                // Neither comma nor end found - error
                Debug.LogError("JSON parsing failed: Expected comma or array end");

                break;
            }
        }

        static JsonResult ParseAndPlotObject(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            if (Json99.ParseObjectStart(jsonSpan, ref position) != JsonResult.Ok) return JsonResult.InvalidSyntax;

            Span<char> keyBuffer = stackalloc char[32];
            Span<char> typeBuffer = stackalloc char[16];

            if (Json99.ParseKey(jsonSpan, ref position, keyBuffer, out int keyLength) != JsonResult.Ok) return JsonResult.MissingKey;

            ReadOnlySpan<char> key = keyBuffer.Slice(0, keyLength);

            if (key.SequenceEqual("type".AsSpan()) == false) return JsonResult.InvalidSyntax; // First key should always be type

            if (Json99.ParseString(jsonSpan, ref position, typeBuffer, out int typeLength) != JsonResult.Ok) return JsonResult.InvalidSyntax;

            ReadOnlySpan<char> type = typeBuffer.Slice(0, typeLength);

            if (type.SequenceEqual("line".AsSpan())) return ParseLineObject(plotter, jsonSpan, ref position);

            if (type.SequenceEqual("circle".AsSpan())) return ParseCircleObject(plotter, jsonSpan, ref position);

            if (type.SequenceEqual("dot".AsSpan())) return ParseDotObject(plotter, jsonSpan, ref position);

            if (type.SequenceEqual("axes".AsSpan())) return ParseAxesObject(plotter, jsonSpan, ref position);

            if (type.SequenceEqual("label".AsSpan())) return ParseLabelObject(plotter, jsonSpan, ref position);

            if (type.SequenceEqual("angles".AsSpan())) return ParseAnglesObject(plotter, jsonSpan, ref position);

            if (type.SequenceEqual("angle".AsSpan())) return ParseAngleObject(plotter, jsonSpan, ref position);

            if (type.SequenceEqual("pedestal".AsSpan())) return ParsePedestalObject(plotter, jsonSpan, ref position);

            Debug.LogError($"Unknown primitive type: {type.ToString()}");

            return SkipRemainder(jsonSpan, ref position);
        }

        static JsonResult ParseLineObject(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            Span<float> start = stackalloc float[3];
            Span<float> end = stackalloc float[3];
            Span<char> keyBuffer = stackalloc char[32];
            bool hasStart = false, hasEnd = false;

            while (true)
            {
                var propertySetupResult = TryBeginProperty(jsonSpan, ref position, keyBuffer, out int keyLength);
                if (propertySetupResult == null) break;
                if (propertySetupResult.Value != JsonResult.Ok) return propertySetupResult.Value;

                ReadOnlySpan<char> key = keyBuffer.Slice(0, keyLength);

                if (TryParseNumberArrayProperty(jsonSpan, key, "start".AsSpan(), ref position, start, 3, ref hasStart)) continue;

                if (TryParseNumberArrayProperty(jsonSpan, key, "end".AsSpan(), ref position, end, 3, ref hasEnd)) continue;

                Json99.Parse(jsonSpan, ref position); // Skip unknown field
            }

            if (hasStart && hasEnd) plotter.Line(SwizzleFromSpan3(start), SwizzleFromSpan3(end));

            return JsonResult.Ok;
        }

        static JsonResult ParseDotObject(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            Span<float> xyz = stackalloc float[3];
            Span<char> keyBuffer = stackalloc char[32];
            float size = 0;
            bool hasXyz = false, hasSize = false;

            while (true)
            {
                var propertySetupResult = TryBeginProperty(jsonSpan, ref position, keyBuffer, out int keyLength);
                if (propertySetupResult == null) break;
                if (propertySetupResult.Value != JsonResult.Ok) return propertySetupResult.Value;

                ReadOnlySpan<char> key = keyBuffer.Slice(0, keyLength);

                if (TryParseNumberArrayProperty(jsonSpan, key, "xyz".AsSpan(), ref position, xyz, 3, ref hasXyz)) continue;

                if (TryParseNumberProperty(jsonSpan, key, "size".AsSpan(), ref position, out size, ref hasSize)) continue;

                Json99.Parse(jsonSpan, ref position); // Skip unknown field
            }

            if (hasXyz && hasSize) plotter.Dot(SwizzleFromSpan3(xyz), size);

            return JsonResult.Ok;
        }

        static JsonResult ParsePedestalObject(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            Span<float> xyz = stackalloc float[3];
            Span<char> keyBuffer = stackalloc char[32];
            bool hasXyz = false;

            while (true)
            {
                var propertySetupResult = TryBeginProperty(jsonSpan, ref position, keyBuffer, out int keyLength);
                if (propertySetupResult == null) break;
                if (propertySetupResult.Value != JsonResult.Ok) return propertySetupResult.Value;

                ReadOnlySpan<char> key = keyBuffer.Slice(0, keyLength);

                if (TryParseNumberArrayProperty(jsonSpan, key, "xyz".AsSpan(), ref position, xyz, 3, ref hasXyz)) continue;

                Json99.Parse(jsonSpan, ref position); // Skip unknown field
            }

            if (hasXyz) plotter.Pedestal(SwizzleFromSpan3(xyz));

            return JsonResult.Ok;
        }

        static JsonResult ParseCircleObject(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            Span<float> xyz = stackalloc float[3];
            Span<float> axis = stackalloc float[3];
            Span<char> keyBuffer = stackalloc char[32];
            float radius = 0;
            bool hasXyz = false, hasAxis = false, hasRadius = false;

            while (true)
            {
                var propertySetupResult = TryBeginProperty(jsonSpan, ref position, keyBuffer, out int keyLength);
                if (propertySetupResult == null) break;
                if (propertySetupResult.Value != JsonResult.Ok) return propertySetupResult.Value;

                ReadOnlySpan<char> key = keyBuffer.Slice(0, keyLength);

                if (TryParseNumberArrayProperty(jsonSpan, key, "xyz".AsSpan(), ref position, xyz, 3, ref hasXyz)) continue;

                if (TryParseNumberArrayProperty(jsonSpan, key, "axis".AsSpan(), ref position, axis, 3, ref hasAxis)) continue;

                if (TryParseNumberProperty(jsonSpan, key, "radius".AsSpan(), ref position, out radius, ref hasRadius)) continue;

                Json99.Parse(jsonSpan, ref position); // Skip unknown field
            }

            // Call plotter if we have required fields
            if (hasXyz && hasAxis && hasRadius) plotter.Circle(SwizzleFromSpan3(xyz), SwizzleFromSpan3(axis), radius);

            return JsonResult.Ok;
        }

        static JsonResult ParseAxesObject(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            Span<float> xyz = stackalloc float[3];
            Span<float> quaternion = stackalloc float[4];
            Span<char> keyBuffer = stackalloc char[32];
            float scale = 0;
            bool hasXyz = false, hasQuaternion = false, hasScale = false;

            // Parse remaining key-value pairs after type
            while (true)
            {
                var propertySetupResult = TryBeginProperty(jsonSpan, ref position, keyBuffer, out int keyLength);
                if (propertySetupResult == null) break;
                if (propertySetupResult.Value != JsonResult.Ok) return propertySetupResult.Value;

                ReadOnlySpan<char> key = keyBuffer.Slice(0, keyLength);

                if (TryParseNumberArrayProperty(jsonSpan, key, "xyz".AsSpan(), ref position, xyz, 3, ref hasXyz)) continue;

                if (TryParseNumberArrayProperty(jsonSpan, key, "quaternion".AsSpan(), ref position, quaternion, 4, ref hasQuaternion)) continue;

                if (TryParseNumberProperty(jsonSpan, key, "scale".AsSpan(), ref position, out scale, ref hasScale)) continue;

                Json99.Parse(jsonSpan, ref position); // Skip unknown field
            }

            // Call plotter if we have required fields
            if (hasXyz && hasQuaternion && hasScale) plotter.Axes(SwizzleFromSpan3(xyz), SwizzleFromSpan4(quaternion), scale);

            return JsonResult.Ok;
        }

        static JsonResult ParseLabelObject(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            Span<float> xyz = stackalloc float[3];
            Span<char> textBuffer = stackalloc char[128];
            Span<char> keyBuffer = stackalloc char[32];
            bool hasXyz = false, hasText = false;
            int textLength = 0;

            while (true)
            {
                var propertySetupResult = TryBeginProperty(jsonSpan, ref position, keyBuffer, out int keyLength);
                if (propertySetupResult == null) break;
                if (propertySetupResult.Value != JsonResult.Ok) return propertySetupResult.Value;

                ReadOnlySpan<char> key = keyBuffer.Slice(0, keyLength);

                if (TryParseNumberArrayProperty(jsonSpan, key, "xyz".AsSpan(), ref position, xyz, 3, ref hasXyz)) continue;

                if (TryParseStringProperty(jsonSpan, key, "text".AsSpan(), ref position, textBuffer, out textLength, ref hasText)) continue;

                Json99.Parse(jsonSpan, ref position); // Skip unknown field
            }

            if (hasXyz && hasText) plotter.Label(SwizzleFromSpan3(xyz), textBuffer.Slice(0, textLength));

            return JsonResult.Ok;
        }

        static JsonResult ParseAngleObject(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            Span<float> xyz = stackalloc float[3];
            Span<float> quaternion = stackalloc float[4];
            Span<char> keyBuffer = stackalloc char[32];
            float angle = 0, scale = 0;
            bool hasXyz = false, hasQuaternion = false, hasAngle = false, hasScale = false;

            while (true)
            {
                var propertySetupResult = TryBeginProperty(jsonSpan, ref position, keyBuffer, out int keyLength);
                if (propertySetupResult == null) break;
                if (propertySetupResult.Value != JsonResult.Ok) return propertySetupResult.Value;

                ReadOnlySpan<char> key = keyBuffer.Slice(0, keyLength);

                if (TryParseNumberArrayProperty(jsonSpan, key, "xyz".AsSpan(), ref position, xyz, 3, ref hasXyz)) continue;

                if (TryParseNumberArrayProperty(jsonSpan, key, "quaternion".AsSpan(), ref position, quaternion, 4, ref hasQuaternion)) continue;

                if (TryParseNumberProperty(jsonSpan, key, "angle".AsSpan(), ref position, out angle, ref hasAngle)) continue;

                if (TryParseNumberProperty(jsonSpan, key, "scale".AsSpan(), ref position, out scale, ref hasScale)) continue;

                Json99.Parse(jsonSpan, ref position); // Skip unknown field
            }

            if (hasXyz && hasQuaternion && hasAngle && hasScale) plotter.Angle(SwizzleFromSpan3(xyz), SwizzleFromSpan4(quaternion), angle, scale);

            return JsonResult.Ok;
        }

        static JsonResult ParseAnglesObject(Plotter plotter, ReadOnlySpan<char> jsonSpan, ref int position)
        {
            Span<float> xyz = stackalloc float[3];
            Span<float> quaternion = stackalloc float[4];
            Span<float> alphaLimit = stackalloc float[2];
            Span<float> betaLimit = stackalloc float[2];
            Span<float> gammaLimit = stackalloc float[2];
            Span<char> keyBuffer = stackalloc char[32];
            float? alpha = null, beta = null, gamma = null;
            float scale = 1;
            bool mirror = false;
            bool hasXyz = false, hasQuaternion = false, hasScale = false;
            bool hasAlphaLimit = false, hasBetaLimit = false, hasGammaLimit = false;

            while (true)
            {
                var propertySetupResult = TryBeginProperty(jsonSpan, ref position, keyBuffer, out int keyLength);
                if (propertySetupResult == null) break;
                if (propertySetupResult.Value != JsonResult.Ok) return propertySetupResult.Value;

                ReadOnlySpan<char> key = keyBuffer.Slice(0, keyLength);

                if (TryParseNumberArrayProperty(jsonSpan, key, "xyz".AsSpan(), ref position, xyz, 3, ref hasXyz)) continue;

                if (TryParseNumberArrayProperty(jsonSpan, key, "quaternion".AsSpan(), ref position, quaternion, 4, ref hasQuaternion)) continue;

                if (TryParseNullableNumberProperty(jsonSpan, key, "alpha".AsSpan(), ref position, ref alpha)) continue;

                if (TryParseNullableNumberProperty(jsonSpan, key, "beta".AsSpan(), ref position, ref beta)) continue;

                if (TryParseNullableNumberProperty(jsonSpan, key, "gamma".AsSpan(), ref position, ref gamma)) continue;

                if (TryParseNumberArrayProperty(jsonSpan, key, "alpha_limit".AsSpan(), ref position, alphaLimit, 2, ref hasAlphaLimit)) continue;

                if (TryParseNumberArrayProperty(jsonSpan, key, "beta_limit".AsSpan(), ref position, betaLimit, 2, ref hasBetaLimit)) continue;

                if (TryParseNumberArrayProperty(jsonSpan, key, "gamma_limit".AsSpan(), ref position, gammaLimit, 2, ref hasGammaLimit)) continue;

                if (TryParseNumberProperty(jsonSpan, key, "scale".AsSpan(), ref position, out scale, ref hasScale)) continue;

                if (TryParseBooleanProperty(jsonSpan, key, "mirror".AsSpan(), ref position, ref mirror)) continue;

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

        static JsonResult SkipRemainder(ReadOnlySpan<char> jsonSpan, ref int position)
        {
            Span<char> keyBuffer = stackalloc char[32];

            while (true)
            {
                var propertySetupResult = TryBeginProperty(jsonSpan, ref position, keyBuffer, out _);

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


        private static JsonResult? TryBeginProperty(ReadOnlySpan<char> jsonSpan, ref int position, Span<char> keyBuffer, out int keyLength)
        {
            keyLength = 0;

            if (Json99.ParseObjectEnd(jsonSpan, ref position) == JsonResult.Ok) return null;

            if (Json99.ParseComma(jsonSpan, ref position) != JsonResult.Ok) return JsonResult.MissingComma;

            if (Json99.ParseKey(jsonSpan, ref position, keyBuffer, out keyLength) != JsonResult.Ok) return JsonResult.MissingKey;

            return JsonResult.Ok;
        }

        private static bool TryParseNumberProperty(ReadOnlySpan<char> json, ReadOnlySpan<char> key, ReadOnlySpan<char> expectedKey, ref int position, out float value, ref bool flag)
        {
            value = 0;

            if (key.SequenceEqual(expectedKey) == false) return false;

            flag |= Json99.ParseNumber(json, ref position, out value) == JsonResult.Ok;

            return true;
        }

        private static bool TryParseNumberArrayProperty(ReadOnlySpan<char> jsonSpan, ReadOnlySpan<char> key, ReadOnlySpan<char> expectedKey, ref int position, Span<float> values, int expectedCount, ref bool flag)
        {
            if (key.SequenceEqual(expectedKey) == false) return false;

            flag |= Json99.ParseNumberArray(jsonSpan, ref position, values, out int count) == JsonResult.Ok && count == expectedCount;

            return true;
        }

        private static bool TryParseStringProperty(ReadOnlySpan<char> jsonSpan, ReadOnlySpan<char> key, ReadOnlySpan<char> expectedKey, ref int position, Span<char> buffer, out int length, ref bool flag)
        {
            length = 0;

            if (key.SequenceEqual(expectedKey) == false) return false;

            flag |= Json99.ParseString(jsonSpan, ref position, buffer, out length) == JsonResult.Ok;

            return true;
        }

        private static bool TryParseBooleanProperty(ReadOnlySpan<char> jsonSpan, ReadOnlySpan<char> key, ReadOnlySpan<char> expectedKey, ref int position, ref bool value)
        {
            if (key.SequenceEqual(expectedKey) == false) return false;

            Json99.ParseBoolean(jsonSpan, ref position, out value);

            return true;
        }

        private static bool TryParseNullableNumberProperty(ReadOnlySpan<char> jsonSpan, ReadOnlySpan<char> key, ReadOnlySpan<char> expectedKey, ref int position, ref float? value)
        {
            if (key.SequenceEqual(expectedKey) == false) return false;

            if (Json99.ParseNumber(jsonSpan, ref position, out float val) == JsonResult.Ok) value = val;

            return true;
        }
    }
}