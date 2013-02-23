using UnityEngine;
using System.Collections;

public abstract class Level : MonoBehaviour {
	
	public GameManager gameManager;
	
	protected int scale = 5;
	
	protected int width;
	protected int height;
	
	protected Transform playerTransform;
	protected Vector3 initialPlayerPosition;
	
	protected enum SwitchType
	{
		KICK,
		CLAP,
		SNARE,
		FBASS,
		SYNTH,
		SYNTH2,
		LEVEL_END
	}
	
	protected enum BridgeType
	{
		BLUE,
		RED,
		ORANGE,
		PURPLE,
		YELLOW,
		GREEN
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected void Update () {
	
		// Reset Level
		if(Input.GetKeyDown(KeyCode.R) && gameManager.R_keyEnabled)
		{
			// Reset Level
			//playerTransform.position = new Vector3(initialPlayerPosition.x, initialPlayerPosition.y, initialPlayerPosition.z);
			
			// Awesome Feature
			playerTransform.gameObject.GetComponent<Player>().RevertOneSwitch();
			
			
			playerTransform.rigidbody.velocity = new Vector3(0, 0, 0);
		}
		
		if(Input.GetKeyDown(KeyCode.C))
		{
			gameManager.NextLevel();
		}
	}
	
	protected void CreateSurroundingWalls(int w, int h)
	{
		width = w;
		height = h;
		
		for(int i = 0; i < width; i++)
		{
			for(int j = 0; j < height; j++)
			{
				if((i == 0) || (i == width-1) || (j == height - 1) || (j == 0))
				{
					CreateWall(i, j);
				}
			}
		}
	}
	
	protected void CreateWall(int x, int y)
	{
		int posX = (int)gameObject.transform.position.x + (x * scale);
		int posY = (int)gameObject.transform.position.y + (y * scale);
		
		GameObject wallObj = (GameObject)Instantiate(gameManager.wall, new Vector3(posX, posY, gameObject.transform.position.z), Quaternion.identity);
		wallObj.transform.localScale = new Vector3(scale, scale, scale);
		wallObj.transform.parent = gameObject.transform;
	}
	
	protected void CreateFloor(int x, int y)
	{
		int posX = (int)gameObject.transform.position.x + (x * scale);
		int posY = (int)gameObject.transform.position.y + (y * scale);
		
		GameObject wallObj = (GameObject)Instantiate(gameManager.floor, new Vector3(posX, posY, gameObject.transform.position.z), Quaternion.identity);
		wallObj.transform.Rotate(new Vector3(270, 0, 0));
		wallObj.transform.localScale = new Vector3(scale * 0.1f , 1, scale * 0.1f);
		wallObj.transform.Translate(new Vector3(0, -10, 0));
		wallObj.transform.parent = gameObject.transform;
	}
	
	protected GameObject CreateSwitch(SwitchType type, int x, int y)
	{
		GameObject obj = null;
		
		switch(type)
		{
		case SwitchType.KICK:
			obj = gameManager.kickSwitch;
			break;
			
		case SwitchType.CLAP:
			obj = gameManager.clapSwitch;
			break;
			
		case SwitchType.SNARE:
			obj = gameManager.snareSwitch;
			break;
			
		case SwitchType.FBASS:
			obj = gameManager.fbassSwitch;
			break;
			
		case SwitchType.SYNTH:
			obj = gameManager.synthSwitch;
			break;
			
		case SwitchType.SYNTH2:
			obj = gameManager.synth2Switch;
			break;
			
		case SwitchType.LEVEL_END:
			obj = gameManager.endSwitch;
			break;
		}
		
		
		GameObject switchObj = (GameObject)Instantiate(obj, new Vector3(transform.position.x + (x * scale), transform.position.y + (y * scale), -2), Quaternion.identity);
		switchObj.transform.parent = gameObject.transform;
		switchObj.transform.Rotate(new Vector3(90, 180, 0));
		switchObj.transform.localScale = new Vector3(scale * 0.1f , 1, scale * 0.1f);
		
		return switchObj;
	}
	
