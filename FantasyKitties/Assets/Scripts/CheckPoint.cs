using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    static Vector3 ReachedPoint;
    public Transform startPos;
    public GameObject CheckPointSound;

    private void Awake()
    {
        this.transform.position = new Vector3(startPos.position.x, startPos.position.y, startPos.position.z);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(transform.position.x > ReachedPoint.x)
            {
                Instantiate(CheckPointSound, transform.position, Quaternion.identity);                
                ReachedPoint = collision.transform.position;               

            }

        }
    }

    private void Update()
    {
        
    }

}
