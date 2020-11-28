using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineroShoot : MonoBehaviour
{
    public Transform bulletPoint;
    public GameObject bullet;
    float _timeSpawn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _timeSpawn += Time.deltaTime;
        if (_timeSpawn > 0.9) {
            Instantiate(bullet, bulletPoint.position, Quaternion.identity);
            _timeSpawn = 0;
        }
    }
}
