#ifndef SCTCGUnlit
#define SCTCGUnlit

#include "UnityCG.cginc"
//====================================================
//=====================Variables======================
sampler2D _MainTex;
float4 _MainTex_ST;
fixed4 _SeeThroughColor;
fixed4 _Color;
#ifdef ISCUTOUT
	fixed _Cutoff;
#endif

//=====================Structs========================
struct appdata
{
    float4 vertex : POSITION;
    float2 uv : TEXCOORD0;
    fixed4 color : COLOR;
};

struct v2f
{
    float2 uv : TEXCOORD0;
    float4 vertex : SV_POSITION;
    fixed4 color : COLOR;
};

//=====================Vert===========================
v2f vert (appdata v)
{
    v2f o;
    o.vertex = UnityObjectToClipPos(v.vertex);
    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
    o.color = v.color;
    return o;
}

//=====================Frag===========================
fixed4 frag_unlit (v2f i) : SV_Target
{
    fixed4 col = tex2D(_MainTex, i.uv) * _Color;

    #if ISCUTOUT
    	clip (col.a - _Cutoff);
    #endif

    return col * i.color;
}

fixed4 frag_unlit_seethru (v2f i) : SV_Target
{
	fixed4 col;

	#if ISCUTOUT
		col = tex2D(_MainTex, i.uv);
    	clip (col.a - _Cutoff);
    #endif

    col = _SeeThroughColor;
    return col * i.color;
}

fixed4 frag_unlit_seethru_invert (v2f i) : SV_Target
{
	fixed4 col = tex2D(_MainTex, i.uv);

	#if ISCUTOUT
		col = tex2D(_MainTex, i.uv);
    	clip (col.a - _Cutoff);
    #else
    	col.a *= 0.5f;
    #endif

    col.rgb = 1.00f - col.rgb;
    return col * _SeeThroughColor * i.color;
}
//====================================================
#endif // SCTCGUnlit