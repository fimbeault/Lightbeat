using UnityEngine;
using System.Collections;

public abstract class Switch : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.tag = "Switch";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	abstract public void Activate();
}
