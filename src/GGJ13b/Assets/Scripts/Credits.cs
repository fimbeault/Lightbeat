using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {
	
	public Texture blackScreen;
	
	private float timer = 0;
	private float splashTime = 20.0f;
	private float fadeValue = 1;
	
	int count = 0;
	
	// Use this for initialization
	void Start () {
		GameObject.Find("Credits").renderer.enabled = true;
		GameObject.Find("Thanks").renderer.enabled = false;
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
			count++;
			
			if(count > 1)
			{
				Application.Quit ();
				Debug.Break();
			}
			
			else
			{
				timer = 0;
				
				if(count == 1)
				{
					GameObject.Find("Credits").renderer.enabled = false;
					GameObject.Find("Thanks").renderer.enabled = true;
					
					Text text = GameObject.Find ("Text").GetComponent<Text>();
			
					text.gameObject.renderer.material.mainTexture = text.thanks;
					text.speed = 32;
					text.ShowText();
				}
			}
		}
	}
}

