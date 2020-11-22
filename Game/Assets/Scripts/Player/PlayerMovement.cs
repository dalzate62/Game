﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject game;
    public float movX, movY, jump;
    private Vector2 ForceVector;
    public Animator anim;
    public AudioClip jumpclip; 

    public float forceMultiplier, jumpMultiplayer;
    private Rigidbody2D rb;


    private bool canJump = false;
    private Collider2D groundCollider;

    public bool jumpSelector;
    public Transform[] checkPoint;
    public LayerMask layers;
    public float[] checkRadius;

    private AudioSource audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxisRaw("Horizontal");
        movY = Input.GetAxis("Vertical");
        jump = Input.GetAxis("Jump");
        anim.SetFloat("Speed_x", Mathf.Abs(movX));

        if (movX > 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);

        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (groundCollider != null)
        {
            canJump = true;
            anim.SetBool("Jump", false);
        }
        else
        {
            canJump = false;
            anim.SetBool("Jump", true);
        }

        if (Input.GetButtonDown("Fire1"))
            anim.SetTrigger("Fire");
        else if (Input.GetButtonDown("Fire1") && Input.GetButtonDown("Horizontal"))
            anim.SetTrigger("Fire1");

    }

    private void FixedUpdate()
    {

        ForceVector = new Vector2(movX, 0f) * forceMultiplier;

        rb.AddForce(ForceVector, ForceMode2D.Force);

        if (canJump && jump > 0)
        {
            rb.AddForce(Vector2.up * jumpMultiplayer, ForceMode2D.Impulse);
        }

        groundCollider = Physics2D.OverlapCircle((Vector2)checkPoint[0].position, checkRadius[0], layers);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            audioPlayer.clip = jumpclip;
            audioPlayer.Play();
        }
    }


}
