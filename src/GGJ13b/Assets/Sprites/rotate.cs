using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {
	public float rotateAngle = 2.0F;
	public bool reverse = true;

	void Start()
	{
	}

	void Update() {
		if(reverse)
			gameObject.transform.Rotate(new Vector3(0, rotateAngle, 0)); // or += value if want to rotate in the other direction
		else
			gameObject.transform.Rotate(new Vector3(0, -rotateAngle, 0)); // or += value if want to rotate in the other direction
    }
}