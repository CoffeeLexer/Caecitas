Shader "Unlit/Wave"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1, 1, 1, 1)
        _NormalWeight ("Normal Weight", Range(0.0, 1.0)) = 1
    }
    SubShader
    {
        Blend SrcAlpha OneMinusSrcAlpha
        Tags { "Queue"="Transparent" }
        LOD 100
        
        // Force transparency to be rendered when it is inside object
        ZTest GEqual
        Cull Front
        ZWrite Off
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog
            //#pragma multi_compile COMPUTE_EYEDEPTH

            sampler2D _CameraNormalsTexture;
            sampler2D _CameraDepthTexture;
            float4 _CameraDepthTexture_TexelSize;

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 screenPos : TEXCOORD0;
                float3 viewDirection : TEXCOORD1;
                float3 cameraDirection : TEXCOORD2;
                float3 viewPos : TEXCOORD3;
                float3 worldPos : TEXCOORD5;
                float4 worldPosVertex : TEXCOORD6;
                float4 vertex : SV_POSITION;
                float3 normal : NORMAL;
                float eyeDepth : TEXCOORD4;
            };
            
            float ComputeEyeDepth(float linearDepth)
            {
                float depth = linearDepth * _ProjectionParams.z;
                float eyeDepth = _ZBufferParams.y / (depth - _ZBufferParams.x);
                return eyeDepth;
            }

            float4 _Color;
            float _NormalWeight;
            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex.xyz);
                o.screenPos = ComputeScreenPos(o.vertex);
                float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                float3 viewDir = normalize(_WorldSpaceCameraPos.xyz - worldPos);
                float3 cameraDir = normalize(_WorldSpaceCameraPos.xyz - mul(unity_ObjectToWorld, v.vertex).xyz);
                o.viewDirection = viewDir;
                o.cameraDirection = cameraDir;
                
                o.worldPos =  mul(unity_ObjectToWorld, float4(0.0, 0.0, 0.0, 1.0)).xyz;;
                o.worldPosVertex =  mul(unity_ObjectToWorld, v.vertex);;

                float4 viewPos = mul(UNITY_MATRIX_V, worldPos);
                o.viewPos = viewPos;

                COMPUTE_EYEDEPTH(o.eyeDepth);
                
                return o;
            }
            float Linear01ToEyeDepth(float linear01Depth, float nearClip, float farClip, float projectionParamsY)
            {
                float z = linear01Depth * 2.0 - 1.0; // Remap from [0,1] to [-1,1]
                float eyeZ = 2.0 * nearClip * farClip / (farClip + nearClip - z * (farClip - nearClip)); // Apply perspective transformation
                return eyeZ / projectionParamsY; // Convert to eye space units
            }
            float noise(float2 xy) {
                return frac(sin(dot(xy, float2(12.9898,78.233))) * 43758.5453);
            }
            float2 dither(float2 p) {
                float texel = 100;
                float2 uv = p.xy * texel.xx;
                float DITHER_THRESHOLDS[16] =
                {
                    0.0 / 16.0,  8.0 / 16.0,  2.0 / 16.0, 10.0 / 16.0,
                    12.0 / 16.0,  4.0 / 16.0, 14.0 / 16.0,  6.0 / 16.0,
                    3.0 / 16.0, 11.0 / 16.0,  1.0 / 16.0, 9.0 / 16.0,
                    15.0 / 16.0,  7.0 / 16.0, 13.0 / 16.0,  5.0 / 16.0
                };
                uint index = (uint(uv.x) % 4) * 4 + uint(uv.y) % 4;
                return DITHER_THRESHOLDS[index];
            }
            float3 dither3(float3 p) {
                float texel = 500;
                float3 uv = p.xyz * texel.xxx;
                float DITHER_THRESHOLDS[64] =
                {
                    0/64.0,8/64.0,34/64.0,42/64.0,
                    12/64.0,4/64.0,46/64.0,38/64.0,
                    50/64.0,58/64.0,16/64.0,24/64.0,
                    62/64.0,54/64.0,28/64.0,0/64.0,
                    
                    32/64.0,40/64.0,2/64.0,10/64.0,
                    44/64.0,36/64.0,14/64.0,6/64.0,
                    18/64.0,26/64.0,48/64.0,56/64.0,
                    30/64.0,22/64.0,60/64.0,52/64.0,
                    
                    63/64.0,55/64.0,17/64.0,25/64.0,
                    59/64.0,51/64.0,29/64.0,21/64.0,
                    35/64.0,43/64.0,1/64.0,9/64.0,
                    47/64.0,39/64.0,13/64.0,5/64.0,

                    31/64.0,23/64.0,49/64.0,57/64.0,
                    27/64.0,19/64.0,61/64.0,53/64.0,
                    3/64.0,11/64.0,33/64.0,41/64.0,
                    15/64.0,7/64.0,45/64.0,37/64
                };
                uint index = (uint(uv.x) % 4) * 16 + (uint(uv.y) % 4) * 4 + uint(uv.z) % 4;
                return DITHER_THRESHOLDS[index];
            }
            fixed4 frag (v2f _in) : SV_Target
            {
                // Get UV
                float2 uv = _in.screenPos.xy / _in.screenPos.w;
                
                // Sample Scene Depth
                float depth = (tex2D(_CameraDepthTexture, uv).r);
                float eyeDepth =  LinearEyeDepth(depth);
                // Sample Scene Normals 
                float3 normal = tex2D(_CameraNormalsTexture, uv);

                // Negate Normal
                //float3 a = -1 * normal;

                // Extract view direction
                float3 v = _in.viewDirection;

                // For calculations make vector look at camera not from it
                v *= -1;
                // Normalize for dot product multiplication
                v = normalize(v);
                
                // Extract camera direction
                float3 cameraDir = -UNITY_MATRIX_V[2].xyz;

                // Find view deformation ration per pixel for
                // Scene depths normalization
                float a = dot(cameraDir, v);

                // Make screen depth uniform, independent of camera angle
                float b = eyeDepth / a;

                // Put pixel in relation to camera
                float3 c = v * b;

                // Transform pixel from relation to camera, to relation to world
                // Pixel is now in coordinates of the world
                float3 d = _WorldSpaceCameraPos + c;

                // Vector of pixel from objects pivot
                float3 e = d - _in.worldPos;

                // Distance from pivot to pixel
                float f = length(e);

                // Model matrix
                float4x4 model = UNITY_MATRIX_M;

                // Extracting pixels scale
                float3 xRow = float3(model[0].xyz);

                // Calculate magnitude of scale
                float g = length(xRow);

                // Ratio between scale's magnitude and pixels distance
                // On 1x1x1 sphere we would have that surface pixel has ratio of 0.5
                float h = f / g;

                // Create smooth bevel for wave
                float i = smoothstep(0.45, 0.445, h);

                // Calculate Smooth fadeout
                float j = smoothstep(0.4, 0.350, h);

                float k = i - j;
                float l = clamp(k, 0, 1);

                // Allow for script to fade waves color
                float q = min(l, _Color.a);

                // Sampling Normal, so it would not draw on faces that are not
                // Facing the camera
                float m = dot(-normal.xyz, e.xyz);

                float n = ceil(m);

                float o = abs(n);

                // Remove Not camera facing camera pixel
                float p = lerp(q, min(o, q), _NormalWeight);

                // For small objects disable object normals check
                float r = lerp(l, p, clamp(0, 1, g));

                // MAY CAUSE EPILEPSY
                float ditherVal = dither3(d);
                
                return float4(_Color.rgb, r);
            }
            ENDCG
        }
    }
}
