using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contacto : MonoBehaviour
{
    public PlayerShoot ps;
    public Animator Anim;

    public AudioClip die;
    public AudioClip damageclip;

    public AudioSource fondo;
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (ps.cantidadbalas == 0)
            {
                fondo.Stop();
                ps.audioPlayer.clip = die;
                ps.audioPlayer.Play();
                transform.root.gameObject.SetActive(false);
            }
            else
            {
                Anim.SetTrigger("Damage");
                ps.audioPlayer.clip = damageclip;
                ps.audioPlayer.Play();
                ps.cantidadbalas = 0;
                ps.textoContadorBalas.text = ps.cantidadbalas.ToString();
            }
        }
    }
}
