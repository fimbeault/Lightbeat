using UnityEngine;
using System.Collections;

public class SoundListener : MonoBehaviour {
	
	public SoundLevel.Sounds sound;
	
	private SoundLevel soundClass;
	private ParticleSystem paticles;
	
	// Use this for initialization
	void Start () {
		soundClass = GameObject.Find("SoundLevel").GetComponent<SoundLevel>();
		paticles = gameObject.GetComponent<ParticleSystem>();
		paticles.enableEmission = false;
		
		//soundClass.AddListener(this, sound);
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void notifySound()
	{
		//paticles.enableEmission = true;
	}
}
