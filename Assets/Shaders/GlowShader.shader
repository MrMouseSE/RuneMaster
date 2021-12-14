Shader "Unlit/GlowShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _AdditiveColor ("AdditiveColor", color) = (1,1,1,1)
        _ColorIntencity ("Color Intencity", Range(0,1)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            Blend One One
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
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST, _AdditiveColor;
            fixed _ColorIntencity;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = _AdditiveColor * tex2D(_MainTex, i.uv).a * _ColorIntencity;
                return col;
            }
            ENDCG
        }
    }
}