Shader "Custom/SilhouetteShader"
{
    Properties //Serialized Variables
    {
        _MainTex ("Main Texture", 2D) = "white" {} //Main texture (albedo)
        _MainColor ("Main Color", Color) = (1.0, 1.0, 1.0, 1.0) //Main color applied to the texture
        
        _SilhouetteTex ("Silhouette Texture", 2D) = "white" {}
        _SilhouetteColor ("Silhouette Color", Color) = (1.0, 1.0, 1.0, 1.0)
        _SilhouetteWidth ("Silhouette Width", Range(1.0, 10.0)) = 1.1
    }
    SubShader
    {
        Tags {
        "Queue" = "Transparent"
        }

		Pass //Pass silhouette Rendering
		{
			NAME "SILHOUETTE"
			
			ZWrite Off
			
			CGPROGRAM
				#pragma vertex vert
            	#pragma fragment frag
            
            	#include "UnityCG.cginc"
            	
            	struct appdata {
            		float4 vertex : POSITION;
            		float2 uv : TEXCOORD0;
            	};
            	
            	struct v2f {
            		float4 pos : SV_POSITION;
            		float2 uv : TEXCOORD0;
            	};
            	
            	sampler2D _SilhouetteTex;
            	float4 _SilhouetteColor;
            	float _SilhouetteWidth;
            	
            	v2f vert (appdata IN) {
            		IN.vertex.xyz *= _SilhouetteWidth;
            	
            		v2f OUT;
            		
            		OUT.pos = UnityObjectToClipPos(IN.vertex);
            		OUT.uv = IN.uv;
            		
            		return OUT;
            	}
            	
            	fixed4 frag (v2f IN) : SV_Target {
            	
            		float4 texColor = tex2D(_SilhouetteTex, IN.uv);
            		
            		return texColor * _SilhouetteColor;
            	}

			ENDCG
		}

        Pass //Pass Object rendering
        {
        	NAME "OBJECT"
			
            CGPROGRAM
            	#pragma vertex vert
            	#pragma fragment frag
            
            	#include "UnityCG.cginc" //Built-in library for Shader/Unity
            	
            	struct appdata {
            		float4 vertex : POSITION;
            		float2 uv : TEXCOORD0;
            	};
            	
            	struct v2f {
            		float4 pos : SV_POSITION;
            		float2 uv : TEXCOORD0;
            	};
            	
            	sampler2D _MainTex;
            	float4 _MainColor;
            	
            	v2f vert (appdata IN) {
            		v2f OUT;
            		
            		OUT.pos = UnityObjectToClipPos(IN.vertex);
            		OUT.uv = IN.uv;
            		
            		return OUT;
            	}
            	
            	fixed4 frag (v2f IN) : SV_Target {
            	
            		float4 texColor = tex2D(_MainTex, IN.uv);
            		
            		return texColor * _MainColor;
            	}
            	            	
            ENDCG
        }
    }
}
