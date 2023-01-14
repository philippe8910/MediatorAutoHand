Shader "Custom/Sandfall"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _Speed ("Speed", Range(0, 10)) = 1
        _Tiling ("Tiling", Vector) = (1,1,1,1)
        _Direction ("Direction", Vector) = (0,1,0,0)
    }

    SubShader
    {
        Tags {"Queue"="Transparent" "RenderType"="Transparent"}
        LOD 100

        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;
        float _Speed;
        float4 _Tiling;
        float4 _Direction;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutput o)
{
fixed4 c = tex2D(_MainTex, IN.uv_MainTex * _Tiling + _Time.y * _Speed * _Direction.xy);
o.Albedo = c.rgb;
o.Alpha = c.a;
}
ENDCG
}
FallBack "Diffuse"
}