Shader "Unlit/ScrollShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Scroll ("Scroll", Vector) = (0,0,0,0)
        _Colorize ("Colorize Clouds", color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            ZTest off
            Blend SrcAlpha OneMinusSrcAlpha
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
                float2 uv1 : TEXCOORD1;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST, _Scroll, _Colorize;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv1 = v.uv;
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);                
                
                _Scroll *= frac(_Time.x);
                o.uv.x += _Scroll.x;
                o.uv.y += _Scroll.y;

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv); 
                col.rgb = lerp(_Colorize.rgb/2,_Colorize.rgb,col.r);
                fixed alpha = 1-saturate(length(abs(i.uv1-0.5)*2)) ;
                col.a *= alpha * _Colorize.a;
                return col;
            }
            ENDCG
        }
    }
}
