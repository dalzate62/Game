using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShoot : MonoBehaviour
{
    private Rigidbody2D _rb;
    private bool isFalling;

    public Transformacion.TurtlePstation ms;

    private DamageType _damageType;

    public enum DamageType
    {
        ToPlayer
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        isFalling = true;
    }

    // Update is called once per frame
    void Update()
    {

        _rb.AddForce(Vector2.down * 1, ForceMode2D.Impulse);
        Destroy(gameObject, 2f);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject obj_c = other.gameObject;
        GameObject obj_f = other.transform.root.gameObject;

        if (obj_c.CompareTag("Ground"))
        {
            isFalling = false;
        }
        else if (obj_f.CompareTag("Enemy"))
        {
            obj_f.GetComponentInChildren<Transformacion>().ChangeState(ms);
            //AusioManager.p_Instance.PlaySFX(sfx);
            Destroy(this.gameObject);
        }

        GameObject obj = other.transform.root.gameObject;
        switch (_damageType)
        {
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
