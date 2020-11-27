using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliGeneration : MonoBehaviour
{
    public Transform bulletPoint;
    public GameObject Fire;
    float _timeSpawn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _timeSpawn += Time.deltaTime;
        if (_timeSpawn > 1)
        {
            Instantiate(Fire, bulletPoint.position, Quaternion.identity);
            _timeSpawn = 0;
        }
    }
}
