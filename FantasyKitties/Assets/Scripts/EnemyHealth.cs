using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public AudioClip playerDamaged;
    AudioSource playerAudioSource;

    public float enemyHealth;
    float currentHealth;

    bool damaged;
        
    void Start()
    {
        currentHealth = enemyHealth;
        playerAudioSource = GetComponent<AudioSource>();
    }

   
    void Update()
    {
        if (damaged)
        {
            currentHealth = enemyHealth - 1;
        }
        damaged = true;
    }

    public void EnemyDeath()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
