using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineroShoot : MonoBehaviour
{
    public Transform bulletPoint;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      Instantiate(bullet, bulletPoint.position, Quaternion.identity);
    }
}
