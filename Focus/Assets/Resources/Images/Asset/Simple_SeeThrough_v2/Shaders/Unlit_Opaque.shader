Shader "Simple SeeThrough v2/Unlit NPC or Props"
{
	Properties
	{
        [Enum(Off,0,Front,1,Back,2)] _CullMode ("Culling Mode", int) = 0
        [Enum(UnityEngine.Rendering.CompareFunction)] _ZTest ("ZTest", Float) = 8
        _Color ("Color", Color) = (1,1,1,1)
		_MainTex ("_MainTex (RGBA)", 2D) = "white" {}

		[Header(Cutout)]
		[Toggle(ISCUTOUT)] _isCutout ("Is Cutout?", Float) = 0
		_Cutoff ("Alpha Cutoff", Range(0,1)) = 0.5
	}
	SubShader
	{
        Tags { "Queue"="Geometry" "RenderType"="Opaque" }
        Lighting Off ZWrite On Cull [_CullMode]

		Pass
		{
            ZTest [_ZTest]
			CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag_unlit
            #pragma shader_feature ISCUTOUT
            #include "SCTCGUnlit.cginc"
			ENDCG
		}
	}
}
