using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {
	
	public Texture blackScreen;
	
	private float timer = 0;
	private float splashTime = 16.0f;
	private float fadeValue = 1;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnGUI()
	{
		timer += Time.deltaTime;
		
		if (timer >= (splashTime - 6.0f))
		{
			if (fadeValue < 1)
				fadeValue += Mathf.Clamp01(Time.deltaTime/4);
			GUI.color = new Color(0,0,0, fadeValue);
			GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height), blackScreen);
		}
		else
		{
			if (fadeValue > 0)
				fadeValue -= Mathf.Clamp01(Time.deltaTime/8);
			GUI.color = new Color(0,0,0, fadeValue);
			GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height), blackScreen);
		}
		
		if(timer >= splashTime)
		{
			Application.LoadLevel("Story");
		}
	}
}

