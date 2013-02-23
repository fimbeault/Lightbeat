using UnityEngine;
using System.Collections;

// How to use:
// Make your sprite (don't put any offset between frames), Attach the picture to
// a Material, then attch the material to a new plane and drag this script on the
// plane, set the correct values and enjoy your sprite, tada!

class AnimateTiledTexture : MonoBehaviour
{
    public int columns = 6;
    public int rows = 1;
    public float framesPerSecond = 25f;
	public float startDelay = 0;
	public bool useStartDelay = false;
	public bool loop = false;
	public bool PulseOnInit = false;
	public WINDING_ORDER winding = WINDING_ORDER.CW;
 
    //the current frame to display (and starting index)
	public int endIndex = 0;
    public int startIndex = 0;
	private int index = 0;
	
	public int iddleIndex = 0;
	public bool skipIddleIndexInLoop = false;
 
	private bool isPlaying = false;
	private bool isIdle = false;
	
	// Which way to wind polygons?
	public enum WINDING_ORDER
	{
		CCW,		// Counter-clockwise
		CW			// Clockwise
	};
	
    void Start()
    {
        //set the tile size of the texture (in UV units), based on the rows and columns
        Vector2 size = new Vector2(1f / columns, 1f / rows);
        renderer.sharedMaterial.SetTextureScale("_MainTex", size);
		
		idle ();
		
		if(PulseOnInit)
			pulseOnce();
    }
	
	public void pulseOnce()
	{
		restart ();
		StartCoroutine(pulse());
	}
	
	public void idle()
	{
		isIdle = true;
		index = iddleIndex;
		renderImage();
	}
	
	public void restart()
	{
		isIdle = false;
	}
	
	private IEnumerator pulse()
	{
		if(isIdle)
		{
			yield return new WaitForSeconds(1f / framesPerSecond);
		}
		
		else
		{
			do
			{
				index = startIndex;
				int theWinding = 1;
				if (winding == WINDING_ORDER.CW)
					theWinding = 1;
				else if (winding == WINDING_ORDER.CCW)
					theWinding = -1;
				
				if(useStartDelay)
					yield return new WaitForSeconds(startDelay);
				
				for (index = startIndex; index <= endIndex; index += theWinding)
				{
					isPlaying = true;
		 
					if (skipIddleIndexInLoop)
						if (iddleIndex == index)
							continue;
					
					renderImage();
		 		
		            yield return new WaitForSeconds(1f / framesPerSecond);
				}
				
		        index = startIndex;
				
				if(isIdle)
					index = iddleIndex;
				
				renderImage();
			} while(loop);
			
			isPlaying = false;
		}
	}
	
	void renderImage()
	{
        //split into x and y indexes
        Vector2 offset = new Vector2((float)index / columns - (index / columns), //x index
                                      (index / columns) / (float)rows);          //y index

        renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);	
	}
}