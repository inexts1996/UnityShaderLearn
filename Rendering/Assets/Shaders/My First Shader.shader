Shader "Custom/My First Shader"
{
    SubShader
    {
        pass
        {
            CGPROGRAM
            #pragma vertex MyVertexProgram
            #pragma fragment MyFragmentProgram

            #include "UnityCG.cginc"

            float4 MyVertexProgram(): SV_POSITION
            {
                return 0;
            }
            void MyFragmentProgram()
            {

            }
            ENDCG
        }
    }
}
