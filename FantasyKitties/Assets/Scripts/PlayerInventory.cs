using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public Text scoreRings;
    
    
    
    int Rings = 0;
          

    void Start()
    {
        scoreRings.text = Rings.ToString();
    }

    //Unfortunately I'm still not able to create an one time totalScore function that using the same methods
    //duplicated in the 2 functions

        public void AddRings()
    {
        Rings = Rings + 5;
        scoreRings.text = Rings.ToString();       
    }

    public void TotalScore(int totalScore)
    {
        totalScore =Rings;

        //if (totalScore >= 35)
        //{
        //    GetComponent<PlayerHealth>().EndGame();
        //}        
    }
}

         

