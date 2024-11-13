Shader "Custom/羽化"
{
     Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _FeatherWidth ("Feather Width", Range(0, 1)) = 0.1
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        LOD 200

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float _FeatherWidth;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 pos : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 center = float2(0.5, 0.5);
                float distanceToCenter = length(i.uv - center);
                
                // 使用 smoothstep 创建渐变效果，边缘羽化
                float alpha = smoothstep(0.5, 0.5 - _FeatherWidth, distanceToCenter);

                // 应用到纹理颜色
                fixed4 col = tex2D(_MainTex, i.uv);
                col.a *= alpha; // 将渐变效果应用到 Alpha 通道
                return col;
            }
            ENDCG
        }
    }
}
