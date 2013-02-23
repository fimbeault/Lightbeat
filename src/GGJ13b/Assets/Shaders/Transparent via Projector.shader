Shader "Transparent via Projector"
{
	SubShader
	{
		Tags
			{"Queue" = "Overlay"}
		
	    Color (.26,.27,.28)
	    
		Pass
		{
			Blend OneMinusDstAlpha DstAlpha
		}
	}
}