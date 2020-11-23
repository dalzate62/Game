using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocity;

    private Rigidbody2D _rb;

    private DamageType _damageType;

    public enum DamageType
    {
        ToPlayer,
        ToEnemy
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = transform.right * velocity;
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        GameObject obj = other.transform.root.gameObject;
        switch (_damageType)
        {
            case DamageType.ToEnemy:
                if (other.gameObject.CompareTag("Enemy"))
                {
                    //Destroy(obj);
                    obj.SetActive(false);
                    Destroy(gameObject);
                }
                break;
            case DamageType.ToPlayer:
                if (obj.CompareTag("Player"))
                {
                    Destroy(obj);
                    Destroy(gameObject);
                }

                break;
        }
    }
}
