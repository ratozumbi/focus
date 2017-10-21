Shader "Simple SeeThrough v2/Surf NPC or Props"
{
	Properties 
	{
	    [Enum(Off,0,Front,1,Back,2)] _CullMode ("Culling Mode", int) = 0
        [Enum(UnityEngine.Rendering.CompareFunction)] _ZTest ("ZTest", Float) = 8
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0

		[Header(Cutout)]
		[Toggle(ISCUTOUT)] _isCutout ("Is Cutout?", Float) = 0
		_Cutoff ("Alpha Cutoff", Range(0,1)) = 0.5
	}
	SubShader 
	{
        Tags { "Queue"="Geometry" "RenderType"="Opaque" }
        ZWrite On Cull [_CullMode]
        ZTest [_ZTest]
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
