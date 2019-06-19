using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public Text scoreRings;
    public Text scoreCherry;
    
    
    int Rings = 0;
    int Cherry = 0;
    int totalScore = 0;    

    void Start()
    {
        scoreRings.text = Rings.ToString();
        scoreCherry.text = Cherry.ToString();        
    }

    //Unfortunately I'm still not able to create an one time totalScore function that using the same methods
    //duplicated in the 2 functions

        public void AddRings()
    {
        Rings = Rings + 5;
        scoreRings.text = Rings.ToString();       
    }

    public void AddCherry()
    {
        Cherry++;
        scoreCherry.text = Cherry.ToString();
    }

    public void TotalScore(int totalScore)
    {
        totalScore = Cherry + Rings;

        if (totalScore >= 35)
        {
            GetComponent<PlayerHealth>().EndGame();
        }        
    }
}

         

