using UnityEngine;
using System.Collections;

public class AudioWall : MonoBehaviour {
	
	bool activated = true;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Toogle()
	{
		if(activated)
			Deactivate();
		
		else
			Activate();
	}
	
	public void Activate()
	{
		gameObject.GetComponent<BoxCollider>().enabled = true;
		gameObject.renderer.enabled = true;
		
		activated = true;
	}
	
	public void Deactivate()
	{
		gameObject.GetComponent<BoxCollider>().enabled = false;
		gameObject.renderer.enabled = false;
		
		activated = false;
	}
}
