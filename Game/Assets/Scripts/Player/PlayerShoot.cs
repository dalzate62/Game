using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject bj = Instantiate(bullet, bulletPoint.position, Quaternion.identity);
            bj.GetComponent<Bullet>().EnviarDireccion(transform.root.localScale);
        }

    }
}
