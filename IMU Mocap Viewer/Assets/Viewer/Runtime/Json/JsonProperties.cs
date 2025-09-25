using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Viewer.Runtime.Json
{
    internal interface IPropertyParser
    {
        int Map(ReadOnlySpan<char> key);
    }
    
    internal static class JsonProperties
    {
        public const int KeySize = 64;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static JsonResult GetSingleProperty(ReadOnlySpan<char> jsonSpan, int position, string key, out int valuePosition)
        {
            valuePosition = -1;

            Span<char> keyBuffer = stackalloc char[KeySize];

            ReadOnlySpan<char> matcher = key.AsSpan();

            while (true)
            {
                JsonResult result = JsonZero.ParseKey(jsonSpan, ref position, keyBuffer, out int keyLength);
                if (result != JsonResult.Ok) return result;

                ReadOnlySpan<char> propertyKey = keyBuffer.Slice(0, keyLength);

                if (matcher.SequenceEqual(propertyKey) == true)
                {
                    valuePosition = position;

                    return JsonResult.Ok;
                }

                result = JsonZero.Parse(jsonSpan, ref position);
                if (result != JsonResult.Ok) return result;

                result = JsonZero.ParseComma(jsonSpan, ref position);
                if (result == JsonResult.Ok) continue;

                result = JsonZero.ParseObjectEnd(jsonSpan, ref position);
                if (result != JsonResult.Ok) return result;

                break;
            }

            return JsonResult.MissingKey;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static JsonResult MapProperties<TPropertyParser>(ReadOnlySpan<char> jsonSpan, ref int position, Span<int> positions, ref TPropertyParser properties) where TPropertyParser : struct, IPropertyParser
        {
            Span<char> keyBuffer = stackalloc char[KeySize];

            while (true)
            {
                JsonResult result = JsonZero.ParseKey(jsonSpan, ref position, keyBuffer, out int keyLength);
                if (result != JsonResult.Ok) return result;

                ReadOnlySpan<char> key = keyBuffer.Slice(0, keyLength);

                int index = properties.Map(key);

                if (index >= 0) positions[index] = position;

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
        public static bool IsKey(ReadOnlySpan<char> buffer, string literal) => buffer.SequenceEqual(literal.AsSpan());
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static JsonResult Required(ReadOnlySpan<char> jsonSpan, int position, out float value)
        {
            value = 0;

            if (position < 0) return JsonResult.MissingKey;

            return JsonZero.ParseNumber(jsonSpan, ref position, out value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static JsonResult Required(ReadOnlySpan<char> jsonSpan, int position, Span<char> destination, out int length)
        {
            length = 0;

            if (position < 0) return JsonResult.MissingKey;

            return JsonZero.ParseString(jsonSpan, ref position, destination, out length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static JsonResult Required(ReadOnlySpan<char> jsonSpan, int position, out Vector3 xyz)
        {
            xyz = Vector3.zero;

            if (position < 0) return JsonResult.MissingKey;

            Span<float> destination = stackalloc float[3];
            JsonResult result = JsonZero.ParseNumberArray(jsonSpan, ref position, destination, out int parsedLength);

            if (parsedLength != 3) return JsonResult.InvalidNumberFormat;

            xyz = new Vector3(destination[0], destination[2], destination[1]); // swizzle! 

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static JsonResult Required(ReadOnlySpan<char> jsonSpan, int position, out Quaternion quaternion)
        {
            quaternion = Quaternion.identity;

            if (position < 0) return JsonResult.MissingKey;

            Span<float> destination = stackalloc float[4];
            JsonResult result = JsonZero.ParseNumberArray(jsonSpan, ref position, destination, out int parsedLength);

            if (parsedLength != 4) return JsonResult.InvalidNumberFormat;

            quaternion = new Quaternion(-destination[1], -destination[3], -destination[2], destination[0]).normalized; // swizzle! 

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static JsonResult Required(ReadOnlySpan<char> jsonSpan, int position, Span<float> destination, int length)
        {
            if (position < 0) return JsonResult.MissingKey;

            JsonResult result = JsonZero.ParseNumberArray(jsonSpan, ref position, destination, out int parsedLength);

            if (parsedLength != length) return JsonResult.InvalidNumberFormat;

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static JsonResult Required(ReadOnlySpan<char> jsonSpan, int position, out string value)
        {
            value = null;

            if (position < 0) return JsonResult.MissingKey;

            int start = position;

            var result = JsonZero.ParseString(jsonSpan, ref position, Span<char>.Empty, out int len);
            if (result != JsonResult.Ok) return result;

            char[] buf = new char[len];

            position = start;

            result = JsonZero.ParseString(jsonSpan, ref position, buf.AsSpan(0, len), out int written);

            if (result != JsonResult.Ok) return result;

            value = new string(buf, 0, written); // can this come from a pool or something? is buffer owned by string at this point? 

            return JsonResult.Ok;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static JsonResult Optional(ReadOnlySpan<char> jsonSpan, int position, out float value, float @default = 0)
        {
            value = @default;

            if (position < 0) return JsonResult.Ok;

            return JsonZero.ParseNumber(jsonSpan, ref position, out value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static JsonResult Optional(ReadOnlySpan<char> jsonSpan, int position, out int value, int @default = 0)
        {
            value = @default;

            if (position < 0) return JsonResult.Ok;

            JsonResult result = JsonZero.ParseNumber(jsonSpan, ref position, out float floatValue);

            if (result != JsonResult.Ok) return result;

            value = (int)floatValue;

            return JsonResult.Ok;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static JsonResult Optional(ReadOnlySpan<char> jsonSpan, int position, out float? value)
        {
            value = null;

            if (position < 0) return JsonResult.Ok;

            var result = JsonZero.ParseNumber(jsonSpan, ref position, out float floatValue);

            if (result != JsonResult.Ok) return result;

            value = floatValue;

            return JsonResult.Ok;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static JsonResult Optional(ReadOnlySpan<char> jsonSpan, int position, out bool value, bool @default = false)
        {
            value = @default;

            if (position < 0) return JsonResult.Ok;

            return JsonZero.ParseBoolean(jsonSpan, ref position, out value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static JsonResult Optional(ReadOnlySpan<char> jsonSpan, int position, out (float min, float max)? value)
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