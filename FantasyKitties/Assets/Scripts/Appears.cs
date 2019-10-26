using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appears : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       GetComponent<SpriteRenderer>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")                 
            GetComponent<SpriteRenderer>().enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
