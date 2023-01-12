// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/My First Shader"
{
    Properties
    {
        _Tint("Tint", Color) = (1, 1, 1,1)
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
            struct Interpolators
            {
               float4 position:SV_POSITION;
               float3 localPosition:TEXTURECOORD0;

            };

            float4 MyVertexProgram(float4 position:POSITION, out float3 localPosition:TEXTURECOORD0): SV_POSITION
            {
                localPosition = position.xyz;

                return UnityObjectToClipPos(position);
            }

            float4 MyFragmentProgram(Interpolators i) : SV_TARGET
            {
                return float4(i.localPosition + 0.5, 1) * _Tint;
            }
            ENDCG
        }
    }
}
