using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public class filelevel1 : Level {
	

	
	public string fileName = "level1.txt";
	
		
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

		List<AudioWall> wallsLockedKick = new List<AudioWall>();
		List<AudioWall> wallsLockedSnare = new List<AudioWall>();
		List<AudioWall> wallsLockedClap = new List<AudioWall>();
		List<AudioWall> wallsLockedFbass = new List<AudioWall>();
		List<AudioWall> wallsLockedSynth = new List<AudioWall>();
		List<AudioWall> wallsLockedSynth2 = new List<AudioWall>();
		
		List<EmptyBridge> BridgesKick = new List<EmptyBridge>();
		List<EmptyBridge> BridgesSnare = new List<EmptyBridge>();
		List<EmptyBridge> BridgesClap = new List<EmptyBridge>();
		List<EmptyBridge> BridgesFbass = new List<EmptyBridge>();
		List<EmptyBridge> BridgesSynth = new List<EmptyBridge>();
		List<EmptyBridge> BridgesSynth2 = new List<EmptyBridge>();

		List<EmptyBridge> BridgesLockedKick = new List<EmptyBridge>();
		List<EmptyBridge> BridgesLockedSnare = new List<EmptyBridge>();
		List<EmptyBridge> BridgesLockedClap = new List<EmptyBridge>();
		List<EmptyBridge> BridgesLockedFbass = new List<EmptyBridge>();
		List<EmptyBridge> BridgesLockedSynth = new List<EmptyBridge>();
		List<EmptyBridge> BridgesLockedSynth2 = new List<EmptyBridge>();
		
		for(int i = lines.Length - 1; i >= 0; i--)
		{
			int y = lines.Length - i;
			string line = lines[i];
			
			for(int x = 0; x <= line.Length - 1; x++)
			{
				char theCharToAnalyse = line[x];
				switch (theCharToAnalyse)
				{
					// wall
				case '#':
					CreateWall(x, y);
					break;

				//end
				case 'Z':
					CreateSwitch(Level.SwitchType.LEVEL_END, x, y).GetComponent<LevelEnd>().level = this;
					CreateFloor(x, y);
					break;

					//start
				case 'S':
					CreateFloor(x, y);
					playerSpawnX = x;
					playerSpawnY = y;
					break;

				case 'a':
					switchesKick.Add(CreateSwitch(Level.SwitchType.KICK, x, y).GetComponent<SoundSwitch>());
					CreateFloor(x, y);
					break;
				case 'b':
					switchesSnare.Add(CreateSwitch(Level.SwitchType.SNARE, x, y).GetComponent<SoundSwitch>());
					CreateFloor(x, y);
					break;
				case 'c':
					switchesClap.Add(CreateSwitch(Level.SwitchType.CLAP, x, y).GetComponent<SoundSwitch>());
					CreateFloor(x, y);
					break;
				case 'd':
					// FBASS car on a trouvé F*cking Bass fun, Game Jam fun happens quand on manque de sommeile :)
					switchesFbass.Add(CreateSwitch(Level.SwitchType.FBASS, x, y).GetComponent<SoundSwitch>());
					CreateFloor(x, y);
					break;
				case 'e':
					switchesSynth.Add(CreateSwitch(Level.SwitchType.SYNTH, x, y).GetComponent<SoundSwitch>());
					CreateFloor(x, y);
					break;
				case 'f':
					switchesSynth2.Add(CreateSwitch(Level.SwitchType.SYNTH2, x, y).GetComponent<SoundSwitch>());
					CreateFloor(x, y);
					break;

				// MUR BARRÉ
				case 'A':
					wallsLockedKick.Add(CreateAudioWall(Level.BridgeType.RED, x, y).GetComponent<AudioWall>());
					CreateFloor(x, y);
					break;

				case 'B':
					wallsLockedSnare.Add(CreateAudioWall(Level.BridgeType.BLUE, x, y).GetComponent<AudioWall>());
					CreateFloor(x, y);
					break;

				case 'C':
					wallsLockedClap.Add(CreateAudioWall(Level.BridgeType.ORANGE, x, y).GetComponent<AudioWall>());
					CreateFloor(x, y);
					break;

				case 'D':
					wallsLockedFbass.Add(CreateAudioWall(Level.BridgeType.PURPLE, x, y).GetComponent<AudioWall>());
					CreateFloor(x, y);
					break;

				case 'E':
					wallsLockedSynth.Add(CreateAudioWall(Level.BridgeType.GREEN, x, y).GetComponent<AudioWall>());
					CreateFloor(x, y);
					break;
				case 'F':
					wallsLockedSynth2.Add(CreateAudioWall(Level.BridgeType.YELLOW, x, y).GetComponent<AudioWall>());
					CreateFloor(x, y);
					break;



					// Mur debare
				case '1':
					wallsKick.Add(CreateAudioWall(Level.BridgeType.RED, x, y).GetComponent<AudioWall>());
					CreateFloor(x, y);
					wallsKick[wallsKick.Count - 1].Deactivate();

					break;
				case '2':
					wallsSnare.Add(CreateAudioWall(Level.BridgeType.BLUE, x, y).GetComponent<AudioWall>());
					CreateFloor(x, y);
					wallsSnare[wallsSnare.Count - 1].Deactivate();
					break;
				case '3':
					wallsClap.Add(CreateAudioWall(Level.BridgeType.ORANGE, x, y).GetComponent<AudioWall>());
					CreateFloor(x, y);
					wallsClap[wallsClap.Count - 1].Deactivate();
					break;
				case '4':
					wallsFbass.Add(CreateAudioWall(Level.BridgeType.PURPLE, x, y).GetComponent<AudioWall>());
					CreateFloor(x, y);
					wallsFbass[wallsFbass.Count - 1].Deactivate();
					break;
				case '5':
					wallsSynth.Add(CreateAudioWall(Level.BridgeType.GREEN, x, y).GetComponent<AudioWall>());
					CreateFloor(x, y);
					wallsSynth[wallsSynth.Count - 1].Deactivate();
					break;
				case '6':
					wallsSynth2.Add(CreateAudioWall(Level.BridgeType.YELLOW, x, y).GetComponent<AudioWall>());
					CreateFloor(x, y);
					wallsSynth2[wallsSynth2.Count - 1].Deactivate();
					break;



					// Ponts Locked
				case 'M':
					BridgesLockedKick.Add(CreateBridge(Level.BridgeType.RED, x, y, 1, 1).GetComponent<EmptyBridge>());
					break;
				case 'N':
					BridgesLockedKick.Add(CreateBridge(Level.BridgeType.BLUE, x, y, 1, 1).GetComponent<EmptyBridge>());
					break;
				case 'O':
					BridgesLockedKick.Add(CreateBridge(Level.BridgeType.ORANGE, x, y, 1, 1).GetComponent<EmptyBridge>());
					break;
				case 'P':
					BridgesLockedKick.Add(CreateBridge(Level.BridgeType.PURPLE, x, y, 1, 1).GetComponent<EmptyBridge>());
					break;
				case 'Q':
					BridgesLockedKick.Add(CreateBridge(Level.BridgeType.GREEN, x, y, 1, 1).GetComponent<EmptyBridge>());
					break;
				case 'R':
					BridgesLockedKick.Add(CreateBridge(Level.BridgeType.YELLOW, x, y, 1, 1).GetComponent<EmptyBridge>());
					break;

					// Ponts Unlocked
				case 'm':
					BridgesKick.Add(CreateBridge(Level.BridgeType.RED, x, y, 1, 1).GetComponent<EmptyBridge>());
					break;
				case 'n':
					BridgesKick.Add(CreateBridge(Level.BridgeType.BLUE, x, y, 1, 1).GetComponent<EmptyBridge>());
					break;
				case 'o':
					BridgesKick.Add(CreateBridge(Level.BridgeType.ORANGE, x, y, 1, 1).GetComponent<EmptyBridge>());
					break;
				case 'p':
					BridgesKick.Add(CreateBridge(Level.BridgeType.PURPLE, x, y, 1, 1).GetComponent<EmptyBridge>());
					break;
				case 'q':
					BridgesKick.Add(CreateBridge(Level.BridgeType.GREEN, x, y, 1, 1).GetComponent<EmptyBridge>());
					break;
				case 'r':
					BridgesKick.Add(CreateBridge(Level.BridgeType.YELLOW, x, y, 1, 1).GetComponent<EmptyBridge>());
					break;

				case ' ':
					CreateFloor(x, y);
					break;
				case '0':
					// No floor ici
					CreateHole(x, y);
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

		// Désastre algorithmique ( Partie 2 )
		foreach(SoundSwitch audioSwitch in switchesKick)
		{
			foreach(AudioWall audioWall in wallsLockedKick)
			{
				audioSwitch.LinkWall(audioWall);
			}
		}
		foreach(SoundSwitch audioSwitch in switchesSnare)
		{
			foreach(AudioWall audioWall in wallsLockedSnare)
			{
				audioSwitch.LinkWall(audioWall);
			}
		}
		foreach(SoundSwitch audioSwitch in switchesClap)
		{
			foreach(AudioWall audioWall in wallsLockedClap)
			{
				audioSwitch.LinkWall(audioWall);
			}
		}
		foreach(SoundSwitch audioSwitch in switchesFbass)
		{
			foreach(AudioWall audioWall in wallsLockedFbass)
			{
				audioSwitch.LinkWall(audioWall);
			}
		}
		foreach(SoundSwitch audioSwitch in switchesSynth)
		{
			foreach(AudioWall audioWall in wallsLockedSynth)
			{
				audioSwitch.LinkWall(audioWall);
			}
		}
		foreach(SoundSwitch audioSwitch in switchesSynth2)
		{
			foreach(AudioWall audioWall in wallsLockedSynth2)
			{
				audioSwitch.LinkWall(audioWall);
			}
		}

		// Désastre algorithmique ( Partie 3 )
		foreach(SoundSwitch audioSwitch in switchesKick)
		{
			foreach(EmptyBridge EmptyBridge in BridgesLockedKick)
			{
				audioSwitch.LinkBridge(EmptyBridge);
			}
		}
		foreach(SoundSwitch audioSwitch in switchesSnare)
		{
			foreach(EmptyBridge EmptyBridge in BridgesLockedSnare)
			{
				audioSwitch.LinkBridge(EmptyBridge);
			}
		}
		foreach(SoundSwitch audioSwitch in switchesClap)
		{
			foreach(EmptyBridge EmptyBridge in BridgesLockedClap)
			{
				audioSwitch.LinkBridge(EmptyBridge);
			}
		}
		foreach(SoundSwitch audioSwitch in switchesFbass)
		{
			foreach(EmptyBridge EmptyBridge in BridgesLockedFbass)
			{
				audioSwitch.LinkBridge(EmptyBridge);
			}
		}
		foreach(SoundSwitch audioSwitch in switchesSynth)
		{
			foreach(EmptyBridge EmptyBridge in BridgesLockedSynth)
			{
				audioSwitch.LinkBridge(EmptyBridge);
			}
		}
		foreach(SoundSwitch audioSwitch in switchesSynth2)
		{
			foreach(EmptyBridge EmptyBridge in BridgesLockedSynth2)
			{
				audioSwitch.LinkBridge(EmptyBridge);
			}
		}

		// Désastre algorithmique ( Partie 3  Bridges Locked)
		foreach(SoundSwitch audioSwitch in switchesKick)
		{
			foreach(EmptyBridge EmptyBridge in BridgesKick)
			{
				audioSwitch.LinkBridge(EmptyBridge);
			}
		}
		foreach(SoundSwitch audioSwitch in switchesSnare)
		{
			foreach(EmptyBridge EmptyBridge in BridgesSnare)
			{
				audioSwitch.LinkBridge(EmptyBridge);
			}
		}
		foreach(SoundSwitch audioSwitch in switchesClap)
		{
			foreach(EmptyBridge EmptyBridge in BridgesClap)
			{
				audioSwitch.LinkBridge(EmptyBridge);
			}
		}
		foreach(SoundSwitch audioSwitch in switchesFbass)
		{
			foreach(EmptyBridge EmptyBridge in BridgesFbass)
			{
				audioSwitch.LinkBridge(EmptyBridge);
			}
		}
		foreach(SoundSwitch audioSwitch in switchesSynth)
		{
			foreach(EmptyBridge EmptyBridge in BridgesSynth)
			{
				audioSwitch.LinkBridge(EmptyBridge);
			}
		}
		foreach(SoundSwitch audioSwitch in switchesSynth2)
		{
			foreach(EmptyBridge EmptyBridge in BridgesSynth2)
			{
				audioSwitch.LinkBridge(EmptyBridge);
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
