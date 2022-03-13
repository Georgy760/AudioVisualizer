﻿using System;
using UnityEngine;
using UnityEngine.UI; 
using System.Collections.Generic; 

[RequireComponent(typeof(AudioSource))]
public class MicrophoneInput : MonoBehaviour {
	public float minThreshold = 0;
	public float frequency = 0.0f;
	public int audioSampleRate = 44100;
	public string microphone;
	public FFTWindow fftWindow;
	
	private List<string> options = new List<string>();
	private int samples = 8192; 
	private AudioSource audioSource;

	void OnEnable() {
		
		
		audioSource = GetComponent<AudioSource> ();
		
		foreach (string device in Microphone.devices) {
			if (microphone == null) {

				microphone = device;
			}
			options.Add(device);
		}
		microphone = options[PlayerPrefsManager.GetMicrophone ()];
		minThreshold = PlayerPrefsManager.GetThreshold ();

		
		UpdateMicrophone ();
	}

	void UpdateMicrophone(){
		audioSource.Stop(); 
		
		audioSource.clip = Microphone.Start(microphone, true, 10, audioSampleRate);
		audioSource.loop = true; 
		//Mute Audio Mixer group!
		Debug.Log(Microphone.IsRecording(microphone).ToString()); 

		if (Microphone.IsRecording (microphone)) { 
			while (!(Microphone.GetPosition (microphone) > 0)) {
			} 
		
			Debug.Log ("recording started with " + microphone);

			
			audioSource.Play (); 
		} else {
			

			Debug.Log (microphone + " doesn't work!");
		}
	}


	public void micDropdownValueChangedHandler(Dropdown mic){
		microphone = options[mic.value];
		UpdateMicrophone ();
	}

	public void thresholdValueChangedHandler(Slider thresholdSlider){
		minThreshold = thresholdSlider.value;
	}
	
	public float GetAveragedVolume()
	{ 
		float[] data = new float[256];
		float a = 0;
		audioSource.GetOutputData(data,0);
		foreach(float s in data)
		{
			a += Mathf.Abs(s);
		}
		return a/256;
	}
	
	public float GetFundamentalFrequency()
	{
		float fundamentalFrequency = 0.0f;
		float[] data = new float[samples];
		audioSource.GetSpectrumData(data,0,fftWindow);
		float s = 0.0f;
		int i = 0;
		for (int j = 1; j < samples; j++)
		{
			if(data[j] > minThreshold) 
			{
				if ( s < data[j] )
				{
					s = data[j];
					i = j;
				}
			}
		}
		fundamentalFrequency = i * audioSampleRate / samples;
		frequency = fundamentalFrequency;
		return fundamentalFrequency;
	}
}