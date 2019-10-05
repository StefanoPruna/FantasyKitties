﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Animator enemyRuns;

    private GameObject player;
    public GameObject EnemyBullet;
    public float enemyAccel;
    public float maxSpeed = 20f;

    //public AudioClip playerDamaged;
    //AudioSource playerAudioSource;

    //public float enemyHealth;
    //float currentHealth;


    public float chargeTime;
    float startChargeTime;
    bool charging = false;
    Rigidbody2D enemyRB;

    bool canFlip = true;
    bool facingRight = false;
    float flipTime = 5f;
    float nextFlipChance = 0f;
    Transform enemyTransform;

    public bool isAlive;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        isAlive = true;
        enemyTransform = GetComponent<Transform>();
        enemyRB = GetComponent<Rigidbody2D>();
        enemyRuns = GetComponentInChildren<Animator>();        
        //playerAudioSource = GetComponent<AudioSource>();
        //currentHealth = enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            if (Time.time > nextFlipChance)
            {
                if (Random.Range(0, 10) >= 5) flipFacing();
                nextFlipChance = Time.time + flipTime;
            }
            if (charging && Time.time > startChargeTime && enemyRB.velocity.x < maxSpeed)
            {
                if (!facingRight) enemyRB.AddForce(new Vector2(-1f, 0f) * enemyAccel);
                else enemyRB.AddForce(new Vector2(1f, 0f) * enemyAccel);
                enemyRuns.SetBool("isCharging", charging);
            }

           
        }
        else
            enemyRB.velocity = new Vector2(0f, 0f);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(facingRight && collision.transform.position.x < transform.position.x)
            {
                flipFacing();
            }
            else if(!facingRight && collision.transform.position.x > transform.position.x)
            {
                flipFacing();
            }
            canFlip = false;
            charging = true;
            startChargeTime = Time.time + chargeTime;
        }

        //if (collision.tag == "shurikens")
        //{
        //    currentHealth = enemyHealth - 1f;
        //    print(enemyHealth);
        //    playerAudioSource.PlayOneShot(playerDamaged);
        //    if (currentHealth <= 0)
        //    {
        //        playerAudioSource.PlayOneShot(playerDamaged);
        //        GetComponent<Flame>();
        //    }
        //}
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag =="Player")
        {
            charging = true;
        }         
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canFlip = true;
            charging = false;
            enemyRB.velocity = new Vector2(0f, 0f);
            enemyRuns.SetBool("isCharging", charging);
        }
    }

    void flipFacing()
    {
        if (!canFlip)
            return;
        float facingX = enemyTransform.localScale.x;
        facingX *= -1;
        enemyTransform.localScale = new Vector3(facingX, enemyTransform.localScale.y, enemyTransform.localScale.z);
        facingRight = !facingRight;
    }
}
