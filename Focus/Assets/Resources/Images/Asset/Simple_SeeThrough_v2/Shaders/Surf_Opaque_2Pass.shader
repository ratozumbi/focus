Shader "Simple SeeThrough v2/Surf Player"
{
	Properties 
	{
        [Enum(Off,0,Front,1,Back,2)] _CullMode ("Culling Mode", int) = 0
		_Color ("Color", Color) = (1,1,1,1)
		_SeeThroughColor ("SeeThrough Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0

		[Header(Cutout)]
		[Toggle(ISCUTOUT)] _isCutout ("Is Cutout?", Float) = 0
		_Cutoff ("Alpha Cutoff", Range(0,1)) = 0.5
	}
	SubShader 
	{
		Pass
		{
			Tags {"Queue"="Transparent+100" "IgnoreProjector"="True" "RenderType"="Transparent"}
			Blend SrcAlpha OneMinusSrcAlpha //Alpha Blend
        	Lighting Off ZWrite Off Cull [_CullMode]
            ZTest Greater
			CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag_unlit_seethru
            //#pragma fragment frag_unlit_seethru_invert
            #pragma shader_feature ISCUTOUT
            #include "SCTCGUnlit.cginc"
			ENDCG
		}

    	Tags {"Queue"="Geometry" "RenderType"="Opaque"}
    	ZWrite On Cull [_CullMode]
        ZTest LEqual
		LOD 200
		
		CGPROGRAM
		#include "SCTCGSurf.cginc"
		#pragma surface surf Standard fullforwardshadows addshadow
		#pragma shader_feature ISCUTOUT
		#pragma target 3.0
		ENDCG
	}
	FallBack "Diffuse"
}
