using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    static Vector3 ReachedPoint;
    public GameObject CheckPointSound;
    public AudioClip checkPoint;
    AudioSource checkPointAudio;
    

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(transform.position.x > ReachedPoint.x)
            {
                Instantiate(CheckPointSound, transform.position, Quaternion.identity);
                ReachedPoint = collision.transform.position;
                checkPointAudio = GetComponent<AudioSource>();

            }

        }
    }
    
}
