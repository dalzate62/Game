using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocity;

    private Rigidbody2D _rb;

    private DamageType _damageType;

    private Vector2 _direccion;

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
        _rb.velocity = _direccion * velocity;
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

    public void EnviarDireccion(Vector3 v3)
    {
        if (v3.x > 0.5f)
            _direccion = Vector2.left;
        else
            _direccion = Vector2.right;
    }
}
