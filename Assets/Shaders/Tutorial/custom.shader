Shader "Custom/NewShader" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Alpha ("Alpha", Float) = 1.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		Blend One One
		pass{
			CGINCLUDE
			 #pragma vertex vert
            #pragma fragment frag

            float4 vert(float4 v:POSITION) : SV_POSITION {
                return mul (UNITY_MATRIX_MVP, v);
            }

            fixed4 frag() : COLOR {
                return fixed4(1.0,0.0,0.0,0.0);
            }

			ENDCG
		}
		
		pass{
			CGPROGRAM
			 #pragma vertex vert
            #pragma fragment frag
			fixed _Alpha;
            float4 vert(float4 v:POSITION) : SV_POSITION {
                return mul (UNITY_MATRIX_MVP, v);
            }

            fixed4 frag() : COLOR {
                fixed4 c =  fixed4(0.0,0.0,0.0,0.0);
                c.a = _Alpha;
                return c;
            }

			ENDCG
		}
	} 
	FallBack "Diffuse"
}
