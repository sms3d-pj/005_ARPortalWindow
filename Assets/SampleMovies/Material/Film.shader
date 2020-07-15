Shader "Sample/Film" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		time ("time", Float) = 0.0
		nIntensity ("nIntensity", Float) = 0.5
		sIntensity ("sIntensity", Float) = 0.05
		sCount ("sCount", Float) = 4096
		grayscale ("grayscale", Int) = 1
	}
	SubShader {
		// No culling or depth
        Cull Off ZWrite Off ZTest Always

		Pass
	    {            
	        CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag
            #pragma target 3.0

            #include "UnityCG.cginc"
            
			sampler2D _MainTex;
			
			// control parameter
			uniform float time;

			uniform bool grayscale;

			// noise effect intensity value (0 = no effect, 1 = full effect)
			uniform float nIntensity;

			// scanlines effect intensity value (0 = no effect, 1 = full effect)
			uniform float sIntensity;

			// scanlines effect count value (0 = no effect, 4096 = full effect)
			uniform float sCount;
			
			float4 frag(v2f_img i) : COLOR {
				half2 vUv = i.uv;
				
				// sample the source
				half4 cTextureScreen = tex2D( _MainTex, vUv );

				// make some noise
				float x = vUv.x * vUv.y * time *  1000.0;
				x = fmod( x, 13.0 ) * fmod( x, 123.0 );
				float dx = fmod( x, 0.01 );

				// add noise
				half3 cResult = cTextureScreen.rgb + cTextureScreen.rgb * clamp( 0.1 + dx * 100.0, 0.0, 1.0 );

				// get us a sine and cosine
				half2 sc = half2( sin( vUv.y * sCount ), cos( vUv.y * sCount ) );

				// add scanlines
				cResult += cTextureScreen.rgb * half3( sc.x, sc.y, sc.x ) * sIntensity;

				// interpolate between source and result by intensity
				cResult = cTextureScreen.rgb + clamp( nIntensity, 0.0,1.0 ) * ( cResult - cTextureScreen.rgb );

				// convert to grayscale if desired
				//if( grayscale ) {
				//	half v =  cResult.r * 0.3 + cResult.g * 0.59 + cResult.b * 0.11;
				//	cResult = half3( v, v, v );
				//}

				float4 fragColor = float4( cResult, cTextureScreen.a );
				return fragColor;
			}
			
			ENDCG
		}
	} 
	
}