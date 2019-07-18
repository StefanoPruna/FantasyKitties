using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public AudioClip playerDamaged;
    AudioSource playerAudioSource;
    public AudioClip explosion;
    AudioSource deathAudioSource;

    public float enemyHealth;
    float currentHealth;
        
    void Start()
    {
        currentHealth = enemyHealth;
        playerAudioSource = GetComponent<AudioSource>();
        deathAudioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
    }
    private void OnTriggerEnter2d(Collider2D collision)
    {     
        if (collision.tag == "shurikens")
        {
            playerAudioSource.PlayOneShot(playerDamaged);
            currentHealth = enemyHealth - 1f;
            print(currentHealth);
            
        }
    }

    public void EnemyDeath()
    {
        if(currentHealth < 0)
        {
            Destroy(gameObject);
            deathAudioSource.PlayOneShot(explosion);
        }
    }
}
