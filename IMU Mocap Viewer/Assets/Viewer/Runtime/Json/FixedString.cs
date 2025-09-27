using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Viewer.Runtime.Json
{
    public static class FixedString 
    {
        public interface IFixedString
        {
            bool HasValue { get; }
            
            int MaxLength { get; }
            
            int Length { get; }

            void SetLength(int length);
            
            Span<char> AsSpan();

            ReadOnlySpan<char> AsReadOnlySpan();
        }
        
        public static JsonResult ParseTruncate<TFixedString>(this ref TFixedString fixedString, ReadOnlySpan<char> jsonSpan, ref int position, out int length) where TFixedString : struct, IFixedString
        {
            length = 0;
            
            Span<char> span = fixedString.AsSpan();
            
            JsonResult result = JsonZero.MessureAndTryParse(jsonSpan, ref position, span, out length);
            if (result != JsonResult.Ok) return result;

            fixedString.SetLength(Mathf.Min(length, fixedString.MaxLength));
                
            return JsonResult.Ok;
        }
        
        public static JsonResult Parse<TFixedString>(this ref TFixedString fixedString, ReadOnlySpan<char> jsonSpan, ref int position, out int length, out string dynamicString) where TFixedString : struct, IFixedString
        {
            length = 0;
            dynamicString = null; 
            
            int start = position; 
            
            Span<char> span = fixedString.AsSpan();
        
            JsonResult result = JsonZero.MessureAndTryParse(jsonSpan, ref position, span, out length);
            if (result != JsonResult.Ok) return result;
            
            fixedString.SetLength(Mathf.Min(length, fixedString.MaxLength));
            
            if (length < fixedString.MaxLength) return JsonResult.Ok;
            
            position = start;
            
            return JsonZero.ParseDynamicString(jsonSpan, ref position, out dynamicString);
        }
        
        public static string ToNewString<TFixedString>(this ref TFixedString fixedString) where TFixedString : struct, IFixedString
        {
            if (fixedString.Length <= 0) return string.Empty;
        
            return new string(fixedString.AsReadOnlySpan());
        }
    }

    public struct FixedString32 : FixedString.IFixedString
    {
        private const int MaxLength = 32;

        private unsafe fixed char buffer[MaxLength];
        private int? bufferLength;

        public bool HasValue => bufferLength != null;

        public int Length => bufferLength ?? 0;

        int FixedString.IFixedString.MaxLength => MaxLength;

        void FixedString.IFixedString.SetLength(int length) => bufferLength = length;

        unsafe Span<char> FixedString.IFixedString.AsSpan() => MemoryMarshal.CreateSpan(ref buffer[0], MaxLength);

        unsafe ReadOnlySpan<char> FixedString.IFixedString.AsReadOnlySpan() => MemoryMarshal.CreateSpan(ref buffer[0], Length);
    }

    public struct FixedString128 : FixedString.IFixedString
    {
        private const int MaxLength = 128;
        
        private unsafe fixed char buffer[MaxLength];        
        private int? bufferLength;
        
        public bool HasValue => bufferLength != null;
        
        public int Length => bufferLength ?? 0;
        
        int FixedString.IFixedString.MaxLength => MaxLength;

        void FixedString.IFixedString.SetLength(int length) => bufferLength = length;
        
        public unsafe Span<char> AsSpan() => MemoryMarshal.CreateSpan(ref buffer[0], MaxLength);

        public unsafe ReadOnlySpan<char> AsReadOnlySpan() => MemoryMarshal.CreateSpan(ref buffer[0], Length);
    }
}