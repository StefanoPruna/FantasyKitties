using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    public GameObject Cherryreward;
    public float healthAmount;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Instantiate(Cherryreward, transform.position, Quaternion.identity);            
            Destroy(gameObject.transform.gameObject);
            collision.GetComponent<PlayerHealth>().AddHealth(healthAmount);
        }
    }
    void Update()
    {
        transform.Rotate(new Vector2(0, 60) * Time.deltaTime);

    }
}
