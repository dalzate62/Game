using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        transform.root.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
       FindObjectOfType<GoobaPool>().ReturnEnemyInstanceToPool(transform.root.gameObject);
    }
}
