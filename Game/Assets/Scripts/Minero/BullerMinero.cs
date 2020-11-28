using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullerMinero : MonoBehaviour
{

    private Rigidbody2D _rb;

    private DamageType _damageType;

    public enum DamageType
    {
        ToPlayer
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        _rb.AddForce(Vector2.left * 1, ForceMode2D.Impulse);
        Destroy(gameObject, 1f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        GameObject obj = other.transform.root.gameObject;
        switch (_damageType)
        {
            case DamageType.ToPlayer:
                if (obj.CompareTag("Player"))
                {
                    Destroy(gameObject);
                }

                break;
        }
    }
}
