using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    public GameObject fireWorks;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().EndGame("YOU WIN!");
            collision.GetComponent<PlayerController>().gameFinished = true;
            PlayerPrefsManager.saveLevel("Level_2");
            Instantiate(fireWorks, transform.position, Quaternion.identity);
        }
    }
}
