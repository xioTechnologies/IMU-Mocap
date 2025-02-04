Shader "Plot/Stretchables"
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
                uint instanceID : SV_InstanceID;
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float4 color : COLOR;
            };

            struct Instance
            {
                float4x4 transform;
                float4 nearColor;
                float4 farColor;
            };

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);
            float _PixelScaleFactor;
            
            StructuredBuffer<Instance> _Instances;
            
            float3x3 GetRotationMatrix(float4x4 m)
            {
                // Assumes uniform scale 
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
                Instance instance = _Instances[input.instanceID];
                float4x4 transform = instance.transform;

                // m33 was repurposed to store thickness in DrawBatch.cs
                float thickness = transform[3][3];
                transform[3][3] = 1.0;
                
                float4 worldPos = mul(transform, input.positionOS);
                float4 viewPos = mul(GetWorldToViewMatrix(), worldPos);
                float distance = max(-viewPos.z, 0.01);
                float adjustedThickness = thickness * _PixelScaleFactor * distance;
                
                float3x3 rotation = GetRotationMatrix(transform);
                worldPos.xyz += mul(rotation, input.thick.xyz) * adjustedThickness;
                
                output.positionCS = mul(GetWorldToHClipMatrix(), worldPos);
                
                output.color = pow(abs(lerp(instance.nearColor, instance.farColor, input.uv.x)), 2.2); 
                
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