using UnityEngine;
using System.Collections;

public class Level1 : Level {
	
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		
		Destroy(GameObject.Find("Player(Clone)"));
		
		Transform level = GameObject.Find ("Level").transform;
		for(int i = 0; i < level.childCount; i++)
		{
			Destroy (level.GetChild(i).gameObject);
		}
		
		CreateSurroundingWalls(9, 7);
		CreateWalls();
		CreateFloors();
		CreateBridgesAndSwitches();
		SpawnPlayer(1, 3);
	}
	
	private void CreateWalls()
	{
		CreateWall(2,1);
		CreateWall(4,1);
		CreateWall(5,1);
		CreateWall(4,5);
		CreateWall(5,5);
	}
	
	private void CreateFloors()
	{
		for(int i = 1; i < 9; i++)
		{
			if(i != 4 && i != 5)
			{
				for(int j = 1; j < 7; j++)
				{
					CreateFloor(i, j);
				}
			}
		}
	}
	
	private void CreateBridgesAndSwitches()
	{
		SoundSwitch switchObj;
		switchObj = CreateSwitch(Level.SwitchType.KICK, 3, 1).GetComponent<SoundSwitch>();
		switchObj.LinkBridge( CreateBridge(Level.BridgeType.RED, 4, 2, 2, 3) );
		
		CreateSwitch(Level.SwitchType.LEVEL_END, 7, 3).GetComponent<LevelEnd>().level = this;
	}	
	
	// Update is called once per frame
	void Update () {
		base.Update();
	}
}
