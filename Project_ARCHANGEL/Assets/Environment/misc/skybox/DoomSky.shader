 Shader "FX/DoomSky"
 {
     Properties
     {
         _MainTex ("Texture", 2D) = "white" {}
         _StretchDown ("Stretch", Range(0, 0.5)) = 0
     }
     SubShader
     {
         Tags { "RenderType"="Opaque" }
         Cull off ZWrite On ZTest Lequal
 
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
             };
 
             struct v2f
             {
                 float3 worldView : TEXCOORD1;
                 float4 vertex : SV_POSITION;
             };
 
             v2f vert (appdata v)
             {
                 v2f o;
                 o.vertex = UnityObjectToClipPos(v.vertex);
                 o.worldView = -WorldSpaceViewDir (v.vertex);
                 return o;
             }
             sampler2D _MainTex;
             float _StretchDown;
             
             fixed4 frag (v2f i) : SV_Target
             {
                 float3 dir = normalize(i.worldView);
                 float2 uv = float2(0.5+atan2(dir.z, dir.x)/(2*UNITY_PI), _StretchDown+dir.y*(1-_StretchDown));
                 fixed4 col = tex2D(_MainTex, uv);
                 return col;
             }
             ENDCG
         }
     }
 }
