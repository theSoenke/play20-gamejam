Shader "Drunk"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "black" {}
		_Warp ("Warp", Float) = 0.02
		_Blur ("Blur", Float) = 0.004
		_BlurMin ("BlurMin", Float) = 0
		_TimeScale ("TimeScale", Float) = 1		
	}
	Subshader
	{		
		Pass
		{
			CGPROGRAM
			#pragma vertex vertex_shader
			#pragma fragment pixel_shader
			#pragma target 2.0

			sampler2D _MainTex;
			float _Warp;
			float _Blur;
			float _TimeScale;
			float _BlurMin;

			float4 vertex_shader (float4 vertex:POSITION):SV_POSITION
			{
				return UnityObjectToClipPos(vertex);
			}

			float4 pixel_shader (float4 vertex:SV_POSITION):COLOR
			{
				vector <float,2> uv = vertex.xy/_ScreenParams.xy;
				#if UNITY_UV_STARTS_AT_TOP
					uv.y = 1-uv.y;
				#endif
				uv.x+=cos(uv.y*2.0+_Time.g*_TimeScale) * _Warp;
				uv.y+=sin(uv.x*2.0+_Time.g*_TimeScale) * _Warp;
				float o = (sin(_Time.g*_TimeScale*0.5) + 1) / 2; // 0-1
				float offset = (_BlurMin + o * (_Blur - _BlurMin)) / 100; //(_BlurMin + sin(_Time.g*_TimeScale*0.5) * 100 * (_Blur - _BlurMin)) / 1000;    
				float4 a = tex2D(_MainTex,uv);    
				float4 b = tex2D(_MainTex,uv-float2(offset,0.0));    
				float4 c = tex2D(_MainTex,uv+float2(offset,0.0));    
				float4 d = tex2D(_MainTex,uv-float2(0.0,offset));    
				float4 e = tex2D(_MainTex,uv+float2(0.0,offset));        
				return (a+b+c+d+e)/5.0;
			}
			ENDCG
		}
	}
}