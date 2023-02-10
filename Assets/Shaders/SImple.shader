Shader "Unlit/SImple"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float4 screenSpace : TEXCOORD1;
                float3 normal : TEXCOORD2;
                float3 viewDirection : TEXCOORD3;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _CameraDepthTexture;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.screenSpace = ComputeScreenPos(o.vertex);
                o.normal = UnityObjectToWorldNormal(v.normal);
                o.viewDirection = normalize(WorldSpaceViewDir(v.vertex));
                
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                //SAMPLE_DEPTH_TEXTURE()
                
                fixed4 col = tex2D(_MainTex, i.uv);

                
                float2 screenSpaceUV = i.screenSpace.xy / i.screenSpace.w;
                float depth = Linear01Depth(SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, screenSpaceUV));
                float3 mixedColor = lerp(float3(1,0,0), float3(0,0,0), depth);
                float frensel = dot(i.viewDirection, i.normal);
                
                return fixed4(depth, 0, 0, 1);
            }
            ENDCG
        }
    }
}
