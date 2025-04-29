Shader "Plot/Stretchables (Omni)"
{
    Properties 
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Thickness ("Thickness", Float) = 1.0
        _NearColor ("Near Color", Color) = (1,1,1,1)
        _FarColor ("Far Color", Color) = (1,1,1,1)
        
        _StartAngle ("Start Angle", Float) = 0.0
        _EndAngle ("End Angle", Float) = 1.0
        
        [HideInInspector] _StencilComp ("Stencil Comparison", Float) = 8  // Always
        [HideInInspector] _StencilPass ("Stencil Pass", Float) = 0        // Keep
        [HideInInspector] _StencilValue ("Stencil Reference Value", Int) = 0
        
        [HideInInspector] _SrcBlend ("", Int) = 1 // One
        [HideInInspector] _DstBlend ("", Int) = 0 // Zero
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
                        
            Stencil
            {
                Ref [_StencilValue]
                Comp [_StencilComp]
                Pass [_StencilPass]
            }
            
            ZWrite On
            ZTest LESS
            Blend [_SrcBlend] [_DstBlend]
            
            HLSLPROGRAM
            
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 4.5

            #pragma multi_compile _ USE_STRUCTURED_BUFFER
            #pragma multi_compile _ ANGLES_ENABLED
            
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);
            float _PixelScaleFactor; // this is defiend globally in code

            struct Attributes
            {
                float4 positionOS : POSITION;
                float4 thick : TANGENT;
                float2 uv : TEXCOORD0;
#ifdef USE_STRUCTURED_BUFFER                
                uint instanceID : SV_InstanceID;
#endif                
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float4 color : COLOR;
            };
            
            struct Instance
            {
                float4x4 transform;
#ifdef ANGLES_ENABLED
                float4 color;
                float startAngle;
                float endAngle;
                
                float padding0;
                float padding1;
#else
                float4 nearColor;
                float4 farColor;
#endif                
            };
            
#ifdef USE_STRUCTURED_BUFFER
            StructuredBuffer<Instance> _Instances;

#ifdef ANGLES_ENABLED
            void GetInstanceData(in Attributes input, out float4x4 transform, out float thickness, out float start, out float end, out float4 nearColor, out float4 farColor)
            {
                Instance instance = _Instances[input.instanceID];
                transform = instance.transform;
                
                // m33 was repurposed to store thickness in DrawBatch.cs
                thickness = transform[3][3];
                transform[3][3] = 1.0;

                start = -instance.endAngle;
                end = -instance.startAngle;
                
                nearColor = instance.color;
                farColor = instance.color;
            }
#else
            void GetInstanceData(in Attributes input, out float4x4 transform, out float thickness, out float4 nearColor, out float4 farColor)
            {
                Instance instance = _Instances[input.instanceID];
                transform = instance.transform;

                // m33 was repurposed to store thickness in DrawBatch.cs
                thickness = transform[3][3];
                transform[3][3] = 1.0;

                nearColor = instance.nearColor;
                farColor = instance.farColor;
            }
#endif
            
#else

#ifdef ANGLES_ENABLED            
            CBUFFER_START(UnityPerMaterial)
                float4x4 _ObjectTransform;
                float _Thickness;
                float4 _NearColor;
                float4 _FarColor;

                float _StartAngle;
                float _EndAngle;
            CBUFFER_END

            void GetInstanceData(in Attributes input, out float4x4 transform, out float thickness, out float start, out float end, out float4 nearColor, out float4 farColor)
            {
                transform = GetObjectToWorldMatrix();
                thickness = _Thickness;

                start = -_EndAngle;
                end = -_StartAngle;
                
                nearColor = _NearColor;
                farColor = _FarColor;
            }
#else
            CBUFFER_START(UnityPerMaterial)
                float4x4 _ObjectTransform;
                float _Thickness;
                float4 _NearColor;
                float4 _FarColor;
            CBUFFER_END
            
            void GetInstanceData(in Attributes input, out float4x4 transform, out float thickness, out float4 nearColor, out float4 farColor)
            {
                transform = GetObjectToWorldMatrix();
                thickness = _Thickness;
                nearColor = _NearColor;
                farColor = _FarColor;
            }
#endif
            
#endif
            
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

            float UpDown(float In)
            {
                return abs( 2 * (In - floor(0.5 + In)));
            }

#ifdef ANGLES_ENABLED
            Varyings vert(Attributes input)
            {
                Varyings output;

                float4x4 transform;
                float thickness;
                float start;
                float end;
                float4 nearColor;
                float4 farColor; 
                
                GetInstanceData(input, transform, thickness, start, end, nearColor, farColor);
                
                float4 position = input.positionOS;
                
                float vertexAngle = position.z;
                
                float angle = (start + vertexAngle * (end - start)) * PI * 2.0;

                // Create an angle-specific rotation matrix
                float3x3 angleRotation = float3x3(
                    1, 0, 0,
                    0, -sin(angle), cos(angle), 
                    0, cos(angle), sin(angle)
                );
                
                // Apply angle rotation to base position
                position.xyz = mul(angleRotation, float3(position.x, position.y, 0));
                
                // Calculate world position
                float4 worldPos = mul(transform, position);
                float4 viewPos = mul(GetWorldToViewMatrix(), worldPos);
                float distance = max(-viewPos.z, 0.01);
                float adjustedThickness = thickness * _PixelScaleFactor * distance;
                
                // Apply thickness after rotating by the angle
                float3 thickDirection = input.thick.xyz * float3(1, 1, -1);
                
                // Rotate thickness direction according to the same angle
                thickDirection = mul(angleRotation, thickDirection);
                
                // Now apply object rotation to the already angle-rotated thickness
                float3x3 objRotation = GetRotationMatrix(transform);
                worldPos.xyz += mul(objRotation, thickDirection) * adjustedThickness;
                
                output.positionCS = mul(GetWorldToHClipMatrix(), worldPos);
                
                const float angleScale = 1.0 / (PI * 2.0);
                
                // remap uv
                float color = UpDown(angle * angleScale);
                
                output.color = lerp(nearColor, farColor, color);

                return output;
            }
#else
            Varyings vert(Attributes input)
            {
                float4x4 transform;
                float thickness;
                float4 nearColor;
                float4 farColor; 
                
                GetInstanceData(input, transform, thickness, nearColor, farColor); 
                
                Varyings output;
                
                float4 worldPos = mul(transform, input.positionOS);
                float4 viewPos = mul(GetWorldToViewMatrix(), worldPos);
                float distance = max(-viewPos.z, 0.01);
                float adjustedThickness = thickness * _PixelScaleFactor * distance;
                
                float3x3 rotation = GetRotationMatrix(transform);
                worldPos.xyz += mul(rotation, input.thick.xyz) * adjustedThickness;
                
                output.positionCS = mul(GetWorldToHClipMatrix(), worldPos);
                
                output.color = lerp(nearColor, farColor, input.uv.x); 
                
                return output;
            }
#endif
            
            half4 frag(Varyings input) : SV_Target
            {
                return input.color;
            }
            
            ENDHLSL
        }
    }
}