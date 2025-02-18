Shader "Plot/Stretchable (Stencil)"
{
    Properties 
    { 
        _MainTex ("Texture", 2D) = "white" {}
        _Thickness ("Thickness", Float) = 1.0
        _NearColor ("Near Color", Color) = (1,1,1,1)
        _FarColor ("Far Color", Color) = (1,1,1,1)
        
        _PixelScaleFactor ("Pixel Scale Factor", Float) = 1.0
        
        _StencilValue ("Stencil Value", Float) = 1
    }
    
    SubShader
    {
        Tags
        {
            "RenderType" = "Transparent"
            "RenderPipeline" = "UniversalPipeline"
            "Queue" = "Transparent"
        }
        LOD 100
        
        Pass
        {
            Name "Stretchable"
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            Stencil
            {
                Ref [_StencilValue]
                Comp GEqual
                Pass Replace
            }
            
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 4.5
            
            #include "StretchableShared.hlsl"
            ENDHLSL
        }
    }
}