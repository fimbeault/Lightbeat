using UnityEngine;
using System.Collections;

public class Level22 : Level {
	
	public int levelWidth = 9;	// Including Contour (drawable: levelWidth-2)
	public int levelheight = 16; // Including Contour (drawable: levelheight-2)
	
	public int playerSpawnX = 1;
	public int playerSpawnY = 1;
	
	public int varLevelEndX = 8;
	public int varLevelEndY = 1;
	
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		
		Destroy(GameObject.Find("Player(Clone)"));
		
		Transform level = GameObject.Find ("Level").transform;
		for(int i = 0; i < level.childCount; i++)
		{
			Destroy (level.GetChild(i).gameObject);
		}
		
		// Grosseur du level (x,y)
		CreateSurroundingWalls(levelWidth, levelheight);
		// Murs intérieur (0, 0) en bas a gauche
		CreateWalls();
		// u kidding me?
		CreateBridgesAndSwitches();
		// u kidding me?
		SpawnPlayer(playerSpawnX, playerSpawnY);
	}
	
	private void CreateWalls()
	{
		for (int i = 1; i < 4; i++)
			CreateWall(2,i);
		
		for (int i = 6; i < levelheight-1; i++)
		{
			CreateWall(1,i);
			CreateWall(2,i);
		}
		
	}
	
	private void CreateBridgesAndSwitches()
	{
		SoundSwitch switchObj1;
		SoundSwitch switchObj2;
		SoundSwitch switchObj3;
		SoundSwitch switchObj4;

		switchObj1 = CreateSwitch(Level.SwitchType.KICK, 2, 4).GetComponent<SoundSwitch>();
		switchObj2 = CreateSwitch(Level.SwitchType.KICK, 2, 5).GetComponent<SoundSwitch>();
		switchObj3 = CreateSwitch(Level.SwitchType.SNARE, 3, 6).GetComponent<SoundSwitch>();
		switchObj4 = CreateSwitch(Level.SwitchType.SNARE, 4, 6).GetComponent<SoundSwitch>();
		
		// bridge: x, y, a, b  --> x, y point en bas gauche, a, b, nb bloques hauteur, largeur.
		EmptyBridge bridge1 = CreateBridge(Level.BridgeType.RED, 3, 4, 2, 2);
		EmptyBridge bridge2 = CreateBridge(Level.BridgeType.BLUE, 3, 7, 2, 2);
		
		switchObj1.LinkBridge( bridge1 );
		switchObj2.LinkBridge( bridge1 );
		switchObj3.LinkBridge( bridge2 );
		switchObj4.LinkBridge( bridge2 );
		
		// End level: Titre de la switch  				Prochain niveau:
		CreateSwitch(Level.SwitchType.LEVEL_END, varLevelEndX, varLevelEndY).GetComponent<LevelEnd>().level = this;
		
	}	
	
	// Update is called once per frame
	void Update () {
	
	}
}
