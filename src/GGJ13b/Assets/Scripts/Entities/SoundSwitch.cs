using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundSwitch : Switch {
	
	public SoundLevel.Sounds sound;
	private SoundLevel soundClass;
	private AnalyseSound soundAnalyser;
	
	private List<EmptyBridge> bridges;
	private List<AudioWall> walls;
	
	// Use this for initialization
	void Awake () {
		bridges = new List<EmptyBridge>();
		walls = new List<AudioWall>();
		
		soundClass = GameObject.Find("SoundLevel").GetComponent<SoundLevel>();
		soundAnalyser = gameObject.GetComponent<AnalyseSound>();
		
		soundAnalyser = (AnalyseSound)gameObject.AddComponent<AnalyseSound>();
		soundAnalyser.sound = sound;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void LinkBridge(EmptyBridge obj)
	{
		bridges.Add(obj);
	}
	
	public void LinkWall(AudioWall obj)
	{
		walls.Add(obj);
	}
	
	override public void Activate()
	{
		soundClass.ToogleTrack(sound);
		soundAnalyser.Toogle();
		
		foreach(EmptyBridge bridge in bridges)
		{
			bridge.Toogle();
		}
		
		foreach(AudioWall wall in walls)
		{
			wall.Toogle();
		}
	}
}
