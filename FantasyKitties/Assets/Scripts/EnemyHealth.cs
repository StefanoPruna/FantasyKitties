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

    public float flashTime = 0.1f;
    Color origionalColor;
    public MeshRenderer renderer;
            

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = enemyHealth;
        origionalColor = GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        playerAudioSource = GetComponent<AudioSource>();
        enemyAudioSource = GetComponent<AudioSource>();

    }
   public void FlashRed()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        Invoke("ResetColor", flashTime);
    }

    void ResetColor()
    {
        GetComponent<SpriteRenderer>().color = origionalColor;
    }

    public void Damage()
    {
        FlashRed();

        currentHealth = currentHealth - 1f;
        print(currentHealth);
        playerAudioSource.PlayOneShot(playerDamaged);

        if (currentHealth <= 0f)
        {
            OnFlames();
        }
    }

    void OnFlames()
    {
        Instantiate(enemyDeathFX, new Vector3(transform.position.x, transform.position.y, -1f), Quaternion.identity);
        if (transform.parent.gameObject.name == "Boss")
        {
            GameObject.FindGameObjectWithTag("Door").GetComponent<EdgeCollider2D>().enabled = false; ;
        }
        enemyAudioSource.PlayOneShot(death);

        transform.parent.gameObject.SetActive(false);
        Destroy(transform.parent.gameObject, 0.5f);
       
    }
    //private void OnTriggerEnter2D(Collider2D target)
    //{


    //    if (target.gameObject.tag == "shurikens")
    //    {
    //        currentHealth = currentHealth - 1f;
    //        print(currentHealth);
    //        playerAudioSource.PlayOneShot(playerDamaged);
    //    }

    //    if (currentHealth <= 0f)
    //    {
    //        OnFlames();
    //    }

    //}


}

