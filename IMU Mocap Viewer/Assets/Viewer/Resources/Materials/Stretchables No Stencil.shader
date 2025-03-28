Shader "Plot/Stretchables (No Stencil)"
{
    Properties 
    { 
        _PixelScaleFactor ("Pixel Scale Factor", Float) = 1.0
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