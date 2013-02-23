using UnityEngine;
using System.Collections;

public class Story : MonoBehaviour {
	
	public Texture blackScreen;
	
	private float timer = 0;
	private float splashTime = 16.0f;
	private float fadeValue = 1;
	
	int count = 0;
	
	// Use this for initialization
	void Start () {
		GameObject.Find("board1").renderer.enabled = true;
		GameObject.Find("board2").renderer.enabled = false;
		GameObject.Find("board3").renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnGUI()
	{
		timer += Time.deltaTime;
		
		if (timer >= (splashTime - 8.0f))
		{
			if (fadeValue < 1)
				fadeValue += Mathf.Clamp01(Time.deltaTime/8);
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
			count++;
			
			if(count > 2)
				Application.LoadLevel("main");
			
			else
			{
				timer = 0;
				
				if(count == 1)
				{
					GameObject.Find("board1").renderer.enabled = false;
					GameObject.Find("board2").renderer.enabled = true;
					GameObject.Find("board3").renderer.enabled = false;
				}
				
				else if(count == 2)
				{
					GameObject.Find("board1").renderer.enabled = false;
					GameObject.Find("board2").renderer.enabled = false;
					GameObject.Find("board3").renderer.enabled = true;
				}
			}
		}
	}
}