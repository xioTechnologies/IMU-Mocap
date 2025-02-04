Shader "Plot/Stretchable"
{
    Properties 
    { 
        _MainTex ("Texture", 2D) = "white" {}
        _Thickness ("Thickness", Float) = 1.0
        _NearColor ("Near Color", Color) = (1,1,1,1)
        _FarColor ("Far Color", Color) = (1,1,1,1)
        _PixelScaleFactor ("Pixel Scale Factor", Float) = 1.0
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
            
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 4.5
            
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float4 thick : TANGENT;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float4 color : COLOR;
            };

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);
            
           CBUFFER_START(UnityPerMaterial)
                float4x4 _ObjectTransform;
                float _Thickness;
                float _PixelScaleFactor;
                float4 _NearColor;
                float4 _FarColor;
            CBUFFER_END

            float3x3 GetRotationMatrix(float4x4 m)
            {
                // Assuming uniform scale, if any
                float3 x = normalize(m[0].xyz);
                float3 y = normalize(m[1].xyz);
                float3 z = normalize(m[2].xyz);
                
                return float3x3(
                    x.x, x.y, x.z,
                    y.x, y.y, y.z,
                    z.x, z.y, z.z
                );
            }

            Varyings vert(Attributes input)
            {
                Varyings output;
                
                float4x4 transform = GetObjectToWorldMatrix();

                float4 worldPos = mul(transform, input.positionOS);
                float4 viewPos = mul(GetWorldToViewMatrix(), worldPos);
                float distance = max(-viewPos.z, 0.01);
                float adjustedThickness = _Thickness * _PixelScaleFactor * distance;

                float3x3 rotation = GetRotationMatrix(transform);
                worldPos.xyz += mul(rotation, input.thick.xyz) * adjustedThickness;
                
                output.positionCS = mul(GetWorldToHClipMatrix(), worldPos);
                
                output.color = lerp(_NearColor, _FarColor, input.uv.x);
                
                return output;
            }
            
            half4 frag(Varyings input) : SV_Target
            {
                return input.color;
            }
            ENDHLSL
        }
    }
}