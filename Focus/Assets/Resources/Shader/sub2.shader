Shader "Custom/subtractive2"
{
	SubShader
	{
		Pass
	{
		// use a pixel blend, so that it takes from the color from the buffer 
		Blend SrcAlpha OneMinusSrcAlpha

		// pixel blending only works with lighting, so turn it on
		Lighting On
		// make sure the depth gets written in
		ZWrite On

		// set the material color to invisible
		Material
	{
		Diffuse(0,0,0,0)
	}
	}
	}
}