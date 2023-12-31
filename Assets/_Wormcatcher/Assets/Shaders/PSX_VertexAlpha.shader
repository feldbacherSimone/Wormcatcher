﻿// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "psx/vertexAlpha" {
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
					float _Transparency;
					uniform half4 unity_FogStart;
					uniform half4 unity_FogEnd;

					v2f vert(appdata_full v)
					{
						v2f o;

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
						o.color = float4(ShadeVertexLightsFull(v.vertex, v.normal, 4, true), 1.0);
						o.color *= v.color;

						float distance = length(mul(UNITY_MATRIX_MV,v.vertex));

						//Affine Texture Mapping
						float4 affinePos = vertex; //vertex;				
						o.uv_MainTex = TRANSFORM_TEX(v.texcoord, _MainTex);
						o.uv_MainTex *= distance + (vertex.w*(UNITY_LIGHTMODEL_AMBIENT.a * 8)) / distance / 2;
						o.normal = distance + (vertex.w*(UNITY_LIGHTMODEL_AMBIENT.a * 8)) / distance / 2;

						//Fog
						float4 fogColor = unity_FogColor;

						float fogDensity = (unity_FogEnd - distance) / (unity_FogEnd - unity_FogStart);
						o.normal.g = fogDensity;
						o.normal.b = 1;

						o.colorFog = fogColor;
						o.colorFog.a = clamp(fogDensity,0,1);

						//Cut out polygons
						if (distance > unity_FogStart.z + unity_FogColor.a * 255)
						{
							o.pos.w = 0;
						}

						return o;
					}

					sampler2D _MainTex;

					float4 frag(v2f IN) : COLOR
					{
						half4 c = tex2D(_MainTex, IN.uv_MainTex / IN.normal.r)*IN.color;
						half4 color = c * (IN.colorFog.a);
						color.rgb += IN.colorFog.rgb*(1 - IN.colorFog.a);
						color.a = c.a * _Transparency;
						return color;
					}
				ENDCG
			}
		UsePass "Legacy Shaders/VertexLit/SHADOWCASTER"
		}
			Fallback "VertexLit"
}