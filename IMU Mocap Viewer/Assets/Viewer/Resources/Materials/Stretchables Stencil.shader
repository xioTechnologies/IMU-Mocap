Shader "Plot/Stretchables (Stencil)"
{
    Properties 
    { 
        _PixelScaleFactor ("Pixel Scale Factor", Float) = 1.0
        _StencilValue ("Stencil Value", Int) = 10
    }
    
    SubShader
    {
        Tags 
        { 
            "RenderType" = "Opaque"
            "RenderPipeline" = "UniversalPipeline"
        } 
        LOD 100

        Pass
        {
            Name "Stretchable"
            
            Stencil
            {
                Ref [_StencilValue]
                Comp GEqual
                Pass Replace
            }
            
            ZWrite On
            ZTest LESS
            
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 4.5
            
            #include "StretchablesShared.hlsl"
            
            ENDHLSL
        }
    }
}