using UnityEngine;
using System.Collections;

public class FirstLevelFade : MonoBehaviour {
	
	public Texture blackScreen;
	
	private float timer = 0;
	private float splashTime = 8.0f;
	private float fadeValue = 1;
	
	int count = 0;
	
	bool hack1Use = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject.Find ("Player(Clone)").GetComponent<Player>().playEnabled = false;
	}
	
	void OnGUI()
	{
		timer += Time.deltaTime;
		
		if (fadeValue > 0)
			fadeValue -= Mathf.Clamp01(Time.deltaTime/8);
		
		GUI.color = new Color(0,0,0, fadeValue);
		GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height), blackScreen);

		if(timer >= splashTime)
		{
			if(!hack1Use)
			{
				GameObject.Find("Audio").GetComponent<AudioIntro>().Stop();
				hack1Use = true;
			}
			
			Text text = GameObject.Find ("Text").GetComponent<Text>();
			
			text.gameObject.renderer.material.mainTexture = text.moveExplainations;
			text.ShowText();
			
			
			GameObject.Find ("Player(Clone)").GetComponent<Player>().playEnabled = true;
			Destroy(this);
		}
	}
}