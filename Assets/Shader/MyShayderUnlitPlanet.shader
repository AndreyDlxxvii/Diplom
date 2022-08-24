Shader "Custom/MyShayderUnlitPlanet"
{
    Properties 
    {
        _Color("Main color", COLOR) = (1,1,1,1)
        _AtmosphereSize("AtmosphereSize", Range(0,5)) = 0.5
        _Ambient ("Ambient", float) = 0
    }
    
    SubShader
    {
        Tags {"RenderType"="Opaque" "Queue" = "Transparent"}
        blend SrcAlpha OneMinusSrcAlpha
        LOD 100
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag 
            #include "UnityCG.cginc"
                       
            float _Ambient; 
            float4 _Color;
            float _AtmosphereSize;
            

            struct v2f
            {
                float4 vertex : SV_POSITION;
                fixed diff : COLOR0;
            };
            
            v2f vert (appdata_full v)
            {
                v.vertex.xyz += v.normal * _AtmosphereSize;                  
                v2f result;
                result.vertex = UnityObjectToClipPos(v.vertex);
                return result;
            }
            
            fixed4 frag(v2f i) : SV_Target
            {
                return i.diff * _Color + _Ambient * _Color;
            }
            ENDCG
        }
    }
}
