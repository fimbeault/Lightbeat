Shader "Transparency Projector" {	

	Properties
	{
		_MainTex ("Cookie", 2D) = "" {TexGen ObjectLinear}
	}
	
	SubShader
	{		
		Blend Zero SrcColor
		
		Pass 
		{        		
			SetTexture [_MainTex] 
			{
				ConstantColor (0.8,0.8,0.8)
				Combine constant, texture
				Matrix [_Projector]
			}
		}   
	}
}