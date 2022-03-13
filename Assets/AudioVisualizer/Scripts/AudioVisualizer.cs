//v.01

using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class AudioVisualizer : MonoBehaviour {
		
	public Transform[] audioSpectrumObjects;
	[Range(1, 100)] public float heightMultiplier;
	[Range(64, 8192)] public int numberOfSamples = 1024; //step by 2
	public FFTWindow fftWindow;
	public float lerpTime = 1;
	[SerializeField] private Material mat;
	int i = 0;
	void Start(){
		heightMultiplier = PlayerPrefsManager.GetSensitivity ();
		mat = audioSpectrumObjects[0].gameObject.GetComponent<Renderer>().material;
		
		foreach (var spectrumObject in audioSpectrumObjects)
		{
			
			Material spectrumObjectMaterial = new Material(mat);
			spectrumObjectMaterial.name = "NewMat " + i;
			i++;
			spectrumObject.gameObject.GetComponent<Renderer>().material = spectrumObjectMaterial;
			spectrumObject.GetComponentInChildren<ParticleSystemRenderer>().trailMaterial = spectrumObjectMaterial;
			//spectrumObject.GetComponentInChildren<Transform>().localScale = new Vector3(1, 1, 0);
			//spectrumObject.GetChild(0).gameObject.SetActive(true);

		}
		for (int i = 0; i < audioSpectrumObjects.Length; i++)
		{
			
		}
	}

	void Update() {

		
		float[] spectrum = new float[numberOfSamples];
		
		GetComponent<AudioSource>().GetSpectrumData(spectrum, 0, fftWindow);
		
		if (audioSpectrumObjects.Length != 0)
		{
			for (int i = 0; i < audioSpectrumObjects.Length; i++)
			{
				float intensity = spectrum[i] * heightMultiplier;
				float lerpY = Mathf.Lerp(audioSpectrumObjects[i].localScale.y, intensity, lerpTime);
				Vector3 newScale = new Vector3(audioSpectrumObjects[i].localScale.x, lerpY,
					audioSpectrumObjects[i].localScale.z);
				audioSpectrumObjects[i].localScale = newScale;
				//audioSpectrumObjects[i].GetComponentInChildren<Transform>().localScale = newScale;
				/*
				if (audioSpectrumObjects[i].GetChild(0).GetComponent<Transform>().localScale.y > 0.1f)
				{
					audioSpectrumObjects[i].GetChild(0).gameObject.SetActive(true);
				} else audioSpectrumObjects[i].GetChild(0).gameObject.SetActive(false);
				*/
				audioSpectrumObjects[i].GetChild(0).GetComponent<Transform>().localScale = newScale;
				
				if (audioSpectrumObjects[i].localScale.y > 0f && audioSpectrumObjects[i].localScale.y < 1f)
				{
					audioSpectrumObjects[i].gameObject.GetComponent<Renderer>().material.color = mat.color;
					audioSpectrumObjects[i].GetComponentInChildren<ParticleSystemRenderer>().trailMaterial.color =
						mat.color;
					audioSpectrumObjects[i].GetComponentInChildren<ParticleSystemRenderer>().trailMaterial.SetColor("_EmissionColor", mat.color);
				}

				if (audioSpectrumObjects[i].localScale.y > 1f && audioSpectrumObjects[i].localScale.y < 5f)
				{
					audioSpectrumObjects[i].gameObject.GetComponent<Renderer>().material.color = mat.color * Color.red;
					audioSpectrumObjects[i].GetComponentInChildren<ParticleSystemRenderer>().trailMaterial.SetColor("_EmissionColor", mat.color * Color.red);
				}

				if (audioSpectrumObjects[i].localScale.y > 5f && audioSpectrumObjects[i].localScale.y < 7.5f)
				{
					audioSpectrumObjects[i].gameObject.GetComponent<Renderer>().material.color = Color.red;
					audioSpectrumObjects[i].GetComponentInChildren<ParticleSystemRenderer>().trailMaterial.SetColor("_EmissionColor", Color.red);

				}
			}
			
		}
	}

	public void SensitivityValueChangedHandler(Slider sensitivitySlider){
		heightMultiplier = sensitivitySlider.value;
	}

}
