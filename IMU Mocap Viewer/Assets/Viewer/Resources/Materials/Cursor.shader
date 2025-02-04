Shader "Plot/Cursor"
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

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct Attributes
            {
                float4 position : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 position : SV_POSITION;
                float2 uv : TEXCOORD0;
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
                
                VertexPositionInputs posInputs = GetVertexPositionInputs(input.position.xyz);
                output.position = posInputs.positionCS;
                
                output.uv = input.uv;
                
                return output;
            }

            float4 frag(Varyings input) : SV_Target
            {
                float4 texColor = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, input.uv);

                clip(texColor.a - 0.5);
                
                float4 finalColor = lerp(_TipColor, _MiddleColor, texColor.r);

                finalColor.a = texColor.a;
                
                return finalColor;
            }
            ENDHLSL
        }
    }
}