#ifndef SCTCGSurf
#define SCTCGSurf

//#include "UnityCG.cginc"
//====================================================
//=====================Variables======================
sampler2D _MainTex;
fixed4 _Color;
#ifdef ISCUTOUT
	fixed _Cutoff;
#endif
half _Glossiness;
half _Metallic;

//=====================Structs========================
struct Input 
{
	float2 uv_MainTex;
};

//=====================Vert===========================


//=====================Frag / Surf===========================
void surf (Input IN, inout SurfaceOutputStandard o) 
{
	fixed4 col = tex2D (_MainTex, IN.uv_MainTex) * _Color;

	#if ISCUTOUT
    	clip (col.a - _Cutoff);
    #endif

	o.Albedo = col.rgb;
	o.Metallic = _Metallic;
	o.Smoothness = _Glossiness;
	o.Alpha = col.a;
}
//====================================================
#endif // SCTCGSurf