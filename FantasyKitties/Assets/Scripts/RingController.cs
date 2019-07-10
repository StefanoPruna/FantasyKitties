using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MonoBehaviour
{
    public GameObject reward;
    public GameObject sparkle;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Instantiate(reward, transform.position, Quaternion.identity);
            Instantiate(sparkle, transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<PlayerInventory>().AddRings();            
            Destroy(gameObject.transform.gameObject);
        }        
    }
}
