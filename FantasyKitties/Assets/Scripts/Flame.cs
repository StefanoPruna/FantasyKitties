using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flame : MonoBehaviour
{
    public Debris enemyDeath;
    public int totalDebris = 10;
    public float enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.gameObject.tag == "Enemy")
        {
            OnFlames();
        }
    }

    void OnFlames()
    {
        var t = transform;
        for (int i = 0; i <totalDebris; i++)
        {
            t.TransformPoint(0, -100, 0);
            var clone = Instantiate(enemyDeath, t.position, Quaternion.identity) as Debris;
            var body2D = clone.GetComponent<Rigidbody2D>();

          //  body2D.AddForce(Vector3.right * Random (-1000, 1000));
          //  body2D.AddForce(Vector3.up * Random.Range(500, 2000));
        }

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }    
}
