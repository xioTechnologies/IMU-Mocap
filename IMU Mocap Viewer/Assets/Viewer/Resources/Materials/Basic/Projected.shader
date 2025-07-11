Shader "Plot/Projected"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}

        _TipColor ("Tip Color", Color) = (1,1,1,1)
        _MiddleColor ("Middle Color", Color) = (1,1,1,1)
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
            Name "Forward"
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZTest Always

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct Attributes
            {
                float4 position : POSITION;
                float3 normal : NORMAL;
            };

            struct Varyings
            {
                float4 position : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : TEXCOORD1;
                float3 viewDir : TEXCOORD2;
                float og_normal : TEXCOORD3;
            };

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);

            CBUFFER_START(UnityPerMaterial)
                float4 _MainTex_ST;
                float4 _TipColor;
                float4 _MiddleColor;
            CBUFFER_END

            Varyings vert(Attributes input)
            {
                Varyings output;

                VertexPositionInputs positionInputs = GetVertexPositionInputs(input.position.xyz);
                output.position = positionInputs.positionCS;

                output.uv = input.position.xy + 0.5;

                output.og_normal = dot(input.normal, float3(0, 0, 1)) > 0 ? 0 : 1;

                VertexNormalInputs normalInputs = GetVertexNormalInputs(input.normal);
                output.normal = normalInputs.normalWS;

                output.viewDir = GetWorldSpaceViewDir(positionInputs.positionWS);

                return output;
            }

            float4 frag(Varyings input) : SV_Target
            {
                float4 texColor = lerp(
                    SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, input.uv), float4(0, 0, 0, 0), input.og_normal);

                clip(texColor.a - 0.5);

                float4 finalColor = lerp(_TipColor, _MiddleColor, texColor.r);

                finalColor.a = texColor.a;

                return finalColor;
            }
            ENDHLSL
        }
    }
}