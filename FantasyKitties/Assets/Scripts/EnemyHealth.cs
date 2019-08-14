using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    //public Debris enemyDeath;
    //public int totalDebris = 10;

    public AudioClip playerDamaged;
    AudioSource playerAudioSource;
    private AudioSource enemyAudioSource;
    public AudioClip death;

    public float enemyHealth;
    float currentHealth;

    //Enemy Death FX
    public GameObject enemyDeathFX;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        playerAudioSource = GetComponent<AudioSource>();
        enemyAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "shurikens")
        {
            currentHealth = currentHealth - 1f;
            print(currentHealth);
            playerAudioSource.PlayOneShot(playerDamaged);
        }

        if (currentHealth <= 0f)
        {
            OnFlames();
        }


        void OnFlames()
        {
            Instantiate(enemyDeathFX, new Vector3(transform.position.x,transform.position.y,-1f), Quaternion.identity);
            if (gameObject.name == "Boss")
            {
                GameObject.FindGameObjectWithTag("Door").GetComponent<EdgeCollider2D>().enabled = false; ;
            }
            Destroy(gameObject);
            enemyAudioSource.PlayOneShot(death);
        }
    }
}

