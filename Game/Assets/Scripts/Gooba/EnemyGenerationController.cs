using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerationController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float generatorTimer = 1.75f;
    public float numenemy;

    // Start is called before the first frame update
    void Start()
    {
            InvokeRepeating("CreateEnemy", 0f, generatorTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateEnemy()
    {
        if (numenemy < 5) {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            numenemy += 1;
        }
        else
        {
            Debug.Log("hola");
        }
    }
}
