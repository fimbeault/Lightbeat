using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Spritesheet {
    GameObject gameobject;
	Texture2D spritesheet = null;
	
	Dictionary<string, SpriteAnimation> animations = new Dictionary<string, SpriteAnimation>();
	SpriteAnimation activeAnimation = null;
	
	public Spritesheet(GameObject o)
	{
        gameobject = o;
	}
	
	public void Render()
	{
		gameobject.renderer.material.mainTexture = activeAnimation.CurrentFrame.GetFrame(spritesheet);
	}
	
	public bool Load(string sprite)
	{
		spritesheet = (Texture2D)Resources.Load(sprite);
		
		if(spritesheet == null)
			return false;
		
		gameobject.renderer.material.shader = Shader.Find("Unlit/Transparent");
		return true;
	}
	
	public void Reset() {
		foreach (SpriteAnimation a in animations.Values) {
			a.Reset();
		}
	}
	
	public void CreateAnimation(string name, int framerate)
	{
		SpriteAnimation animation = new SpriteAnimation(framerate);
		animations.Add(name, animation);
	}
	
	public bool AddFrame(string animationName, int x, int y, int width, int height, int offsetX = 0, int offsetY = 0)
	{
		if(animations.ContainsKey(animationName))
		{
			AnimationFrame frame = new AnimationFrame(x, y, width, height, offsetX, offsetY);
			animations[animationName].Add(frame);
			
			return true;
		}
		
		else
			return false;
	}
	
	public void SetCurrentAnimation(string animation)
	{
		if(animations.ContainsKey(animation))
			activeAnimation = animations[animation];
	}
	
	public SpriteAnimation this[string anim] {
		get {
			if (animations.ContainsKey(anim)) {
				return animations[anim];
			}
			
			return null;
		}
	}
}
