using UnityEngine;
using System.Collections;

public class Level2 : Level {
	
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		
		Destroy(GameObject.Find("Player(Clone)"));
		
		Transform level = GameObject.Find ("Level").transform;
		for(int i = 0; i < level.childCount; i++)
		{
			Destroy (level.GetChild(i).gameObject);
		}
		
		CreateSurroundingWalls(11, 7);
		CreateWalls();
		CreateFloors();
		CreateBridgesAndSwitches();
		SpawnPlayer(1, 3);
	}
	
	private void CreateWalls()
	{
		CreateWall(3,1);
		CreateWall(4,1);
		CreateWall(5,1);
		CreateWall(6,1);
		CreateWall(7,1);
		CreateWall(8,1);
		CreateWall(9,1);
		CreateWall(10,1);
		
		CreateWall(3,4);
		CreateWall(4,4);
		CreateWall(7,4);
		CreateWall(8,4);
		CreateWall(3,5);
		CreateWall(4,5);
		CreateWall(7,5);
		CreateWall(8,5);
		CreateWall(3,6);
		CreateWall(4,6);
		CreateWall(7,6);
		CreateWall(8,6);
	}
	
	private void CreateFloors()
	{/*
		for(int i = 1; i < 9; i++)
		{
			if(i != 4 && i != 5)
			{
				for(int j = 1; j < 7; j++)
				{
					CreateFloor(i, j);
				}
			}
		}*/
	}
	
	private void CreateBridgesAndSwitches()
	{
		SoundSwitch switchObj;
		switchObj = CreateSwitch(Level.SwitchType.KICK, 2, 1).GetComponent<SoundSwitch>();
		switchObj.LinkBridge( CreateBridge(Level.BridgeType.RED, 3, 2, 2, 2) );
		
		switchObj = CreateSwitch(Level.SwitchType.SNARE, 6, 2).GetComponent<SoundSwitch>();
		switchObj.LinkBridge( CreateBridge(Level.BridgeType.GREEN, 8, 2, 2, 2) );
		switchObj.LinkBridge( CreateBridge(Level.BridgeType.GREEN, 5, 4, 2, 2) );
		
		CreateSwitch(Level.SwitchType.LEVEL_END, 10, 3).GetComponent<LevelEnd>().level = this;
	}	
	
	// Update is called once per frame
	void Update () {
		base.Update();
	}
}
