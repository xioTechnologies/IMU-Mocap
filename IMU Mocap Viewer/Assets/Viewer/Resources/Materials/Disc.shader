Shader "Plot/Disc"
{
    Properties
    {
        _CenterColor ("Center Color", Color) = (1,1,1,1)
        _EdgeColor ("Edge Color", Color) = (0,0,0,1)
        _Radius ("Radius", Range(0,1)) = 0.5
        _Softness ("Edge Softness", Range(0,1)) = 0.1
    }
    SubShader
    {
        Tags 
        { 
            "RenderType" = "Transparent"
            "RenderPipeline" = "UniversalPipeline"
            "Queue" = "Transparent"
        }

        Pass
        {
            Name "Unlit"
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            Cull Off  

            HLSLPROGRAM
            #pragma target 4.5
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            CBUFFER_START(UnityPerMaterial)
                float4 _CenterColor;
                float4 _EdgeColor;
                float _Radius;
                float _Softness;
            CBUFFER_END

            Varyings vert(Attributes input)
            {
                Varyings output;
                output.positionCS = TransformObjectToHClip(input.positionOS.xyz);
                output.uv = input.uv;
                return output;
            }

            float4 frag(Varyings input) : SV_Target
            {
                float2 centeredUV = input.uv - 0.5;
                
                float dist = length(centeredUV);
                
                float t = smoothstep(_Radius - _Softness, _Radius, dist);
                
                float4 finalColor =  lerp(_CenterColor, _EdgeColor, t);
                
                finalColor.a *= 1.0 - smoothstep(_Radius, _Radius + _Softness, dist);
                
                return finalColor;
            }
            ENDHLSL
        }
    }
}