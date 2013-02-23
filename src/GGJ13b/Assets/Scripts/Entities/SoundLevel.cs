using UnityEngine;
using System.Collections;

public class SoundLevel : MonoBehaviour {
	
	public enum Sounds
	{
		KICK,
		CLAP,
		SNARE,
		FBASS,
		SYNTH,
		SYNTH2
	}
	
	AudioSource[] sounds;
	
	// Use this for initialization
	void Awake () {
		sounds = gameObject.GetComponents<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Keypad1))
			ToogleTrack(Sounds.KICK);
		
		if(Input.GetKeyDown(KeyCode.Keypad2))
			ToogleTrack(Sounds.CLAP);
		
		if(Input.GetKeyDown(KeyCode.Keypad3))
			ToogleTrack(Sounds.SNARE);
		
		if(Input.GetKeyDown(KeyCode.Keypad4))
			ToogleTrack(Sounds.FBASS);
		
		if(Input.GetKeyDown(KeyCode.Keypad5))
			ToogleTrack(Sounds.SYNTH);
		
		if(Input.GetKeyDown(KeyCode.Keypad6))
			ToogleTrack(Sounds.SYNTH2);
	}
	
	public void MuteAll()
	{
		sounds[0].mute = true;
		sounds[1].mute = true;
		sounds[2].mute = true;
		sounds[3].mute = true;
		sounds[4].mute = true;
		sounds[5].mute = true;
	}
	
	public void ToogleTrack(Sounds sound)
	{
		switch(sound)
		{
		case Sounds.KICK:
			sounds[0].mute = !sounds[0].mute;
			break;
		
		case Sounds.CLAP:
			sounds[1].mute = !sounds[1].mute;
			break;
			
		case Sounds.SNARE:
			sounds[2].mute = !sounds[2].mute;
			break;
			
		case Sounds.FBASS:
			sounds[3].mute = !sounds[3].mute;
			break;
			
		case Sounds.SYNTH:
			sounds[4].mute = !sounds[4].mute;
			break;
			
		case Sounds.SYNTH2:
			sounds[5].mute = !sounds[5].mute;
			break;
		}
	}
	
	public AudioSource GetSound(Sounds sound)
	{
		switch(sound)
		{
		case Sounds.KICK:
			return sounds[0];
		
		case Sounds.CLAP:
			return sounds[1];
			
		case Sounds.SNARE:
			return sounds[2];
			
		case Sounds.FBASS:
			return sounds[3];
			
		case Sounds.SYNTH:
			return sounds[4];
			
		case Sounds.SYNTH2:
			return sounds[5];
		}
		
		return null;
	}
}
