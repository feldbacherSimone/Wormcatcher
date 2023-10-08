 // Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "psx/vertexunlit" {
	Properties{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_SnapStrength("Snap Strength", Float) = 1
		_Transparency("Transparency", Range(0,1)) = 1
	}
		SubShader{
			Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
			AlphaToMask On
			LOD 100

			ZWrite On
			Blend SrcAlpha OneMinusSrcAlpha

			Pass {
			Lighting On
				CGPROGRAM

					#pragma vertex vert
					#pragma fragment frag
					#include "UnityCG.cginc"

					struct v2f
					{
						fixed4 pos : SV_POSITION;
						half4 color : COLOR0;
						half4 colorFog : COLOR1;
						float2 uv_MainTex : TEXCOORD0;
						half3 normal : TEXCOORD1;
					};

					float4 _MainTex_ST;
					float _SnapStrength;
						
					v2f vert(appdata_full v)
					{
						v2f o;
						UNITY_INITIALIZE_OUTPUT(v2f, o);

						//Vertex snapping
						float4 snapToPixel = UnityObjectToClipPos(v.vertex);
						float4 vertex = snapToPixel;
						vertex.xyz = snapToPixel.xyz / snapToPixel.w;
						float snap = 1 / _SnapStrength;
						vertex.x = floor(160 * snap * vertex.x) / (160 * snap);
						vertex.y = floor(120 * snap * vertex.y) / (120 * snap);
						vertex.xyz *= snapToPixel.w;
						o.pos = vertex;

						//Vertex lighting 
					//	o.color =  float4(ShadeVertexLights(v.vertex, v.normal), 1.0);
						o.color = float4(ShadeVertexLightsFull(v.vertex, v.normal, 4, false), 1.0);
						o.color *= v.color;

						float distance = length(mul(UNITY_MATRIX_MV,v.vertex));

						//Affine Texture Mapping
						float4 affinePos = vertex; //vertex;				
						o.uv_MainTex = TRANSFORM_TEX(v.texcoord, _MainTex);
						o.uv_MainTex *= distance + (vertex.w*(UNITY_LIGHTMODEL_AMBIENT.a * 8)) / distance / 2;
						o.normal = distance + (vertex.w*(UNITY_LIGHTMODEL_AMBIENT.a * 8)) / distance / 2;
						return o;
					}

					sampler2D _MainTex;

					float4 frag(v2f IN) : COLOR
					{
						half4 color = tex2D(_MainTex, IN.uv_MainTex / IN.normal.r);
						return color;
					}
				ENDCG
			}
		UsePass "Legacy Shaders/VertexLit/SHADOWCASTER"
		}
			Fallback "VertexLit"
}