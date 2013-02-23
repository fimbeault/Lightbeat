using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {
	
	public Transform target;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(!target)
			return;
		
		float wantedX = target.position.x;
		float wantedY = target.position.y;
	
		transform.position = new Vector3(wantedX, wantedY, -12);
	}
	
	public void SetTarget(Transform trans)
	{
		target = trans;
	}
}
