using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityHole : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" || collision.tag == "Enemy")
        {
            GetComponent<BoxCollider2D>().enabled = false;
                                    
        }        
    }

    public void SetAllColliderStatus (bool active, Transform transform)
    {
        foreach(BoxCollider2D c in transform.GetComponents<BoxCollider2D>())
        {
            c.enabled = active;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Enemy")
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
