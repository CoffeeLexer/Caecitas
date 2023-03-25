Shader "Unlit/Normal"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

             struct appdata
             {
                 float4 vertex : POSITION;
             };
 
             struct v2f
             {
                 float4 pos : SV_POSITION;
                 float4 scrPos : TEXCOORD0;
             };
 
             UNITY_DECLARE_DEPTH_TEXTURE(_CameraDepthNormalsTexture);
             float4 _Color;
 
             v2f vert (appdata v)
             {
                 v2f o;
                 o.pos = UnityObjectToClipPos(v.vertex);
                 o.scrPos = ComputeScreenPos(o.pos);
                 o.scrPos.y = 1 - o.scrPos.y;
                 return o;
             }
 
             fixed4 frag (v2f i) : SV_Target
             {
                 float depth;
                 float3 normals;
                 DecodeDepthNormal(tex2D(_CameraDepthNormalsTexture, i.scrPos.xy), depth, normals);
 
                 return float4 (normals.xyz, 1);
             }
            ENDCG
        }
    }
}
