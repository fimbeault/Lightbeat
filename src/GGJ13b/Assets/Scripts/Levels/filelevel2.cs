using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public class filelevel2 : Level {
	

	
	public string fileName = "level2.txt";
	
		
	private int levelWidth;	// Including Contour (drawable: levelWidth-2)
	private int levelheight; // Including Contour (drawable: levelheight-2)
	
	private int playerSpawnX;
	private int playerSpawnY;
	
	private int varLevelEndX;
	private int varLevelEndY;
	
	// Use this for initialization
	void Start () {
		
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		Destroy(GameObject.Find("Player(Clone)"));
		Transform level = GameObject.Find ("Level").transform;
		for(int i = 0; i < level.childCount; i++)
		{
			Destroy (level.GetChild(i).gameObject);
		}
		
		
	    StreamReader sr = new StreamReader(Application.dataPath + "/levels/" + fileName);
	    string fileContents = sr.ReadToEnd();
	    sr.Close();
	 
	    string[] lines = fileContents.Split("\n"[0]);
		levelWidth = lines[0].Length;
		levelheight = lines.Length;
		
		// Désastre algorithmique ^ un désastre algorithmique
		List<SoundSwitch> switchesKick = new List<SoundSwitch>();
		List<SoundSwitch> switchesSnare = new List<SoundSwitch>();
		List<SoundSwitch> switchesClap = new List<SoundSwitch>();
		List<SoundSwitch> switchesFbass = new List<SoundSwitch>();
		List<SoundSwitch> switchesSynth = new List<SoundSwitch>();
		List<SoundSwitch> switchesSynth2 = new List<SoundSwitch>();
		
		List<AudioWall> wallsKick = new List<AudioWall>();
		List<AudioWall> wallsSnare = new List<AudioWall>();
		List<AudioWall> wallsClap = new List<AudioWall>();
		List<AudioWall> wallsFbass = new List<AudioWall>();
		List<AudioWall> wallsSynth = new List<AudioWall>();
		List<AudioWall> wallsSynth2 = new List<AudioWall>();
		
		for(int i = lines.Length - 1; i >= 0; i--)
		{
			int y = lines.Length - i;
			string line = lines[i];
			
			for(int x = 0; x <= line.Length - 1; x++)
			{
				char theCharToAnalyse = line[x];
				switch (theCharToAnalyse)
				{
				case '#':
					CreateWall(x, y);
					break;
				case 'Z':
					CreateSwitch(Level.SwitchType.LEVEL_END, x, y).GetComponent<LevelEnd>().level = this;
					CreateFloor(x, y);
					break;
				case 'a':
					switchesKick.Add(CreateSwitch(Level.SwitchType.KICK, x, y).GetComponent<SoundSwitch>());
					CreateFloor(x, y);
					break;
				case 'A':
					wallsKick.Add(CreateAudioWall(Level.BridgeType.RED, x, y).GetComponent<AudioWall>());
					CreateFloor(x, y);
					break;
				case 'b':
					switchesSnare.Add(CreateSwitch(Level.SwitchType.SNARE, x, y).GetComponent<SoundSwitch>());
					CreateFloor(x, y);
					break;
				case 'B':
					wallsSnare.Add(CreateAudioWall(Level.BridgeType.BLUE, x, y).GetComponent<AudioWall>());
					CreateFloor(x, y);
					break;
				case 'c':
					switchesClap.Add(CreateSwitch(Level.SwitchType.CLAP, x, y).GetComponent<SoundSwitch>());
					CreateFloor(x, y);
					break;
				case 'C':
					wallsClap.Add(CreateAudioWall(Level.BridgeType.ORANGE, x, y).GetComponent<AudioWall>());
					CreateFloor(x, y);
					break;
				case 'd':
					// FBASS car on a trouvé F*cking Bass fun, Game Jam fun happens quand on manque de sommeile :)
					switchesFbass.Add(CreateSwitch(Level.SwitchType.FBASS, x, y).GetComponent<SoundSwitch>());
					CreateFloor(x, y);
					break;
				case 'D':
					wallsFbass.Add(CreateAudioWall(Level.BridgeType.PURPLE, x, y).GetComponent<AudioWall>());
					CreateFloor(x, y);
					break;
				case 'e':
					switchesSynth.Add(CreateSwitch(Level.SwitchType.SYNTH, x, y).GetComponent<SoundSwitch>());
					CreateFloor(x, y);
					break;
				case 'E':
					wallsSynth.Add(CreateAudioWall(Level.BridgeType.GREEN, x, y).GetComponent<AudioWall>());
					CreateFloor(x, y);
					break;
				case 'f':
					switchesSynth2.Add(CreateSwitch(Level.SwitchType.SYNTH2, x, y).GetComponent<SoundSwitch>());
					CreateFloor(x, y);
					break;
				case 'F':
					wallsSynth2.Add(CreateAudioWall(Level.BridgeType.YELLOW, x, y).GetComponent<AudioWall>());
					CreateFloor(x, y);
					break;
				case ' ':
					CreateFloor(x, y);
					break;
				case '0':
					// No floor ici
					CreateHole(x, y);
					break;
				case 'S':
					CreateFloor(x, y);
					playerSpawnX = x;
					playerSpawnY = y;
					break;
			   default:
			      	break;
				}
			}
		}
		// Désastre algorithmique ( Partie 2 )
		foreach(SoundSwitch audioSwitch in switchesKick)
		{
			foreach(AudioWall audioWall in wallsKick)
			{
				audioSwitch.LinkWall(audioWall);
			}
		}
		foreach(SoundSwitch audioSwitch in switchesSnare)
		{
			foreach(AudioWall audioWall in wallsSnare)
			{
				audioSwitch.LinkWall(audioWall);
			}
		}
		foreach(SoundSwitch audioSwitch in switchesClap)
		{
			foreach(AudioWall audioWall in wallsClap)
			{
				audioSwitch.LinkWall(audioWall);
			}
		}
		foreach(SoundSwitch audioSwitch in switchesFbass)
		{
			foreach(AudioWall audioWall in wallsFbass)
			{
				audioSwitch.LinkWall(audioWall);
			}
		}
		foreach(SoundSwitch audioSwitch in switchesSynth)
		{
			foreach(AudioWall audioWall in wallsSynth)
			{
				audioSwitch.LinkWall(audioWall);
			}
		}
		foreach(SoundSwitch audioSwitch in switchesSynth2)
		{
			foreach(AudioWall audioWall in wallsSynth2)
			{
				audioSwitch.LinkWall(audioWall);
			}
		}
		
		SpawnPlayer(playerSpawnX, playerSpawnY);
		
		
		
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
		
		
	}	
	
	// Update is called once per frame
	void Update () {
		base.Update();
	}
}