	protected void CreateHole(int x, int y)
	{
		int posX = (int)gameObject.transform.position.x + (x * scale);
		int posY = (int)gameObject.transform.position.y + (y * scale);
		GameObject obj = gameManager.Hole;
		
		GameObject holeObj = (GameObject)Instantiate(obj, new Vector3(posX, posY, gameObject.transform.position.z), Quaternion.identity);
		holeObj.transform.parent = gameObject.transform;
		holeObj.transform.Rotate(new Vector3(0, 180, 0));
		holeObj.transform.localScale = new Vector3(scale, scale, scale);
	}
	
	protected EmptyBridge CreateBridge(BridgeType type, int x, int y, int tileX, int tileY)
	{
		GameObject obj = null;
		
		switch(type)
		{
		case BridgeType.BLUE:
			obj = gameManager.blueBridge;
			break;
			
		case BridgeType.RED:
			obj = gameManager.redBridge;
			break;
			
		case BridgeType.ORANGE:
			obj = gameManager.orangeBridge;
			break;
			
		case BridgeType.PURPLE:
			obj = gameManager.purpleBridge;
			break;
			
		case BridgeType.GREEN:
			obj = gameManager.greenBridge;
			break;
			
		case BridgeType.YELLOW:
			obj = gameManager.yellowBridge;
			break;
		}
		
		GameObject bridgeObj = (GameObject)Instantiate(gameManager.bridgeBuilder, new Vector3(transform.position.x + (x * scale), transform.position.y + (y * scale), -2), Quaternion.identity);
		bridgeObj.transform.parent = gameObject.transform;
		bridgeObj.transform.Rotate(new Vector3(270, 0, 0));
		
		bridgeObj.GetComponent<EmptyBridge>().scale = scale;
		bridgeObj.GetComponent<EmptyBridge>().nbBlocX = tileX;
		bridgeObj.GetComponent<EmptyBridge>().nbBlocY = tileY;
		bridgeObj.GetComponent<EmptyBridge>().bridgePart = obj;
		
		return bridgeObj.GetComponent<EmptyBridge>();
	}
	
	protected AudioWall CreateAudioWall(BridgeType type, int x, int y)
	{
		GameObject obj = null;
		
		switch(type)
		{
		case BridgeType.BLUE:
			obj = gameManager.blueWall;
			break;
			
		case BridgeType.RED:
			obj = gameManager.redWall;
			break;
			
		case BridgeType.ORANGE:
			obj = gameManager.orangeWall;
			break;
			
		case BridgeType.PURPLE:
			obj = gameManager.purpleWall;
			break;
			
		case BridgeType.GREEN:
			obj = gameManager.greenWall;
			break;
			
		case BridgeType.YELLOW:
			obj = gameManager.yellowWall;
			break;
		}
		
		int posX = (int)gameObject.transform.position.x + (x * scale);
		int posY = (int)gameObject.transform.position.y + (y * scale);
		
		GameObject wallObj = (GameObject)Instantiate(obj, new Vector3(posX, posY, gameObject.transform.position.z), Quaternion.identity);
		wallObj.transform.parent = gameObject.transform;
		wallObj.transform.Rotate(new Vector3(0, 180, 0));
		wallObj.transform.localScale = new Vector3(scale, scale, scale);
		
		return wallObj.GetComponent<AudioWall>();
	}
	
	protected void SpawnPlayer(int x, int y)
	{
		GameObject playerObj = (GameObject)(Instantiate(gameManager.player, new Vector3(transform.position.x + (x * scale), transform.position.y + (y * scale), -5), Quaternion.identity));
		playerObj.transform.Rotate(new Vector3(270, 0, 0));
		playerObj.transform.localScale = new Vector3(scale * 0.08f ,1 ,scale * 0.08f);
		
		playerTransform = playerObj.transform;
		initialPlayerPosition = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z);
		
		Camera.main.GetComponent<FollowCamera>().SetTarget(playerObj.transform);
	}
}
