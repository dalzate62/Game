using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public AudioClip fireclip;
    public Transform bulletPoint;
    public GameObject bullet;
    public TMPro.TextMeshProUGUI textoContadorBalas;
    float currentTime = 0;
    public int cantidadbalas = 5;

    //[SerializeField] private float _timeToSpawn = 5f;
    private float _timeSinceSpawn;
    public AudioSource audioPlayer;

    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        
        if (Input.GetKeyDown(KeyCode.X))
        {  if (cantidadbalas > 0)
            {
                audioPlayer.clip = fireclip;
                audioPlayer.Play();
                GameObject bj = Instantiate(bullet, bulletPoint.position, Quaternion.identity);
                bj.GetComponent<Bullet>().EnviarDireccion(transform.root.localScale);
                cantidadbalas -= 1;
                
            }
            else
            {
                currentTime += Time.deltaTime;
                if (currentTime >= 0.05) {
                    cantidadbalas = 5;
                    currentTime = 0;
                }
            }
        }
        if (cantidadbalas > 0)
        {
            textoContadorBalas.text = cantidadbalas.ToString();
        }
        else
        {
            textoContadorBalas.text = "sigue oprimiendo x para recargar mas rapido";
        }
        _timeSinceSpawn += Time.deltaTime;
        if (_timeSinceSpawn >= 5)
        {
            cantidadbalas = 5;
            _timeSinceSpawn = 0;
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (cantidadbalas == 0)
            {
                transform.root.gameObject.SetActive(false);
            }
            cantidadbalas = 0;
            textoContadorBalas.text = cantidadbalas.ToString();
        }
        
    }
}
