using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Viewer.Runtime.Json
{
    public interface IJsonObjectParser
    {
        JsonResult Defaults();

        JsonResult Peek(ReadOnlySpan<char> jsonSpan, int position);

        JsonResult Parse(ReadOnlySpan<char> key, ReadOnlySpan<char> jsonSpan, ref int position);

        JsonResult Finish();
    }

    public interface IJsonTypeDiscriminatingParser
    {
        JsonResult Parse(ReadOnlySpan<char> type, ReadOnlySpan<char> jsonSpan, ref int position);
    }

    public static partial class JsonZero
    {
        public static JsonResult ParseObject<TParser>(ReadOnlySpan<char> jsonSpan, ref int position, ref TParser parser) where TParser : struct, IJsonObjectParser
        {
            JsonResult result = parser.Defaults();
            if (result != JsonResult.Ok) return result;

            // Allow parser to perform an optional pre-scan without affecting position
            result = parser.Peek(jsonSpan, position);
            if (result != JsonResult.Ok) return result;

            result = ParseObjectStart(jsonSpan, ref position);
            if (result != JsonResult.Ok) return result;

            result = ParseObjectEnd(jsonSpan, ref position);
            if (result == JsonResult.Ok) return JsonResult.Ok;

            while (true)
            {
                result = ParseKey(jsonSpan, ref position, out FixedString64 key);
                if (result != JsonResult.Ok) return result;

                result = parser.Parse(key.AsReadOnlySpan(), jsonSpan, ref position);
                if (result != JsonResult.Ok) return result;

                result = ParseComma(jsonSpan, ref position);
                if (result == JsonResult.Ok) continue;

                result = ParseObjectEnd(jsonSpan, ref position);
                if (result != JsonResult.Ok) return result;

                break;
            }

            return parser.Finish();
        }

        public static JsonResult ParseObjectArray<TParser>(ReadOnlySpan<char> jsonSpan, ref int position, ref TParser parser) where TParser : struct, IJsonObjectParser
        {
            JsonResult result = ParseArrayStart(jsonSpan, ref position);
            if (result != JsonResult.Ok) return result;

            result = ParseArrayEnd(jsonSpan, ref position);
            if (result == JsonResult.Ok) return JsonResult.Ok;

            while (true)
            {
                result = ParseObject(jsonSpan, ref position, ref parser);
                if (result != JsonResult.Ok) return result;

                result = ParseComma(jsonSpan, ref position);
                if (result == JsonResult.Ok) continue;

                result = ParseArrayEnd(jsonSpan, ref position);
                if (result == JsonResult.Ok) break;
            }

            return JsonResult.Ok;
        }

        public static JsonResult ParseDiscriminatedArray<TParser>(ReadOnlySpan<char> jsonSpan, ref int position, ref TParser parser) where TParser : struct, IJsonTypeDiscriminatingParser
        {
            JsonResult result = ParseArrayStart(jsonSpan, ref position);
            if (result != JsonResult.Ok) return result;

            result = ParseArrayEnd(jsonSpan, ref position);
            if (result == JsonResult.Ok) return JsonResult.Ok;

            while (true)
            {
                result = Peek(jsonSpan, position, "type", out FixedString64 type);
                if (result != JsonResult.Ok) return result;

                result = parser.Parse(type.AsReadOnlySpan(), jsonSpan, ref position);
                if (result != JsonResult.Ok) return result;

                result = ParseComma(jsonSpan, ref position);
                if (result == JsonResult.Ok) continue;

                result = ParseArrayEnd(jsonSpan, ref position);
                if (result == JsonResult.Ok) break;
            }

            return JsonResult.Ok;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static JsonResult Peek(ReadOnlySpan<char> jsonSpan, int position, string key, out int value, int defaultValue)
        {
            value = defaultValue;

            JsonResult result = PeekMember(jsonSpan, position, key, out int valuePosition);
            if (result != JsonResult.Ok) return result;

            result = ParseNumber(jsonSpan, ref valuePosition, out float floatValue);
            if (result != JsonResult.Ok) return result;

            value = (int)floatValue;

            return JsonResult.Ok;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static JsonResult Peek<TFixedString>(ReadOnlySpan<char> jsonSpan, int position, string key, out TFixedString value) where TFixedString : struct, IFixedString
        {
            value = default;

            JsonResult result = PeekMember(jsonSpan, position, key, out int valuePosition);

            if (result != JsonResult.Ok) return result;

            return Parse(jsonSpan, ref valuePosition, out value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonResult PeekMember(ReadOnlySpan<char> jsonSpan, int position, string key, out int valuePosition)
        {
            valuePosition = -1;

            JsonResult result = ParseObjectStart(jsonSpan, ref position);
            if (result != JsonResult.Ok) return result;

            result = ParseObjectEnd(jsonSpan, ref position);
            if (result == JsonResult.Ok) return JsonResult.Ok;

            ReadOnlySpan<char> matcher = key.AsSpan();

            while (true)
            {
                result = ParseKey(jsonSpan, ref position, out FixedString64 memberKey);
                if (result != JsonResult.Ok) return result;

                if (matcher.SequenceEqual(memberKey.AsReadOnlySpan()) == true)
                {
                    valuePosition = position;

                    return JsonResult.Ok;
                }

                result = Parse(jsonSpan, ref position);
                if (result != JsonResult.Ok) return result;

                result = ParseComma(jsonSpan, ref position);
                if (result == JsonResult.Ok) continue;

                result = ParseObjectEnd(jsonSpan, ref position);
                if (result != JsonResult.Ok) return result;

                break;
            }

            return JsonResult.MissingKey;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsKey(ReadOnlySpan<char> buffer, string literal) => buffer.SequenceEqual(literal.AsSpan());

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static JsonResult Parse(ReadOnlySpan<char> jsonSpan, ref int position, out float value)
        {
            value = 0;

            return ParseNumber(jsonSpan, ref position, out value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static JsonResult Parse(ReadOnlySpan<char> jsonSpan, ref int position, out float? value)
        {
            value = null;

            JsonResult result = ParseNumber(jsonSpan, ref position, out float floatValue);
            if (result != JsonResult.Ok) return result;

            value = floatValue;

            return JsonResult.Ok;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static JsonResult Parse(ReadOnlySpan<char> jsonSpan, ref int position, out Vector3? xyz)
        {
            xyz = null;

            Span<float> destination = stackalloc float[3];
            JsonResult result = ParseNumberArray(jsonSpan, ref position, destination, out int parsedLength);
            if (result != JsonResult.Ok) return result;

            if (parsedLength != 3) return JsonResult.InvalidNumberFormat;

            xyz = new Vector3(destination[0], destination[2], destination[1]); // swizzle! 

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static JsonResult Parse(ReadOnlySpan<char> jsonSpan, ref int position, out Quaternion? quaternion)
        {
            quaternion = null;

            Span<float> destination = stackalloc float[4];
            JsonResult result = ParseNumberArray(jsonSpan, ref position, destination, out int parsedLength);
            if (result != JsonResult.Ok) return result;

            if (parsedLength != 4) return JsonResult.InvalidNumberFormat;

            quaternion = new Quaternion(-destination[1], -destination[3], -destination[2], destination[0]).normalized; // swizzle! 

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static JsonResult Parse(ReadOnlySpan<char> jsonSpan, ref int position, out float value, float @default)
        {
            value = @default;

            return ParseNumber(jsonSpan, ref position, out value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static JsonResult Parse(ReadOnlySpan<char> jsonSpan, ref int position, out int value, int @default = 0)
        {
            value = @default;

            JsonResult result = ParseNumber(jsonSpan, ref position, out float floatValue);
            if (result != JsonResult.Ok) return result;

            value = (int)floatValue;

            return JsonResult.Ok;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static JsonResult Parse(ReadOnlySpan<char> jsonSpan, ref int position, out bool value, bool @default = false)
        {
            value = @default;

            return ParseBoolean(jsonSpan, ref position, out value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static JsonResult Parse(ReadOnlySpan<char> jsonSpan, ref int position, out (float min, float max)? value)
        {
            value = null;

            Span<float> values = stackalloc float[2];

            JsonResult result = Parse(jsonSpan, ref position, values, 2);

            if (result != JsonResult.Ok) return result;

            value = (values[0], values[1]);

            return JsonResult.Ok;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonResult Parse(ReadOnlySpan<char> jsonSpan, ref int position, Span<float> destination, int length)
        {
            JsonResult result = ParseNumberArray(jsonSpan, ref position, destination, out int parsedLength);
            if (result != JsonResult.Ok) return result;

            if (parsedLength != length) return JsonResult.InvalidNumberFormat;

            return result;
        }

        /// <summary>
        /// Parses a JSON array of numbers into a span. Returns the number of elements parsed.
        /// </summary>
        /// <param name="jsonSpan">JSON span</param>
        /// <param name="position">Current position</param>
        /// <param name="destination">Destination span for parsed numbers</param>
        /// <param name="count">Number of elements parsed</param>
        /// <returns>Result</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonResult ParseNumberArray(ReadOnlySpan<char> jsonSpan, ref int position, Span<float> destination, out int count)
        {
            count = 0;

            JsonResult result = ParseArrayStart(jsonSpan, ref position);
            if (result != JsonResult.Ok) return result;

            result = ParseArrayEnd(jsonSpan, ref position);
            if (result == JsonResult.Ok) return JsonResult.Ok;

            while (true)
            {
                result = ParseNumber(jsonSpan, ref position, out float number);
                if (result != JsonResult.Ok) return result;

                if (count < destination.Length) destination[count] = number;
                count++;

                result = ParseComma(jsonSpan, ref position);
                if (result == JsonResult.Ok) continue;

                result = ParseArrayEnd(jsonSpan, ref position);
                if (result == JsonResult.Ok) break;
            }

            return JsonResult.Ok;
        }

        public static JsonResult Parse<TFixedString>(ReadOnlySpan<char> jsonSpan, ref int position, out TFixedString fixedString) where TFixedString : struct, IFixedString
        {
            fixedString = default;

            Span<char> span = fixedString.AsSpan();

            JsonResult result = ParseString(jsonSpan, ref position, span, out int length);
            if (result != JsonResult.Ok) return result;

            fixedString.SetLength(Mathf.Min(length, fixedString.MaxLength));

            return JsonResult.Ok;
        }

        public static JsonResult ParseTruncate<TFixedString>(ReadOnlySpan<char> jsonSpan, ref int position, out TFixedString fixedString, out int fullLength) where TFixedString : struct, IFixedString
        {
            fullLength = 0;

            fixedString = default;

            Span<char> span = fixedString.AsSpan();

            JsonResult result = ParseStringTruncate(jsonSpan, ref position, span, out fullLength);
            if (result != JsonResult.Ok) return result;

            fixedString.SetLength(Mathf.Min(fullLength, fixedString.MaxLength));

            return JsonResult.Ok;
        }

        public static JsonResult Parse<TFixedString>(ReadOnlySpan<char> jsonSpan, ref int position, out TFixedString fixedString, out string dynamicString) where TFixedString : struct, IFixedString
        {
            dynamicString = null;
            fixedString = default;

            int start = position;

            Span<char> span = fixedString.AsSpan();

            JsonResult result = ParseStringTruncate(jsonSpan, ref position, span, out int length);
            if (result != JsonResult.Ok) return result;

            fixedString.SetLength(Mathf.Min(length, fixedString.MaxLength));

            if (length < fixedString.MaxLength) return JsonResult.Ok;

            char[] buf = new char[length];

            position = start;

            result = ParseString(jsonSpan, ref position, buf.AsSpan(0, length), out int written);
            if (result != JsonResult.Ok) return result;

            dynamicString = new string(buf, 0, written); // can this come from a pool or something? is buffer owned by string at this point? 

            return JsonResult.Ok;
        }

        /// <summary>
        /// Parses the key in a JSON object. The position is advanced to the character after the colon that separates the key/value pair.
        /// </summary>
        /// <param name="json">JSON span</param>
        /// <param name="position">Current position</param>
        /// <param name="fixedString">Destination string</param>
        /// <returns>Result</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static JsonResult ParseKey<TFixedString>(ReadOnlySpan<char> json, ref int position, out TFixedString fixedString) where TFixedString : struct, IFixedString
        {
            fixedString = default;

            // Check type
            if (CheckType(json, ref position, JsonType.String) != JsonResult.Ok)
            {
                return JsonResult.MissingKey;
            }

            // Parse key
            JsonResult result = Parse(json, ref position, out fixedString);
            if (result != JsonResult.Ok) return result;

            // Parse colon
            SkipWhiteSpace(json, ref position);
            if (position >= json.Length || json[position] != ':') return JsonResult.MissingColon;

            position++;

            return JsonResult.Ok;
        }

        /// <summary>
        /// Parse string. The position is advanced to the first character after the string.
        /// </summary>
        /// <param name="json">JSON span</param>
        /// <param name="position">Current position</param>
        /// <param name="destination">Destination span</param>
        /// <param name="numberOfBytes">Number of characters written</param>
        /// <returns>Result</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static JsonResult ParseStringTruncate(ReadOnlySpan<char> json, ref int position, Span<char> destination, out int numberOfBytes)
        {
            numberOfBytes = 0;

            // Check type
            JsonResult result = CheckType(json, ref position, JsonType.String);
            if (result != JsonResult.Ok) return result;

            position++; // Skip opening quote

            // Parse string
            int index = 0;
            while (position < json.Length)
            {
                char ch = json[position];

                if (ch == '\0') return JsonResult.MissingStringEnd;
                if (ch >= 0 && ch < 0x20) return JsonResult.InvalidStringCharacter; // control characters must be escaped
                if (ch == '\\')
                {
                    result = ParseEscapeSequence(json, ref position, destination, ref index);
                    if (result != JsonResult.Ok) return result;

                    continue;
                }

                if (ch == '"')
                {
                    position++;
                    numberOfBytes = index;
                    return JsonResult.Ok;
                }

                WriteToDestination(destination, ref index, ch);

                position++;
            }

            return JsonResult.MissingStringEnd;
        }
    }
}