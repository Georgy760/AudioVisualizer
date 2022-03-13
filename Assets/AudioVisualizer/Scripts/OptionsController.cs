using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour
{

	public int microphone = 0;
	public float sensitivity = 100f;
	public float threshold = 0.001f;

	private void Update()
	{
		PlayerPrefsManager.SetMicrophone(microphone);
		PlayerPrefsManager.SetSensitivity (sensitivity);
		PlayerPrefsManager.SetThreshold (threshold);
	}
}
