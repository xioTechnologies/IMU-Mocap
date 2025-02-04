Shader "Plot/Fresnel"
{
    Properties
    {
        _InnerColor ("Inner Color", Color) = (1,1,1,1)
        _FresnelColor ("Fresnel Color", Color) = (1,1,1,1)
        _FresnelPower ("Fresnel Power", Range(0.1, 10)) = 5
        _FresnelIntensity ("Fresnel Intensity", Range(0, 1)) = 1
    }
    
    SubShader
    {
        Tags 
        { 
            "RenderType" = "Transparent"
            "RenderPipeline" = "UniversalPipeline"
            "Queue" = "Transparent+1"  // Render after the projection
        }

        Pass
        {
            Name "Forward"
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 position : POSITION;
                float3 normal : NORMAL;
            };

            struct Varyings
            {
                float4 position : SV_POSITION;
                float3 normal : TEXCOORD0;
                float3 viewDir : TEXCOORD1;
            };
            
            CBUFFER_START(UnityPerMaterial)
                float4 _InnerColor;
                float4 _FresnelColor;
                float _FresnelPower;
                float _FresnelIntensity;
            CBUFFER_END

            Varyings vert(Attributes input)
            {
                Varyings output;
                
                VertexPositionInputs posInputs = GetVertexPositionInputs(input.position.xyz);
                output.position = posInputs.positionCS;
                
                VertexNormalInputs normalInputs = GetVertexNormalInputs(input.normal);
                output.normal = normalInputs.normalWS;
                
                output.viewDir = GetWorldSpaceViewDir(posInputs.positionWS);
                
                return output;
            }

            float4 frag(Varyings input) : SV_Target
            {
                float3 normalWS = normalize(input.normal);
                
                float3 viewDirWS = normalize(input.viewDir);
                
                float fresnelFactor = pow(1.0 - saturate(dot(normalWS, viewDirWS)), _FresnelPower);
                
                return lerp(_InnerColor, _FresnelColor, fresnelFactor * _FresnelIntensity);
            }
            ENDHLSL
        }
    }
}