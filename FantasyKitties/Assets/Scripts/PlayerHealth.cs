using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public AudioClip playerDamaged;
    AudioSource playerAudioSource;

    public float fullHealth;
    float currentHealth;

    public GameObject playerFaintFX;

    public Image damageIndicator;
    public Image damageSlider;
    
    public Image deathScreen;
    public CanvasGroup EndCavas;
    public Text endGameUI;

    Color flashColor = new Color(255f, 255f, 255f, 0.5f);
    float indicatorSpeed = 5f;
    bool damaged;

    private void Start()
    {
        endGameUI.transform.parent.gameObject.SetActive(false);

        currentHealth = fullHealth;
        playerAudioSource = GetComponent<AudioSource>();        
        damageSlider.fillAmount = 0f;
    }

    private void Update()
    {
        if(damaged)
        {
            damageIndicator.color = flashColor;
        }
        else
        {
            damageIndicator.color = Color.Lerp(damageIndicator.color, Color.clear, indicatorSpeed * Time.deltaTime);
        }
        damaged = false;
    }

    public void AddHealth(float healthAmount)
    {        
        currentHealth += healthAmount;
        damageSlider.fillAmount = 1 - currentHealth / fullHealth;
    }

    public void addDamage(float damage)
    {
        if (damage <= 0)
            return;
        currentHealth -= damage;

        damageSlider.fillAmount = 1 - currentHealth / fullHealth;

        playerAudioSource.PlayOneShot(playerDamaged);

        damaged = true;

        if(currentHealth <=0)
        {
            MakeDead();
        }
    }

    public void MakeDead()
    {
        Instantiate(playerFaintFX, transform.position, Quaternion.identity);
        
        EndGame("YOU LOSE!");
        deathScreen.color = Color.white;
        Destroy(gameObject);
    }    

    public void EndGame(string endText)
    {
        endGameUI.transform.parent.gameObject.SetActive(true);
        endGameUI.text = endText;
        EndCavas.alpha = 1;
        print(endText);
    }
}
