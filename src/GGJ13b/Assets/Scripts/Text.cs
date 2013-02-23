using UnityEngine;
using System.Collections;

public class Text : MonoBehaviour {
		
	public Texture2D moveExplainations;
	public Texture2D revertExplainations;
	public Texture2D thanks;
	
	private float timer = 0;
	private float splashTime = 8.0f;
	
	bool enabled = false;
	
	public int speed = 8;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void ShowText()
	{
		enabled = true;
		timer = 0;
	}
	
	void OnGUI()
	{
		if(!enabled)
			return;
		
		timer += Time.deltaTime;
		
		if(timer <= splashTime - 7)
			gameObject.transform.Translate(0, 0, -Time.deltaTime * speed);
		
		if(timer >= splashTime)
		{
			gameObject.transform.Translate(0, 0, Time.deltaTime * speed);
			
			if(timer >= splashTime + 3)
			{
				enabled = false;
				timer = 0;
			}
		}
	}
}