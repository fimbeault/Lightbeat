using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	
	public bool R_keyEnabled = true;
	
	public GameObject wall;
	public GameObject Hole;
	public GameObject floor;
	public GameObject kickSwitch;
	public GameObject clapSwitch;
	public GameObject snareSwitch;
	public GameObject fbassSwitch;
	public GameObject synthSwitch;
	public GameObject synth2Switch;
	public GameObject endSwitch;
	public GameObject player;
	
	public GameObject bridgeBuilder;
	public GameObject blueBridge;
	public GameObject redBridge;
	public GameObject orangeBridge;
	public GameObject purpleBridge;
	public GameObject yellowBridge;
	public GameObject greenBridge;
	
	public GameObject blueWall;
	public GameObject redWall;
	public GameObject orangeWall;
	public GameObject purpleWall;
	public GameObject yellowWall;
	public GameObject greenWall;
	
	List<string> levels;
	int currentLevelIndex = 0;
	
	// Use this for initialization
	void Start () {
		levels = new List<string>();
		levels.Add("filelevel2");
		levels.Add("filelevel3");
		levels.Add("filelevel4");
		levels.Add("filelevel5");
		levels.Add("filelevel6");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void NextLevel()
	{
		if(currentLevelIndex >= levels.Count)
		{
			Application.LoadLevel("Credits");
		}
		
		else
		{
			GameObject.Find("Level").AddComponent(levels[currentLevelIndex]);
			currentLevelIndex++;
			
			// HACKS HERE
			GameObject.Find ("SoundLevel").GetComponent<SoundLevel>().MuteAll();
			
			Player p = GameObject.Find ("Player(Clone)").GetComponent<Player>();
			p.lastSwitches.Clear();
		}
	}
}
