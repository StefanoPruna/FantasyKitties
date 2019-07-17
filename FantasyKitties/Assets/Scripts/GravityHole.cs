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
        if(collision.tag == "Player") //|| collision.tag == "Enemy")
        {
            SetAllColliderStatus(false, collision.transform);                         
        }        
    }

    public void SetAllColliderStatus (bool active, Transform transform)
    {
        foreach(Collider2D c in transform.GetComponents<Collider2D>())
        {
            c.enabled = active;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") //|| collision.tag == "Enemy")
        {
            SetAllColliderStatus(true, collision.transform);
        }
    }
}
