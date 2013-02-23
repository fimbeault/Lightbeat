using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	
	public int forcePush;
	private bool lastFrameCollided;
	private Transform lastCollided;
	
	Vector2 direction = new Vector2(0, -1);
	
	public List<Transform> lastSwitches;
	
	public bool playEnabled = true;
	
	// Use this for initialization
	void Awake () {
		lastSwitches = new List<Transform>();
		lastCollided = null;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(!playEnabled)
			return;
		
		if(Input.GetAxis("Horizontal") < 0 || Input.GetKey(KeyCode.A))
		{
			gameObject.rigidbody.AddForce(new Vector3(-forcePush, 0, 0));
		}
		
		if(Input.GetAxis("Horizontal") > 0 || Input.GetKey(KeyCode.D))
		{
			gameObject.rigidbody.AddForce(new Vector3(forcePush, 0, 0));
		}
		
		if(Input.GetAxis("Vertical") < 0 || Input.GetKey(KeyCode.W))
		{
			gameObject.rigidbody.AddForce(new Vector3(0, forcePush, 0));
		}
		
		if(Input.GetAxis("Vertical") > 0 || Input.GetKey(KeyCode.S))
		{
			gameObject.rigidbody.AddForce(new Vector3(0, -forcePush, 0));
		}
		
		// Facing		
		gameObject.transform.LookAt(transform.position - transform.rigidbody.velocity, Vector3.back);
		
		// Collisions
		RaycastHit[] hits = Physics.RaycastAll(new Ray(gameObject.transform.position, new Vector3(0, 0, 3)));
		
		int nHits = 0;
		
		foreach(RaycastHit hit in hits)
		{
			if(hit.collider.tag == "Switch")
			{
				nHits++;
				
				if(!lastFrameCollided || (lastFrameCollided && lastCollided != hit.transform))
				{
					hit.collider.gameObject.GetComponent<Switch>().Activate();
					lastFrameCollided = true;
					lastCollided = hit.transform;
					
					AddSwitch(hit.transform);
				}				
			}
		}
		
		if(nHits == 0)
		{
			lastFrameCollided = false;
			lastCollided = null;
		}
	}
	
	void AddSwitch(Transform trans)
	{
		foreach(Transform t in lastSwitches)
		{
			if(t == trans)
				return;
		}
		
		lastSwitches.Add(trans);
	}
	
	public void RevertOneSwitch()
	{
		if(lastSwitches.Count > 0)
		{
			lastFrameCollided = true;
				
			Transform t = lastSwitches[lastSwitches.Count - 1];
			lastSwitches.RemoveAt(lastSwitches.Count - 1);
			
			lastCollided = t;
			
			gameObject.transform.position = new Vector3(t.position.x, t.position.y, -5);
		}
	}
}
