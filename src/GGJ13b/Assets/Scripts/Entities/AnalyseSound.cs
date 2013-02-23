using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnalyseSound : MonoBehaviour {
	
	bool triggered = false;
	
	public SoundLevel.Sounds sound;
	private AudioSource son;
	
	//ParticleSystem particles;
	private AnimateTiledTexture animation;
	
	private bool beatSpace = true;
	int currentIndex = -1;
	public float baseValue = 0.02f;
	
	private int qSamples = 1024;  // array size
	private float refValue = 0.1f; // RMS value for 0 dB
	private float threshold = 0.02f;      // minimum amplitude to extract pitch
	private float rmsValue;   // sound level - RMS
	private float dbValue;    // sound level - dB
	private float pitchValue; // sound pitch - Hz
	
	private float[] samples; // audio samples
	private float[] spectrum; // audio spectrum
	
	GUIText display = new GUIText(); 
	// Use this for initialization
	void Start () {
	
		
			samples = new float[qSamples];
			spectrum = new float[qSamples];
		
		son = GameObject.Find("SoundLevel").GetComponent<SoundLevel>().GetSound(sound);
		
		//particles = gameObject.GetComponent<ParticleSystem>();
		animation = gameObject.GetComponent<AnimateTiledTexture>();
	}
	
	private void  AnalyzeSound(){
		son.GetOutputData(samples, 0); // fill array with samples
		int i;
		float sum = 0;
		for (i=0; i < qSamples; i++){
			sum += samples[i]*samples[i]; // sum squared samples
		}
		rmsValue = Mathf.Sqrt(sum/qSamples); // rms = square root of average
		dbValue = 20*Mathf.Log10(rmsValue/refValue); // calculate dB
		if (dbValue < -160) dbValue = -160; // clamp it to -160dB min
		// get sound spectrum
		son.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
		float maxV= 0;
		int maxN = 0;
		for (i=0; i < qSamples; i++){ // find max 
			if (spectrum[i] > maxV && spectrum[i] > threshold){
				maxV = spectrum[i];
				maxN = i; // maxN is the index of max
			}
		}
		float freqN = maxN; // pass the index to a float variable
		if (maxN > 0 && maxN < qSamples-1){ // interpolate index using neighbours
			var dL = spectrum[maxN-1]/spectrum[maxN];
			var dR = spectrum[maxN+1]/spectrum[maxN];
			freqN += 0.5f*(dR*dR - dL*dL);
		}
		pitchValue = freqN*24000/qSamples; // convert index to frequency
}
	
	public void Toogle()
	{
		if(son.mute)
			animation.idle();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!son.mute)
		{
			AnalyzeSound();
			
			if(rmsValue	>= baseValue)
			{
				if(!triggered)
				{
					//particles.Play();
					//particles.enableEmission = true;
					
					animation.pulseOnce();
					triggered = true;
				}
			}
			
			else
			{
				triggered = false;
			}
		}
	}
}
