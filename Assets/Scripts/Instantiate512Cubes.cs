using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate512Cubes : MonoBehaviour
{
    public GameObject AudioPeer;
    public GameObject _sampleCubePrefab;
    private GameObject[] _sampleCube = new GameObject[128];
    public float _maxScale;
    void Start()
    {
        for (int i = 0; i < 128; i++)
        {
            GameObject _instanceSampleCube = (GameObject) Instantiate(_sampleCubePrefab);
            _instanceSampleCube.transform.position = this.transform.position;
            _instanceSampleCube.transform.parent = this.transform;
            _instanceSampleCube.name = "SampleIco" + i;
            this.transform.eulerAngles = new Vector3(0, -0.703125f * 2 * 2 * i, 0);
            _instanceSampleCube.transform.position = Vector3.forward * 100;
            _sampleCube[i] = _instanceSampleCube;
        }
    }


    void Update()
    {
        for (int i = 0; i < 128; i++)
        {
            if (_sampleCube != null)
            {
                _sampleCube[i].transform.localScale = new Vector3(1000, (AudioPeer.GetComponent<AudioPeer>()._samples[i] *_maxScale) + 2, 1000);
            }
        }
    }
}
