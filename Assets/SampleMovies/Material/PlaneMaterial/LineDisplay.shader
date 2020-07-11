﻿Shader "Sample/LineDisplay"
{
    Properties
    {
        _LineTex ("Texture", 2D) = "white" {}
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

            sampler2D _LineTex;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);

                // https://light11.hatenadiary.com/entry/2018/06/13/235543
                o.pos = ComputeScreenPos(o.vertex);
                return o;
            }

            float rand(float3 co)
			{
				return frac(sin(dot(co.xyz, float3(12.9898, 78.233, 56.787))) * 43758.5453);
			}
 
			float noise(float3 pos)
			{
				float3 ip = floor(pos);
				float3 fp = smoothstep(0, 1, frac(pos));
				float4 a = float4(
					rand(ip + float3(0, 0, 0)),
					rand(ip + float3(1, 0, 0)),
					rand(ip + float3(0, 1, 0)),
					rand(ip + float3(1, 1, 0)));
				float4 b = float4(
					rand(ip + float3(0, 0, 1)),
					rand(ip + float3(1, 0, 1)),
					rand(ip + float3(0, 1, 1)),
					rand(ip + float3(1, 1, 1)));
 
				a = lerp(a, b, fp.z);
				a.xy = lerp(a.xy, a.zw, fp.y);
				return lerp(a.x, a.y, fp.x);
			}
 
			float perlin(float3 pos)
			{
				return 
					(noise(pos) * 32 +
					noise(pos * 2 ) * 16 +
					noise(pos * 4) * 8 +
					noise(pos * 8) * 4 +
					noise(pos * 16) * 2 +
					noise(pos * 32) ) / 63;
			}
 
			float monochrome(float3 col)
			{
				return 0.299 * col.r + 0.587 * col.g + 0.114 * col.b;
			}

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.pos.xy / i.pos.w;

                float2 screenUV = uv * _ScreenParams.xy;
				uv += (float2(perlin(float3(screenUV, _Time.y) * 5), perlin(float3(screenUV, _Time.y + 100) * 5)) - 0.5) * 0.01;
				float col = monochrome(tex2D(_LineTex, uv)) + 0.2f;
 
				float2 pixelSize = _ScreenParams.zw - 1;
				col -= abs(	monochrome(tex2D(_LineTex, uv - float2(pixelSize.x, 0)))
						  - monochrome(tex2D(_LineTex, uv + float2(pixelSize.x, 0)))
						  + monochrome(tex2D(_LineTex, uv - float2(0, pixelSize.y)))
						  - monochrome(tex2D(_LineTex, uv + float2(0, pixelSize.y)))	) * 0.7;
				col *= perlin(float3(screenUV, _Time.y * 10) * 1) * 0.5f + 0.8f;
				return float4(col, col, col, 1);
            }
            ENDCG
        }
    }
}
