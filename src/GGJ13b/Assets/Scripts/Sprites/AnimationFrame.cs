using UnityEngine;
using System.Collections;

public class AnimationFrame
{
	public int X { get; private set; }

	public int Y { get; private set; }

	public int Width { get; private set; }

	public int Height { get; private set; }

	public int OffsetX { get; private set; }

	public int OffsetY { get; private set; }
	
	public Vector2 Offset { get { return new Vector2 (OffsetX, OffsetY); } }
	
	public AnimationFrame (int x, int y, int width, int height, int offX = 0, int offY = 0)
	{
		X = x;
		Y = y;
		Width = width;
		Height = height;
		OffsetX = offX;
		OffsetY = offY;
	}
	
	private Texture2D frame = null;

	public Texture GetFrame (Texture2D sheet)
	{
		if (frame == null) {
			frame = new Texture2D (Width, Height);
			frame.filterMode = FilterMode.Point;
 			frame.SetPixels (sheet.GetPixels (X, sheet.height - Y - Height, Width, Height));
			frame.Apply ();
		}	
			
		return frame;
	}
}
