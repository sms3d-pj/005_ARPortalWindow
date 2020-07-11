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
            

            sampler2D _InvertTex;

            v2f vert (appdata v)
            {
                
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
