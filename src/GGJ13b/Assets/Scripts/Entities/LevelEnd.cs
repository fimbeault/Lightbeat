using UnityEngine;
using System.Collections;

public class LevelEnd : Switch {

	public Level level;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	override public void Activate()
	{
		GameObject.Find ("GameManager").GetComponent<GameManager>().NextLevel();
	}
}
