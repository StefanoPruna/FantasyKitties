﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shuriken : MonoBehaviour
{
    private GameObject player;
    float speed;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        speed = 8f;
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 position = transform.position;
        //position = new Vector2(position.x + speed * Time.deltaTime, position.y);
        //transform.position = position;

        transform.Rotate(new Vector3(0, 0, -360) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.name == "Dangerzone")
        {
            Destroy(gameObject);

            //Get the enemy parent object
            target.gameObject.GetComponentInParent<EnemyHealth>().Damage();

        }
    }
}