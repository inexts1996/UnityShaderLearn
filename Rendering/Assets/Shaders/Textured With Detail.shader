// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Textured With Detail"
{
    Properties
    {
        _Tint("Tint", Color) = (1, 1, 1,1)
        _MainTex("MainTex", 2D) = "white" {}
    }
    SubShader
    {
        pass
        {
            CGPROGRAM
            #pragma vertex MyVertexProgram
            #pragma fragment MyFragmentProgram

            #include "UnityCG.cginc"

            float4 _Tint;
            sampler2D _MainTex;
            float4 _MainTex_ST;
            
            struct Interpolators
            {
               float4 position:SV_POSITION;
               float2 uv:TEXCOORD0;
            };

            struct VertexData
            {
                float4 position:POSITION;
                float2 uv:TEXCOORD0;
            };

            Interpolators MyVertexProgram(VertexData v)
            {
                Interpolators i;
                i.position = UnityObjectToClipPos(v.position);

                i.uv = v.uv * _MainTex_ST.xy + _MainTex_ST.zw;

                return i;
            }

            float4 MyFragmentProgram(Interpolators i) : SV_TARGET
            {
                float4 color = tex2D(_MainTex, i.uv) * _Tint; 
                return color; 
            }
            ENDCG
        }
    }
}
