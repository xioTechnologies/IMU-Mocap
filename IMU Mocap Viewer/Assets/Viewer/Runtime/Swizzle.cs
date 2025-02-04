using System.Runtime.CompilerServices;
using UnityEngine;

namespace Viewer.Runtime
{
    static class Swizzle
    {
        // swizzle of size 2
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _xx(this Vector2 a)
        {
            return new Vector2(a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _xy(this Vector2 a)
        {
            return new Vector2(a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _x0(this Vector2 a)
        {
            return new Vector2(a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _x1(this Vector2 a)
        {
            return new Vector2(a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _yx(this Vector2 a)
        {
            return new Vector2(a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _yy(this Vector2 a)
        {
            return new Vector2(a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _y0(this Vector2 a)
        {
            return new Vector2(a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _y1(this Vector2 a)
        {
            return new Vector2(a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _0x(this Vector2 a)
        {
            return new Vector2(0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _0y(this Vector2 a)
        {
            return new Vector2(0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _00(this Vector2 a)
        {
            return new Vector2(0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _01(this Vector2 a)
        {
            return new Vector2(0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _1x(this Vector2 a)
        {
            return new Vector2(1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _1y(this Vector2 a)
        {
            return new Vector2(1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _10(this Vector2 a)
        {
            return new Vector2(1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _11(this Vector2 a)
        {
            return new Vector2(1, 1);
        }

        // swizzle of size 3
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xxx(this Vector2 a)
        {
            return new Vector3(a.x, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xxy(this Vector2 a)
        {
            return new Vector3(a.x, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xx0(this Vector2 a)
        {
            return new Vector3(a.x, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xx1(this Vector2 a)
        {
            return new Vector3(a.x, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xyx(this Vector2 a)
        {
            return new Vector3(a.x, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xyy(this Vector2 a)
        {
            return new Vector3(a.x, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xy0(this Vector2 a)
        {
            return new Vector3(a.x, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xy1(this Vector2 a)
        {
            return new Vector3(a.x, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _x0x(this Vector2 a)
        {
            return new Vector3(a.x, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _x0y(this Vector2 a)
        {
            return new Vector3(a.x, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _x00(this Vector2 a)
        {
            return new Vector3(a.x, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _x01(this Vector2 a)
        {
            return new Vector3(a.x, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _x1x(this Vector2 a)
        {
            return new Vector3(a.x, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _x1y(this Vector2 a)
        {
            return new Vector3(a.x, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _x10(this Vector2 a)
        {
            return new Vector3(a.x, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _x11(this Vector2 a)
        {
            return new Vector3(a.x, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yxx(this Vector2 a)
        {
            return new Vector3(a.y, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yxy(this Vector2 a)
        {
            return new Vector3(a.y, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yx0(this Vector2 a)
        {
            return new Vector3(a.y, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yx1(this Vector2 a)
        {
            return new Vector3(a.y, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yyx(this Vector2 a)
        {
            return new Vector3(a.y, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yyy(this Vector2 a)
        {
            return new Vector3(a.y, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yy0(this Vector2 a)
        {
            return new Vector3(a.y, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yy1(this Vector2 a)
        {
            return new Vector3(a.y, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _y0x(this Vector2 a)
        {
            return new Vector3(a.y, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _y0y(this Vector2 a)
        {
            return new Vector3(a.y, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _y00(this Vector2 a)
        {
            return new Vector3(a.y, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _y01(this Vector2 a)
        {
            return new Vector3(a.y, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _y1x(this Vector2 a)
        {
            return new Vector3(a.y, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _y1y(this Vector2 a)
        {
            return new Vector3(a.y, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _y10(this Vector2 a)
        {
            return new Vector3(a.y, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _y11(this Vector2 a)
        {
            return new Vector3(a.y, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0xx(this Vector2 a)
        {
            return new Vector3(0, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0xy(this Vector2 a)
        {
            return new Vector3(0, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0x0(this Vector2 a)
        {
            return new Vector3(0, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0x1(this Vector2 a)
        {
            return new Vector3(0, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0yx(this Vector2 a)
        {
            return new Vector3(0, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0yy(this Vector2 a)
        {
            return new Vector3(0, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0y0(this Vector2 a)
        {
            return new Vector3(0, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0y1(this Vector2 a)
        {
            return new Vector3(0, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _00x(this Vector2 a)
        {
            return new Vector3(0, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _00y(this Vector2 a)
        {
            return new Vector3(0, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _000(this Vector2 a)
        {
            return new Vector3(0, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _001(this Vector2 a)
        {
            return new Vector3(0, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _01x(this Vector2 a)
        {
            return new Vector3(0, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _01y(this Vector2 a)
        {
            return new Vector3(0, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _010(this Vector2 a)
        {
            return new Vector3(0, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _011(this Vector2 a)
        {
            return new Vector3(0, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1xx(this Vector2 a)
        {
            return new Vector3(1, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1xy(this Vector2 a)
        {
            return new Vector3(1, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1x0(this Vector2 a)
        {
            return new Vector3(1, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1x1(this Vector2 a)
        {
            return new Vector3(1, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1yx(this Vector2 a)
        {
            return new Vector3(1, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1yy(this Vector2 a)
        {
            return new Vector3(1, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1y0(this Vector2 a)
        {
            return new Vector3(1, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1y1(this Vector2 a)
        {
            return new Vector3(1, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _10x(this Vector2 a)
        {
            return new Vector3(1, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _10y(this Vector2 a)
        {
            return new Vector3(1, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _100(this Vector2 a)
        {
            return new Vector3(1, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _101(this Vector2 a)
        {
            return new Vector3(1, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _11x(this Vector2 a)
        {
            return new Vector3(1, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _11y(this Vector2 a)
        {
            return new Vector3(1, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _110(this Vector2 a)
        {
            return new Vector3(1, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _111(this Vector2 a)
        {
            return new Vector3(1, 1, 1);
        }

        // swizzle of size 4
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxxx(this Vector2 a)
        {
            return new Vector4(a.x, a.x, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxxy(this Vector2 a)
        {
            return new Vector4(a.x, a.x, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxx0(this Vector2 a)
        {
            return new Vector4(a.x, a.x, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxx1(this Vector2 a)
        {
            return new Vector4(a.x, a.x, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxyx(this Vector2 a)
        {
            return new Vector4(a.x, a.x, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxyy(this Vector2 a)
        {
            return new Vector4(a.x, a.x, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxy0(this Vector2 a)
        {
            return new Vector4(a.x, a.x, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxy1(this Vector2 a)
        {
            return new Vector4(a.x, a.x, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xx0x(this Vector2 a)
        {
            return new Vector4(a.x, a.x, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xx0y(this Vector2 a)
        {
            return new Vector4(a.x, a.x, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xx00(this Vector2 a)
        {
            return new Vector4(a.x, a.x, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xx01(this Vector2 a)
        {
            return new Vector4(a.x, a.x, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xx1x(this Vector2 a)
        {
            return new Vector4(a.x, a.x, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xx1y(this Vector2 a)
        {
            return new Vector4(a.x, a.x, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xx10(this Vector2 a)
        {
            return new Vector4(a.x, a.x, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xx11(this Vector2 a)
        {
            return new Vector4(a.x, a.x, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyxx(this Vector2 a)
        {
            return new Vector4(a.x, a.y, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyxy(this Vector2 a)
        {
            return new Vector4(a.x, a.y, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyx0(this Vector2 a)
        {
            return new Vector4(a.x, a.y, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyx1(this Vector2 a)
        {
            return new Vector4(a.x, a.y, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyyx(this Vector2 a)
        {
            return new Vector4(a.x, a.y, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyyy(this Vector2 a)
        {
            return new Vector4(a.x, a.y, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyy0(this Vector2 a)
        {
            return new Vector4(a.x, a.y, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyy1(this Vector2 a)
        {
            return new Vector4(a.x, a.y, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xy0x(this Vector2 a)
        {
            return new Vector4(a.x, a.y, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xy0y(this Vector2 a)
        {
            return new Vector4(a.x, a.y, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xy00(this Vector2 a)
        {
            return new Vector4(a.x, a.y, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xy01(this Vector2 a)
        {
            return new Vector4(a.x, a.y, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xy1x(this Vector2 a)
        {
            return new Vector4(a.x, a.y, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xy1y(this Vector2 a)
        {
            return new Vector4(a.x, a.y, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xy10(this Vector2 a)
        {
            return new Vector4(a.x, a.y, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xy11(this Vector2 a)
        {
            return new Vector4(a.x, a.y, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0xx(this Vector2 a)
        {
            return new Vector4(a.x, 0, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0xy(this Vector2 a)
        {
            return new Vector4(a.x, 0, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0x0(this Vector2 a)
        {
            return new Vector4(a.x, 0, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0x1(this Vector2 a)
        {
            return new Vector4(a.x, 0, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0yx(this Vector2 a)
        {
            return new Vector4(a.x, 0, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0yy(this Vector2 a)
        {
            return new Vector4(a.x, 0, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0y0(this Vector2 a)
        {
            return new Vector4(a.x, 0, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0y1(this Vector2 a)
        {
            return new Vector4(a.x, 0, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x00x(this Vector2 a)
        {
            return new Vector4(a.x, 0, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x00y(this Vector2 a)
        {
            return new Vector4(a.x, 0, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x000(this Vector2 a)
        {
            return new Vector4(a.x, 0, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x001(this Vector2 a)
        {
            return new Vector4(a.x, 0, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x01x(this Vector2 a)
        {
            return new Vector4(a.x, 0, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x01y(this Vector2 a)
        {
            return new Vector4(a.x, 0, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x010(this Vector2 a)
        {
            return new Vector4(a.x, 0, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x011(this Vector2 a)
        {
            return new Vector4(a.x, 0, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1xx(this Vector2 a)
        {
            return new Vector4(a.x, 1, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1xy(this Vector2 a)
        {
            return new Vector4(a.x, 1, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1x0(this Vector2 a)
        {
            return new Vector4(a.x, 1, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1x1(this Vector2 a)
        {
            return new Vector4(a.x, 1, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1yx(this Vector2 a)
        {
            return new Vector4(a.x, 1, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1yy(this Vector2 a)
        {
            return new Vector4(a.x, 1, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1y0(this Vector2 a)
        {
            return new Vector4(a.x, 1, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1y1(this Vector2 a)
        {
            return new Vector4(a.x, 1, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x10x(this Vector2 a)
        {
            return new Vector4(a.x, 1, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x10y(this Vector2 a)
        {
            return new Vector4(a.x, 1, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x100(this Vector2 a)
        {
            return new Vector4(a.x, 1, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x101(this Vector2 a)
        {
            return new Vector4(a.x, 1, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x11x(this Vector2 a)
        {
            return new Vector4(a.x, 1, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x11y(this Vector2 a)
        {
            return new Vector4(a.x, 1, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x110(this Vector2 a)
        {
            return new Vector4(a.x, 1, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x111(this Vector2 a)
        {
            return new Vector4(a.x, 1, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxxx(this Vector2 a)
        {
            return new Vector4(a.y, a.x, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxxy(this Vector2 a)
        {
            return new Vector4(a.y, a.x, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxx0(this Vector2 a)
        {
            return new Vector4(a.y, a.x, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxx1(this Vector2 a)
        {
            return new Vector4(a.y, a.x, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxyx(this Vector2 a)
        {
            return new Vector4(a.y, a.x, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxyy(this Vector2 a)
        {
            return new Vector4(a.y, a.x, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxy0(this Vector2 a)
        {
            return new Vector4(a.y, a.x, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxy1(this Vector2 a)
        {
            return new Vector4(a.y, a.x, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yx0x(this Vector2 a)
        {
            return new Vector4(a.y, a.x, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yx0y(this Vector2 a)
        {
            return new Vector4(a.y, a.x, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yx00(this Vector2 a)
        {
            return new Vector4(a.y, a.x, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yx01(this Vector2 a)
        {
            return new Vector4(a.y, a.x, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yx1x(this Vector2 a)
        {
            return new Vector4(a.y, a.x, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yx1y(this Vector2 a)
        {
            return new Vector4(a.y, a.x, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yx10(this Vector2 a)
        {
            return new Vector4(a.y, a.x, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yx11(this Vector2 a)
        {
            return new Vector4(a.y, a.x, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyxx(this Vector2 a)
        {
            return new Vector4(a.y, a.y, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyxy(this Vector2 a)
        {
            return new Vector4(a.y, a.y, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyx0(this Vector2 a)
        {
            return new Vector4(a.y, a.y, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyx1(this Vector2 a)
        {
            return new Vector4(a.y, a.y, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyyx(this Vector2 a)
        {
            return new Vector4(a.y, a.y, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyyy(this Vector2 a)
        {
            return new Vector4(a.y, a.y, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyy0(this Vector2 a)
        {
            return new Vector4(a.y, a.y, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyy1(this Vector2 a)
        {
            return new Vector4(a.y, a.y, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yy0x(this Vector2 a)
        {
            return new Vector4(a.y, a.y, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yy0y(this Vector2 a)
        {
            return new Vector4(a.y, a.y, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yy00(this Vector2 a)
        {
            return new Vector4(a.y, a.y, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yy01(this Vector2 a)
        {
            return new Vector4(a.y, a.y, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yy1x(this Vector2 a)
        {
            return new Vector4(a.y, a.y, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yy1y(this Vector2 a)
        {
            return new Vector4(a.y, a.y, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yy10(this Vector2 a)
        {
            return new Vector4(a.y, a.y, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yy11(this Vector2 a)
        {
            return new Vector4(a.y, a.y, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0xx(this Vector2 a)
        {
            return new Vector4(a.y, 0, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0xy(this Vector2 a)
        {
            return new Vector4(a.y, 0, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0x0(this Vector2 a)
        {
            return new Vector4(a.y, 0, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0x1(this Vector2 a)
        {
            return new Vector4(a.y, 0, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0yx(this Vector2 a)
        {
            return new Vector4(a.y, 0, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0yy(this Vector2 a)
        {
            return new Vector4(a.y, 0, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0y0(this Vector2 a)
        {
            return new Vector4(a.y, 0, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0y1(this Vector2 a)
        {
            return new Vector4(a.y, 0, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y00x(this Vector2 a)
        {
            return new Vector4(a.y, 0, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y00y(this Vector2 a)
        {
            return new Vector4(a.y, 0, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y000(this Vector2 a)
        {
            return new Vector4(a.y, 0, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y001(this Vector2 a)
        {
            return new Vector4(a.y, 0, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y01x(this Vector2 a)
        {
            return new Vector4(a.y, 0, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y01y(this Vector2 a)
        {
            return new Vector4(a.y, 0, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y010(this Vector2 a)
        {
            return new Vector4(a.y, 0, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y011(this Vector2 a)
        {
            return new Vector4(a.y, 0, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1xx(this Vector2 a)
        {
            return new Vector4(a.y, 1, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1xy(this Vector2 a)
        {
            return new Vector4(a.y, 1, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1x0(this Vector2 a)
        {
            return new Vector4(a.y, 1, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1x1(this Vector2 a)
        {
            return new Vector4(a.y, 1, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1yx(this Vector2 a)
        {
            return new Vector4(a.y, 1, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1yy(this Vector2 a)
        {
            return new Vector4(a.y, 1, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1y0(this Vector2 a)
        {
            return new Vector4(a.y, 1, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1y1(this Vector2 a)
        {
            return new Vector4(a.y, 1, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y10x(this Vector2 a)
        {
            return new Vector4(a.y, 1, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y10y(this Vector2 a)
        {
            return new Vector4(a.y, 1, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y100(this Vector2 a)
        {
            return new Vector4(a.y, 1, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y101(this Vector2 a)
        {
            return new Vector4(a.y, 1, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y11x(this Vector2 a)
        {
            return new Vector4(a.y, 1, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y11y(this Vector2 a)
        {
            return new Vector4(a.y, 1, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y110(this Vector2 a)
        {
            return new Vector4(a.y, 1, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y111(this Vector2 a)
        {
            return new Vector4(a.y, 1, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xxx(this Vector2 a)
        {
            return new Vector4(0, a.x, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xxy(this Vector2 a)
        {
            return new Vector4(0, a.x, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xx0(this Vector2 a)
        {
            return new Vector4(0, a.x, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xx1(this Vector2 a)
        {
            return new Vector4(0, a.x, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xyx(this Vector2 a)
        {
            return new Vector4(0, a.x, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xyy(this Vector2 a)
        {
            return new Vector4(0, a.x, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xy0(this Vector2 a)
        {
            return new Vector4(0, a.x, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xy1(this Vector2 a)
        {
            return new Vector4(0, a.x, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0x0x(this Vector2 a)
        {
            return new Vector4(0, a.x, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0x0y(this Vector2 a)
        {
            return new Vector4(0, a.x, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0x00(this Vector2 a)
        {
            return new Vector4(0, a.x, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0x01(this Vector2 a)
        {
            return new Vector4(0, a.x, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0x1x(this Vector2 a)
        {
            return new Vector4(0, a.x, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0x1y(this Vector2 a)
        {
            return new Vector4(0, a.x, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0x10(this Vector2 a)
        {
            return new Vector4(0, a.x, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0x11(this Vector2 a)
        {
            return new Vector4(0, a.x, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yxx(this Vector2 a)
        {
            return new Vector4(0, a.y, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yxy(this Vector2 a)
        {
            return new Vector4(0, a.y, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yx0(this Vector2 a)
        {
            return new Vector4(0, a.y, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yx1(this Vector2 a)
        {
            return new Vector4(0, a.y, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yyx(this Vector2 a)
        {
            return new Vector4(0, a.y, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yyy(this Vector2 a)
        {
            return new Vector4(0, a.y, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yy0(this Vector2 a)
        {
            return new Vector4(0, a.y, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yy1(this Vector2 a)
        {
            return new Vector4(0, a.y, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0y0x(this Vector2 a)
        {
            return new Vector4(0, a.y, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0y0y(this Vector2 a)
        {
            return new Vector4(0, a.y, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0y00(this Vector2 a)
        {
            return new Vector4(0, a.y, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0y01(this Vector2 a)
        {
            return new Vector4(0, a.y, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0y1x(this Vector2 a)
        {
            return new Vector4(0, a.y, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0y1y(this Vector2 a)
        {
            return new Vector4(0, a.y, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0y10(this Vector2 a)
        {
            return new Vector4(0, a.y, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0y11(this Vector2 a)
        {
            return new Vector4(0, a.y, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00xx(this Vector2 a)
        {
            return new Vector4(0, 0, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00xy(this Vector2 a)
        {
            return new Vector4(0, 0, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00x0(this Vector2 a)
        {
            return new Vector4(0, 0, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00x1(this Vector2 a)
        {
            return new Vector4(0, 0, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00yx(this Vector2 a)
        {
            return new Vector4(0, 0, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00yy(this Vector2 a)
        {
            return new Vector4(0, 0, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00y0(this Vector2 a)
        {
            return new Vector4(0, 0, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00y1(this Vector2 a)
        {
            return new Vector4(0, 0, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _000x(this Vector2 a)
        {
            return new Vector4(0, 0, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _000y(this Vector2 a)
        {
            return new Vector4(0, 0, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0000(this Vector2 a)
        {
            return new Vector4(0, 0, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0001(this Vector2 a)
        {
            return new Vector4(0, 0, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _001x(this Vector2 a)
        {
            return new Vector4(0, 0, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _001y(this Vector2 a)
        {
            return new Vector4(0, 0, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0010(this Vector2 a)
        {
            return new Vector4(0, 0, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0011(this Vector2 a)
        {
            return new Vector4(0, 0, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01xx(this Vector2 a)
        {
            return new Vector4(0, 1, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01xy(this Vector2 a)
        {
            return new Vector4(0, 1, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01x0(this Vector2 a)
        {
            return new Vector4(0, 1, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01x1(this Vector2 a)
        {
            return new Vector4(0, 1, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01yx(this Vector2 a)
        {
            return new Vector4(0, 1, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01yy(this Vector2 a)
        {
            return new Vector4(0, 1, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01y0(this Vector2 a)
        {
            return new Vector4(0, 1, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01y1(this Vector2 a)
        {
            return new Vector4(0, 1, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _010x(this Vector2 a)
        {
            return new Vector4(0, 1, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _010y(this Vector2 a)
        {
            return new Vector4(0, 1, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0100(this Vector2 a)
        {
            return new Vector4(0, 1, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0101(this Vector2 a)
        {
            return new Vector4(0, 1, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _011x(this Vector2 a)
        {
            return new Vector4(0, 1, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _011y(this Vector2 a)
        {
            return new Vector4(0, 1, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0110(this Vector2 a)
        {
            return new Vector4(0, 1, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0111(this Vector2 a)
        {
            return new Vector4(0, 1, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xxx(this Vector2 a)
        {
            return new Vector4(1, a.x, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xxy(this Vector2 a)
        {
            return new Vector4(1, a.x, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xx0(this Vector2 a)
        {
            return new Vector4(1, a.x, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xx1(this Vector2 a)
        {
            return new Vector4(1, a.x, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xyx(this Vector2 a)
        {
            return new Vector4(1, a.x, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xyy(this Vector2 a)
        {
            return new Vector4(1, a.x, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xy0(this Vector2 a)
        {
            return new Vector4(1, a.x, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xy1(this Vector2 a)
        {
            return new Vector4(1, a.x, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1x0x(this Vector2 a)
        {
            return new Vector4(1, a.x, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1x0y(this Vector2 a)
        {
            return new Vector4(1, a.x, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1x00(this Vector2 a)
        {
            return new Vector4(1, a.x, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1x01(this Vector2 a)
        {
            return new Vector4(1, a.x, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1x1x(this Vector2 a)
        {
            return new Vector4(1, a.x, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1x1y(this Vector2 a)
        {
            return new Vector4(1, a.x, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1x10(this Vector2 a)
        {
            return new Vector4(1, a.x, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1x11(this Vector2 a)
        {
            return new Vector4(1, a.x, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yxx(this Vector2 a)
        {
            return new Vector4(1, a.y, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yxy(this Vector2 a)
        {
            return new Vector4(1, a.y, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yx0(this Vector2 a)
        {
            return new Vector4(1, a.y, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yx1(this Vector2 a)
        {
            return new Vector4(1, a.y, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yyx(this Vector2 a)
        {
            return new Vector4(1, a.y, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yyy(this Vector2 a)
        {
            return new Vector4(1, a.y, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yy0(this Vector2 a)
        {
            return new Vector4(1, a.y, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yy1(this Vector2 a)
        {
            return new Vector4(1, a.y, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1y0x(this Vector2 a)
        {
            return new Vector4(1, a.y, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1y0y(this Vector2 a)
        {
            return new Vector4(1, a.y, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1y00(this Vector2 a)
        {
            return new Vector4(1, a.y, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1y01(this Vector2 a)
        {
            return new Vector4(1, a.y, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1y1x(this Vector2 a)
        {
            return new Vector4(1, a.y, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1y1y(this Vector2 a)
        {
            return new Vector4(1, a.y, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1y10(this Vector2 a)
        {
            return new Vector4(1, a.y, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1y11(this Vector2 a)
        {
            return new Vector4(1, a.y, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10xx(this Vector2 a)
        {
            return new Vector4(1, 0, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10xy(this Vector2 a)
        {
            return new Vector4(1, 0, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10x0(this Vector2 a)
        {
            return new Vector4(1, 0, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10x1(this Vector2 a)
        {
            return new Vector4(1, 0, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10yx(this Vector2 a)
        {
            return new Vector4(1, 0, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10yy(this Vector2 a)
        {
            return new Vector4(1, 0, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10y0(this Vector2 a)
        {
            return new Vector4(1, 0, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10y1(this Vector2 a)
        {
            return new Vector4(1, 0, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _100x(this Vector2 a)
        {
            return new Vector4(1, 0, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _100y(this Vector2 a)
        {
            return new Vector4(1, 0, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1000(this Vector2 a)
        {
            return new Vector4(1, 0, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1001(this Vector2 a)
        {
            return new Vector4(1, 0, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _101x(this Vector2 a)
        {
            return new Vector4(1, 0, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _101y(this Vector2 a)
        {
            return new Vector4(1, 0, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1010(this Vector2 a)
        {
            return new Vector4(1, 0, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1011(this Vector2 a)
        {
            return new Vector4(1, 0, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11xx(this Vector2 a)
        {
            return new Vector4(1, 1, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11xy(this Vector2 a)
        {
            return new Vector4(1, 1, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11x0(this Vector2 a)
        {
            return new Vector4(1, 1, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11x1(this Vector2 a)
        {
            return new Vector4(1, 1, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11yx(this Vector2 a)
        {
            return new Vector4(1, 1, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11yy(this Vector2 a)
        {
            return new Vector4(1, 1, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11y0(this Vector2 a)
        {
            return new Vector4(1, 1, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11y1(this Vector2 a)
        {
            return new Vector4(1, 1, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _110x(this Vector2 a)
        {
            return new Vector4(1, 1, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _110y(this Vector2 a)
        {
            return new Vector4(1, 1, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1100(this Vector2 a)
        {
            return new Vector4(1, 1, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1101(this Vector2 a)
        {
            return new Vector4(1, 1, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _111x(this Vector2 a)
        {
            return new Vector4(1, 1, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _111y(this Vector2 a)
        {
            return new Vector4(1, 1, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1110(this Vector2 a)
        {
            return new Vector4(1, 1, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1111(this Vector2 a)
        {
            return new Vector4(1, 1, 1, 1);
        }

        // swizzle of size 2
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _xx(this Vector3 a)
        {
            return new Vector2(a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _xy(this Vector3 a)
        {
            return new Vector2(a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _xz(this Vector3 a)
        {
            return new Vector2(a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _x0(this Vector3 a)
        {
            return new Vector2(a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _x1(this Vector3 a)
        {
            return new Vector2(a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _yx(this Vector3 a)
        {
            return new Vector2(a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _yy(this Vector3 a)
        {
            return new Vector2(a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _yz(this Vector3 a)
        {
            return new Vector2(a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _y0(this Vector3 a)
        {
            return new Vector2(a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _y1(this Vector3 a)
        {
            return new Vector2(a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _zx(this Vector3 a)
        {
            return new Vector2(a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _zy(this Vector3 a)
        {
            return new Vector2(a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _zz(this Vector3 a)
        {
            return new Vector2(a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _z0(this Vector3 a)
        {
            return new Vector2(a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _z1(this Vector3 a)
        {
            return new Vector2(a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _0x(this Vector3 a)
        {
            return new Vector2(0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _0y(this Vector3 a)
        {
            return new Vector2(0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _0z(this Vector3 a)
        {
            return new Vector2(0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _00(this Vector3 a)
        {
            return new Vector2(0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _01(this Vector3 a)
        {
            return new Vector2(0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _1x(this Vector3 a)
        {
            return new Vector2(1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _1y(this Vector3 a)
        {
            return new Vector2(1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _1z(this Vector3 a)
        {
            return new Vector2(1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _10(this Vector3 a)
        {
            return new Vector2(1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _11(this Vector3 a)
        {
            return new Vector2(1, 1);
        }

        // swizzle of size 3
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xxx(this Vector3 a)
        {
            return new Vector3(a.x, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xxy(this Vector3 a)
        {
            return new Vector3(a.x, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xxz(this Vector3 a)
        {
            return new Vector3(a.x, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xx0(this Vector3 a)
        {
            return new Vector3(a.x, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xx1(this Vector3 a)
        {
            return new Vector3(a.x, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xyx(this Vector3 a)
        {
            return new Vector3(a.x, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xyy(this Vector3 a)
        {
            return new Vector3(a.x, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xyz(this Vector3 a)
        {
            return new Vector3(a.x, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xy0(this Vector3 a)
        {
            return new Vector3(a.x, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xy1(this Vector3 a)
        {
            return new Vector3(a.x, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xzx(this Vector3 a)
        {
            return new Vector3(a.x, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xzy(this Vector3 a)
        {
            return new Vector3(a.x, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xzz(this Vector3 a)
        {
            return new Vector3(a.x, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xz0(this Vector3 a)
        {
            return new Vector3(a.x, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xz1(this Vector3 a)
        {
            return new Vector3(a.x, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _x0x(this Vector3 a)
        {
            return new Vector3(a.x, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _x0y(this Vector3 a)
        {
            return new Vector3(a.x, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _x0z(this Vector3 a)
        {
            return new Vector3(a.x, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _x00(this Vector3 a)
        {
            return new Vector3(a.x, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _x01(this Vector3 a)
        {
            return new Vector3(a.x, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _x1x(this Vector3 a)
        {
            return new Vector3(a.x, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _x1y(this Vector3 a)
        {
            return new Vector3(a.x, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _x1z(this Vector3 a)
        {
            return new Vector3(a.x, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _x10(this Vector3 a)
        {
            return new Vector3(a.x, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _x11(this Vector3 a)
        {
            return new Vector3(a.x, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yxx(this Vector3 a)
        {
            return new Vector3(a.y, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yxy(this Vector3 a)
        {
            return new Vector3(a.y, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yxz(this Vector3 a)
        {
            return new Vector3(a.y, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yx0(this Vector3 a)
        {
            return new Vector3(a.y, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yx1(this Vector3 a)
        {
            return new Vector3(a.y, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yyx(this Vector3 a)
        {
            return new Vector3(a.y, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yyy(this Vector3 a)
        {
            return new Vector3(a.y, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yyz(this Vector3 a)
        {
            return new Vector3(a.y, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yy0(this Vector3 a)
        {
            return new Vector3(a.y, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yy1(this Vector3 a)
        {
            return new Vector3(a.y, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yzx(this Vector3 a)
        {
            return new Vector3(a.y, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yzy(this Vector3 a)
        {
            return new Vector3(a.y, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yzz(this Vector3 a)
        {
            return new Vector3(a.y, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yz0(this Vector3 a)
        {
            return new Vector3(a.y, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yz1(this Vector3 a)
        {
            return new Vector3(a.y, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _y0x(this Vector3 a)
        {
            return new Vector3(a.y, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _y0y(this Vector3 a)
        {
            return new Vector3(a.y, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _y0z(this Vector3 a)
        {
            return new Vector3(a.y, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _y00(this Vector3 a)
        {
            return new Vector3(a.y, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _y01(this Vector3 a)
        {
            return new Vector3(a.y, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _y1x(this Vector3 a)
        {
            return new Vector3(a.y, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _y1y(this Vector3 a)
        {
            return new Vector3(a.y, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _y1z(this Vector3 a)
        {
            return new Vector3(a.y, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _y10(this Vector3 a)
        {
            return new Vector3(a.y, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _y11(this Vector3 a)
        {
            return new Vector3(a.y, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zxx(this Vector3 a)
        {
            return new Vector3(a.z, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zxy(this Vector3 a)
        {
            return new Vector3(a.z, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zxz(this Vector3 a)
        {
            return new Vector3(a.z, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zx0(this Vector3 a)
        {
            return new Vector3(a.z, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zx1(this Vector3 a)
        {
            return new Vector3(a.z, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zyx(this Vector3 a)
        {
            return new Vector3(a.z, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zyy(this Vector3 a)
        {
            return new Vector3(a.z, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zyz(this Vector3 a)
        {
            return new Vector3(a.z, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zy0(this Vector3 a)
        {
            return new Vector3(a.z, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zy1(this Vector3 a)
        {
            return new Vector3(a.z, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zzx(this Vector3 a)
        {
            return new Vector3(a.z, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zzy(this Vector3 a)
        {
            return new Vector3(a.z, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zzz(this Vector3 a)
        {
            return new Vector3(a.z, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zz0(this Vector3 a)
        {
            return new Vector3(a.z, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zz1(this Vector3 a)
        {
            return new Vector3(a.z, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _z0x(this Vector3 a)
        {
            return new Vector3(a.z, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _z0y(this Vector3 a)
        {
            return new Vector3(a.z, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _z0z(this Vector3 a)
        {
            return new Vector3(a.z, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _z00(this Vector3 a)
        {
            return new Vector3(a.z, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _z01(this Vector3 a)
        {
            return new Vector3(a.z, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _z1x(this Vector3 a)
        {
            return new Vector3(a.z, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _z1y(this Vector3 a)
        {
            return new Vector3(a.z, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _z1z(this Vector3 a)
        {
            return new Vector3(a.z, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _z10(this Vector3 a)
        {
            return new Vector3(a.z, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _z11(this Vector3 a)
        {
            return new Vector3(a.z, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0xx(this Vector3 a)
        {
            return new Vector3(0, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0xy(this Vector3 a)
        {
            return new Vector3(0, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0xz(this Vector3 a)
        {
            return new Vector3(0, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0x0(this Vector3 a)
        {
            return new Vector3(0, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0x1(this Vector3 a)
        {
            return new Vector3(0, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0yx(this Vector3 a)
        {
            return new Vector3(0, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0yy(this Vector3 a)
        {
            return new Vector3(0, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0yz(this Vector3 a)
        {
            return new Vector3(0, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0y0(this Vector3 a)
        {
            return new Vector3(0, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0y1(this Vector3 a)
        {
            return new Vector3(0, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0zx(this Vector3 a)
        {
            return new Vector3(0, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0zy(this Vector3 a)
        {
            return new Vector3(0, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0zz(this Vector3 a)
        {
            return new Vector3(0, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0z0(this Vector3 a)
        {
            return new Vector3(0, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0z1(this Vector3 a)
        {
            return new Vector3(0, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _00x(this Vector3 a)
        {
            return new Vector3(0, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _00y(this Vector3 a)
        {
            return new Vector3(0, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _00z(this Vector3 a)
        {
            return new Vector3(0, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _000(this Vector3 a)
        {
            return new Vector3(0, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _001(this Vector3 a)
        {
            return new Vector3(0, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _01x(this Vector3 a)
        {
            return new Vector3(0, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _01y(this Vector3 a)
        {
            return new Vector3(0, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _01z(this Vector3 a)
        {
            return new Vector3(0, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _010(this Vector3 a)
        {
            return new Vector3(0, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _011(this Vector3 a)
        {
            return new Vector3(0, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1xx(this Vector3 a)
        {
            return new Vector3(1, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1xy(this Vector3 a)
        {
            return new Vector3(1, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1xz(this Vector3 a)
        {
            return new Vector3(1, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1x0(this Vector3 a)
        {
            return new Vector3(1, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1x1(this Vector3 a)
        {
            return new Vector3(1, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1yx(this Vector3 a)
        {
            return new Vector3(1, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1yy(this Vector3 a)
        {
            return new Vector3(1, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1yz(this Vector3 a)
        {
            return new Vector3(1, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1y0(this Vector3 a)
        {
            return new Vector3(1, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1y1(this Vector3 a)
        {
            return new Vector3(1, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1zx(this Vector3 a)
        {
            return new Vector3(1, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1zy(this Vector3 a)
        {
            return new Vector3(1, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1zz(this Vector3 a)
        {
            return new Vector3(1, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1z0(this Vector3 a)
        {
            return new Vector3(1, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1z1(this Vector3 a)
        {
            return new Vector3(1, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _10x(this Vector3 a)
        {
            return new Vector3(1, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _10y(this Vector3 a)
        {
            return new Vector3(1, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _10z(this Vector3 a)
        {
            return new Vector3(1, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _100(this Vector3 a)
        {
            return new Vector3(1, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _101(this Vector3 a)
        {
            return new Vector3(1, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _11x(this Vector3 a)
        {
            return new Vector3(1, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _11y(this Vector3 a)
        {
            return new Vector3(1, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _11z(this Vector3 a)
        {
            return new Vector3(1, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _110(this Vector3 a)
        {
            return new Vector3(1, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _111(this Vector3 a)
        {
            return new Vector3(1, 1, 1);
        }

        // swizzle of size 4
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxxx(this Vector3 a)
        {
            return new Vector4(a.x, a.x, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxxy(this Vector3 a)
        {
            return new Vector4(a.x, a.x, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxxz(this Vector3 a)
        {
            return new Vector4(a.x, a.x, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxx0(this Vector3 a)
        {
            return new Vector4(a.x, a.x, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxx1(this Vector3 a)
        {
            return new Vector4(a.x, a.x, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxyx(this Vector3 a)
        {
            return new Vector4(a.x, a.x, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxyy(this Vector3 a)
        {
            return new Vector4(a.x, a.x, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxyz(this Vector3 a)
        {
            return new Vector4(a.x, a.x, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxy0(this Vector3 a)
        {
            return new Vector4(a.x, a.x, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxy1(this Vector3 a)
        {
            return new Vector4(a.x, a.x, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxzx(this Vector3 a)
        {
            return new Vector4(a.x, a.x, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxzy(this Vector3 a)
        {
            return new Vector4(a.x, a.x, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxzz(this Vector3 a)
        {
            return new Vector4(a.x, a.x, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxz0(this Vector3 a)
        {
            return new Vector4(a.x, a.x, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxz1(this Vector3 a)
        {
            return new Vector4(a.x, a.x, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xx0x(this Vector3 a)
        {
            return new Vector4(a.x, a.x, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xx0y(this Vector3 a)
        {
            return new Vector4(a.x, a.x, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xx0z(this Vector3 a)
        {
            return new Vector4(a.x, a.x, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xx00(this Vector3 a)
        {
            return new Vector4(a.x, a.x, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xx01(this Vector3 a)
        {
            return new Vector4(a.x, a.x, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xx1x(this Vector3 a)
        {
            return new Vector4(a.x, a.x, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xx1y(this Vector3 a)
        {
            return new Vector4(a.x, a.x, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xx1z(this Vector3 a)
        {
            return new Vector4(a.x, a.x, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xx10(this Vector3 a)
        {
            return new Vector4(a.x, a.x, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xx11(this Vector3 a)
        {
            return new Vector4(a.x, a.x, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyxx(this Vector3 a)
        {
            return new Vector4(a.x, a.y, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyxy(this Vector3 a)
        {
            return new Vector4(a.x, a.y, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyxz(this Vector3 a)
        {
            return new Vector4(a.x, a.y, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyx0(this Vector3 a)
        {
            return new Vector4(a.x, a.y, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyx1(this Vector3 a)
        {
            return new Vector4(a.x, a.y, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyyx(this Vector3 a)
        {
            return new Vector4(a.x, a.y, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyyy(this Vector3 a)
        {
            return new Vector4(a.x, a.y, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyyz(this Vector3 a)
        {
            return new Vector4(a.x, a.y, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyy0(this Vector3 a)
        {
            return new Vector4(a.x, a.y, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyy1(this Vector3 a)
        {
            return new Vector4(a.x, a.y, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyzx(this Vector3 a)
        {
            return new Vector4(a.x, a.y, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyzy(this Vector3 a)
        {
            return new Vector4(a.x, a.y, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyzz(this Vector3 a)
        {
            return new Vector4(a.x, a.y, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyz0(this Vector3 a)
        {
            return new Vector4(a.x, a.y, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyz1(this Vector3 a)
        {
            return new Vector4(a.x, a.y, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xy0x(this Vector3 a)
        {
            return new Vector4(a.x, a.y, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xy0y(this Vector3 a)
        {
            return new Vector4(a.x, a.y, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xy0z(this Vector3 a)
        {
            return new Vector4(a.x, a.y, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xy00(this Vector3 a)
        {
            return new Vector4(a.x, a.y, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xy01(this Vector3 a)
        {
            return new Vector4(a.x, a.y, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xy1x(this Vector3 a)
        {
            return new Vector4(a.x, a.y, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xy1y(this Vector3 a)
        {
            return new Vector4(a.x, a.y, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xy1z(this Vector3 a)
        {
            return new Vector4(a.x, a.y, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xy10(this Vector3 a)
        {
            return new Vector4(a.x, a.y, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xy11(this Vector3 a)
        {
            return new Vector4(a.x, a.y, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzxx(this Vector3 a)
        {
            return new Vector4(a.x, a.z, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzxy(this Vector3 a)
        {
            return new Vector4(a.x, a.z, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzxz(this Vector3 a)
        {
            return new Vector4(a.x, a.z, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzx0(this Vector3 a)
        {
            return new Vector4(a.x, a.z, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzx1(this Vector3 a)
        {
            return new Vector4(a.x, a.z, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzyx(this Vector3 a)
        {
            return new Vector4(a.x, a.z, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzyy(this Vector3 a)
        {
            return new Vector4(a.x, a.z, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzyz(this Vector3 a)
        {
            return new Vector4(a.x, a.z, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzy0(this Vector3 a)
        {
            return new Vector4(a.x, a.z, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzy1(this Vector3 a)
        {
            return new Vector4(a.x, a.z, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzzx(this Vector3 a)
        {
            return new Vector4(a.x, a.z, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzzy(this Vector3 a)
        {
            return new Vector4(a.x, a.z, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzzz(this Vector3 a)
        {
            return new Vector4(a.x, a.z, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzz0(this Vector3 a)
        {
            return new Vector4(a.x, a.z, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzz1(this Vector3 a)
        {
            return new Vector4(a.x, a.z, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xz0x(this Vector3 a)
        {
            return new Vector4(a.x, a.z, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xz0y(this Vector3 a)
        {
            return new Vector4(a.x, a.z, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xz0z(this Vector3 a)
        {
            return new Vector4(a.x, a.z, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xz00(this Vector3 a)
        {
            return new Vector4(a.x, a.z, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xz01(this Vector3 a)
        {
            return new Vector4(a.x, a.z, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xz1x(this Vector3 a)
        {
            return new Vector4(a.x, a.z, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xz1y(this Vector3 a)
        {
            return new Vector4(a.x, a.z, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xz1z(this Vector3 a)
        {
            return new Vector4(a.x, a.z, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xz10(this Vector3 a)
        {
            return new Vector4(a.x, a.z, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xz11(this Vector3 a)
        {
            return new Vector4(a.x, a.z, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0xx(this Vector3 a)
        {
            return new Vector4(a.x, 0, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0xy(this Vector3 a)
        {
            return new Vector4(a.x, 0, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0xz(this Vector3 a)
        {
            return new Vector4(a.x, 0, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0x0(this Vector3 a)
        {
            return new Vector4(a.x, 0, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0x1(this Vector3 a)
        {
            return new Vector4(a.x, 0, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0yx(this Vector3 a)
        {
            return new Vector4(a.x, 0, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0yy(this Vector3 a)
        {
            return new Vector4(a.x, 0, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0yz(this Vector3 a)
        {
            return new Vector4(a.x, 0, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0y0(this Vector3 a)
        {
            return new Vector4(a.x, 0, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0y1(this Vector3 a)
        {
            return new Vector4(a.x, 0, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0zx(this Vector3 a)
        {
            return new Vector4(a.x, 0, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0zy(this Vector3 a)
        {
            return new Vector4(a.x, 0, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0zz(this Vector3 a)
        {
            return new Vector4(a.x, 0, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0z0(this Vector3 a)
        {
            return new Vector4(a.x, 0, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0z1(this Vector3 a)
        {
            return new Vector4(a.x, 0, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x00x(this Vector3 a)
        {
            return new Vector4(a.x, 0, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x00y(this Vector3 a)
        {
            return new Vector4(a.x, 0, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x00z(this Vector3 a)
        {
            return new Vector4(a.x, 0, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x000(this Vector3 a)
        {
            return new Vector4(a.x, 0, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x001(this Vector3 a)
        {
            return new Vector4(a.x, 0, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x01x(this Vector3 a)
        {
            return new Vector4(a.x, 0, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x01y(this Vector3 a)
        {
            return new Vector4(a.x, 0, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x01z(this Vector3 a)
        {
            return new Vector4(a.x, 0, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x010(this Vector3 a)
        {
            return new Vector4(a.x, 0, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x011(this Vector3 a)
        {
            return new Vector4(a.x, 0, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1xx(this Vector3 a)
        {
            return new Vector4(a.x, 1, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1xy(this Vector3 a)
        {
            return new Vector4(a.x, 1, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1xz(this Vector3 a)
        {
            return new Vector4(a.x, 1, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1x0(this Vector3 a)
        {
            return new Vector4(a.x, 1, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1x1(this Vector3 a)
        {
            return new Vector4(a.x, 1, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1yx(this Vector3 a)
        {
            return new Vector4(a.x, 1, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1yy(this Vector3 a)
        {
            return new Vector4(a.x, 1, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1yz(this Vector3 a)
        {
            return new Vector4(a.x, 1, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1y0(this Vector3 a)
        {
            return new Vector4(a.x, 1, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1y1(this Vector3 a)
        {
            return new Vector4(a.x, 1, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1zx(this Vector3 a)
        {
            return new Vector4(a.x, 1, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1zy(this Vector3 a)
        {
            return new Vector4(a.x, 1, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1zz(this Vector3 a)
        {
            return new Vector4(a.x, 1, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1z0(this Vector3 a)
        {
            return new Vector4(a.x, 1, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1z1(this Vector3 a)
        {
            return new Vector4(a.x, 1, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x10x(this Vector3 a)
        {
            return new Vector4(a.x, 1, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x10y(this Vector3 a)
        {
            return new Vector4(a.x, 1, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x10z(this Vector3 a)
        {
            return new Vector4(a.x, 1, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x100(this Vector3 a)
        {
            return new Vector4(a.x, 1, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x101(this Vector3 a)
        {
            return new Vector4(a.x, 1, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x11x(this Vector3 a)
        {
            return new Vector4(a.x, 1, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x11y(this Vector3 a)
        {
            return new Vector4(a.x, 1, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x11z(this Vector3 a)
        {
            return new Vector4(a.x, 1, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x110(this Vector3 a)
        {
            return new Vector4(a.x, 1, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x111(this Vector3 a)
        {
            return new Vector4(a.x, 1, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxxx(this Vector3 a)
        {
            return new Vector4(a.y, a.x, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxxy(this Vector3 a)
        {
            return new Vector4(a.y, a.x, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxxz(this Vector3 a)
        {
            return new Vector4(a.y, a.x, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxx0(this Vector3 a)
        {
            return new Vector4(a.y, a.x, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxx1(this Vector3 a)
        {
            return new Vector4(a.y, a.x, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxyx(this Vector3 a)
        {
            return new Vector4(a.y, a.x, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxyy(this Vector3 a)
        {
            return new Vector4(a.y, a.x, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxyz(this Vector3 a)
        {
            return new Vector4(a.y, a.x, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxy0(this Vector3 a)
        {
            return new Vector4(a.y, a.x, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxy1(this Vector3 a)
        {
            return new Vector4(a.y, a.x, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxzx(this Vector3 a)
        {
            return new Vector4(a.y, a.x, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxzy(this Vector3 a)
        {
            return new Vector4(a.y, a.x, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxzz(this Vector3 a)
        {
            return new Vector4(a.y, a.x, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxz0(this Vector3 a)
        {
            return new Vector4(a.y, a.x, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxz1(this Vector3 a)
        {
            return new Vector4(a.y, a.x, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yx0x(this Vector3 a)
        {
            return new Vector4(a.y, a.x, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yx0y(this Vector3 a)
        {
            return new Vector4(a.y, a.x, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yx0z(this Vector3 a)
        {
            return new Vector4(a.y, a.x, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yx00(this Vector3 a)
        {
            return new Vector4(a.y, a.x, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yx01(this Vector3 a)
        {
            return new Vector4(a.y, a.x, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yx1x(this Vector3 a)
        {
            return new Vector4(a.y, a.x, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yx1y(this Vector3 a)
        {
            return new Vector4(a.y, a.x, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yx1z(this Vector3 a)
        {
            return new Vector4(a.y, a.x, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yx10(this Vector3 a)
        {
            return new Vector4(a.y, a.x, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yx11(this Vector3 a)
        {
            return new Vector4(a.y, a.x, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyxx(this Vector3 a)
        {
            return new Vector4(a.y, a.y, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyxy(this Vector3 a)
        {
            return new Vector4(a.y, a.y, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyxz(this Vector3 a)
        {
            return new Vector4(a.y, a.y, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyx0(this Vector3 a)
        {
            return new Vector4(a.y, a.y, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyx1(this Vector3 a)
        {
            return new Vector4(a.y, a.y, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyyx(this Vector3 a)
        {
            return new Vector4(a.y, a.y, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyyy(this Vector3 a)
        {
            return new Vector4(a.y, a.y, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyyz(this Vector3 a)
        {
            return new Vector4(a.y, a.y, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyy0(this Vector3 a)
        {
            return new Vector4(a.y, a.y, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyy1(this Vector3 a)
        {
            return new Vector4(a.y, a.y, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyzx(this Vector3 a)
        {
            return new Vector4(a.y, a.y, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyzy(this Vector3 a)
        {
            return new Vector4(a.y, a.y, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyzz(this Vector3 a)
        {
            return new Vector4(a.y, a.y, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyz0(this Vector3 a)
        {
            return new Vector4(a.y, a.y, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyz1(this Vector3 a)
        {
            return new Vector4(a.y, a.y, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yy0x(this Vector3 a)
        {
            return new Vector4(a.y, a.y, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yy0y(this Vector3 a)
        {
            return new Vector4(a.y, a.y, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yy0z(this Vector3 a)
        {
            return new Vector4(a.y, a.y, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yy00(this Vector3 a)
        {
            return new Vector4(a.y, a.y, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yy01(this Vector3 a)
        {
            return new Vector4(a.y, a.y, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yy1x(this Vector3 a)
        {
            return new Vector4(a.y, a.y, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yy1y(this Vector3 a)
        {
            return new Vector4(a.y, a.y, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yy1z(this Vector3 a)
        {
            return new Vector4(a.y, a.y, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yy10(this Vector3 a)
        {
            return new Vector4(a.y, a.y, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yy11(this Vector3 a)
        {
            return new Vector4(a.y, a.y, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzxx(this Vector3 a)
        {
            return new Vector4(a.y, a.z, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzxy(this Vector3 a)
        {
            return new Vector4(a.y, a.z, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzxz(this Vector3 a)
        {
            return new Vector4(a.y, a.z, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzx0(this Vector3 a)
        {
            return new Vector4(a.y, a.z, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzx1(this Vector3 a)
        {
            return new Vector4(a.y, a.z, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzyx(this Vector3 a)
        {
            return new Vector4(a.y, a.z, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzyy(this Vector3 a)
        {
            return new Vector4(a.y, a.z, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzyz(this Vector3 a)
        {
            return new Vector4(a.y, a.z, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzy0(this Vector3 a)
        {
            return new Vector4(a.y, a.z, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzy1(this Vector3 a)
        {
            return new Vector4(a.y, a.z, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzzx(this Vector3 a)
        {
            return new Vector4(a.y, a.z, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzzy(this Vector3 a)
        {
            return new Vector4(a.y, a.z, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzzz(this Vector3 a)
        {
            return new Vector4(a.y, a.z, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzz0(this Vector3 a)
        {
            return new Vector4(a.y, a.z, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzz1(this Vector3 a)
        {
            return new Vector4(a.y, a.z, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yz0x(this Vector3 a)
        {
            return new Vector4(a.y, a.z, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yz0y(this Vector3 a)
        {
            return new Vector4(a.y, a.z, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yz0z(this Vector3 a)
        {
            return new Vector4(a.y, a.z, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yz00(this Vector3 a)
        {
            return new Vector4(a.y, a.z, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yz01(this Vector3 a)
        {
            return new Vector4(a.y, a.z, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yz1x(this Vector3 a)
        {
            return new Vector4(a.y, a.z, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yz1y(this Vector3 a)
        {
            return new Vector4(a.y, a.z, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yz1z(this Vector3 a)
        {
            return new Vector4(a.y, a.z, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yz10(this Vector3 a)
        {
            return new Vector4(a.y, a.z, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yz11(this Vector3 a)
        {
            return new Vector4(a.y, a.z, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0xx(this Vector3 a)
        {
            return new Vector4(a.y, 0, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0xy(this Vector3 a)
        {
            return new Vector4(a.y, 0, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0xz(this Vector3 a)
        {
            return new Vector4(a.y, 0, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0x0(this Vector3 a)
        {
            return new Vector4(a.y, 0, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0x1(this Vector3 a)
        {
            return new Vector4(a.y, 0, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0yx(this Vector3 a)
        {
            return new Vector4(a.y, 0, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0yy(this Vector3 a)
        {
            return new Vector4(a.y, 0, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0yz(this Vector3 a)
        {
            return new Vector4(a.y, 0, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0y0(this Vector3 a)
        {
            return new Vector4(a.y, 0, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0y1(this Vector3 a)
        {
            return new Vector4(a.y, 0, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0zx(this Vector3 a)
        {
            return new Vector4(a.y, 0, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0zy(this Vector3 a)
        {
            return new Vector4(a.y, 0, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0zz(this Vector3 a)
        {
            return new Vector4(a.y, 0, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0z0(this Vector3 a)
        {
            return new Vector4(a.y, 0, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0z1(this Vector3 a)
        {
            return new Vector4(a.y, 0, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y00x(this Vector3 a)
        {
            return new Vector4(a.y, 0, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y00y(this Vector3 a)
        {
            return new Vector4(a.y, 0, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y00z(this Vector3 a)
        {
            return new Vector4(a.y, 0, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y000(this Vector3 a)
        {
            return new Vector4(a.y, 0, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y001(this Vector3 a)
        {
            return new Vector4(a.y, 0, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y01x(this Vector3 a)
        {
            return new Vector4(a.y, 0, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y01y(this Vector3 a)
        {
            return new Vector4(a.y, 0, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y01z(this Vector3 a)
        {
            return new Vector4(a.y, 0, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y010(this Vector3 a)
        {
            return new Vector4(a.y, 0, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y011(this Vector3 a)
        {
            return new Vector4(a.y, 0, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1xx(this Vector3 a)
        {
            return new Vector4(a.y, 1, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1xy(this Vector3 a)
        {
            return new Vector4(a.y, 1, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1xz(this Vector3 a)
        {
            return new Vector4(a.y, 1, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1x0(this Vector3 a)
        {
            return new Vector4(a.y, 1, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1x1(this Vector3 a)
        {
            return new Vector4(a.y, 1, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1yx(this Vector3 a)
        {
            return new Vector4(a.y, 1, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1yy(this Vector3 a)
        {
            return new Vector4(a.y, 1, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1yz(this Vector3 a)
        {
            return new Vector4(a.y, 1, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1y0(this Vector3 a)
        {
            return new Vector4(a.y, 1, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1y1(this Vector3 a)
        {
            return new Vector4(a.y, 1, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1zx(this Vector3 a)
        {
            return new Vector4(a.y, 1, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1zy(this Vector3 a)
        {
            return new Vector4(a.y, 1, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1zz(this Vector3 a)
        {
            return new Vector4(a.y, 1, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1z0(this Vector3 a)
        {
            return new Vector4(a.y, 1, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1z1(this Vector3 a)
        {
            return new Vector4(a.y, 1, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y10x(this Vector3 a)
        {
            return new Vector4(a.y, 1, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y10y(this Vector3 a)
        {
            return new Vector4(a.y, 1, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y10z(this Vector3 a)
        {
            return new Vector4(a.y, 1, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y100(this Vector3 a)
        {
            return new Vector4(a.y, 1, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y101(this Vector3 a)
        {
            return new Vector4(a.y, 1, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y11x(this Vector3 a)
        {
            return new Vector4(a.y, 1, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y11y(this Vector3 a)
        {
            return new Vector4(a.y, 1, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y11z(this Vector3 a)
        {
            return new Vector4(a.y, 1, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y110(this Vector3 a)
        {
            return new Vector4(a.y, 1, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y111(this Vector3 a)
        {
            return new Vector4(a.y, 1, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxxx(this Vector3 a)
        {
            return new Vector4(a.z, a.x, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxxy(this Vector3 a)
        {
            return new Vector4(a.z, a.x, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxxz(this Vector3 a)
        {
            return new Vector4(a.z, a.x, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxx0(this Vector3 a)
        {
            return new Vector4(a.z, a.x, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxx1(this Vector3 a)
        {
            return new Vector4(a.z, a.x, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxyx(this Vector3 a)
        {
            return new Vector4(a.z, a.x, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxyy(this Vector3 a)
        {
            return new Vector4(a.z, a.x, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxyz(this Vector3 a)
        {
            return new Vector4(a.z, a.x, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxy0(this Vector3 a)
        {
            return new Vector4(a.z, a.x, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxy1(this Vector3 a)
        {
            return new Vector4(a.z, a.x, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxzx(this Vector3 a)
        {
            return new Vector4(a.z, a.x, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxzy(this Vector3 a)
        {
            return new Vector4(a.z, a.x, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxzz(this Vector3 a)
        {
            return new Vector4(a.z, a.x, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxz0(this Vector3 a)
        {
            return new Vector4(a.z, a.x, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxz1(this Vector3 a)
        {
            return new Vector4(a.z, a.x, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zx0x(this Vector3 a)
        {
            return new Vector4(a.z, a.x, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zx0y(this Vector3 a)
        {
            return new Vector4(a.z, a.x, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zx0z(this Vector3 a)
        {
            return new Vector4(a.z, a.x, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zx00(this Vector3 a)
        {
            return new Vector4(a.z, a.x, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zx01(this Vector3 a)
        {
            return new Vector4(a.z, a.x, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zx1x(this Vector3 a)
        {
            return new Vector4(a.z, a.x, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zx1y(this Vector3 a)
        {
            return new Vector4(a.z, a.x, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zx1z(this Vector3 a)
        {
            return new Vector4(a.z, a.x, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zx10(this Vector3 a)
        {
            return new Vector4(a.z, a.x, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zx11(this Vector3 a)
        {
            return new Vector4(a.z, a.x, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyxx(this Vector3 a)
        {
            return new Vector4(a.z, a.y, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyxy(this Vector3 a)
        {
            return new Vector4(a.z, a.y, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyxz(this Vector3 a)
        {
            return new Vector4(a.z, a.y, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyx0(this Vector3 a)
        {
            return new Vector4(a.z, a.y, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyx1(this Vector3 a)
        {
            return new Vector4(a.z, a.y, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyyx(this Vector3 a)
        {
            return new Vector4(a.z, a.y, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyyy(this Vector3 a)
        {
            return new Vector4(a.z, a.y, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyyz(this Vector3 a)
        {
            return new Vector4(a.z, a.y, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyy0(this Vector3 a)
        {
            return new Vector4(a.z, a.y, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyy1(this Vector3 a)
        {
            return new Vector4(a.z, a.y, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyzx(this Vector3 a)
        {
            return new Vector4(a.z, a.y, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyzy(this Vector3 a)
        {
            return new Vector4(a.z, a.y, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyzz(this Vector3 a)
        {
            return new Vector4(a.z, a.y, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyz0(this Vector3 a)
        {
            return new Vector4(a.z, a.y, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyz1(this Vector3 a)
        {
            return new Vector4(a.z, a.y, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zy0x(this Vector3 a)
        {
            return new Vector4(a.z, a.y, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zy0y(this Vector3 a)
        {
            return new Vector4(a.z, a.y, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zy0z(this Vector3 a)
        {
            return new Vector4(a.z, a.y, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zy00(this Vector3 a)
        {
            return new Vector4(a.z, a.y, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zy01(this Vector3 a)
        {
            return new Vector4(a.z, a.y, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zy1x(this Vector3 a)
        {
            return new Vector4(a.z, a.y, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zy1y(this Vector3 a)
        {
            return new Vector4(a.z, a.y, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zy1z(this Vector3 a)
        {
            return new Vector4(a.z, a.y, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zy10(this Vector3 a)
        {
            return new Vector4(a.z, a.y, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zy11(this Vector3 a)
        {
            return new Vector4(a.z, a.y, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzxx(this Vector3 a)
        {
            return new Vector4(a.z, a.z, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzxy(this Vector3 a)
        {
            return new Vector4(a.z, a.z, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzxz(this Vector3 a)
        {
            return new Vector4(a.z, a.z, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzx0(this Vector3 a)
        {
            return new Vector4(a.z, a.z, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzx1(this Vector3 a)
        {
            return new Vector4(a.z, a.z, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzyx(this Vector3 a)
        {
            return new Vector4(a.z, a.z, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzyy(this Vector3 a)
        {
            return new Vector4(a.z, a.z, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzyz(this Vector3 a)
        {
            return new Vector4(a.z, a.z, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzy0(this Vector3 a)
        {
            return new Vector4(a.z, a.z, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzy1(this Vector3 a)
        {
            return new Vector4(a.z, a.z, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzzx(this Vector3 a)
        {
            return new Vector4(a.z, a.z, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzzy(this Vector3 a)
        {
            return new Vector4(a.z, a.z, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzzz(this Vector3 a)
        {
            return new Vector4(a.z, a.z, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzz0(this Vector3 a)
        {
            return new Vector4(a.z, a.z, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzz1(this Vector3 a)
        {
            return new Vector4(a.z, a.z, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zz0x(this Vector3 a)
        {
            return new Vector4(a.z, a.z, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zz0y(this Vector3 a)
        {
            return new Vector4(a.z, a.z, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zz0z(this Vector3 a)
        {
            return new Vector4(a.z, a.z, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zz00(this Vector3 a)
        {
            return new Vector4(a.z, a.z, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zz01(this Vector3 a)
        {
            return new Vector4(a.z, a.z, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zz1x(this Vector3 a)
        {
            return new Vector4(a.z, a.z, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zz1y(this Vector3 a)
        {
            return new Vector4(a.z, a.z, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zz1z(this Vector3 a)
        {
            return new Vector4(a.z, a.z, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zz10(this Vector3 a)
        {
            return new Vector4(a.z, a.z, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zz11(this Vector3 a)
        {
            return new Vector4(a.z, a.z, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0xx(this Vector3 a)
        {
            return new Vector4(a.z, 0, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0xy(this Vector3 a)
        {
            return new Vector4(a.z, 0, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0xz(this Vector3 a)
        {
            return new Vector4(a.z, 0, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0x0(this Vector3 a)
        {
            return new Vector4(a.z, 0, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0x1(this Vector3 a)
        {
            return new Vector4(a.z, 0, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0yx(this Vector3 a)
        {
            return new Vector4(a.z, 0, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0yy(this Vector3 a)
        {
            return new Vector4(a.z, 0, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0yz(this Vector3 a)
        {
            return new Vector4(a.z, 0, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0y0(this Vector3 a)
        {
            return new Vector4(a.z, 0, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0y1(this Vector3 a)
        {
            return new Vector4(a.z, 0, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0zx(this Vector3 a)
        {
            return new Vector4(a.z, 0, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0zy(this Vector3 a)
        {
            return new Vector4(a.z, 0, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0zz(this Vector3 a)
        {
            return new Vector4(a.z, 0, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0z0(this Vector3 a)
        {
            return new Vector4(a.z, 0, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0z1(this Vector3 a)
        {
            return new Vector4(a.z, 0, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z00x(this Vector3 a)
        {
            return new Vector4(a.z, 0, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z00y(this Vector3 a)
        {
            return new Vector4(a.z, 0, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z00z(this Vector3 a)
        {
            return new Vector4(a.z, 0, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z000(this Vector3 a)
        {
            return new Vector4(a.z, 0, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z001(this Vector3 a)
        {
            return new Vector4(a.z, 0, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z01x(this Vector3 a)
        {
            return new Vector4(a.z, 0, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z01y(this Vector3 a)
        {
            return new Vector4(a.z, 0, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z01z(this Vector3 a)
        {
            return new Vector4(a.z, 0, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z010(this Vector3 a)
        {
            return new Vector4(a.z, 0, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z011(this Vector3 a)
        {
            return new Vector4(a.z, 0, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1xx(this Vector3 a)
        {
            return new Vector4(a.z, 1, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1xy(this Vector3 a)
        {
            return new Vector4(a.z, 1, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1xz(this Vector3 a)
        {
            return new Vector4(a.z, 1, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1x0(this Vector3 a)
        {
            return new Vector4(a.z, 1, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1x1(this Vector3 a)
        {
            return new Vector4(a.z, 1, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1yx(this Vector3 a)
        {
            return new Vector4(a.z, 1, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1yy(this Vector3 a)
        {
            return new Vector4(a.z, 1, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1yz(this Vector3 a)
        {
            return new Vector4(a.z, 1, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1y0(this Vector3 a)
        {
            return new Vector4(a.z, 1, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1y1(this Vector3 a)
        {
            return new Vector4(a.z, 1, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1zx(this Vector3 a)
        {
            return new Vector4(a.z, 1, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1zy(this Vector3 a)
        {
            return new Vector4(a.z, 1, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1zz(this Vector3 a)
        {
            return new Vector4(a.z, 1, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1z0(this Vector3 a)
        {
            return new Vector4(a.z, 1, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1z1(this Vector3 a)
        {
            return new Vector4(a.z, 1, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z10x(this Vector3 a)
        {
            return new Vector4(a.z, 1, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z10y(this Vector3 a)
        {
            return new Vector4(a.z, 1, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z10z(this Vector3 a)
        {
            return new Vector4(a.z, 1, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z100(this Vector3 a)
        {
            return new Vector4(a.z, 1, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z101(this Vector3 a)
        {
            return new Vector4(a.z, 1, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z11x(this Vector3 a)
        {
            return new Vector4(a.z, 1, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z11y(this Vector3 a)
        {
            return new Vector4(a.z, 1, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z11z(this Vector3 a)
        {
            return new Vector4(a.z, 1, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z110(this Vector3 a)
        {
            return new Vector4(a.z, 1, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z111(this Vector3 a)
        {
            return new Vector4(a.z, 1, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xxx(this Vector3 a)
        {
            return new Vector4(0, a.x, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xxy(this Vector3 a)
        {
            return new Vector4(0, a.x, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xxz(this Vector3 a)
        {
            return new Vector4(0, a.x, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xx0(this Vector3 a)
        {
            return new Vector4(0, a.x, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xx1(this Vector3 a)
        {
            return new Vector4(0, a.x, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xyx(this Vector3 a)
        {
            return new Vector4(0, a.x, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xyy(this Vector3 a)
        {
            return new Vector4(0, a.x, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xyz(this Vector3 a)
        {
            return new Vector4(0, a.x, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xy0(this Vector3 a)
        {
            return new Vector4(0, a.x, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xy1(this Vector3 a)
        {
            return new Vector4(0, a.x, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xzx(this Vector3 a)
        {
            return new Vector4(0, a.x, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xzy(this Vector3 a)
        {
            return new Vector4(0, a.x, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xzz(this Vector3 a)
        {
            return new Vector4(0, a.x, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xz0(this Vector3 a)
        {
            return new Vector4(0, a.x, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xz1(this Vector3 a)
        {
            return new Vector4(0, a.x, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0x0x(this Vector3 a)
        {
            return new Vector4(0, a.x, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0x0y(this Vector3 a)
        {
            return new Vector4(0, a.x, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0x0z(this Vector3 a)
        {
            return new Vector4(0, a.x, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0x00(this Vector3 a)
        {
            return new Vector4(0, a.x, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0x01(this Vector3 a)
        {
            return new Vector4(0, a.x, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0x1x(this Vector3 a)
        {
            return new Vector4(0, a.x, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0x1y(this Vector3 a)
        {
            return new Vector4(0, a.x, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0x1z(this Vector3 a)
        {
            return new Vector4(0, a.x, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0x10(this Vector3 a)
        {
            return new Vector4(0, a.x, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0x11(this Vector3 a)
        {
            return new Vector4(0, a.x, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yxx(this Vector3 a)
        {
            return new Vector4(0, a.y, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yxy(this Vector3 a)
        {
            return new Vector4(0, a.y, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yxz(this Vector3 a)
        {
            return new Vector4(0, a.y, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yx0(this Vector3 a)
        {
            return new Vector4(0, a.y, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yx1(this Vector3 a)
        {
            return new Vector4(0, a.y, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yyx(this Vector3 a)
        {
            return new Vector4(0, a.y, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yyy(this Vector3 a)
        {
            return new Vector4(0, a.y, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yyz(this Vector3 a)
        {
            return new Vector4(0, a.y, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yy0(this Vector3 a)
        {
            return new Vector4(0, a.y, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yy1(this Vector3 a)
        {
            return new Vector4(0, a.y, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yzx(this Vector3 a)
        {
            return new Vector4(0, a.y, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yzy(this Vector3 a)
        {
            return new Vector4(0, a.y, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yzz(this Vector3 a)
        {
            return new Vector4(0, a.y, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yz0(this Vector3 a)
        {
            return new Vector4(0, a.y, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yz1(this Vector3 a)
        {
            return new Vector4(0, a.y, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0y0x(this Vector3 a)
        {
            return new Vector4(0, a.y, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0y0y(this Vector3 a)
        {
            return new Vector4(0, a.y, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0y0z(this Vector3 a)
        {
            return new Vector4(0, a.y, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0y00(this Vector3 a)
        {
            return new Vector4(0, a.y, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0y01(this Vector3 a)
        {
            return new Vector4(0, a.y, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0y1x(this Vector3 a)
        {
            return new Vector4(0, a.y, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0y1y(this Vector3 a)
        {
            return new Vector4(0, a.y, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0y1z(this Vector3 a)
        {
            return new Vector4(0, a.y, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0y10(this Vector3 a)
        {
            return new Vector4(0, a.y, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0y11(this Vector3 a)
        {
            return new Vector4(0, a.y, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zxx(this Vector3 a)
        {
            return new Vector4(0, a.z, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zxy(this Vector3 a)
        {
            return new Vector4(0, a.z, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zxz(this Vector3 a)
        {
            return new Vector4(0, a.z, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zx0(this Vector3 a)
        {
            return new Vector4(0, a.z, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zx1(this Vector3 a)
        {
            return new Vector4(0, a.z, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zyx(this Vector3 a)
        {
            return new Vector4(0, a.z, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zyy(this Vector3 a)
        {
            return new Vector4(0, a.z, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zyz(this Vector3 a)
        {
            return new Vector4(0, a.z, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zy0(this Vector3 a)
        {
            return new Vector4(0, a.z, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zy1(this Vector3 a)
        {
            return new Vector4(0, a.z, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zzx(this Vector3 a)
        {
            return new Vector4(0, a.z, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zzy(this Vector3 a)
        {
            return new Vector4(0, a.z, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zzz(this Vector3 a)
        {
            return new Vector4(0, a.z, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zz0(this Vector3 a)
        {
            return new Vector4(0, a.z, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zz1(this Vector3 a)
        {
            return new Vector4(0, a.z, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0z0x(this Vector3 a)
        {
            return new Vector4(0, a.z, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0z0y(this Vector3 a)
        {
            return new Vector4(0, a.z, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0z0z(this Vector3 a)
        {
            return new Vector4(0, a.z, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0z00(this Vector3 a)
        {
            return new Vector4(0, a.z, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0z01(this Vector3 a)
        {
            return new Vector4(0, a.z, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0z1x(this Vector3 a)
        {
            return new Vector4(0, a.z, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0z1y(this Vector3 a)
        {
            return new Vector4(0, a.z, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0z1z(this Vector3 a)
        {
            return new Vector4(0, a.z, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0z10(this Vector3 a)
        {
            return new Vector4(0, a.z, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0z11(this Vector3 a)
        {
            return new Vector4(0, a.z, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00xx(this Vector3 a)
        {
            return new Vector4(0, 0, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00xy(this Vector3 a)
        {
            return new Vector4(0, 0, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00xz(this Vector3 a)
        {
            return new Vector4(0, 0, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00x0(this Vector3 a)
        {
            return new Vector4(0, 0, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00x1(this Vector3 a)
        {
            return new Vector4(0, 0, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00yx(this Vector3 a)
        {
            return new Vector4(0, 0, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00yy(this Vector3 a)
        {
            return new Vector4(0, 0, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00yz(this Vector3 a)
        {
            return new Vector4(0, 0, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00y0(this Vector3 a)
        {
            return new Vector4(0, 0, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00y1(this Vector3 a)
        {
            return new Vector4(0, 0, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00zx(this Vector3 a)
        {
            return new Vector4(0, 0, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00zy(this Vector3 a)
        {
            return new Vector4(0, 0, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00zz(this Vector3 a)
        {
            return new Vector4(0, 0, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00z0(this Vector3 a)
        {
            return new Vector4(0, 0, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00z1(this Vector3 a)
        {
            return new Vector4(0, 0, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _000x(this Vector3 a)
        {
            return new Vector4(0, 0, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _000y(this Vector3 a)
        {
            return new Vector4(0, 0, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _000z(this Vector3 a)
        {
            return new Vector4(0, 0, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0000(this Vector3 a)
        {
            return new Vector4(0, 0, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0001(this Vector3 a)
        {
            return new Vector4(0, 0, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _001x(this Vector3 a)
        {
            return new Vector4(0, 0, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _001y(this Vector3 a)
        {
            return new Vector4(0, 0, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _001z(this Vector3 a)
        {
            return new Vector4(0, 0, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0010(this Vector3 a)
        {
            return new Vector4(0, 0, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0011(this Vector3 a)
        {
            return new Vector4(0, 0, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01xx(this Vector3 a)
        {
            return new Vector4(0, 1, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01xy(this Vector3 a)
        {
            return new Vector4(0, 1, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01xz(this Vector3 a)
        {
            return new Vector4(0, 1, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01x0(this Vector3 a)
        {
            return new Vector4(0, 1, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01x1(this Vector3 a)
        {
            return new Vector4(0, 1, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01yx(this Vector3 a)
        {
            return new Vector4(0, 1, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01yy(this Vector3 a)
        {
            return new Vector4(0, 1, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01yz(this Vector3 a)
        {
            return new Vector4(0, 1, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01y0(this Vector3 a)
        {
            return new Vector4(0, 1, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01y1(this Vector3 a)
        {
            return new Vector4(0, 1, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01zx(this Vector3 a)
        {
            return new Vector4(0, 1, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01zy(this Vector3 a)
        {
            return new Vector4(0, 1, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01zz(this Vector3 a)
        {
            return new Vector4(0, 1, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01z0(this Vector3 a)
        {
            return new Vector4(0, 1, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01z1(this Vector3 a)
        {
            return new Vector4(0, 1, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _010x(this Vector3 a)
        {
            return new Vector4(0, 1, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _010y(this Vector3 a)
        {
            return new Vector4(0, 1, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _010z(this Vector3 a)
        {
            return new Vector4(0, 1, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0100(this Vector3 a)
        {
            return new Vector4(0, 1, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0101(this Vector3 a)
        {
            return new Vector4(0, 1, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _011x(this Vector3 a)
        {
            return new Vector4(0, 1, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _011y(this Vector3 a)
        {
            return new Vector4(0, 1, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _011z(this Vector3 a)
        {
            return new Vector4(0, 1, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0110(this Vector3 a)
        {
            return new Vector4(0, 1, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0111(this Vector3 a)
        {
            return new Vector4(0, 1, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xxx(this Vector3 a)
        {
            return new Vector4(1, a.x, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xxy(this Vector3 a)
        {
            return new Vector4(1, a.x, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xxz(this Vector3 a)
        {
            return new Vector4(1, a.x, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xx0(this Vector3 a)
        {
            return new Vector4(1, a.x, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xx1(this Vector3 a)
        {
            return new Vector4(1, a.x, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xyx(this Vector3 a)
        {
            return new Vector4(1, a.x, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xyy(this Vector3 a)
        {
            return new Vector4(1, a.x, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xyz(this Vector3 a)
        {
            return new Vector4(1, a.x, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xy0(this Vector3 a)
        {
            return new Vector4(1, a.x, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xy1(this Vector3 a)
        {
            return new Vector4(1, a.x, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xzx(this Vector3 a)
        {
            return new Vector4(1, a.x, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xzy(this Vector3 a)
        {
            return new Vector4(1, a.x, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xzz(this Vector3 a)
        {
            return new Vector4(1, a.x, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xz0(this Vector3 a)
        {
            return new Vector4(1, a.x, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xz1(this Vector3 a)
        {
            return new Vector4(1, a.x, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1x0x(this Vector3 a)
        {
            return new Vector4(1, a.x, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1x0y(this Vector3 a)
        {
            return new Vector4(1, a.x, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1x0z(this Vector3 a)
        {
            return new Vector4(1, a.x, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1x00(this Vector3 a)
        {
            return new Vector4(1, a.x, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1x01(this Vector3 a)
        {
            return new Vector4(1, a.x, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1x1x(this Vector3 a)
        {
            return new Vector4(1, a.x, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1x1y(this Vector3 a)
        {
            return new Vector4(1, a.x, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1x1z(this Vector3 a)
        {
            return new Vector4(1, a.x, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1x10(this Vector3 a)
        {
            return new Vector4(1, a.x, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1x11(this Vector3 a)
        {
            return new Vector4(1, a.x, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yxx(this Vector3 a)
        {
            return new Vector4(1, a.y, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yxy(this Vector3 a)
        {
            return new Vector4(1, a.y, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yxz(this Vector3 a)
        {
            return new Vector4(1, a.y, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yx0(this Vector3 a)
        {
            return new Vector4(1, a.y, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yx1(this Vector3 a)
        {
            return new Vector4(1, a.y, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yyx(this Vector3 a)
        {
            return new Vector4(1, a.y, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yyy(this Vector3 a)
        {
            return new Vector4(1, a.y, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yyz(this Vector3 a)
        {
            return new Vector4(1, a.y, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yy0(this Vector3 a)
        {
            return new Vector4(1, a.y, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yy1(this Vector3 a)
        {
            return new Vector4(1, a.y, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yzx(this Vector3 a)
        {
            return new Vector4(1, a.y, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yzy(this Vector3 a)
        {
            return new Vector4(1, a.y, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yzz(this Vector3 a)
        {
            return new Vector4(1, a.y, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yz0(this Vector3 a)
        {
            return new Vector4(1, a.y, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yz1(this Vector3 a)
        {
            return new Vector4(1, a.y, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1y0x(this Vector3 a)
        {
            return new Vector4(1, a.y, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1y0y(this Vector3 a)
        {
            return new Vector4(1, a.y, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1y0z(this Vector3 a)
        {
            return new Vector4(1, a.y, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1y00(this Vector3 a)
        {
            return new Vector4(1, a.y, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1y01(this Vector3 a)
        {
            return new Vector4(1, a.y, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1y1x(this Vector3 a)
        {
            return new Vector4(1, a.y, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1y1y(this Vector3 a)
        {
            return new Vector4(1, a.y, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1y1z(this Vector3 a)
        {
            return new Vector4(1, a.y, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1y10(this Vector3 a)
        {
            return new Vector4(1, a.y, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1y11(this Vector3 a)
        {
            return new Vector4(1, a.y, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zxx(this Vector3 a)
        {
            return new Vector4(1, a.z, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zxy(this Vector3 a)
        {
            return new Vector4(1, a.z, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zxz(this Vector3 a)
        {
            return new Vector4(1, a.z, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zx0(this Vector3 a)
        {
            return new Vector4(1, a.z, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zx1(this Vector3 a)
        {
            return new Vector4(1, a.z, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zyx(this Vector3 a)
        {
            return new Vector4(1, a.z, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zyy(this Vector3 a)
        {
            return new Vector4(1, a.z, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zyz(this Vector3 a)
        {
            return new Vector4(1, a.z, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zy0(this Vector3 a)
        {
            return new Vector4(1, a.z, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zy1(this Vector3 a)
        {
            return new Vector4(1, a.z, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zzx(this Vector3 a)
        {
            return new Vector4(1, a.z, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zzy(this Vector3 a)
        {
            return new Vector4(1, a.z, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zzz(this Vector3 a)
        {
            return new Vector4(1, a.z, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zz0(this Vector3 a)
        {
            return new Vector4(1, a.z, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zz1(this Vector3 a)
        {
            return new Vector4(1, a.z, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1z0x(this Vector3 a)
        {
            return new Vector4(1, a.z, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1z0y(this Vector3 a)
        {
            return new Vector4(1, a.z, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1z0z(this Vector3 a)
        {
            return new Vector4(1, a.z, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1z00(this Vector3 a)
        {
            return new Vector4(1, a.z, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1z01(this Vector3 a)
        {
            return new Vector4(1, a.z, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1z1x(this Vector3 a)
        {
            return new Vector4(1, a.z, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1z1y(this Vector3 a)
        {
            return new Vector4(1, a.z, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1z1z(this Vector3 a)
        {
            return new Vector4(1, a.z, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1z10(this Vector3 a)
        {
            return new Vector4(1, a.z, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1z11(this Vector3 a)
        {
            return new Vector4(1, a.z, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10xx(this Vector3 a)
        {
            return new Vector4(1, 0, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10xy(this Vector3 a)
        {
            return new Vector4(1, 0, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10xz(this Vector3 a)
        {
            return new Vector4(1, 0, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10x0(this Vector3 a)
        {
            return new Vector4(1, 0, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10x1(this Vector3 a)
        {
            return new Vector4(1, 0, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10yx(this Vector3 a)
        {
            return new Vector4(1, 0, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10yy(this Vector3 a)
        {
            return new Vector4(1, 0, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10yz(this Vector3 a)
        {
            return new Vector4(1, 0, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10y0(this Vector3 a)
        {
            return new Vector4(1, 0, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10y1(this Vector3 a)
        {
            return new Vector4(1, 0, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10zx(this Vector3 a)
        {
            return new Vector4(1, 0, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10zy(this Vector3 a)
        {
            return new Vector4(1, 0, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10zz(this Vector3 a)
        {
            return new Vector4(1, 0, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10z0(this Vector3 a)
        {
            return new Vector4(1, 0, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10z1(this Vector3 a)
        {
            return new Vector4(1, 0, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _100x(this Vector3 a)
        {
            return new Vector4(1, 0, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _100y(this Vector3 a)
        {
            return new Vector4(1, 0, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _100z(this Vector3 a)
        {
            return new Vector4(1, 0, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1000(this Vector3 a)
        {
            return new Vector4(1, 0, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1001(this Vector3 a)
        {
            return new Vector4(1, 0, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _101x(this Vector3 a)
        {
            return new Vector4(1, 0, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _101y(this Vector3 a)
        {
            return new Vector4(1, 0, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _101z(this Vector3 a)
        {
            return new Vector4(1, 0, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1010(this Vector3 a)
        {
            return new Vector4(1, 0, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1011(this Vector3 a)
        {
            return new Vector4(1, 0, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11xx(this Vector3 a)
        {
            return new Vector4(1, 1, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11xy(this Vector3 a)
        {
            return new Vector4(1, 1, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11xz(this Vector3 a)
        {
            return new Vector4(1, 1, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11x0(this Vector3 a)
        {
            return new Vector4(1, 1, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11x1(this Vector3 a)
        {
            return new Vector4(1, 1, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11yx(this Vector3 a)
        {
            return new Vector4(1, 1, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11yy(this Vector3 a)
        {
            return new Vector4(1, 1, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11yz(this Vector3 a)
        {
            return new Vector4(1, 1, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11y0(this Vector3 a)
        {
            return new Vector4(1, 1, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11y1(this Vector3 a)
        {
            return new Vector4(1, 1, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11zx(this Vector3 a)
        {
            return new Vector4(1, 1, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11zy(this Vector3 a)
        {
            return new Vector4(1, 1, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11zz(this Vector3 a)
        {
            return new Vector4(1, 1, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11z0(this Vector3 a)
        {
            return new Vector4(1, 1, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11z1(this Vector3 a)
        {
            return new Vector4(1, 1, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _110x(this Vector3 a)
        {
            return new Vector4(1, 1, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _110y(this Vector3 a)
        {
            return new Vector4(1, 1, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _110z(this Vector3 a)
        {
            return new Vector4(1, 1, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1100(this Vector3 a)
        {
            return new Vector4(1, 1, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1101(this Vector3 a)
        {
            return new Vector4(1, 1, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _111x(this Vector3 a)
        {
            return new Vector4(1, 1, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _111y(this Vector3 a)
        {
            return new Vector4(1, 1, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _111z(this Vector3 a)
        {
            return new Vector4(1, 1, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1110(this Vector3 a)
        {
            return new Vector4(1, 1, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1111(this Vector3 a)
        {
            return new Vector4(1, 1, 1, 1);
        }

        // swizzle of size 2
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _xx(this Vector4 a)
        {
            return new Vector2(a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _xy(this Vector4 a)
        {
            return new Vector2(a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _xz(this Vector4 a)
        {
            return new Vector2(a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _xw(this Vector4 a)
        {
            return new Vector2(a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _x0(this Vector4 a)
        {
            return new Vector2(a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _x1(this Vector4 a)
        {
            return new Vector2(a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _yx(this Vector4 a)
        {
            return new Vector2(a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _yy(this Vector4 a)
        {
            return new Vector2(a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _yz(this Vector4 a)
        {
            return new Vector2(a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _yw(this Vector4 a)
        {
            return new Vector2(a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _y0(this Vector4 a)
        {
            return new Vector2(a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _y1(this Vector4 a)
        {
            return new Vector2(a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _zx(this Vector4 a)
        {
            return new Vector2(a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _zy(this Vector4 a)
        {
            return new Vector2(a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _zz(this Vector4 a)
        {
            return new Vector2(a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _zw(this Vector4 a)
        {
            return new Vector2(a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _z0(this Vector4 a)
        {
            return new Vector2(a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _z1(this Vector4 a)
        {
            return new Vector2(a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _wx(this Vector4 a)
        {
            return new Vector2(a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _wy(this Vector4 a)
        {
            return new Vector2(a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _wz(this Vector4 a)
        {
            return new Vector2(a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _ww(this Vector4 a)
        {
            return new Vector2(a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _w0(this Vector4 a)
        {
            return new Vector2(a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _w1(this Vector4 a)
        {
            return new Vector2(a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _0x(this Vector4 a)
        {
            return new Vector2(0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _0y(this Vector4 a)
        {
            return new Vector2(0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _0z(this Vector4 a)
        {
            return new Vector2(0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _0w(this Vector4 a)
        {
            return new Vector2(0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _00(this Vector4 a)
        {
            return new Vector2(0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _01(this Vector4 a)
        {
            return new Vector2(0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _1x(this Vector4 a)
        {
            return new Vector2(1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _1y(this Vector4 a)
        {
            return new Vector2(1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _1z(this Vector4 a)
        {
            return new Vector2(1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _1w(this Vector4 a)
        {
            return new Vector2(1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _10(this Vector4 a)
        {
            return new Vector2(1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 _11(this Vector4 a)
        {
            return new Vector2(1, 1);
        }

        // swizzle of size 3
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xxx(this Vector4 a)
        {
            return new Vector3(a.x, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xxy(this Vector4 a)
        {
            return new Vector3(a.x, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xxz(this Vector4 a)
        {
            return new Vector3(a.x, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xxw(this Vector4 a)
        {
            return new Vector3(a.x, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xx0(this Vector4 a)
        {
            return new Vector3(a.x, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xx1(this Vector4 a)
        {
            return new Vector3(a.x, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xyx(this Vector4 a)
        {
            return new Vector3(a.x, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xyy(this Vector4 a)
        {
            return new Vector3(a.x, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xyz(this Vector4 a)
        {
            return new Vector3(a.x, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xyw(this Vector4 a)
        {
            return new Vector3(a.x, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xy0(this Vector4 a)
        {
            return new Vector3(a.x, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xy1(this Vector4 a)
        {
            return new Vector3(a.x, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xzx(this Vector4 a)
        {
            return new Vector3(a.x, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xzy(this Vector4 a)
        {
            return new Vector3(a.x, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xzz(this Vector4 a)
        {
            return new Vector3(a.x, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xzw(this Vector4 a)
        {
            return new Vector3(a.x, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xz0(this Vector4 a)
        {
            return new Vector3(a.x, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xz1(this Vector4 a)
        {
            return new Vector3(a.x, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xwx(this Vector4 a)
        {
            return new Vector3(a.x, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xwy(this Vector4 a)
        {
            return new Vector3(a.x, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xwz(this Vector4 a)
        {
            return new Vector3(a.x, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xww(this Vector4 a)
        {
            return new Vector3(a.x, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xw0(this Vector4 a)
        {
            return new Vector3(a.x, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _xw1(this Vector4 a)
        {
            return new Vector3(a.x, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _x0x(this Vector4 a)
        {
            return new Vector3(a.x, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _x0y(this Vector4 a)
        {
            return new Vector3(a.x, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _x0z(this Vector4 a)
        {
            return new Vector3(a.x, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _x0w(this Vector4 a)
        {
            return new Vector3(a.x, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _x00(this Vector4 a)
        {
            return new Vector3(a.x, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _x01(this Vector4 a)
        {
            return new Vector3(a.x, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _x1x(this Vector4 a)
        {
            return new Vector3(a.x, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _x1y(this Vector4 a)
        {
            return new Vector3(a.x, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _x1z(this Vector4 a)
        {
            return new Vector3(a.x, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _x1w(this Vector4 a)
        {
            return new Vector3(a.x, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _x10(this Vector4 a)
        {
            return new Vector3(a.x, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _x11(this Vector4 a)
        {
            return new Vector3(a.x, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yxx(this Vector4 a)
        {
            return new Vector3(a.y, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yxy(this Vector4 a)
        {
            return new Vector3(a.y, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yxz(this Vector4 a)
        {
            return new Vector3(a.y, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yxw(this Vector4 a)
        {
            return new Vector3(a.y, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yx0(this Vector4 a)
        {
            return new Vector3(a.y, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yx1(this Vector4 a)
        {
            return new Vector3(a.y, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yyx(this Vector4 a)
        {
            return new Vector3(a.y, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yyy(this Vector4 a)
        {
            return new Vector3(a.y, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yyz(this Vector4 a)
        {
            return new Vector3(a.y, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yyw(this Vector4 a)
        {
            return new Vector3(a.y, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yy0(this Vector4 a)
        {
            return new Vector3(a.y, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yy1(this Vector4 a)
        {
            return new Vector3(a.y, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yzx(this Vector4 a)
        {
            return new Vector3(a.y, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yzy(this Vector4 a)
        {
            return new Vector3(a.y, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yzz(this Vector4 a)
        {
            return new Vector3(a.y, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yzw(this Vector4 a)
        {
            return new Vector3(a.y, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yz0(this Vector4 a)
        {
            return new Vector3(a.y, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yz1(this Vector4 a)
        {
            return new Vector3(a.y, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _ywx(this Vector4 a)
        {
            return new Vector3(a.y, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _ywy(this Vector4 a)
        {
            return new Vector3(a.y, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _ywz(this Vector4 a)
        {
            return new Vector3(a.y, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yww(this Vector4 a)
        {
            return new Vector3(a.y, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yw0(this Vector4 a)
        {
            return new Vector3(a.y, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _yw1(this Vector4 a)
        {
            return new Vector3(a.y, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _y0x(this Vector4 a)
        {
            return new Vector3(a.y, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _y0y(this Vector4 a)
        {
            return new Vector3(a.y, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _y0z(this Vector4 a)
        {
            return new Vector3(a.y, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _y0w(this Vector4 a)
        {
            return new Vector3(a.y, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _y00(this Vector4 a)
        {
            return new Vector3(a.y, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _y01(this Vector4 a)
        {
            return new Vector3(a.y, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _y1x(this Vector4 a)
        {
            return new Vector3(a.y, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _y1y(this Vector4 a)
        {
            return new Vector3(a.y, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _y1z(this Vector4 a)
        {
            return new Vector3(a.y, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _y1w(this Vector4 a)
        {
            return new Vector3(a.y, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _y10(this Vector4 a)
        {
            return new Vector3(a.y, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _y11(this Vector4 a)
        {
            return new Vector3(a.y, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zxx(this Vector4 a)
        {
            return new Vector3(a.z, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zxy(this Vector4 a)
        {
            return new Vector3(a.z, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zxz(this Vector4 a)
        {
            return new Vector3(a.z, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zxw(this Vector4 a)
        {
            return new Vector3(a.z, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zx0(this Vector4 a)
        {
            return new Vector3(a.z, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zx1(this Vector4 a)
        {
            return new Vector3(a.z, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zyx(this Vector4 a)
        {
            return new Vector3(a.z, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zyy(this Vector4 a)
        {
            return new Vector3(a.z, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zyz(this Vector4 a)
        {
            return new Vector3(a.z, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zyw(this Vector4 a)
        {
            return new Vector3(a.z, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zy0(this Vector4 a)
        {
            return new Vector3(a.z, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zy1(this Vector4 a)
        {
            return new Vector3(a.z, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zzx(this Vector4 a)
        {
            return new Vector3(a.z, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zzy(this Vector4 a)
        {
            return new Vector3(a.z, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zzz(this Vector4 a)
        {
            return new Vector3(a.z, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zzw(this Vector4 a)
        {
            return new Vector3(a.z, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zz0(this Vector4 a)
        {
            return new Vector3(a.z, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zz1(this Vector4 a)
        {
            return new Vector3(a.z, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zwx(this Vector4 a)
        {
            return new Vector3(a.z, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zwy(this Vector4 a)
        {
            return new Vector3(a.z, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zwz(this Vector4 a)
        {
            return new Vector3(a.z, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zww(this Vector4 a)
        {
            return new Vector3(a.z, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zw0(this Vector4 a)
        {
            return new Vector3(a.z, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _zw1(this Vector4 a)
        {
            return new Vector3(a.z, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _z0x(this Vector4 a)
        {
            return new Vector3(a.z, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _z0y(this Vector4 a)
        {
            return new Vector3(a.z, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _z0z(this Vector4 a)
        {
            return new Vector3(a.z, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _z0w(this Vector4 a)
        {
            return new Vector3(a.z, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _z00(this Vector4 a)
        {
            return new Vector3(a.z, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _z01(this Vector4 a)
        {
            return new Vector3(a.z, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _z1x(this Vector4 a)
        {
            return new Vector3(a.z, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _z1y(this Vector4 a)
        {
            return new Vector3(a.z, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _z1z(this Vector4 a)
        {
            return new Vector3(a.z, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _z1w(this Vector4 a)
        {
            return new Vector3(a.z, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _z10(this Vector4 a)
        {
            return new Vector3(a.z, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _z11(this Vector4 a)
        {
            return new Vector3(a.z, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _wxx(this Vector4 a)
        {
            return new Vector3(a.w, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _wxy(this Vector4 a)
        {
            return new Vector3(a.w, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _wxz(this Vector4 a)
        {
            return new Vector3(a.w, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _wxw(this Vector4 a)
        {
            return new Vector3(a.w, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _wx0(this Vector4 a)
        {
            return new Vector3(a.w, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _wx1(this Vector4 a)
        {
            return new Vector3(a.w, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _wyx(this Vector4 a)
        {
            return new Vector3(a.w, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _wyy(this Vector4 a)
        {
            return new Vector3(a.w, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _wyz(this Vector4 a)
        {
            return new Vector3(a.w, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _wyw(this Vector4 a)
        {
            return new Vector3(a.w, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _wy0(this Vector4 a)
        {
            return new Vector3(a.w, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _wy1(this Vector4 a)
        {
            return new Vector3(a.w, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _wzx(this Vector4 a)
        {
            return new Vector3(a.w, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _wzy(this Vector4 a)
        {
            return new Vector3(a.w, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _wzz(this Vector4 a)
        {
            return new Vector3(a.w, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _wzw(this Vector4 a)
        {
            return new Vector3(a.w, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _wz0(this Vector4 a)
        {
            return new Vector3(a.w, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _wz1(this Vector4 a)
        {
            return new Vector3(a.w, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _wwx(this Vector4 a)
        {
            return new Vector3(a.w, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _wwy(this Vector4 a)
        {
            return new Vector3(a.w, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _wwz(this Vector4 a)
        {
            return new Vector3(a.w, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _www(this Vector4 a)
        {
            return new Vector3(a.w, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _ww0(this Vector4 a)
        {
            return new Vector3(a.w, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _ww1(this Vector4 a)
        {
            return new Vector3(a.w, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _w0x(this Vector4 a)
        {
            return new Vector3(a.w, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _w0y(this Vector4 a)
        {
            return new Vector3(a.w, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _w0z(this Vector4 a)
        {
            return new Vector3(a.w, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _w0w(this Vector4 a)
        {
            return new Vector3(a.w, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _w00(this Vector4 a)
        {
            return new Vector3(a.w, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _w01(this Vector4 a)
        {
            return new Vector3(a.w, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _w1x(this Vector4 a)
        {
            return new Vector3(a.w, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _w1y(this Vector4 a)
        {
            return new Vector3(a.w, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _w1z(this Vector4 a)
        {
            return new Vector3(a.w, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _w1w(this Vector4 a)
        {
            return new Vector3(a.w, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _w10(this Vector4 a)
        {
            return new Vector3(a.w, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _w11(this Vector4 a)
        {
            return new Vector3(a.w, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0xx(this Vector4 a)
        {
            return new Vector3(0, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0xy(this Vector4 a)
        {
            return new Vector3(0, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0xz(this Vector4 a)
        {
            return new Vector3(0, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0xw(this Vector4 a)
        {
            return new Vector3(0, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0x0(this Vector4 a)
        {
            return new Vector3(0, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0x1(this Vector4 a)
        {
            return new Vector3(0, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0yx(this Vector4 a)
        {
            return new Vector3(0, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0yy(this Vector4 a)
        {
            return new Vector3(0, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0yz(this Vector4 a)
        {
            return new Vector3(0, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0yw(this Vector4 a)
        {
            return new Vector3(0, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0y0(this Vector4 a)
        {
            return new Vector3(0, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0y1(this Vector4 a)
        {
            return new Vector3(0, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0zx(this Vector4 a)
        {
            return new Vector3(0, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0zy(this Vector4 a)
        {
            return new Vector3(0, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0zz(this Vector4 a)
        {
            return new Vector3(0, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0zw(this Vector4 a)
        {
            return new Vector3(0, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0z0(this Vector4 a)
        {
            return new Vector3(0, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0z1(this Vector4 a)
        {
            return new Vector3(0, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0wx(this Vector4 a)
        {
            return new Vector3(0, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0wy(this Vector4 a)
        {
            return new Vector3(0, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0wz(this Vector4 a)
        {
            return new Vector3(0, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0ww(this Vector4 a)
        {
            return new Vector3(0, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0w0(this Vector4 a)
        {
            return new Vector3(0, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _0w1(this Vector4 a)
        {
            return new Vector3(0, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _00x(this Vector4 a)
        {
            return new Vector3(0, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _00y(this Vector4 a)
        {
            return new Vector3(0, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _00z(this Vector4 a)
        {
            return new Vector3(0, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _00w(this Vector4 a)
        {
            return new Vector3(0, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _000(this Vector4 a)
        {
            return new Vector3(0, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _001(this Vector4 a)
        {
            return new Vector3(0, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _01x(this Vector4 a)
        {
            return new Vector3(0, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _01y(this Vector4 a)
        {
            return new Vector3(0, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _01z(this Vector4 a)
        {
            return new Vector3(0, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _01w(this Vector4 a)
        {
            return new Vector3(0, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _010(this Vector4 a)
        {
            return new Vector3(0, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _011(this Vector4 a)
        {
            return new Vector3(0, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1xx(this Vector4 a)
        {
            return new Vector3(1, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1xy(this Vector4 a)
        {
            return new Vector3(1, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1xz(this Vector4 a)
        {
            return new Vector3(1, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1xw(this Vector4 a)
        {
            return new Vector3(1, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1x0(this Vector4 a)
        {
            return new Vector3(1, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1x1(this Vector4 a)
        {
            return new Vector3(1, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1yx(this Vector4 a)
        {
            return new Vector3(1, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1yy(this Vector4 a)
        {
            return new Vector3(1, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1yz(this Vector4 a)
        {
            return new Vector3(1, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1yw(this Vector4 a)
        {
            return new Vector3(1, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1y0(this Vector4 a)
        {
            return new Vector3(1, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1y1(this Vector4 a)
        {
            return new Vector3(1, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1zx(this Vector4 a)
        {
            return new Vector3(1, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1zy(this Vector4 a)
        {
            return new Vector3(1, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1zz(this Vector4 a)
        {
            return new Vector3(1, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1zw(this Vector4 a)
        {
            return new Vector3(1, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1z0(this Vector4 a)
        {
            return new Vector3(1, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1z1(this Vector4 a)
        {
            return new Vector3(1, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1wx(this Vector4 a)
        {
            return new Vector3(1, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1wy(this Vector4 a)
        {
            return new Vector3(1, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1wz(this Vector4 a)
        {
            return new Vector3(1, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1ww(this Vector4 a)
        {
            return new Vector3(1, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1w0(this Vector4 a)
        {
            return new Vector3(1, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _1w1(this Vector4 a)
        {
            return new Vector3(1, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _10x(this Vector4 a)
        {
            return new Vector3(1, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _10y(this Vector4 a)
        {
            return new Vector3(1, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _10z(this Vector4 a)
        {
            return new Vector3(1, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _10w(this Vector4 a)
        {
            return new Vector3(1, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _100(this Vector4 a)
        {
            return new Vector3(1, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _101(this Vector4 a)
        {
            return new Vector3(1, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _11x(this Vector4 a)
        {
            return new Vector3(1, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _11y(this Vector4 a)
        {
            return new Vector3(1, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _11z(this Vector4 a)
        {
            return new Vector3(1, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _11w(this Vector4 a)
        {
            return new Vector3(1, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _110(this Vector4 a)
        {
            return new Vector3(1, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 _111(this Vector4 a)
        {
            return new Vector3(1, 1, 1);
        }

        // swizzle of size 4
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxxx(this Vector4 a)
        {
            return new Vector4(a.x, a.x, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxxy(this Vector4 a)
        {
            return new Vector4(a.x, a.x, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxxz(this Vector4 a)
        {
            return new Vector4(a.x, a.x, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxxw(this Vector4 a)
        {
            return new Vector4(a.x, a.x, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxx0(this Vector4 a)
        {
            return new Vector4(a.x, a.x, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxx1(this Vector4 a)
        {
            return new Vector4(a.x, a.x, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxyx(this Vector4 a)
        {
            return new Vector4(a.x, a.x, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxyy(this Vector4 a)
        {
            return new Vector4(a.x, a.x, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxyz(this Vector4 a)
        {
            return new Vector4(a.x, a.x, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxyw(this Vector4 a)
        {
            return new Vector4(a.x, a.x, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxy0(this Vector4 a)
        {
            return new Vector4(a.x, a.x, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxy1(this Vector4 a)
        {
            return new Vector4(a.x, a.x, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxzx(this Vector4 a)
        {
            return new Vector4(a.x, a.x, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxzy(this Vector4 a)
        {
            return new Vector4(a.x, a.x, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxzz(this Vector4 a)
        {
            return new Vector4(a.x, a.x, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxzw(this Vector4 a)
        {
            return new Vector4(a.x, a.x, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxz0(this Vector4 a)
        {
            return new Vector4(a.x, a.x, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxz1(this Vector4 a)
        {
            return new Vector4(a.x, a.x, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxwx(this Vector4 a)
        {
            return new Vector4(a.x, a.x, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxwy(this Vector4 a)
        {
            return new Vector4(a.x, a.x, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxwz(this Vector4 a)
        {
            return new Vector4(a.x, a.x, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxww(this Vector4 a)
        {
            return new Vector4(a.x, a.x, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxw0(this Vector4 a)
        {
            return new Vector4(a.x, a.x, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xxw1(this Vector4 a)
        {
            return new Vector4(a.x, a.x, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xx0x(this Vector4 a)
        {
            return new Vector4(a.x, a.x, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xx0y(this Vector4 a)
        {
            return new Vector4(a.x, a.x, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xx0z(this Vector4 a)
        {
            return new Vector4(a.x, a.x, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xx0w(this Vector4 a)
        {
            return new Vector4(a.x, a.x, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xx00(this Vector4 a)
        {
            return new Vector4(a.x, a.x, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xx01(this Vector4 a)
        {
            return new Vector4(a.x, a.x, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xx1x(this Vector4 a)
        {
            return new Vector4(a.x, a.x, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xx1y(this Vector4 a)
        {
            return new Vector4(a.x, a.x, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xx1z(this Vector4 a)
        {
            return new Vector4(a.x, a.x, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xx1w(this Vector4 a)
        {
            return new Vector4(a.x, a.x, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xx10(this Vector4 a)
        {
            return new Vector4(a.x, a.x, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xx11(this Vector4 a)
        {
            return new Vector4(a.x, a.x, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyxx(this Vector4 a)
        {
            return new Vector4(a.x, a.y, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyxy(this Vector4 a)
        {
            return new Vector4(a.x, a.y, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyxz(this Vector4 a)
        {
            return new Vector4(a.x, a.y, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyxw(this Vector4 a)
        {
            return new Vector4(a.x, a.y, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyx0(this Vector4 a)
        {
            return new Vector4(a.x, a.y, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyx1(this Vector4 a)
        {
            return new Vector4(a.x, a.y, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyyx(this Vector4 a)
        {
            return new Vector4(a.x, a.y, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyyy(this Vector4 a)
        {
            return new Vector4(a.x, a.y, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyyz(this Vector4 a)
        {
            return new Vector4(a.x, a.y, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyyw(this Vector4 a)
        {
            return new Vector4(a.x, a.y, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyy0(this Vector4 a)
        {
            return new Vector4(a.x, a.y, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyy1(this Vector4 a)
        {
            return new Vector4(a.x, a.y, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyzx(this Vector4 a)
        {
            return new Vector4(a.x, a.y, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyzy(this Vector4 a)
        {
            return new Vector4(a.x, a.y, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyzz(this Vector4 a)
        {
            return new Vector4(a.x, a.y, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyzw(this Vector4 a)
        {
            return new Vector4(a.x, a.y, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyz0(this Vector4 a)
        {
            return new Vector4(a.x, a.y, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyz1(this Vector4 a)
        {
            return new Vector4(a.x, a.y, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xywx(this Vector4 a)
        {
            return new Vector4(a.x, a.y, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xywy(this Vector4 a)
        {
            return new Vector4(a.x, a.y, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xywz(this Vector4 a)
        {
            return new Vector4(a.x, a.y, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyww(this Vector4 a)
        {
            return new Vector4(a.x, a.y, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyw0(this Vector4 a)
        {
            return new Vector4(a.x, a.y, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xyw1(this Vector4 a)
        {
            return new Vector4(a.x, a.y, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xy0x(this Vector4 a)
        {
            return new Vector4(a.x, a.y, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xy0y(this Vector4 a)
        {
            return new Vector4(a.x, a.y, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xy0z(this Vector4 a)
        {
            return new Vector4(a.x, a.y, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xy0w(this Vector4 a)
        {
            return new Vector4(a.x, a.y, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xy00(this Vector4 a)
        {
            return new Vector4(a.x, a.y, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xy01(this Vector4 a)
        {
            return new Vector4(a.x, a.y, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xy1x(this Vector4 a)
        {
            return new Vector4(a.x, a.y, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xy1y(this Vector4 a)
        {
            return new Vector4(a.x, a.y, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xy1z(this Vector4 a)
        {
            return new Vector4(a.x, a.y, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xy1w(this Vector4 a)
        {
            return new Vector4(a.x, a.y, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xy10(this Vector4 a)
        {
            return new Vector4(a.x, a.y, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xy11(this Vector4 a)
        {
            return new Vector4(a.x, a.y, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzxx(this Vector4 a)
        {
            return new Vector4(a.x, a.z, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzxy(this Vector4 a)
        {
            return new Vector4(a.x, a.z, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzxz(this Vector4 a)
        {
            return new Vector4(a.x, a.z, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzxw(this Vector4 a)
        {
            return new Vector4(a.x, a.z, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzx0(this Vector4 a)
        {
            return new Vector4(a.x, a.z, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzx1(this Vector4 a)
        {
            return new Vector4(a.x, a.z, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzyx(this Vector4 a)
        {
            return new Vector4(a.x, a.z, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzyy(this Vector4 a)
        {
            return new Vector4(a.x, a.z, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzyz(this Vector4 a)
        {
            return new Vector4(a.x, a.z, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzyw(this Vector4 a)
        {
            return new Vector4(a.x, a.z, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzy0(this Vector4 a)
        {
            return new Vector4(a.x, a.z, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzy1(this Vector4 a)
        {
            return new Vector4(a.x, a.z, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzzx(this Vector4 a)
        {
            return new Vector4(a.x, a.z, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzzy(this Vector4 a)
        {
            return new Vector4(a.x, a.z, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzzz(this Vector4 a)
        {
            return new Vector4(a.x, a.z, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzzw(this Vector4 a)
        {
            return new Vector4(a.x, a.z, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzz0(this Vector4 a)
        {
            return new Vector4(a.x, a.z, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzz1(this Vector4 a)
        {
            return new Vector4(a.x, a.z, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzwx(this Vector4 a)
        {
            return new Vector4(a.x, a.z, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzwy(this Vector4 a)
        {
            return new Vector4(a.x, a.z, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzwz(this Vector4 a)
        {
            return new Vector4(a.x, a.z, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzww(this Vector4 a)
        {
            return new Vector4(a.x, a.z, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzw0(this Vector4 a)
        {
            return new Vector4(a.x, a.z, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xzw1(this Vector4 a)
        {
            return new Vector4(a.x, a.z, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xz0x(this Vector4 a)
        {
            return new Vector4(a.x, a.z, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xz0y(this Vector4 a)
        {
            return new Vector4(a.x, a.z, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xz0z(this Vector4 a)
        {
            return new Vector4(a.x, a.z, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xz0w(this Vector4 a)
        {
            return new Vector4(a.x, a.z, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xz00(this Vector4 a)
        {
            return new Vector4(a.x, a.z, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xz01(this Vector4 a)
        {
            return new Vector4(a.x, a.z, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xz1x(this Vector4 a)
        {
            return new Vector4(a.x, a.z, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xz1y(this Vector4 a)
        {
            return new Vector4(a.x, a.z, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xz1z(this Vector4 a)
        {
            return new Vector4(a.x, a.z, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xz1w(this Vector4 a)
        {
            return new Vector4(a.x, a.z, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xz10(this Vector4 a)
        {
            return new Vector4(a.x, a.z, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xz11(this Vector4 a)
        {
            return new Vector4(a.x, a.z, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xwxx(this Vector4 a)
        {
            return new Vector4(a.x, a.w, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xwxy(this Vector4 a)
        {
            return new Vector4(a.x, a.w, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xwxz(this Vector4 a)
        {
            return new Vector4(a.x, a.w, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xwxw(this Vector4 a)
        {
            return new Vector4(a.x, a.w, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xwx0(this Vector4 a)
        {
            return new Vector4(a.x, a.w, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xwx1(this Vector4 a)
        {
            return new Vector4(a.x, a.w, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xwyx(this Vector4 a)
        {
            return new Vector4(a.x, a.w, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xwyy(this Vector4 a)
        {
            return new Vector4(a.x, a.w, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xwyz(this Vector4 a)
        {
            return new Vector4(a.x, a.w, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xwyw(this Vector4 a)
        {
            return new Vector4(a.x, a.w, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xwy0(this Vector4 a)
        {
            return new Vector4(a.x, a.w, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xwy1(this Vector4 a)
        {
            return new Vector4(a.x, a.w, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xwzx(this Vector4 a)
        {
            return new Vector4(a.x, a.w, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xwzy(this Vector4 a)
        {
            return new Vector4(a.x, a.w, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xwzz(this Vector4 a)
        {
            return new Vector4(a.x, a.w, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xwzw(this Vector4 a)
        {
            return new Vector4(a.x, a.w, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xwz0(this Vector4 a)
        {
            return new Vector4(a.x, a.w, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xwz1(this Vector4 a)
        {
            return new Vector4(a.x, a.w, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xwwx(this Vector4 a)
        {
            return new Vector4(a.x, a.w, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xwwy(this Vector4 a)
        {
            return new Vector4(a.x, a.w, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xwwz(this Vector4 a)
        {
            return new Vector4(a.x, a.w, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xwww(this Vector4 a)
        {
            return new Vector4(a.x, a.w, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xww0(this Vector4 a)
        {
            return new Vector4(a.x, a.w, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xww1(this Vector4 a)
        {
            return new Vector4(a.x, a.w, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xw0x(this Vector4 a)
        {
            return new Vector4(a.x, a.w, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xw0y(this Vector4 a)
        {
            return new Vector4(a.x, a.w, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xw0z(this Vector4 a)
        {
            return new Vector4(a.x, a.w, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xw0w(this Vector4 a)
        {
            return new Vector4(a.x, a.w, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xw00(this Vector4 a)
        {
            return new Vector4(a.x, a.w, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xw01(this Vector4 a)
        {
            return new Vector4(a.x, a.w, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xw1x(this Vector4 a)
        {
            return new Vector4(a.x, a.w, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xw1y(this Vector4 a)
        {
            return new Vector4(a.x, a.w, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xw1z(this Vector4 a)
        {
            return new Vector4(a.x, a.w, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xw1w(this Vector4 a)
        {
            return new Vector4(a.x, a.w, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xw10(this Vector4 a)
        {
            return new Vector4(a.x, a.w, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _xw11(this Vector4 a)
        {
            return new Vector4(a.x, a.w, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0xx(this Vector4 a)
        {
            return new Vector4(a.x, 0, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0xy(this Vector4 a)
        {
            return new Vector4(a.x, 0, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0xz(this Vector4 a)
        {
            return new Vector4(a.x, 0, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0xw(this Vector4 a)
        {
            return new Vector4(a.x, 0, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0x0(this Vector4 a)
        {
            return new Vector4(a.x, 0, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0x1(this Vector4 a)
        {
            return new Vector4(a.x, 0, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0yx(this Vector4 a)
        {
            return new Vector4(a.x, 0, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0yy(this Vector4 a)
        {
            return new Vector4(a.x, 0, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0yz(this Vector4 a)
        {
            return new Vector4(a.x, 0, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0yw(this Vector4 a)
        {
            return new Vector4(a.x, 0, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0y0(this Vector4 a)
        {
            return new Vector4(a.x, 0, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0y1(this Vector4 a)
        {
            return new Vector4(a.x, 0, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0zx(this Vector4 a)
        {
            return new Vector4(a.x, 0, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0zy(this Vector4 a)
        {
            return new Vector4(a.x, 0, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0zz(this Vector4 a)
        {
            return new Vector4(a.x, 0, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0zw(this Vector4 a)
        {
            return new Vector4(a.x, 0, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0z0(this Vector4 a)
        {
            return new Vector4(a.x, 0, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0z1(this Vector4 a)
        {
            return new Vector4(a.x, 0, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0wx(this Vector4 a)
        {
            return new Vector4(a.x, 0, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0wy(this Vector4 a)
        {
            return new Vector4(a.x, 0, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0wz(this Vector4 a)
        {
            return new Vector4(a.x, 0, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0ww(this Vector4 a)
        {
            return new Vector4(a.x, 0, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0w0(this Vector4 a)
        {
            return new Vector4(a.x, 0, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x0w1(this Vector4 a)
        {
            return new Vector4(a.x, 0, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x00x(this Vector4 a)
        {
            return new Vector4(a.x, 0, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x00y(this Vector4 a)
        {
            return new Vector4(a.x, 0, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x00z(this Vector4 a)
        {
            return new Vector4(a.x, 0, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x00w(this Vector4 a)
        {
            return new Vector4(a.x, 0, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x000(this Vector4 a)
        {
            return new Vector4(a.x, 0, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x001(this Vector4 a)
        {
            return new Vector4(a.x, 0, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x01x(this Vector4 a)
        {
            return new Vector4(a.x, 0, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x01y(this Vector4 a)
        {
            return new Vector4(a.x, 0, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x01z(this Vector4 a)
        {
            return new Vector4(a.x, 0, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x01w(this Vector4 a)
        {
            return new Vector4(a.x, 0, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x010(this Vector4 a)
        {
            return new Vector4(a.x, 0, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x011(this Vector4 a)
        {
            return new Vector4(a.x, 0, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1xx(this Vector4 a)
        {
            return new Vector4(a.x, 1, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1xy(this Vector4 a)
        {
            return new Vector4(a.x, 1, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1xz(this Vector4 a)
        {
            return new Vector4(a.x, 1, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1xw(this Vector4 a)
        {
            return new Vector4(a.x, 1, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1x0(this Vector4 a)
        {
            return new Vector4(a.x, 1, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1x1(this Vector4 a)
        {
            return new Vector4(a.x, 1, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1yx(this Vector4 a)
        {
            return new Vector4(a.x, 1, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1yy(this Vector4 a)
        {
            return new Vector4(a.x, 1, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1yz(this Vector4 a)
        {
            return new Vector4(a.x, 1, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1yw(this Vector4 a)
        {
            return new Vector4(a.x, 1, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1y0(this Vector4 a)
        {
            return new Vector4(a.x, 1, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1y1(this Vector4 a)
        {
            return new Vector4(a.x, 1, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1zx(this Vector4 a)
        {
            return new Vector4(a.x, 1, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1zy(this Vector4 a)
        {
            return new Vector4(a.x, 1, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1zz(this Vector4 a)
        {
            return new Vector4(a.x, 1, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1zw(this Vector4 a)
        {
            return new Vector4(a.x, 1, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1z0(this Vector4 a)
        {
            return new Vector4(a.x, 1, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1z1(this Vector4 a)
        {
            return new Vector4(a.x, 1, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1wx(this Vector4 a)
        {
            return new Vector4(a.x, 1, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1wy(this Vector4 a)
        {
            return new Vector4(a.x, 1, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1wz(this Vector4 a)
        {
            return new Vector4(a.x, 1, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1ww(this Vector4 a)
        {
            return new Vector4(a.x, 1, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1w0(this Vector4 a)
        {
            return new Vector4(a.x, 1, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x1w1(this Vector4 a)
        {
            return new Vector4(a.x, 1, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x10x(this Vector4 a)
        {
            return new Vector4(a.x, 1, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x10y(this Vector4 a)
        {
            return new Vector4(a.x, 1, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x10z(this Vector4 a)
        {
            return new Vector4(a.x, 1, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x10w(this Vector4 a)
        {
            return new Vector4(a.x, 1, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x100(this Vector4 a)
        {
            return new Vector4(a.x, 1, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x101(this Vector4 a)
        {
            return new Vector4(a.x, 1, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x11x(this Vector4 a)
        {
            return new Vector4(a.x, 1, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x11y(this Vector4 a)
        {
            return new Vector4(a.x, 1, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x11z(this Vector4 a)
        {
            return new Vector4(a.x, 1, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x11w(this Vector4 a)
        {
            return new Vector4(a.x, 1, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x110(this Vector4 a)
        {
            return new Vector4(a.x, 1, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _x111(this Vector4 a)
        {
            return new Vector4(a.x, 1, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxxx(this Vector4 a)
        {
            return new Vector4(a.y, a.x, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxxy(this Vector4 a)
        {
            return new Vector4(a.y, a.x, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxxz(this Vector4 a)
        {
            return new Vector4(a.y, a.x, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxxw(this Vector4 a)
        {
            return new Vector4(a.y, a.x, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxx0(this Vector4 a)
        {
            return new Vector4(a.y, a.x, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxx1(this Vector4 a)
        {
            return new Vector4(a.y, a.x, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxyx(this Vector4 a)
        {
            return new Vector4(a.y, a.x, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxyy(this Vector4 a)
        {
            return new Vector4(a.y, a.x, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxyz(this Vector4 a)
        {
            return new Vector4(a.y, a.x, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxyw(this Vector4 a)
        {
            return new Vector4(a.y, a.x, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxy0(this Vector4 a)
        {
            return new Vector4(a.y, a.x, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxy1(this Vector4 a)
        {
            return new Vector4(a.y, a.x, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxzx(this Vector4 a)
        {
            return new Vector4(a.y, a.x, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxzy(this Vector4 a)
        {
            return new Vector4(a.y, a.x, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxzz(this Vector4 a)
        {
            return new Vector4(a.y, a.x, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxzw(this Vector4 a)
        {
            return new Vector4(a.y, a.x, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxz0(this Vector4 a)
        {
            return new Vector4(a.y, a.x, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxz1(this Vector4 a)
        {
            return new Vector4(a.y, a.x, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxwx(this Vector4 a)
        {
            return new Vector4(a.y, a.x, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxwy(this Vector4 a)
        {
            return new Vector4(a.y, a.x, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxwz(this Vector4 a)
        {
            return new Vector4(a.y, a.x, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxww(this Vector4 a)
        {
            return new Vector4(a.y, a.x, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxw0(this Vector4 a)
        {
            return new Vector4(a.y, a.x, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yxw1(this Vector4 a)
        {
            return new Vector4(a.y, a.x, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yx0x(this Vector4 a)
        {
            return new Vector4(a.y, a.x, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yx0y(this Vector4 a)
        {
            return new Vector4(a.y, a.x, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yx0z(this Vector4 a)
        {
            return new Vector4(a.y, a.x, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yx0w(this Vector4 a)
        {
            return new Vector4(a.y, a.x, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yx00(this Vector4 a)
        {
            return new Vector4(a.y, a.x, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yx01(this Vector4 a)
        {
            return new Vector4(a.y, a.x, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yx1x(this Vector4 a)
        {
            return new Vector4(a.y, a.x, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yx1y(this Vector4 a)
        {
            return new Vector4(a.y, a.x, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yx1z(this Vector4 a)
        {
            return new Vector4(a.y, a.x, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yx1w(this Vector4 a)
        {
            return new Vector4(a.y, a.x, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yx10(this Vector4 a)
        {
            return new Vector4(a.y, a.x, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yx11(this Vector4 a)
        {
            return new Vector4(a.y, a.x, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyxx(this Vector4 a)
        {
            return new Vector4(a.y, a.y, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyxy(this Vector4 a)
        {
            return new Vector4(a.y, a.y, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyxz(this Vector4 a)
        {
            return new Vector4(a.y, a.y, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyxw(this Vector4 a)
        {
            return new Vector4(a.y, a.y, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyx0(this Vector4 a)
        {
            return new Vector4(a.y, a.y, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyx1(this Vector4 a)
        {
            return new Vector4(a.y, a.y, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyyx(this Vector4 a)
        {
            return new Vector4(a.y, a.y, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyyy(this Vector4 a)
        {
            return new Vector4(a.y, a.y, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyyz(this Vector4 a)
        {
            return new Vector4(a.y, a.y, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyyw(this Vector4 a)
        {
            return new Vector4(a.y, a.y, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyy0(this Vector4 a)
        {
            return new Vector4(a.y, a.y, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyy1(this Vector4 a)
        {
            return new Vector4(a.y, a.y, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyzx(this Vector4 a)
        {
            return new Vector4(a.y, a.y, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyzy(this Vector4 a)
        {
            return new Vector4(a.y, a.y, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyzz(this Vector4 a)
        {
            return new Vector4(a.y, a.y, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyzw(this Vector4 a)
        {
            return new Vector4(a.y, a.y, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyz0(this Vector4 a)
        {
            return new Vector4(a.y, a.y, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyz1(this Vector4 a)
        {
            return new Vector4(a.y, a.y, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yywx(this Vector4 a)
        {
            return new Vector4(a.y, a.y, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yywy(this Vector4 a)
        {
            return new Vector4(a.y, a.y, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yywz(this Vector4 a)
        {
            return new Vector4(a.y, a.y, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyww(this Vector4 a)
        {
            return new Vector4(a.y, a.y, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyw0(this Vector4 a)
        {
            return new Vector4(a.y, a.y, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yyw1(this Vector4 a)
        {
            return new Vector4(a.y, a.y, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yy0x(this Vector4 a)
        {
            return new Vector4(a.y, a.y, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yy0y(this Vector4 a)
        {
            return new Vector4(a.y, a.y, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yy0z(this Vector4 a)
        {
            return new Vector4(a.y, a.y, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yy0w(this Vector4 a)
        {
            return new Vector4(a.y, a.y, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yy00(this Vector4 a)
        {
            return new Vector4(a.y, a.y, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yy01(this Vector4 a)
        {
            return new Vector4(a.y, a.y, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yy1x(this Vector4 a)
        {
            return new Vector4(a.y, a.y, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yy1y(this Vector4 a)
        {
            return new Vector4(a.y, a.y, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yy1z(this Vector4 a)
        {
            return new Vector4(a.y, a.y, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yy1w(this Vector4 a)
        {
            return new Vector4(a.y, a.y, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yy10(this Vector4 a)
        {
            return new Vector4(a.y, a.y, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yy11(this Vector4 a)
        {
            return new Vector4(a.y, a.y, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzxx(this Vector4 a)
        {
            return new Vector4(a.y, a.z, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzxy(this Vector4 a)
        {
            return new Vector4(a.y, a.z, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzxz(this Vector4 a)
        {
            return new Vector4(a.y, a.z, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzxw(this Vector4 a)
        {
            return new Vector4(a.y, a.z, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzx0(this Vector4 a)
        {
            return new Vector4(a.y, a.z, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzx1(this Vector4 a)
        {
            return new Vector4(a.y, a.z, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzyx(this Vector4 a)
        {
            return new Vector4(a.y, a.z, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzyy(this Vector4 a)
        {
            return new Vector4(a.y, a.z, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzyz(this Vector4 a)
        {
            return new Vector4(a.y, a.z, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzyw(this Vector4 a)
        {
            return new Vector4(a.y, a.z, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzy0(this Vector4 a)
        {
            return new Vector4(a.y, a.z, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzy1(this Vector4 a)
        {
            return new Vector4(a.y, a.z, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzzx(this Vector4 a)
        {
            return new Vector4(a.y, a.z, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzzy(this Vector4 a)
        {
            return new Vector4(a.y, a.z, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzzz(this Vector4 a)
        {
            return new Vector4(a.y, a.z, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzzw(this Vector4 a)
        {
            return new Vector4(a.y, a.z, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzz0(this Vector4 a)
        {
            return new Vector4(a.y, a.z, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzz1(this Vector4 a)
        {
            return new Vector4(a.y, a.z, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzwx(this Vector4 a)
        {
            return new Vector4(a.y, a.z, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzwy(this Vector4 a)
        {
            return new Vector4(a.y, a.z, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzwz(this Vector4 a)
        {
            return new Vector4(a.y, a.z, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzww(this Vector4 a)
        {
            return new Vector4(a.y, a.z, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzw0(this Vector4 a)
        {
            return new Vector4(a.y, a.z, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yzw1(this Vector4 a)
        {
            return new Vector4(a.y, a.z, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yz0x(this Vector4 a)
        {
            return new Vector4(a.y, a.z, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yz0y(this Vector4 a)
        {
            return new Vector4(a.y, a.z, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yz0z(this Vector4 a)
        {
            return new Vector4(a.y, a.z, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yz0w(this Vector4 a)
        {
            return new Vector4(a.y, a.z, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yz00(this Vector4 a)
        {
            return new Vector4(a.y, a.z, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yz01(this Vector4 a)
        {
            return new Vector4(a.y, a.z, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yz1x(this Vector4 a)
        {
            return new Vector4(a.y, a.z, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yz1y(this Vector4 a)
        {
            return new Vector4(a.y, a.z, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yz1z(this Vector4 a)
        {
            return new Vector4(a.y, a.z, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yz1w(this Vector4 a)
        {
            return new Vector4(a.y, a.z, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yz10(this Vector4 a)
        {
            return new Vector4(a.y, a.z, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yz11(this Vector4 a)
        {
            return new Vector4(a.y, a.z, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ywxx(this Vector4 a)
        {
            return new Vector4(a.y, a.w, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ywxy(this Vector4 a)
        {
            return new Vector4(a.y, a.w, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ywxz(this Vector4 a)
        {
            return new Vector4(a.y, a.w, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ywxw(this Vector4 a)
        {
            return new Vector4(a.y, a.w, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ywx0(this Vector4 a)
        {
            return new Vector4(a.y, a.w, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ywx1(this Vector4 a)
        {
            return new Vector4(a.y, a.w, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ywyx(this Vector4 a)
        {
            return new Vector4(a.y, a.w, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ywyy(this Vector4 a)
        {
            return new Vector4(a.y, a.w, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ywyz(this Vector4 a)
        {
            return new Vector4(a.y, a.w, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ywyw(this Vector4 a)
        {
            return new Vector4(a.y, a.w, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ywy0(this Vector4 a)
        {
            return new Vector4(a.y, a.w, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ywy1(this Vector4 a)
        {
            return new Vector4(a.y, a.w, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ywzx(this Vector4 a)
        {
            return new Vector4(a.y, a.w, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ywzy(this Vector4 a)
        {
            return new Vector4(a.y, a.w, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ywzz(this Vector4 a)
        {
            return new Vector4(a.y, a.w, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ywzw(this Vector4 a)
        {
            return new Vector4(a.y, a.w, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ywz0(this Vector4 a)
        {
            return new Vector4(a.y, a.w, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ywz1(this Vector4 a)
        {
            return new Vector4(a.y, a.w, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ywwx(this Vector4 a)
        {
            return new Vector4(a.y, a.w, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ywwy(this Vector4 a)
        {
            return new Vector4(a.y, a.w, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ywwz(this Vector4 a)
        {
            return new Vector4(a.y, a.w, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ywww(this Vector4 a)
        {
            return new Vector4(a.y, a.w, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yww0(this Vector4 a)
        {
            return new Vector4(a.y, a.w, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yww1(this Vector4 a)
        {
            return new Vector4(a.y, a.w, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yw0x(this Vector4 a)
        {
            return new Vector4(a.y, a.w, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yw0y(this Vector4 a)
        {
            return new Vector4(a.y, a.w, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yw0z(this Vector4 a)
        {
            return new Vector4(a.y, a.w, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yw0w(this Vector4 a)
        {
            return new Vector4(a.y, a.w, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yw00(this Vector4 a)
        {
            return new Vector4(a.y, a.w, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yw01(this Vector4 a)
        {
            return new Vector4(a.y, a.w, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yw1x(this Vector4 a)
        {
            return new Vector4(a.y, a.w, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yw1y(this Vector4 a)
        {
            return new Vector4(a.y, a.w, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yw1z(this Vector4 a)
        {
            return new Vector4(a.y, a.w, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yw1w(this Vector4 a)
        {
            return new Vector4(a.y, a.w, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yw10(this Vector4 a)
        {
            return new Vector4(a.y, a.w, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _yw11(this Vector4 a)
        {
            return new Vector4(a.y, a.w, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0xx(this Vector4 a)
        {
            return new Vector4(a.y, 0, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0xy(this Vector4 a)
        {
            return new Vector4(a.y, 0, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0xz(this Vector4 a)
        {
            return new Vector4(a.y, 0, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0xw(this Vector4 a)
        {
            return new Vector4(a.y, 0, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0x0(this Vector4 a)
        {
            return new Vector4(a.y, 0, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0x1(this Vector4 a)
        {
            return new Vector4(a.y, 0, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0yx(this Vector4 a)
        {
            return new Vector4(a.y, 0, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0yy(this Vector4 a)
        {
            return new Vector4(a.y, 0, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0yz(this Vector4 a)
        {
            return new Vector4(a.y, 0, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0yw(this Vector4 a)
        {
            return new Vector4(a.y, 0, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0y0(this Vector4 a)
        {
            return new Vector4(a.y, 0, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0y1(this Vector4 a)
        {
            return new Vector4(a.y, 0, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0zx(this Vector4 a)
        {
            return new Vector4(a.y, 0, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0zy(this Vector4 a)
        {
            return new Vector4(a.y, 0, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0zz(this Vector4 a)
        {
            return new Vector4(a.y, 0, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0zw(this Vector4 a)
        {
            return new Vector4(a.y, 0, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0z0(this Vector4 a)
        {
            return new Vector4(a.y, 0, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0z1(this Vector4 a)
        {
            return new Vector4(a.y, 0, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0wx(this Vector4 a)
        {
            return new Vector4(a.y, 0, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0wy(this Vector4 a)
        {
            return new Vector4(a.y, 0, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0wz(this Vector4 a)
        {
            return new Vector4(a.y, 0, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0ww(this Vector4 a)
        {
            return new Vector4(a.y, 0, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0w0(this Vector4 a)
        {
            return new Vector4(a.y, 0, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y0w1(this Vector4 a)
        {
            return new Vector4(a.y, 0, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y00x(this Vector4 a)
        {
            return new Vector4(a.y, 0, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y00y(this Vector4 a)
        {
            return new Vector4(a.y, 0, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y00z(this Vector4 a)
        {
            return new Vector4(a.y, 0, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y00w(this Vector4 a)
        {
            return new Vector4(a.y, 0, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y000(this Vector4 a)
        {
            return new Vector4(a.y, 0, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y001(this Vector4 a)
        {
            return new Vector4(a.y, 0, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y01x(this Vector4 a)
        {
            return new Vector4(a.y, 0, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y01y(this Vector4 a)
        {
            return new Vector4(a.y, 0, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y01z(this Vector4 a)
        {
            return new Vector4(a.y, 0, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y01w(this Vector4 a)
        {
            return new Vector4(a.y, 0, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y010(this Vector4 a)
        {
            return new Vector4(a.y, 0, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y011(this Vector4 a)
        {
            return new Vector4(a.y, 0, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1xx(this Vector4 a)
        {
            return new Vector4(a.y, 1, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1xy(this Vector4 a)
        {
            return new Vector4(a.y, 1, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1xz(this Vector4 a)
        {
            return new Vector4(a.y, 1, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1xw(this Vector4 a)
        {
            return new Vector4(a.y, 1, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1x0(this Vector4 a)
        {
            return new Vector4(a.y, 1, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1x1(this Vector4 a)
        {
            return new Vector4(a.y, 1, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1yx(this Vector4 a)
        {
            return new Vector4(a.y, 1, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1yy(this Vector4 a)
        {
            return new Vector4(a.y, 1, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1yz(this Vector4 a)
        {
            return new Vector4(a.y, 1, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1yw(this Vector4 a)
        {
            return new Vector4(a.y, 1, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1y0(this Vector4 a)
        {
            return new Vector4(a.y, 1, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1y1(this Vector4 a)
        {
            return new Vector4(a.y, 1, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1zx(this Vector4 a)
        {
            return new Vector4(a.y, 1, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1zy(this Vector4 a)
        {
            return new Vector4(a.y, 1, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1zz(this Vector4 a)
        {
            return new Vector4(a.y, 1, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1zw(this Vector4 a)
        {
            return new Vector4(a.y, 1, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1z0(this Vector4 a)
        {
            return new Vector4(a.y, 1, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1z1(this Vector4 a)
        {
            return new Vector4(a.y, 1, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1wx(this Vector4 a)
        {
            return new Vector4(a.y, 1, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1wy(this Vector4 a)
        {
            return new Vector4(a.y, 1, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1wz(this Vector4 a)
        {
            return new Vector4(a.y, 1, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1ww(this Vector4 a)
        {
            return new Vector4(a.y, 1, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1w0(this Vector4 a)
        {
            return new Vector4(a.y, 1, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y1w1(this Vector4 a)
        {
            return new Vector4(a.y, 1, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y10x(this Vector4 a)
        {
            return new Vector4(a.y, 1, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y10y(this Vector4 a)
        {
            return new Vector4(a.y, 1, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y10z(this Vector4 a)
        {
            return new Vector4(a.y, 1, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y10w(this Vector4 a)
        {
            return new Vector4(a.y, 1, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y100(this Vector4 a)
        {
            return new Vector4(a.y, 1, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y101(this Vector4 a)
        {
            return new Vector4(a.y, 1, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y11x(this Vector4 a)
        {
            return new Vector4(a.y, 1, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y11y(this Vector4 a)
        {
            return new Vector4(a.y, 1, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y11z(this Vector4 a)
        {
            return new Vector4(a.y, 1, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y11w(this Vector4 a)
        {
            return new Vector4(a.y, 1, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y110(this Vector4 a)
        {
            return new Vector4(a.y, 1, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _y111(this Vector4 a)
        {
            return new Vector4(a.y, 1, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxxx(this Vector4 a)
        {
            return new Vector4(a.z, a.x, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxxy(this Vector4 a)
        {
            return new Vector4(a.z, a.x, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxxz(this Vector4 a)
        {
            return new Vector4(a.z, a.x, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxxw(this Vector4 a)
        {
            return new Vector4(a.z, a.x, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxx0(this Vector4 a)
        {
            return new Vector4(a.z, a.x, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxx1(this Vector4 a)
        {
            return new Vector4(a.z, a.x, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxyx(this Vector4 a)
        {
            return new Vector4(a.z, a.x, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxyy(this Vector4 a)
        {
            return new Vector4(a.z, a.x, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxyz(this Vector4 a)
        {
            return new Vector4(a.z, a.x, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxyw(this Vector4 a)
        {
            return new Vector4(a.z, a.x, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxy0(this Vector4 a)
        {
            return new Vector4(a.z, a.x, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxy1(this Vector4 a)
        {
            return new Vector4(a.z, a.x, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxzx(this Vector4 a)
        {
            return new Vector4(a.z, a.x, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxzy(this Vector4 a)
        {
            return new Vector4(a.z, a.x, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxzz(this Vector4 a)
        {
            return new Vector4(a.z, a.x, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxzw(this Vector4 a)
        {
            return new Vector4(a.z, a.x, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxz0(this Vector4 a)
        {
            return new Vector4(a.z, a.x, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxz1(this Vector4 a)
        {
            return new Vector4(a.z, a.x, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxwx(this Vector4 a)
        {
            return new Vector4(a.z, a.x, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxwy(this Vector4 a)
        {
            return new Vector4(a.z, a.x, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxwz(this Vector4 a)
        {
            return new Vector4(a.z, a.x, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxww(this Vector4 a)
        {
            return new Vector4(a.z, a.x, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxw0(this Vector4 a)
        {
            return new Vector4(a.z, a.x, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zxw1(this Vector4 a)
        {
            return new Vector4(a.z, a.x, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zx0x(this Vector4 a)
        {
            return new Vector4(a.z, a.x, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zx0y(this Vector4 a)
        {
            return new Vector4(a.z, a.x, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zx0z(this Vector4 a)
        {
            return new Vector4(a.z, a.x, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zx0w(this Vector4 a)
        {
            return new Vector4(a.z, a.x, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zx00(this Vector4 a)
        {
            return new Vector4(a.z, a.x, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zx01(this Vector4 a)
        {
            return new Vector4(a.z, a.x, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zx1x(this Vector4 a)
        {
            return new Vector4(a.z, a.x, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zx1y(this Vector4 a)
        {
            return new Vector4(a.z, a.x, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zx1z(this Vector4 a)
        {
            return new Vector4(a.z, a.x, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zx1w(this Vector4 a)
        {
            return new Vector4(a.z, a.x, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zx10(this Vector4 a)
        {
            return new Vector4(a.z, a.x, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zx11(this Vector4 a)
        {
            return new Vector4(a.z, a.x, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyxx(this Vector4 a)
        {
            return new Vector4(a.z, a.y, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyxy(this Vector4 a)
        {
            return new Vector4(a.z, a.y, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyxz(this Vector4 a)
        {
            return new Vector4(a.z, a.y, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyxw(this Vector4 a)
        {
            return new Vector4(a.z, a.y, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyx0(this Vector4 a)
        {
            return new Vector4(a.z, a.y, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyx1(this Vector4 a)
        {
            return new Vector4(a.z, a.y, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyyx(this Vector4 a)
        {
            return new Vector4(a.z, a.y, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyyy(this Vector4 a)
        {
            return new Vector4(a.z, a.y, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyyz(this Vector4 a)
        {
            return new Vector4(a.z, a.y, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyyw(this Vector4 a)
        {
            return new Vector4(a.z, a.y, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyy0(this Vector4 a)
        {
            return new Vector4(a.z, a.y, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyy1(this Vector4 a)
        {
            return new Vector4(a.z, a.y, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyzx(this Vector4 a)
        {
            return new Vector4(a.z, a.y, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyzy(this Vector4 a)
        {
            return new Vector4(a.z, a.y, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyzz(this Vector4 a)
        {
            return new Vector4(a.z, a.y, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyzw(this Vector4 a)
        {
            return new Vector4(a.z, a.y, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyz0(this Vector4 a)
        {
            return new Vector4(a.z, a.y, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyz1(this Vector4 a)
        {
            return new Vector4(a.z, a.y, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zywx(this Vector4 a)
        {
            return new Vector4(a.z, a.y, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zywy(this Vector4 a)
        {
            return new Vector4(a.z, a.y, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zywz(this Vector4 a)
        {
            return new Vector4(a.z, a.y, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyww(this Vector4 a)
        {
            return new Vector4(a.z, a.y, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyw0(this Vector4 a)
        {
            return new Vector4(a.z, a.y, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zyw1(this Vector4 a)
        {
            return new Vector4(a.z, a.y, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zy0x(this Vector4 a)
        {
            return new Vector4(a.z, a.y, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zy0y(this Vector4 a)
        {
            return new Vector4(a.z, a.y, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zy0z(this Vector4 a)
        {
            return new Vector4(a.z, a.y, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zy0w(this Vector4 a)
        {
            return new Vector4(a.z, a.y, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zy00(this Vector4 a)
        {
            return new Vector4(a.z, a.y, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zy01(this Vector4 a)
        {
            return new Vector4(a.z, a.y, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zy1x(this Vector4 a)
        {
            return new Vector4(a.z, a.y, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zy1y(this Vector4 a)
        {
            return new Vector4(a.z, a.y, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zy1z(this Vector4 a)
        {
            return new Vector4(a.z, a.y, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zy1w(this Vector4 a)
        {
            return new Vector4(a.z, a.y, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zy10(this Vector4 a)
        {
            return new Vector4(a.z, a.y, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zy11(this Vector4 a)
        {
            return new Vector4(a.z, a.y, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzxx(this Vector4 a)
        {
            return new Vector4(a.z, a.z, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzxy(this Vector4 a)
        {
            return new Vector4(a.z, a.z, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzxz(this Vector4 a)
        {
            return new Vector4(a.z, a.z, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzxw(this Vector4 a)
        {
            return new Vector4(a.z, a.z, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzx0(this Vector4 a)
        {
            return new Vector4(a.z, a.z, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzx1(this Vector4 a)
        {
            return new Vector4(a.z, a.z, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzyx(this Vector4 a)
        {
            return new Vector4(a.z, a.z, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzyy(this Vector4 a)
        {
            return new Vector4(a.z, a.z, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzyz(this Vector4 a)
        {
            return new Vector4(a.z, a.z, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzyw(this Vector4 a)
        {
            return new Vector4(a.z, a.z, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzy0(this Vector4 a)
        {
            return new Vector4(a.z, a.z, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzy1(this Vector4 a)
        {
            return new Vector4(a.z, a.z, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzzx(this Vector4 a)
        {
            return new Vector4(a.z, a.z, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzzy(this Vector4 a)
        {
            return new Vector4(a.z, a.z, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzzz(this Vector4 a)
        {
            return new Vector4(a.z, a.z, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzzw(this Vector4 a)
        {
            return new Vector4(a.z, a.z, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzz0(this Vector4 a)
        {
            return new Vector4(a.z, a.z, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzz1(this Vector4 a)
        {
            return new Vector4(a.z, a.z, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzwx(this Vector4 a)
        {
            return new Vector4(a.z, a.z, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzwy(this Vector4 a)
        {
            return new Vector4(a.z, a.z, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzwz(this Vector4 a)
        {
            return new Vector4(a.z, a.z, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzww(this Vector4 a)
        {
            return new Vector4(a.z, a.z, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzw0(this Vector4 a)
        {
            return new Vector4(a.z, a.z, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zzw1(this Vector4 a)
        {
            return new Vector4(a.z, a.z, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zz0x(this Vector4 a)
        {
            return new Vector4(a.z, a.z, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zz0y(this Vector4 a)
        {
            return new Vector4(a.z, a.z, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zz0z(this Vector4 a)
        {
            return new Vector4(a.z, a.z, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zz0w(this Vector4 a)
        {
            return new Vector4(a.z, a.z, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zz00(this Vector4 a)
        {
            return new Vector4(a.z, a.z, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zz01(this Vector4 a)
        {
            return new Vector4(a.z, a.z, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zz1x(this Vector4 a)
        {
            return new Vector4(a.z, a.z, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zz1y(this Vector4 a)
        {
            return new Vector4(a.z, a.z, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zz1z(this Vector4 a)
        {
            return new Vector4(a.z, a.z, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zz1w(this Vector4 a)
        {
            return new Vector4(a.z, a.z, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zz10(this Vector4 a)
        {
            return new Vector4(a.z, a.z, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zz11(this Vector4 a)
        {
            return new Vector4(a.z, a.z, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zwxx(this Vector4 a)
        {
            return new Vector4(a.z, a.w, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zwxy(this Vector4 a)
        {
            return new Vector4(a.z, a.w, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zwxz(this Vector4 a)
        {
            return new Vector4(a.z, a.w, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zwxw(this Vector4 a)
        {
            return new Vector4(a.z, a.w, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zwx0(this Vector4 a)
        {
            return new Vector4(a.z, a.w, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zwx1(this Vector4 a)
        {
            return new Vector4(a.z, a.w, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zwyx(this Vector4 a)
        {
            return new Vector4(a.z, a.w, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zwyy(this Vector4 a)
        {
            return new Vector4(a.z, a.w, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zwyz(this Vector4 a)
        {
            return new Vector4(a.z, a.w, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zwyw(this Vector4 a)
        {
            return new Vector4(a.z, a.w, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zwy0(this Vector4 a)
        {
            return new Vector4(a.z, a.w, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zwy1(this Vector4 a)
        {
            return new Vector4(a.z, a.w, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zwzx(this Vector4 a)
        {
            return new Vector4(a.z, a.w, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zwzy(this Vector4 a)
        {
            return new Vector4(a.z, a.w, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zwzz(this Vector4 a)
        {
            return new Vector4(a.z, a.w, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zwzw(this Vector4 a)
        {
            return new Vector4(a.z, a.w, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zwz0(this Vector4 a)
        {
            return new Vector4(a.z, a.w, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zwz1(this Vector4 a)
        {
            return new Vector4(a.z, a.w, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zwwx(this Vector4 a)
        {
            return new Vector4(a.z, a.w, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zwwy(this Vector4 a)
        {
            return new Vector4(a.z, a.w, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zwwz(this Vector4 a)
        {
            return new Vector4(a.z, a.w, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zwww(this Vector4 a)
        {
            return new Vector4(a.z, a.w, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zww0(this Vector4 a)
        {
            return new Vector4(a.z, a.w, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zww1(this Vector4 a)
        {
            return new Vector4(a.z, a.w, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zw0x(this Vector4 a)
        {
            return new Vector4(a.z, a.w, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zw0y(this Vector4 a)
        {
            return new Vector4(a.z, a.w, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zw0z(this Vector4 a)
        {
            return new Vector4(a.z, a.w, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zw0w(this Vector4 a)
        {
            return new Vector4(a.z, a.w, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zw00(this Vector4 a)
        {
            return new Vector4(a.z, a.w, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zw01(this Vector4 a)
        {
            return new Vector4(a.z, a.w, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zw1x(this Vector4 a)
        {
            return new Vector4(a.z, a.w, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zw1y(this Vector4 a)
        {
            return new Vector4(a.z, a.w, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zw1z(this Vector4 a)
        {
            return new Vector4(a.z, a.w, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zw1w(this Vector4 a)
        {
            return new Vector4(a.z, a.w, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zw10(this Vector4 a)
        {
            return new Vector4(a.z, a.w, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _zw11(this Vector4 a)
        {
            return new Vector4(a.z, a.w, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0xx(this Vector4 a)
        {
            return new Vector4(a.z, 0, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0xy(this Vector4 a)
        {
            return new Vector4(a.z, 0, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0xz(this Vector4 a)
        {
            return new Vector4(a.z, 0, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0xw(this Vector4 a)
        {
            return new Vector4(a.z, 0, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0x0(this Vector4 a)
        {
            return new Vector4(a.z, 0, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0x1(this Vector4 a)
        {
            return new Vector4(a.z, 0, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0yx(this Vector4 a)
        {
            return new Vector4(a.z, 0, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0yy(this Vector4 a)
        {
            return new Vector4(a.z, 0, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0yz(this Vector4 a)
        {
            return new Vector4(a.z, 0, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0yw(this Vector4 a)
        {
            return new Vector4(a.z, 0, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0y0(this Vector4 a)
        {
            return new Vector4(a.z, 0, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0y1(this Vector4 a)
        {
            return new Vector4(a.z, 0, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0zx(this Vector4 a)
        {
            return new Vector4(a.z, 0, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0zy(this Vector4 a)
        {
            return new Vector4(a.z, 0, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0zz(this Vector4 a)
        {
            return new Vector4(a.z, 0, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0zw(this Vector4 a)
        {
            return new Vector4(a.z, 0, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0z0(this Vector4 a)
        {
            return new Vector4(a.z, 0, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0z1(this Vector4 a)
        {
            return new Vector4(a.z, 0, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0wx(this Vector4 a)
        {
            return new Vector4(a.z, 0, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0wy(this Vector4 a)
        {
            return new Vector4(a.z, 0, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0wz(this Vector4 a)
        {
            return new Vector4(a.z, 0, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0ww(this Vector4 a)
        {
            return new Vector4(a.z, 0, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0w0(this Vector4 a)
        {
            return new Vector4(a.z, 0, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z0w1(this Vector4 a)
        {
            return new Vector4(a.z, 0, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z00x(this Vector4 a)
        {
            return new Vector4(a.z, 0, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z00y(this Vector4 a)
        {
            return new Vector4(a.z, 0, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z00z(this Vector4 a)
        {
            return new Vector4(a.z, 0, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z00w(this Vector4 a)
        {
            return new Vector4(a.z, 0, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z000(this Vector4 a)
        {
            return new Vector4(a.z, 0, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z001(this Vector4 a)
        {
            return new Vector4(a.z, 0, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z01x(this Vector4 a)
        {
            return new Vector4(a.z, 0, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z01y(this Vector4 a)
        {
            return new Vector4(a.z, 0, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z01z(this Vector4 a)
        {
            return new Vector4(a.z, 0, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z01w(this Vector4 a)
        {
            return new Vector4(a.z, 0, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z010(this Vector4 a)
        {
            return new Vector4(a.z, 0, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z011(this Vector4 a)
        {
            return new Vector4(a.z, 0, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1xx(this Vector4 a)
        {
            return new Vector4(a.z, 1, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1xy(this Vector4 a)
        {
            return new Vector4(a.z, 1, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1xz(this Vector4 a)
        {
            return new Vector4(a.z, 1, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1xw(this Vector4 a)
        {
            return new Vector4(a.z, 1, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1x0(this Vector4 a)
        {
            return new Vector4(a.z, 1, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1x1(this Vector4 a)
        {
            return new Vector4(a.z, 1, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1yx(this Vector4 a)
        {
            return new Vector4(a.z, 1, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1yy(this Vector4 a)
        {
            return new Vector4(a.z, 1, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1yz(this Vector4 a)
        {
            return new Vector4(a.z, 1, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1yw(this Vector4 a)
        {
            return new Vector4(a.z, 1, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1y0(this Vector4 a)
        {
            return new Vector4(a.z, 1, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1y1(this Vector4 a)
        {
            return new Vector4(a.z, 1, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1zx(this Vector4 a)
        {
            return new Vector4(a.z, 1, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1zy(this Vector4 a)
        {
            return new Vector4(a.z, 1, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1zz(this Vector4 a)
        {
            return new Vector4(a.z, 1, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1zw(this Vector4 a)
        {
            return new Vector4(a.z, 1, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1z0(this Vector4 a)
        {
            return new Vector4(a.z, 1, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1z1(this Vector4 a)
        {
            return new Vector4(a.z, 1, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1wx(this Vector4 a)
        {
            return new Vector4(a.z, 1, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1wy(this Vector4 a)
        {
            return new Vector4(a.z, 1, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1wz(this Vector4 a)
        {
            return new Vector4(a.z, 1, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1ww(this Vector4 a)
        {
            return new Vector4(a.z, 1, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1w0(this Vector4 a)
        {
            return new Vector4(a.z, 1, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z1w1(this Vector4 a)
        {
            return new Vector4(a.z, 1, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z10x(this Vector4 a)
        {
            return new Vector4(a.z, 1, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z10y(this Vector4 a)
        {
            return new Vector4(a.z, 1, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z10z(this Vector4 a)
        {
            return new Vector4(a.z, 1, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z10w(this Vector4 a)
        {
            return new Vector4(a.z, 1, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z100(this Vector4 a)
        {
            return new Vector4(a.z, 1, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z101(this Vector4 a)
        {
            return new Vector4(a.z, 1, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z11x(this Vector4 a)
        {
            return new Vector4(a.z, 1, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z11y(this Vector4 a)
        {
            return new Vector4(a.z, 1, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z11z(this Vector4 a)
        {
            return new Vector4(a.z, 1, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z11w(this Vector4 a)
        {
            return new Vector4(a.z, 1, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z110(this Vector4 a)
        {
            return new Vector4(a.z, 1, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _z111(this Vector4 a)
        {
            return new Vector4(a.z, 1, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wxxx(this Vector4 a)
        {
            return new Vector4(a.w, a.x, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wxxy(this Vector4 a)
        {
            return new Vector4(a.w, a.x, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wxxz(this Vector4 a)
        {
            return new Vector4(a.w, a.x, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wxxw(this Vector4 a)
        {
            return new Vector4(a.w, a.x, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wxx0(this Vector4 a)
        {
            return new Vector4(a.w, a.x, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wxx1(this Vector4 a)
        {
            return new Vector4(a.w, a.x, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wxyx(this Vector4 a)
        {
            return new Vector4(a.w, a.x, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wxyy(this Vector4 a)
        {
            return new Vector4(a.w, a.x, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wxyz(this Vector4 a)
        {
            return new Vector4(a.w, a.x, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wxyw(this Vector4 a)
        {
            return new Vector4(a.w, a.x, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wxy0(this Vector4 a)
        {
            return new Vector4(a.w, a.x, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wxy1(this Vector4 a)
        {
            return new Vector4(a.w, a.x, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wxzx(this Vector4 a)
        {
            return new Vector4(a.w, a.x, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wxzy(this Vector4 a)
        {
            return new Vector4(a.w, a.x, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wxzz(this Vector4 a)
        {
            return new Vector4(a.w, a.x, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wxzw(this Vector4 a)
        {
            return new Vector4(a.w, a.x, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wxz0(this Vector4 a)
        {
            return new Vector4(a.w, a.x, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wxz1(this Vector4 a)
        {
            return new Vector4(a.w, a.x, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wxwx(this Vector4 a)
        {
            return new Vector4(a.w, a.x, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wxwy(this Vector4 a)
        {
            return new Vector4(a.w, a.x, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wxwz(this Vector4 a)
        {
            return new Vector4(a.w, a.x, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wxww(this Vector4 a)
        {
            return new Vector4(a.w, a.x, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wxw0(this Vector4 a)
        {
            return new Vector4(a.w, a.x, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wxw1(this Vector4 a)
        {
            return new Vector4(a.w, a.x, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wx0x(this Vector4 a)
        {
            return new Vector4(a.w, a.x, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wx0y(this Vector4 a)
        {
            return new Vector4(a.w, a.x, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wx0z(this Vector4 a)
        {
            return new Vector4(a.w, a.x, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wx0w(this Vector4 a)
        {
            return new Vector4(a.w, a.x, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wx00(this Vector4 a)
        {
            return new Vector4(a.w, a.x, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wx01(this Vector4 a)
        {
            return new Vector4(a.w, a.x, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wx1x(this Vector4 a)
        {
            return new Vector4(a.w, a.x, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wx1y(this Vector4 a)
        {
            return new Vector4(a.w, a.x, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wx1z(this Vector4 a)
        {
            return new Vector4(a.w, a.x, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wx1w(this Vector4 a)
        {
            return new Vector4(a.w, a.x, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wx10(this Vector4 a)
        {
            return new Vector4(a.w, a.x, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wx11(this Vector4 a)
        {
            return new Vector4(a.w, a.x, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wyxx(this Vector4 a)
        {
            return new Vector4(a.w, a.y, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wyxy(this Vector4 a)
        {
            return new Vector4(a.w, a.y, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wyxz(this Vector4 a)
        {
            return new Vector4(a.w, a.y, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wyxw(this Vector4 a)
        {
            return new Vector4(a.w, a.y, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wyx0(this Vector4 a)
        {
            return new Vector4(a.w, a.y, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wyx1(this Vector4 a)
        {
            return new Vector4(a.w, a.y, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wyyx(this Vector4 a)
        {
            return new Vector4(a.w, a.y, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wyyy(this Vector4 a)
        {
            return new Vector4(a.w, a.y, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wyyz(this Vector4 a)
        {
            return new Vector4(a.w, a.y, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wyyw(this Vector4 a)
        {
            return new Vector4(a.w, a.y, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wyy0(this Vector4 a)
        {
            return new Vector4(a.w, a.y, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wyy1(this Vector4 a)
        {
            return new Vector4(a.w, a.y, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wyzx(this Vector4 a)
        {
            return new Vector4(a.w, a.y, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wyzy(this Vector4 a)
        {
            return new Vector4(a.w, a.y, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wyzz(this Vector4 a)
        {
            return new Vector4(a.w, a.y, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wyzw(this Vector4 a)
        {
            return new Vector4(a.w, a.y, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wyz0(this Vector4 a)
        {
            return new Vector4(a.w, a.y, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wyz1(this Vector4 a)
        {
            return new Vector4(a.w, a.y, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wywx(this Vector4 a)
        {
            return new Vector4(a.w, a.y, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wywy(this Vector4 a)
        {
            return new Vector4(a.w, a.y, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wywz(this Vector4 a)
        {
            return new Vector4(a.w, a.y, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wyww(this Vector4 a)
        {
            return new Vector4(a.w, a.y, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wyw0(this Vector4 a)
        {
            return new Vector4(a.w, a.y, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wyw1(this Vector4 a)
        {
            return new Vector4(a.w, a.y, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wy0x(this Vector4 a)
        {
            return new Vector4(a.w, a.y, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wy0y(this Vector4 a)
        {
            return new Vector4(a.w, a.y, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wy0z(this Vector4 a)
        {
            return new Vector4(a.w, a.y, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wy0w(this Vector4 a)
        {
            return new Vector4(a.w, a.y, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wy00(this Vector4 a)
        {
            return new Vector4(a.w, a.y, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wy01(this Vector4 a)
        {
            return new Vector4(a.w, a.y, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wy1x(this Vector4 a)
        {
            return new Vector4(a.w, a.y, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wy1y(this Vector4 a)
        {
            return new Vector4(a.w, a.y, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wy1z(this Vector4 a)
        {
            return new Vector4(a.w, a.y, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wy1w(this Vector4 a)
        {
            return new Vector4(a.w, a.y, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wy10(this Vector4 a)
        {
            return new Vector4(a.w, a.y, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wy11(this Vector4 a)
        {
            return new Vector4(a.w, a.y, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wzxx(this Vector4 a)
        {
            return new Vector4(a.w, a.z, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wzxy(this Vector4 a)
        {
            return new Vector4(a.w, a.z, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wzxz(this Vector4 a)
        {
            return new Vector4(a.w, a.z, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wzxw(this Vector4 a)
        {
            return new Vector4(a.w, a.z, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wzx0(this Vector4 a)
        {
            return new Vector4(a.w, a.z, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wzx1(this Vector4 a)
        {
            return new Vector4(a.w, a.z, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wzyx(this Vector4 a)
        {
            return new Vector4(a.w, a.z, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wzyy(this Vector4 a)
        {
            return new Vector4(a.w, a.z, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wzyz(this Vector4 a)
        {
            return new Vector4(a.w, a.z, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wzyw(this Vector4 a)
        {
            return new Vector4(a.w, a.z, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wzy0(this Vector4 a)
        {
            return new Vector4(a.w, a.z, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wzy1(this Vector4 a)
        {
            return new Vector4(a.w, a.z, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wzzx(this Vector4 a)
        {
            return new Vector4(a.w, a.z, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wzzy(this Vector4 a)
        {
            return new Vector4(a.w, a.z, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wzzz(this Vector4 a)
        {
            return new Vector4(a.w, a.z, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wzzw(this Vector4 a)
        {
            return new Vector4(a.w, a.z, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wzz0(this Vector4 a)
        {
            return new Vector4(a.w, a.z, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wzz1(this Vector4 a)
        {
            return new Vector4(a.w, a.z, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wzwx(this Vector4 a)
        {
            return new Vector4(a.w, a.z, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wzwy(this Vector4 a)
        {
            return new Vector4(a.w, a.z, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wzwz(this Vector4 a)
        {
            return new Vector4(a.w, a.z, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wzww(this Vector4 a)
        {
            return new Vector4(a.w, a.z, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wzw0(this Vector4 a)
        {
            return new Vector4(a.w, a.z, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wzw1(this Vector4 a)
        {
            return new Vector4(a.w, a.z, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wz0x(this Vector4 a)
        {
            return new Vector4(a.w, a.z, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wz0y(this Vector4 a)
        {
            return new Vector4(a.w, a.z, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wz0z(this Vector4 a)
        {
            return new Vector4(a.w, a.z, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wz0w(this Vector4 a)
        {
            return new Vector4(a.w, a.z, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wz00(this Vector4 a)
        {
            return new Vector4(a.w, a.z, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wz01(this Vector4 a)
        {
            return new Vector4(a.w, a.z, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wz1x(this Vector4 a)
        {
            return new Vector4(a.w, a.z, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wz1y(this Vector4 a)
        {
            return new Vector4(a.w, a.z, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wz1z(this Vector4 a)
        {
            return new Vector4(a.w, a.z, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wz1w(this Vector4 a)
        {
            return new Vector4(a.w, a.z, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wz10(this Vector4 a)
        {
            return new Vector4(a.w, a.z, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wz11(this Vector4 a)
        {
            return new Vector4(a.w, a.z, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wwxx(this Vector4 a)
        {
            return new Vector4(a.w, a.w, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wwxy(this Vector4 a)
        {
            return new Vector4(a.w, a.w, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wwxz(this Vector4 a)
        {
            return new Vector4(a.w, a.w, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wwxw(this Vector4 a)
        {
            return new Vector4(a.w, a.w, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wwx0(this Vector4 a)
        {
            return new Vector4(a.w, a.w, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wwx1(this Vector4 a)
        {
            return new Vector4(a.w, a.w, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wwyx(this Vector4 a)
        {
            return new Vector4(a.w, a.w, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wwyy(this Vector4 a)
        {
            return new Vector4(a.w, a.w, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wwyz(this Vector4 a)
        {
            return new Vector4(a.w, a.w, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wwyw(this Vector4 a)
        {
            return new Vector4(a.w, a.w, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wwy0(this Vector4 a)
        {
            return new Vector4(a.w, a.w, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wwy1(this Vector4 a)
        {
            return new Vector4(a.w, a.w, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wwzx(this Vector4 a)
        {
            return new Vector4(a.w, a.w, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wwzy(this Vector4 a)
        {
            return new Vector4(a.w, a.w, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wwzz(this Vector4 a)
        {
            return new Vector4(a.w, a.w, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wwzw(this Vector4 a)
        {
            return new Vector4(a.w, a.w, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wwz0(this Vector4 a)
        {
            return new Vector4(a.w, a.w, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wwz1(this Vector4 a)
        {
            return new Vector4(a.w, a.w, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wwwx(this Vector4 a)
        {
            return new Vector4(a.w, a.w, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wwwy(this Vector4 a)
        {
            return new Vector4(a.w, a.w, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wwwz(this Vector4 a)
        {
            return new Vector4(a.w, a.w, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _wwww(this Vector4 a)
        {
            return new Vector4(a.w, a.w, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _www0(this Vector4 a)
        {
            return new Vector4(a.w, a.w, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _www1(this Vector4 a)
        {
            return new Vector4(a.w, a.w, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ww0x(this Vector4 a)
        {
            return new Vector4(a.w, a.w, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ww0y(this Vector4 a)
        {
            return new Vector4(a.w, a.w, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ww0z(this Vector4 a)
        {
            return new Vector4(a.w, a.w, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ww0w(this Vector4 a)
        {
            return new Vector4(a.w, a.w, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ww00(this Vector4 a)
        {
            return new Vector4(a.w, a.w, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ww01(this Vector4 a)
        {
            return new Vector4(a.w, a.w, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ww1x(this Vector4 a)
        {
            return new Vector4(a.w, a.w, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ww1y(this Vector4 a)
        {
            return new Vector4(a.w, a.w, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ww1z(this Vector4 a)
        {
            return new Vector4(a.w, a.w, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ww1w(this Vector4 a)
        {
            return new Vector4(a.w, a.w, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ww10(this Vector4 a)
        {
            return new Vector4(a.w, a.w, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _ww11(this Vector4 a)
        {
            return new Vector4(a.w, a.w, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w0xx(this Vector4 a)
        {
            return new Vector4(a.w, 0, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w0xy(this Vector4 a)
        {
            return new Vector4(a.w, 0, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w0xz(this Vector4 a)
        {
            return new Vector4(a.w, 0, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w0xw(this Vector4 a)
        {
            return new Vector4(a.w, 0, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w0x0(this Vector4 a)
        {
            return new Vector4(a.w, 0, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w0x1(this Vector4 a)
        {
            return new Vector4(a.w, 0, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w0yx(this Vector4 a)
        {
            return new Vector4(a.w, 0, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w0yy(this Vector4 a)
        {
            return new Vector4(a.w, 0, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w0yz(this Vector4 a)
        {
            return new Vector4(a.w, 0, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w0yw(this Vector4 a)
        {
            return new Vector4(a.w, 0, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w0y0(this Vector4 a)
        {
            return new Vector4(a.w, 0, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w0y1(this Vector4 a)
        {
            return new Vector4(a.w, 0, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w0zx(this Vector4 a)
        {
            return new Vector4(a.w, 0, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w0zy(this Vector4 a)
        {
            return new Vector4(a.w, 0, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w0zz(this Vector4 a)
        {
            return new Vector4(a.w, 0, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w0zw(this Vector4 a)
        {
            return new Vector4(a.w, 0, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w0z0(this Vector4 a)
        {
            return new Vector4(a.w, 0, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w0z1(this Vector4 a)
        {
            return new Vector4(a.w, 0, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w0wx(this Vector4 a)
        {
            return new Vector4(a.w, 0, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w0wy(this Vector4 a)
        {
            return new Vector4(a.w, 0, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w0wz(this Vector4 a)
        {
            return new Vector4(a.w, 0, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w0ww(this Vector4 a)
        {
            return new Vector4(a.w, 0, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w0w0(this Vector4 a)
        {
            return new Vector4(a.w, 0, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w0w1(this Vector4 a)
        {
            return new Vector4(a.w, 0, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w00x(this Vector4 a)
        {
            return new Vector4(a.w, 0, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w00y(this Vector4 a)
        {
            return new Vector4(a.w, 0, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w00z(this Vector4 a)
        {
            return new Vector4(a.w, 0, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w00w(this Vector4 a)
        {
            return new Vector4(a.w, 0, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w000(this Vector4 a)
        {
            return new Vector4(a.w, 0, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w001(this Vector4 a)
        {
            return new Vector4(a.w, 0, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w01x(this Vector4 a)
        {
            return new Vector4(a.w, 0, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w01y(this Vector4 a)
        {
            return new Vector4(a.w, 0, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w01z(this Vector4 a)
        {
            return new Vector4(a.w, 0, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w01w(this Vector4 a)
        {
            return new Vector4(a.w, 0, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w010(this Vector4 a)
        {
            return new Vector4(a.w, 0, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w011(this Vector4 a)
        {
            return new Vector4(a.w, 0, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w1xx(this Vector4 a)
        {
            return new Vector4(a.w, 1, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w1xy(this Vector4 a)
        {
            return new Vector4(a.w, 1, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w1xz(this Vector4 a)
        {
            return new Vector4(a.w, 1, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w1xw(this Vector4 a)
        {
            return new Vector4(a.w, 1, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w1x0(this Vector4 a)
        {
            return new Vector4(a.w, 1, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w1x1(this Vector4 a)
        {
            return new Vector4(a.w, 1, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w1yx(this Vector4 a)
        {
            return new Vector4(a.w, 1, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w1yy(this Vector4 a)
        {
            return new Vector4(a.w, 1, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w1yz(this Vector4 a)
        {
            return new Vector4(a.w, 1, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w1yw(this Vector4 a)
        {
            return new Vector4(a.w, 1, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w1y0(this Vector4 a)
        {
            return new Vector4(a.w, 1, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w1y1(this Vector4 a)
        {
            return new Vector4(a.w, 1, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w1zx(this Vector4 a)
        {
            return new Vector4(a.w, 1, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w1zy(this Vector4 a)
        {
            return new Vector4(a.w, 1, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w1zz(this Vector4 a)
        {
            return new Vector4(a.w, 1, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w1zw(this Vector4 a)
        {
            return new Vector4(a.w, 1, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w1z0(this Vector4 a)
        {
            return new Vector4(a.w, 1, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w1z1(this Vector4 a)
        {
            return new Vector4(a.w, 1, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w1wx(this Vector4 a)
        {
            return new Vector4(a.w, 1, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w1wy(this Vector4 a)
        {
            return new Vector4(a.w, 1, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w1wz(this Vector4 a)
        {
            return new Vector4(a.w, 1, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w1ww(this Vector4 a)
        {
            return new Vector4(a.w, 1, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w1w0(this Vector4 a)
        {
            return new Vector4(a.w, 1, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w1w1(this Vector4 a)
        {
            return new Vector4(a.w, 1, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w10x(this Vector4 a)
        {
            return new Vector4(a.w, 1, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w10y(this Vector4 a)
        {
            return new Vector4(a.w, 1, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w10z(this Vector4 a)
        {
            return new Vector4(a.w, 1, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w10w(this Vector4 a)
        {
            return new Vector4(a.w, 1, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w100(this Vector4 a)
        {
            return new Vector4(a.w, 1, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w101(this Vector4 a)
        {
            return new Vector4(a.w, 1, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w11x(this Vector4 a)
        {
            return new Vector4(a.w, 1, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w11y(this Vector4 a)
        {
            return new Vector4(a.w, 1, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w11z(this Vector4 a)
        {
            return new Vector4(a.w, 1, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w11w(this Vector4 a)
        {
            return new Vector4(a.w, 1, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w110(this Vector4 a)
        {
            return new Vector4(a.w, 1, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _w111(this Vector4 a)
        {
            return new Vector4(a.w, 1, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xxx(this Vector4 a)
        {
            return new Vector4(0, a.x, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xxy(this Vector4 a)
        {
            return new Vector4(0, a.x, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xxz(this Vector4 a)
        {
            return new Vector4(0, a.x, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xxw(this Vector4 a)
        {
            return new Vector4(0, a.x, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xx0(this Vector4 a)
        {
            return new Vector4(0, a.x, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xx1(this Vector4 a)
        {
            return new Vector4(0, a.x, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xyx(this Vector4 a)
        {
            return new Vector4(0, a.x, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xyy(this Vector4 a)
        {
            return new Vector4(0, a.x, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xyz(this Vector4 a)
        {
            return new Vector4(0, a.x, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xyw(this Vector4 a)
        {
            return new Vector4(0, a.x, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xy0(this Vector4 a)
        {
            return new Vector4(0, a.x, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xy1(this Vector4 a)
        {
            return new Vector4(0, a.x, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xzx(this Vector4 a)
        {
            return new Vector4(0, a.x, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xzy(this Vector4 a)
        {
            return new Vector4(0, a.x, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xzz(this Vector4 a)
        {
            return new Vector4(0, a.x, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xzw(this Vector4 a)
        {
            return new Vector4(0, a.x, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xz0(this Vector4 a)
        {
            return new Vector4(0, a.x, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xz1(this Vector4 a)
        {
            return new Vector4(0, a.x, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xwx(this Vector4 a)
        {
            return new Vector4(0, a.x, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xwy(this Vector4 a)
        {
            return new Vector4(0, a.x, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xwz(this Vector4 a)
        {
            return new Vector4(0, a.x, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xww(this Vector4 a)
        {
            return new Vector4(0, a.x, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xw0(this Vector4 a)
        {
            return new Vector4(0, a.x, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0xw1(this Vector4 a)
        {
            return new Vector4(0, a.x, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0x0x(this Vector4 a)
        {
            return new Vector4(0, a.x, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0x0y(this Vector4 a)
        {
            return new Vector4(0, a.x, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0x0z(this Vector4 a)
        {
            return new Vector4(0, a.x, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0x0w(this Vector4 a)
        {
            return new Vector4(0, a.x, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0x00(this Vector4 a)
        {
            return new Vector4(0, a.x, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0x01(this Vector4 a)
        {
            return new Vector4(0, a.x, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0x1x(this Vector4 a)
        {
            return new Vector4(0, a.x, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0x1y(this Vector4 a)
        {
            return new Vector4(0, a.x, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0x1z(this Vector4 a)
        {
            return new Vector4(0, a.x, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0x1w(this Vector4 a)
        {
            return new Vector4(0, a.x, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0x10(this Vector4 a)
        {
            return new Vector4(0, a.x, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0x11(this Vector4 a)
        {
            return new Vector4(0, a.x, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yxx(this Vector4 a)
        {
            return new Vector4(0, a.y, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yxy(this Vector4 a)
        {
            return new Vector4(0, a.y, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yxz(this Vector4 a)
        {
            return new Vector4(0, a.y, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yxw(this Vector4 a)
        {
            return new Vector4(0, a.y, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yx0(this Vector4 a)
        {
            return new Vector4(0, a.y, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yx1(this Vector4 a)
        {
            return new Vector4(0, a.y, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yyx(this Vector4 a)
        {
            return new Vector4(0, a.y, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yyy(this Vector4 a)
        {
            return new Vector4(0, a.y, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yyz(this Vector4 a)
        {
            return new Vector4(0, a.y, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yyw(this Vector4 a)
        {
            return new Vector4(0, a.y, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yy0(this Vector4 a)
        {
            return new Vector4(0, a.y, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yy1(this Vector4 a)
        {
            return new Vector4(0, a.y, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yzx(this Vector4 a)
        {
            return new Vector4(0, a.y, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yzy(this Vector4 a)
        {
            return new Vector4(0, a.y, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yzz(this Vector4 a)
        {
            return new Vector4(0, a.y, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yzw(this Vector4 a)
        {
            return new Vector4(0, a.y, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yz0(this Vector4 a)
        {
            return new Vector4(0, a.y, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yz1(this Vector4 a)
        {
            return new Vector4(0, a.y, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0ywx(this Vector4 a)
        {
            return new Vector4(0, a.y, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0ywy(this Vector4 a)
        {
            return new Vector4(0, a.y, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0ywz(this Vector4 a)
        {
            return new Vector4(0, a.y, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yww(this Vector4 a)
        {
            return new Vector4(0, a.y, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yw0(this Vector4 a)
        {
            return new Vector4(0, a.y, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0yw1(this Vector4 a)
        {
            return new Vector4(0, a.y, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0y0x(this Vector4 a)
        {
            return new Vector4(0, a.y, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0y0y(this Vector4 a)
        {
            return new Vector4(0, a.y, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0y0z(this Vector4 a)
        {
            return new Vector4(0, a.y, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0y0w(this Vector4 a)
        {
            return new Vector4(0, a.y, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0y00(this Vector4 a)
        {
            return new Vector4(0, a.y, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0y01(this Vector4 a)
        {
            return new Vector4(0, a.y, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0y1x(this Vector4 a)
        {
            return new Vector4(0, a.y, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0y1y(this Vector4 a)
        {
            return new Vector4(0, a.y, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0y1z(this Vector4 a)
        {
            return new Vector4(0, a.y, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0y1w(this Vector4 a)
        {
            return new Vector4(0, a.y, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0y10(this Vector4 a)
        {
            return new Vector4(0, a.y, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0y11(this Vector4 a)
        {
            return new Vector4(0, a.y, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zxx(this Vector4 a)
        {
            return new Vector4(0, a.z, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zxy(this Vector4 a)
        {
            return new Vector4(0, a.z, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zxz(this Vector4 a)
        {
            return new Vector4(0, a.z, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zxw(this Vector4 a)
        {
            return new Vector4(0, a.z, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zx0(this Vector4 a)
        {
            return new Vector4(0, a.z, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zx1(this Vector4 a)
        {
            return new Vector4(0, a.z, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zyx(this Vector4 a)
        {
            return new Vector4(0, a.z, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zyy(this Vector4 a)
        {
            return new Vector4(0, a.z, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zyz(this Vector4 a)
        {
            return new Vector4(0, a.z, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zyw(this Vector4 a)
        {
            return new Vector4(0, a.z, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zy0(this Vector4 a)
        {
            return new Vector4(0, a.z, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zy1(this Vector4 a)
        {
            return new Vector4(0, a.z, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zzx(this Vector4 a)
        {
            return new Vector4(0, a.z, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zzy(this Vector4 a)
        {
            return new Vector4(0, a.z, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zzz(this Vector4 a)
        {
            return new Vector4(0, a.z, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zzw(this Vector4 a)
        {
            return new Vector4(0, a.z, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zz0(this Vector4 a)
        {
            return new Vector4(0, a.z, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zz1(this Vector4 a)
        {
            return new Vector4(0, a.z, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zwx(this Vector4 a)
        {
            return new Vector4(0, a.z, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zwy(this Vector4 a)
        {
            return new Vector4(0, a.z, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zwz(this Vector4 a)
        {
            return new Vector4(0, a.z, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zww(this Vector4 a)
        {
            return new Vector4(0, a.z, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zw0(this Vector4 a)
        {
            return new Vector4(0, a.z, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0zw1(this Vector4 a)
        {
            return new Vector4(0, a.z, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0z0x(this Vector4 a)
        {
            return new Vector4(0, a.z, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0z0y(this Vector4 a)
        {
            return new Vector4(0, a.z, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0z0z(this Vector4 a)
        {
            return new Vector4(0, a.z, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0z0w(this Vector4 a)
        {
            return new Vector4(0, a.z, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0z00(this Vector4 a)
        {
            return new Vector4(0, a.z, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0z01(this Vector4 a)
        {
            return new Vector4(0, a.z, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0z1x(this Vector4 a)
        {
            return new Vector4(0, a.z, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0z1y(this Vector4 a)
        {
            return new Vector4(0, a.z, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0z1z(this Vector4 a)
        {
            return new Vector4(0, a.z, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0z1w(this Vector4 a)
        {
            return new Vector4(0, a.z, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0z10(this Vector4 a)
        {
            return new Vector4(0, a.z, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0z11(this Vector4 a)
        {
            return new Vector4(0, a.z, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0wxx(this Vector4 a)
        {
            return new Vector4(0, a.w, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0wxy(this Vector4 a)
        {
            return new Vector4(0, a.w, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0wxz(this Vector4 a)
        {
            return new Vector4(0, a.w, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0wxw(this Vector4 a)
        {
            return new Vector4(0, a.w, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0wx0(this Vector4 a)
        {
            return new Vector4(0, a.w, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0wx1(this Vector4 a)
        {
            return new Vector4(0, a.w, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0wyx(this Vector4 a)
        {
            return new Vector4(0, a.w, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0wyy(this Vector4 a)
        {
            return new Vector4(0, a.w, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0wyz(this Vector4 a)
        {
            return new Vector4(0, a.w, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0wyw(this Vector4 a)
        {
            return new Vector4(0, a.w, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0wy0(this Vector4 a)
        {
            return new Vector4(0, a.w, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0wy1(this Vector4 a)
        {
            return new Vector4(0, a.w, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0wzx(this Vector4 a)
        {
            return new Vector4(0, a.w, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0wzy(this Vector4 a)
        {
            return new Vector4(0, a.w, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0wzz(this Vector4 a)
        {
            return new Vector4(0, a.w, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0wzw(this Vector4 a)
        {
            return new Vector4(0, a.w, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0wz0(this Vector4 a)
        {
            return new Vector4(0, a.w, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0wz1(this Vector4 a)
        {
            return new Vector4(0, a.w, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0wwx(this Vector4 a)
        {
            return new Vector4(0, a.w, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0wwy(this Vector4 a)
        {
            return new Vector4(0, a.w, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0wwz(this Vector4 a)
        {
            return new Vector4(0, a.w, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0www(this Vector4 a)
        {
            return new Vector4(0, a.w, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0ww0(this Vector4 a)
        {
            return new Vector4(0, a.w, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0ww1(this Vector4 a)
        {
            return new Vector4(0, a.w, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0w0x(this Vector4 a)
        {
            return new Vector4(0, a.w, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0w0y(this Vector4 a)
        {
            return new Vector4(0, a.w, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0w0z(this Vector4 a)
        {
            return new Vector4(0, a.w, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0w0w(this Vector4 a)
        {
            return new Vector4(0, a.w, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0w00(this Vector4 a)
        {
            return new Vector4(0, a.w, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0w01(this Vector4 a)
        {
            return new Vector4(0, a.w, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0w1x(this Vector4 a)
        {
            return new Vector4(0, a.w, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0w1y(this Vector4 a)
        {
            return new Vector4(0, a.w, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0w1z(this Vector4 a)
        {
            return new Vector4(0, a.w, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0w1w(this Vector4 a)
        {
            return new Vector4(0, a.w, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0w10(this Vector4 a)
        {
            return new Vector4(0, a.w, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0w11(this Vector4 a)
        {
            return new Vector4(0, a.w, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00xx(this Vector4 a)
        {
            return new Vector4(0, 0, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00xy(this Vector4 a)
        {
            return new Vector4(0, 0, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00xz(this Vector4 a)
        {
            return new Vector4(0, 0, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00xw(this Vector4 a)
        {
            return new Vector4(0, 0, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00x0(this Vector4 a)
        {
            return new Vector4(0, 0, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00x1(this Vector4 a)
        {
            return new Vector4(0, 0, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00yx(this Vector4 a)
        {
            return new Vector4(0, 0, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00yy(this Vector4 a)
        {
            return new Vector4(0, 0, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00yz(this Vector4 a)
        {
            return new Vector4(0, 0, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00yw(this Vector4 a)
        {
            return new Vector4(0, 0, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00y0(this Vector4 a)
        {
            return new Vector4(0, 0, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00y1(this Vector4 a)
        {
            return new Vector4(0, 0, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00zx(this Vector4 a)
        {
            return new Vector4(0, 0, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00zy(this Vector4 a)
        {
            return new Vector4(0, 0, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00zz(this Vector4 a)
        {
            return new Vector4(0, 0, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00zw(this Vector4 a)
        {
            return new Vector4(0, 0, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00z0(this Vector4 a)
        {
            return new Vector4(0, 0, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00z1(this Vector4 a)
        {
            return new Vector4(0, 0, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00wx(this Vector4 a)
        {
            return new Vector4(0, 0, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00wy(this Vector4 a)
        {
            return new Vector4(0, 0, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00wz(this Vector4 a)
        {
            return new Vector4(0, 0, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00ww(this Vector4 a)
        {
            return new Vector4(0, 0, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00w0(this Vector4 a)
        {
            return new Vector4(0, 0, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _00w1(this Vector4 a)
        {
            return new Vector4(0, 0, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _000x(this Vector4 a)
        {
            return new Vector4(0, 0, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _000y(this Vector4 a)
        {
            return new Vector4(0, 0, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _000z(this Vector4 a)
        {
            return new Vector4(0, 0, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _000w(this Vector4 a)
        {
            return new Vector4(0, 0, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0000(this Vector4 a)
        {
            return new Vector4(0, 0, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0001(this Vector4 a)
        {
            return new Vector4(0, 0, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _001x(this Vector4 a)
        {
            return new Vector4(0, 0, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _001y(this Vector4 a)
        {
            return new Vector4(0, 0, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _001z(this Vector4 a)
        {
            return new Vector4(0, 0, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _001w(this Vector4 a)
        {
            return new Vector4(0, 0, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0010(this Vector4 a)
        {
            return new Vector4(0, 0, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0011(this Vector4 a)
        {
            return new Vector4(0, 0, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01xx(this Vector4 a)
        {
            return new Vector4(0, 1, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01xy(this Vector4 a)
        {
            return new Vector4(0, 1, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01xz(this Vector4 a)
        {
            return new Vector4(0, 1, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01xw(this Vector4 a)
        {
            return new Vector4(0, 1, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01x0(this Vector4 a)
        {
            return new Vector4(0, 1, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01x1(this Vector4 a)
        {
            return new Vector4(0, 1, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01yx(this Vector4 a)
        {
            return new Vector4(0, 1, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01yy(this Vector4 a)
        {
            return new Vector4(0, 1, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01yz(this Vector4 a)
        {
            return new Vector4(0, 1, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01yw(this Vector4 a)
        {
            return new Vector4(0, 1, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01y0(this Vector4 a)
        {
            return new Vector4(0, 1, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01y1(this Vector4 a)
        {
            return new Vector4(0, 1, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01zx(this Vector4 a)
        {
            return new Vector4(0, 1, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01zy(this Vector4 a)
        {
            return new Vector4(0, 1, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01zz(this Vector4 a)
        {
            return new Vector4(0, 1, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01zw(this Vector4 a)
        {
            return new Vector4(0, 1, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01z0(this Vector4 a)
        {
            return new Vector4(0, 1, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01z1(this Vector4 a)
        {
            return new Vector4(0, 1, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01wx(this Vector4 a)
        {
            return new Vector4(0, 1, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01wy(this Vector4 a)
        {
            return new Vector4(0, 1, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01wz(this Vector4 a)
        {
            return new Vector4(0, 1, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01ww(this Vector4 a)
        {
            return new Vector4(0, 1, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01w0(this Vector4 a)
        {
            return new Vector4(0, 1, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _01w1(this Vector4 a)
        {
            return new Vector4(0, 1, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _010x(this Vector4 a)
        {
            return new Vector4(0, 1, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _010y(this Vector4 a)
        {
            return new Vector4(0, 1, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _010z(this Vector4 a)
        {
            return new Vector4(0, 1, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _010w(this Vector4 a)
        {
            return new Vector4(0, 1, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0100(this Vector4 a)
        {
            return new Vector4(0, 1, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0101(this Vector4 a)
        {
            return new Vector4(0, 1, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _011x(this Vector4 a)
        {
            return new Vector4(0, 1, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _011y(this Vector4 a)
        {
            return new Vector4(0, 1, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _011z(this Vector4 a)
        {
            return new Vector4(0, 1, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _011w(this Vector4 a)
        {
            return new Vector4(0, 1, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0110(this Vector4 a)
        {
            return new Vector4(0, 1, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _0111(this Vector4 a)
        {
            return new Vector4(0, 1, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xxx(this Vector4 a)
        {
            return new Vector4(1, a.x, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xxy(this Vector4 a)
        {
            return new Vector4(1, a.x, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xxz(this Vector4 a)
        {
            return new Vector4(1, a.x, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xxw(this Vector4 a)
        {
            return new Vector4(1, a.x, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xx0(this Vector4 a)
        {
            return new Vector4(1, a.x, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xx1(this Vector4 a)
        {
            return new Vector4(1, a.x, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xyx(this Vector4 a)
        {
            return new Vector4(1, a.x, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xyy(this Vector4 a)
        {
            return new Vector4(1, a.x, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xyz(this Vector4 a)
        {
            return new Vector4(1, a.x, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xyw(this Vector4 a)
        {
            return new Vector4(1, a.x, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xy0(this Vector4 a)
        {
            return new Vector4(1, a.x, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xy1(this Vector4 a)
        {
            return new Vector4(1, a.x, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xzx(this Vector4 a)
        {
            return new Vector4(1, a.x, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xzy(this Vector4 a)
        {
            return new Vector4(1, a.x, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xzz(this Vector4 a)
        {
            return new Vector4(1, a.x, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xzw(this Vector4 a)
        {
            return new Vector4(1, a.x, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xz0(this Vector4 a)
        {
            return new Vector4(1, a.x, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xz1(this Vector4 a)
        {
            return new Vector4(1, a.x, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xwx(this Vector4 a)
        {
            return new Vector4(1, a.x, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xwy(this Vector4 a)
        {
            return new Vector4(1, a.x, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xwz(this Vector4 a)
        {
            return new Vector4(1, a.x, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xww(this Vector4 a)
        {
            return new Vector4(1, a.x, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xw0(this Vector4 a)
        {
            return new Vector4(1, a.x, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1xw1(this Vector4 a)
        {
            return new Vector4(1, a.x, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1x0x(this Vector4 a)
        {
            return new Vector4(1, a.x, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1x0y(this Vector4 a)
        {
            return new Vector4(1, a.x, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1x0z(this Vector4 a)
        {
            return new Vector4(1, a.x, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1x0w(this Vector4 a)
        {
            return new Vector4(1, a.x, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1x00(this Vector4 a)
        {
            return new Vector4(1, a.x, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1x01(this Vector4 a)
        {
            return new Vector4(1, a.x, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1x1x(this Vector4 a)
        {
            return new Vector4(1, a.x, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1x1y(this Vector4 a)
        {
            return new Vector4(1, a.x, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1x1z(this Vector4 a)
        {
            return new Vector4(1, a.x, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1x1w(this Vector4 a)
        {
            return new Vector4(1, a.x, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1x10(this Vector4 a)
        {
            return new Vector4(1, a.x, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1x11(this Vector4 a)
        {
            return new Vector4(1, a.x, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yxx(this Vector4 a)
        {
            return new Vector4(1, a.y, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yxy(this Vector4 a)
        {
            return new Vector4(1, a.y, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yxz(this Vector4 a)
        {
            return new Vector4(1, a.y, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yxw(this Vector4 a)
        {
            return new Vector4(1, a.y, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yx0(this Vector4 a)
        {
            return new Vector4(1, a.y, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yx1(this Vector4 a)
        {
            return new Vector4(1, a.y, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yyx(this Vector4 a)
        {
            return new Vector4(1, a.y, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yyy(this Vector4 a)
        {
            return new Vector4(1, a.y, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yyz(this Vector4 a)
        {
            return new Vector4(1, a.y, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yyw(this Vector4 a)
        {
            return new Vector4(1, a.y, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yy0(this Vector4 a)
        {
            return new Vector4(1, a.y, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yy1(this Vector4 a)
        {
            return new Vector4(1, a.y, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yzx(this Vector4 a)
        {
            return new Vector4(1, a.y, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yzy(this Vector4 a)
        {
            return new Vector4(1, a.y, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yzz(this Vector4 a)
        {
            return new Vector4(1, a.y, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yzw(this Vector4 a)
        {
            return new Vector4(1, a.y, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yz0(this Vector4 a)
        {
            return new Vector4(1, a.y, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yz1(this Vector4 a)
        {
            return new Vector4(1, a.y, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1ywx(this Vector4 a)
        {
            return new Vector4(1, a.y, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1ywy(this Vector4 a)
        {
            return new Vector4(1, a.y, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1ywz(this Vector4 a)
        {
            return new Vector4(1, a.y, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yww(this Vector4 a)
        {
            return new Vector4(1, a.y, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yw0(this Vector4 a)
        {
            return new Vector4(1, a.y, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1yw1(this Vector4 a)
        {
            return new Vector4(1, a.y, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1y0x(this Vector4 a)
        {
            return new Vector4(1, a.y, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1y0y(this Vector4 a)
        {
            return new Vector4(1, a.y, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1y0z(this Vector4 a)
        {
            return new Vector4(1, a.y, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1y0w(this Vector4 a)
        {
            return new Vector4(1, a.y, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1y00(this Vector4 a)
        {
            return new Vector4(1, a.y, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1y01(this Vector4 a)
        {
            return new Vector4(1, a.y, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1y1x(this Vector4 a)
        {
            return new Vector4(1, a.y, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1y1y(this Vector4 a)
        {
            return new Vector4(1, a.y, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1y1z(this Vector4 a)
        {
            return new Vector4(1, a.y, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1y1w(this Vector4 a)
        {
            return new Vector4(1, a.y, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1y10(this Vector4 a)
        {
            return new Vector4(1, a.y, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1y11(this Vector4 a)
        {
            return new Vector4(1, a.y, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zxx(this Vector4 a)
        {
            return new Vector4(1, a.z, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zxy(this Vector4 a)
        {
            return new Vector4(1, a.z, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zxz(this Vector4 a)
        {
            return new Vector4(1, a.z, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zxw(this Vector4 a)
        {
            return new Vector4(1, a.z, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zx0(this Vector4 a)
        {
            return new Vector4(1, a.z, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zx1(this Vector4 a)
        {
            return new Vector4(1, a.z, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zyx(this Vector4 a)
        {
            return new Vector4(1, a.z, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zyy(this Vector4 a)
        {
            return new Vector4(1, a.z, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zyz(this Vector4 a)
        {
            return new Vector4(1, a.z, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zyw(this Vector4 a)
        {
            return new Vector4(1, a.z, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zy0(this Vector4 a)
        {
            return new Vector4(1, a.z, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zy1(this Vector4 a)
        {
            return new Vector4(1, a.z, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zzx(this Vector4 a)
        {
            return new Vector4(1, a.z, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zzy(this Vector4 a)
        {
            return new Vector4(1, a.z, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zzz(this Vector4 a)
        {
            return new Vector4(1, a.z, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zzw(this Vector4 a)
        {
            return new Vector4(1, a.z, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zz0(this Vector4 a)
        {
            return new Vector4(1, a.z, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zz1(this Vector4 a)
        {
            return new Vector4(1, a.z, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zwx(this Vector4 a)
        {
            return new Vector4(1, a.z, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zwy(this Vector4 a)
        {
            return new Vector4(1, a.z, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zwz(this Vector4 a)
        {
            return new Vector4(1, a.z, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zww(this Vector4 a)
        {
            return new Vector4(1, a.z, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zw0(this Vector4 a)
        {
            return new Vector4(1, a.z, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1zw1(this Vector4 a)
        {
            return new Vector4(1, a.z, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1z0x(this Vector4 a)
        {
            return new Vector4(1, a.z, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1z0y(this Vector4 a)
        {
            return new Vector4(1, a.z, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1z0z(this Vector4 a)
        {
            return new Vector4(1, a.z, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1z0w(this Vector4 a)
        {
            return new Vector4(1, a.z, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1z00(this Vector4 a)
        {
            return new Vector4(1, a.z, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1z01(this Vector4 a)
        {
            return new Vector4(1, a.z, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1z1x(this Vector4 a)
        {
            return new Vector4(1, a.z, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1z1y(this Vector4 a)
        {
            return new Vector4(1, a.z, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1z1z(this Vector4 a)
        {
            return new Vector4(1, a.z, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1z1w(this Vector4 a)
        {
            return new Vector4(1, a.z, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1z10(this Vector4 a)
        {
            return new Vector4(1, a.z, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1z11(this Vector4 a)
        {
            return new Vector4(1, a.z, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1wxx(this Vector4 a)
        {
            return new Vector4(1, a.w, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1wxy(this Vector4 a)
        {
            return new Vector4(1, a.w, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1wxz(this Vector4 a)
        {
            return new Vector4(1, a.w, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1wxw(this Vector4 a)
        {
            return new Vector4(1, a.w, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1wx0(this Vector4 a)
        {
            return new Vector4(1, a.w, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1wx1(this Vector4 a)
        {
            return new Vector4(1, a.w, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1wyx(this Vector4 a)
        {
            return new Vector4(1, a.w, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1wyy(this Vector4 a)
        {
            return new Vector4(1, a.w, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1wyz(this Vector4 a)
        {
            return new Vector4(1, a.w, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1wyw(this Vector4 a)
        {
            return new Vector4(1, a.w, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1wy0(this Vector4 a)
        {
            return new Vector4(1, a.w, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1wy1(this Vector4 a)
        {
            return new Vector4(1, a.w, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1wzx(this Vector4 a)
        {
            return new Vector4(1, a.w, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1wzy(this Vector4 a)
        {
            return new Vector4(1, a.w, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1wzz(this Vector4 a)
        {
            return new Vector4(1, a.w, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1wzw(this Vector4 a)
        {
            return new Vector4(1, a.w, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1wz0(this Vector4 a)
        {
            return new Vector4(1, a.w, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1wz1(this Vector4 a)
        {
            return new Vector4(1, a.w, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1wwx(this Vector4 a)
        {
            return new Vector4(1, a.w, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1wwy(this Vector4 a)
        {
            return new Vector4(1, a.w, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1wwz(this Vector4 a)
        {
            return new Vector4(1, a.w, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1www(this Vector4 a)
        {
            return new Vector4(1, a.w, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1ww0(this Vector4 a)
        {
            return new Vector4(1, a.w, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1ww1(this Vector4 a)
        {
            return new Vector4(1, a.w, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1w0x(this Vector4 a)
        {
            return new Vector4(1, a.w, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1w0y(this Vector4 a)
        {
            return new Vector4(1, a.w, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1w0z(this Vector4 a)
        {
            return new Vector4(1, a.w, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1w0w(this Vector4 a)
        {
            return new Vector4(1, a.w, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1w00(this Vector4 a)
        {
            return new Vector4(1, a.w, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1w01(this Vector4 a)
        {
            return new Vector4(1, a.w, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1w1x(this Vector4 a)
        {
            return new Vector4(1, a.w, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1w1y(this Vector4 a)
        {
            return new Vector4(1, a.w, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1w1z(this Vector4 a)
        {
            return new Vector4(1, a.w, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1w1w(this Vector4 a)
        {
            return new Vector4(1, a.w, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1w10(this Vector4 a)
        {
            return new Vector4(1, a.w, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1w11(this Vector4 a)
        {
            return new Vector4(1, a.w, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10xx(this Vector4 a)
        {
            return new Vector4(1, 0, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10xy(this Vector4 a)
        {
            return new Vector4(1, 0, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10xz(this Vector4 a)
        {
            return new Vector4(1, 0, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10xw(this Vector4 a)
        {
            return new Vector4(1, 0, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10x0(this Vector4 a)
        {
            return new Vector4(1, 0, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10x1(this Vector4 a)
        {
            return new Vector4(1, 0, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10yx(this Vector4 a)
        {
            return new Vector4(1, 0, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10yy(this Vector4 a)
        {
            return new Vector4(1, 0, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10yz(this Vector4 a)
        {
            return new Vector4(1, 0, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10yw(this Vector4 a)
        {
            return new Vector4(1, 0, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10y0(this Vector4 a)
        {
            return new Vector4(1, 0, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10y1(this Vector4 a)
        {
            return new Vector4(1, 0, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10zx(this Vector4 a)
        {
            return new Vector4(1, 0, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10zy(this Vector4 a)
        {
            return new Vector4(1, 0, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10zz(this Vector4 a)
        {
            return new Vector4(1, 0, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10zw(this Vector4 a)
        {
            return new Vector4(1, 0, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10z0(this Vector4 a)
        {
            return new Vector4(1, 0, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10z1(this Vector4 a)
        {
            return new Vector4(1, 0, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10wx(this Vector4 a)
        {
            return new Vector4(1, 0, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10wy(this Vector4 a)
        {
            return new Vector4(1, 0, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10wz(this Vector4 a)
        {
            return new Vector4(1, 0, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10ww(this Vector4 a)
        {
            return new Vector4(1, 0, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10w0(this Vector4 a)
        {
            return new Vector4(1, 0, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _10w1(this Vector4 a)
        {
            return new Vector4(1, 0, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _100x(this Vector4 a)
        {
            return new Vector4(1, 0, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _100y(this Vector4 a)
        {
            return new Vector4(1, 0, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _100z(this Vector4 a)
        {
            return new Vector4(1, 0, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _100w(this Vector4 a)
        {
            return new Vector4(1, 0, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1000(this Vector4 a)
        {
            return new Vector4(1, 0, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1001(this Vector4 a)
        {
            return new Vector4(1, 0, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _101x(this Vector4 a)
        {
            return new Vector4(1, 0, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _101y(this Vector4 a)
        {
            return new Vector4(1, 0, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _101z(this Vector4 a)
        {
            return new Vector4(1, 0, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _101w(this Vector4 a)
        {
            return new Vector4(1, 0, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1010(this Vector4 a)
        {
            return new Vector4(1, 0, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1011(this Vector4 a)
        {
            return new Vector4(1, 0, 1, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11xx(this Vector4 a)
        {
            return new Vector4(1, 1, a.x, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11xy(this Vector4 a)
        {
            return new Vector4(1, 1, a.x, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11xz(this Vector4 a)
        {
            return new Vector4(1, 1, a.x, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11xw(this Vector4 a)
        {
            return new Vector4(1, 1, a.x, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11x0(this Vector4 a)
        {
            return new Vector4(1, 1, a.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11x1(this Vector4 a)
        {
            return new Vector4(1, 1, a.x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11yx(this Vector4 a)
        {
            return new Vector4(1, 1, a.y, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11yy(this Vector4 a)
        {
            return new Vector4(1, 1, a.y, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11yz(this Vector4 a)
        {
            return new Vector4(1, 1, a.y, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11yw(this Vector4 a)
        {
            return new Vector4(1, 1, a.y, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11y0(this Vector4 a)
        {
            return new Vector4(1, 1, a.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11y1(this Vector4 a)
        {
            return new Vector4(1, 1, a.y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11zx(this Vector4 a)
        {
            return new Vector4(1, 1, a.z, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11zy(this Vector4 a)
        {
            return new Vector4(1, 1, a.z, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11zz(this Vector4 a)
        {
            return new Vector4(1, 1, a.z, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11zw(this Vector4 a)
        {
            return new Vector4(1, 1, a.z, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11z0(this Vector4 a)
        {
            return new Vector4(1, 1, a.z, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11z1(this Vector4 a)
        {
            return new Vector4(1, 1, a.z, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11wx(this Vector4 a)
        {
            return new Vector4(1, 1, a.w, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11wy(this Vector4 a)
        {
            return new Vector4(1, 1, a.w, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11wz(this Vector4 a)
        {
            return new Vector4(1, 1, a.w, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11ww(this Vector4 a)
        {
            return new Vector4(1, 1, a.w, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11w0(this Vector4 a)
        {
            return new Vector4(1, 1, a.w, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _11w1(this Vector4 a)
        {
            return new Vector4(1, 1, a.w, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _110x(this Vector4 a)
        {
            return new Vector4(1, 1, 0, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _110y(this Vector4 a)
        {
            return new Vector4(1, 1, 0, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _110z(this Vector4 a)
        {
            return new Vector4(1, 1, 0, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _110w(this Vector4 a)
        {
            return new Vector4(1, 1, 0, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1100(this Vector4 a)
        {
            return new Vector4(1, 1, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1101(this Vector4 a)
        {
            return new Vector4(1, 1, 0, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _111x(this Vector4 a)
        {
            return new Vector4(1, 1, 1, a.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _111y(this Vector4 a)
        {
            return new Vector4(1, 1, 1, a.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _111z(this Vector4 a)
        {
            return new Vector4(1, 1, 1, a.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _111w(this Vector4 a)
        {
            return new Vector4(1, 1, 1, a.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1110(this Vector4 a)
        {
            return new Vector4(1, 1, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 _1111(this Vector4 a)
        {
            return new Vector4(1, 1, 1, 1);
        }
    }
}