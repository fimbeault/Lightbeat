using UnityEngine;
using System.Collections;

public class AudioIntro : MonoBehaviour {
	
	bool stop = false;
	
	public void Stop()
	{
		stop = true;
	}
	
	// Use this for initialization
	void Awake () {
		Object.DontDestroyOnLoad(gameObject);
		GetComponent<AudioSource>().Play();
		GetComponent<AudioSource>().loop = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(stop)
		{
			GetComponent<AudioSource>().audio.volume -= Time.deltaTime;
			
			if(GetComponent<AudioSource>().audio.volume <= 0)
			{
				Destroy(gameObject);
			}
		}
	}
}
