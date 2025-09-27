using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Viewer.Runtime.Json
{
    public interface IJsonObjectParser
    {
        JsonResult Peep(ReadOnlySpan<char> jsonSpan, int position);
        
        JsonResult Parse(ReadOnlySpan<char> key, ReadOnlySpan<char> jsonSpan, ref int position);

        JsonResult Finish();
    }

    public interface IJsonTypeDiscriminatingParser
    {
        JsonResult Parse(ReadOnlySpan<char> type, ReadOnlySpan<char> jsonSpan, ref int position);
    }

    public static partial class JsonZero
    {
        public const int KeySize = 64;
        private const int TypeSize = 16;
        
        public static JsonResult ParseObject<TParser>(ReadOnlySpan<char> jsonSpan, ref int position, ref TParser parser) where TParser : struct, IJsonObjectParser
        {
            // Allow parser to perform an optional pre-scan without affecting position
            JsonResult result = parser.Peep(jsonSpan, position);
            if (result != JsonResult.Ok) return result;
            
            result = ParseObjectStart(jsonSpan, ref position);
            if (result != JsonResult.Ok) return result;
            
            result = ParseObjectEnd(jsonSpan, ref position);
            if (result == JsonResult.Ok) return JsonResult.Ok;
            
            Span<char> keyBuffer = stackalloc char[KeySize];
            while (true)
            {
                result = ParseKey(jsonSpan, ref position, keyBuffer, out int keyLength);
                if (result != JsonResult.Ok) return result;

                ReadOnlySpan<char> key = keyBuffer.Slice(0, keyLength);

                result = parser.Parse(key, jsonSpan, ref position);
                if (result != JsonResult.Ok) return result;

                result = ParseComma(jsonSpan, ref position);
                if (result == JsonResult.Ok) continue;

                result = ParseObjectEnd(jsonSpan, ref position);
                if (result != JsonResult.Ok) return result;

                break;
            }
            
            return parser.Finish();
        }
        
        public static JsonResult ParseDiscriminatedArray<TParser>(ReadOnlySpan<char> jsonSpan, ref int position, ref TParser parser) where TParser : struct, IJsonTypeDiscriminatingParser
        {
            JsonResult result = ParseArrayStart(jsonSpan, ref position);
            if (result != JsonResult.Ok) return result;

            result = ParseArrayEnd(jsonSpan, ref position);
            if (result == JsonResult.Ok) return JsonResult.Ok;

            Span<char> typeBuffer = stackalloc char[TypeSize];
            
            while (true)
            {
                result = PeepProperty(jsonSpan, position, "type", out int typePosition);
                if (result != JsonResult.Ok) return result;
                
                result = ParseString(jsonSpan, ref typePosition, typeBuffer, out int typeLength);
                if (result != JsonResult.Ok) return result;

                ReadOnlySpan<char> type = typeBuffer.Slice(0, typeLength);
                
                result = parser.Parse(type, jsonSpan, ref position);
                if (result != JsonResult.Ok) return result;
                
                result = ParseComma(jsonSpan, ref position);
                if (result == JsonResult.Ok) continue;

                result = ParseArrayEnd(jsonSpan, ref position);
                if (result == JsonResult.Ok) break;
            }

            return JsonResult.Ok;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static JsonResult PeepProperty(ReadOnlySpan<char> jsonSpan, int position, string key, out int valuePosition)
        {
            valuePosition = -1;

            JsonResult result = ParseObjectStart(jsonSpan, ref position);
            if (result != JsonResult.Ok) return result;
            
            result = ParseObjectEnd(jsonSpan, ref position);
            if (result == JsonResult.Ok) return JsonResult.Ok;
            
            Span<char> keyBuffer = stackalloc char[KeySize];

            ReadOnlySpan<char> matcher = key.AsSpan();

            while (true)
            {
                result = ParseKey(jsonSpan, ref position, keyBuffer, out int keyLength);
                if (result != JsonResult.Ok) return result;

                ReadOnlySpan<char> propertyKey = keyBuffer.Slice(0, keyLength);

                if (matcher.SequenceEqual(propertyKey) == true)
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
        public static JsonResult Parse(ReadOnlySpan<char> jsonSpan, ref int position, Span<char> destination, out int length)
        {
            length = 0;
            
            return ParseString(jsonSpan, ref position, destination, out length);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static JsonResult MessureAndTryParse(ReadOnlySpan<char> jsonSpan, ref int position, Span<char> destination, out int length)
        {
            length = 0;
            
            return ParseString(jsonSpan, ref position, destination, out length);
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
        public static JsonResult ParseDynamicString(ReadOnlySpan<char> jsonSpan, ref int position, out string value)
        {
            value = null;
            
            int start = position;
 
            var result = ParseString(jsonSpan, ref position, Span<char>.Empty, out int len);
            if (result != JsonResult.Ok) return result;

            char[] buf = new char[len];

            position = start;

            result = ParseString(jsonSpan, ref position, buf.AsSpan(0, len), out int written);
            if (result != JsonResult.Ok) return result;

            value = new string(buf, 0, written); // can this come from a pool or something? is buffer owned by string at this point? 

            return JsonResult.Ok;
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
        
        // Helper method for parsing arrays of numbers into spans
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
    }
}