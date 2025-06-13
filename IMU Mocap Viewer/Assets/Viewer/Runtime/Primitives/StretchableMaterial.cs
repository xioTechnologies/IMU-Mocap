using System;
using UnityEngine;

namespace Viewer.Runtime.Primitives
{
    public static class StretchableMaterial
    {
        public static readonly int InstancesProperty = Shader.PropertyToID("_Instances");
        public static readonly int PixelScaleFactor = Shader.PropertyToID("_PixelScaleFactor");

        public static readonly int StencilValue = Shader.PropertyToID("_StencilValue");
        public static readonly int StencilComp = Shader.PropertyToID("_StencilComp");
        public static readonly int StencilPass = Shader.PropertyToID("_StencilPass");

        public static readonly int SrcBlend = Shader.PropertyToID("_SrcBlend");
        public static readonly int DstBlend = Shader.PropertyToID("_DstBlend");

        public static readonly int ThicknessProperty = Shader.PropertyToID("_Thickness");
        public static readonly int NearColorProperty = Shader.PropertyToID("_NearColor");
        public static readonly int FarColorProperty = Shader.PropertyToID("_FarColor");

        public static readonly int StartAngleProperty = Shader.PropertyToID("_StartAngle");
        public static readonly int EndAngleProperty = Shader.PropertyToID("_EndAngle");

        public const int OpaqueRenderQueue = 2256;
        public const int TransparentRenderQueue = 3500;

        public static void EnableAngles(this Material material, bool enabled)
        {
            if (material.IsKeywordEnabled("ANGLES_ENABLED") == enabled) return;

            if (enabled) material.EnableKeyword("ANGLES_ENABLED");
            else material.DisableKeyword("ANGLES_ENABLED");
        }

        public static int GetRenderQueueIndex(DrawType type)
        {
            return type switch
            {
                DrawType.Opaque => OpaqueRenderQueue,
                DrawType.Transparent => TransparentRenderQueue,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }

        public static void SetRenderOrder(this Material material, DrawType drawType, int order)
        {
            material.renderQueue = GetRenderQueueIndex(drawType) - order;
        }

        public static void SetBlendMode(this Material material, DrawType drawType)
        {
            switch (drawType)
            {
                case DrawType.Opaque:
                    material.SetInt(SrcBlend, (int)UnityEngine.Rendering.BlendMode.One);
                    material.SetInt(DstBlend, (int)UnityEngine.Rendering.BlendMode.Zero);
                    break;
                case DrawType.Transparent:
                    material.SetInt(SrcBlend, (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                    material.SetInt(DstBlend, (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static void ConfigureStencil(this Material material, StencilMode stencilMode, int order)
        {
            switch (stencilMode)
            {
                case StencilMode.None:
                    material.SetInt(StencilComp, (int)UnityEngine.Rendering.CompareFunction.Always);
                    material.SetInt(StencilPass, (int)UnityEngine.Rendering.StencilOp.Keep);
                    break;
                case StencilMode.Stencil:
                    material.SetInt(StencilComp, (int)UnityEngine.Rendering.CompareFunction.GreaterEqual);
                    material.SetInt(StencilPass, (int)UnityEngine.Rendering.StencilOp.Replace);
                    material.SetInt(StencilValue, Mathf.Clamp(order, 0, 255));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}