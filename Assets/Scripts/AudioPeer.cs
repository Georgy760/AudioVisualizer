using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPeer : MonoBehaviour
{
    private AudioSource _AudioSource;
    public float[] _samples = new float[128];
    void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        GetSpectrumAudioSource();
    }

    void GetSpectrumAudioSource()
    {
        _AudioSource.GetSpectrumData(_samples, 0, FFTWindow.BlackmanHarris);
    }
}
