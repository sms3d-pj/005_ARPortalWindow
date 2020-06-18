Shader "Sample/InvertDisplay"
{
    Properties
    {
        _InvertTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
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
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float4 pos : TEXCOORD0;
            };

            sampler2D _InvertTex;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);

                // https://light11.hatenadiary.com/entry/2018/06/13/235543
                o.pos = ComputeScreenPos(o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.pos.xy / i.pos.w; // (0.0 ~ 1.0, 0.0 ~ 1.0)
                // float4 col = float4(uv, 0, 1);
                float4 col = tex2D(_InvertTex, uv);
                return col;
            }
            ENDCG
        }
    }
}
