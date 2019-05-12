// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Hidden/EdgeDetectionShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Thickness("Thickness", int ) = 5
        _EdgeColor("Form color", Color) = (0,0,0,1)
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            #define UNITY_SHADER_NO_UPGRADE 1

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _CameraDepthNormalsTexture;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float4 _MainTex_TexelSize;
            int _Thickness;
            fixed4 _EdgeColor;

            float4 GetPixelValue(in float2 uv) {
                float3 normal;
                float depth;
                DecodeDepthNormal(tex2D(_CameraDepthNormalsTexture, uv), depth, normal);
                return float4(normal, depth);
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float4 col = tex2D(_MainTex, i.uv);
                float4 depth = GetPixelValue(i.uv);


                 float2 offsets[8] = {
                    float2(-1 / depth.w, -1 / depth.w),
                    float2(-1 / depth.w, 0),
                    float2(-1 / depth.w, 1 / depth.w),
                    float2(0, -1 / depth.w),
                    float2(0, 1 / depth.w),
                    float2(1 / depth.w, -1 / depth.w),
                    float2(1 / depth.w, 0),
                    float2(1 / depth.w, 1 / depth.w)
                };


                float4 sampledValue = float4(0,0,0,0);
                for(int j = 0; j < 8; j++) {
                    sampledValue += GetPixelValue(i.uv + offsets[j] * _MainTex_TexelSize.xy / 1 / _Thickness);
                }
                float4 divider = 8;
                sampledValue /= divider;

                float len = length(depth - sampledValue);

                return lerp( col,lerp(_EdgeColor,col, step(0.001,  len)), step(depth.w , 0.99));

            }
            ENDCG
        }
    }
}