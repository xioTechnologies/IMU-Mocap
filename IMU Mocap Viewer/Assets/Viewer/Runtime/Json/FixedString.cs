using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Viewer.Runtime.Json
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

    public static class FixedString
    {
        public static string AsString<TFixedString>(this ref TFixedString fixedString) where TFixedString : struct, IFixedString
            => fixedString.Length <= 0 ? string.Empty : new string(fixedString.AsReadOnlySpan());
    }

    public struct FixedString64 : IFixedString
    {
        public const int MaxLength = 64;

        private unsafe fixed char buffer[MaxLength];
        private int? bufferLength;

        public bool HasValue => bufferLength != null;

        public int Length => bufferLength ?? 0;

        int IFixedString.MaxLength => MaxLength;

        public void SetLength(int length) => bufferLength = length;

        public unsafe Span<char> AsSpan() => MemoryMarshal.CreateSpan(ref buffer[0], MaxLength);

        public unsafe ReadOnlySpan<char> AsReadOnlySpan() => MemoryMarshal.CreateSpan(ref buffer[0], Length);
    }

    public struct FixedString128 : IFixedString
    {
        public const int MaxLength = 128;

        private unsafe fixed char buffer[MaxLength];
        private int? bufferLength;

        public bool HasValue => bufferLength != null;

        public int Length => bufferLength ?? 0;

        int IFixedString.MaxLength => MaxLength;

        public void SetLength(int length) => bufferLength = length;

        public unsafe Span<char> AsSpan() => MemoryMarshal.CreateSpan(ref buffer[0], MaxLength);

        public unsafe ReadOnlySpan<char> AsReadOnlySpan() => MemoryMarshal.CreateSpan(ref buffer[0], Length);
    }

    public struct FixedString1k : IFixedString
    {
        public const int MaxLength = 1024;

        private unsafe fixed char buffer[MaxLength];
        private int? bufferLength;

        public bool HasValue => bufferLength != null;

        public int Length => bufferLength ?? 0;

        int IFixedString.MaxLength => MaxLength;

        public void SetLength(int length) => bufferLength = length;

        public unsafe Span<char> AsSpan() => MemoryMarshal.CreateSpan(ref buffer[0], MaxLength);

        public unsafe ReadOnlySpan<char> AsReadOnlySpan() => MemoryMarshal.CreateSpan(ref buffer[0], Length);
    }
}