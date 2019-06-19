using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    public GameObject Cherryreward;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Instantiate(Cherryreward, transform.position, Quaternion.identity);            
            collision.gameObject.GetComponent<PlayerInventory>().AddCherry();            
            Destroy(gameObject.transform.root.gameObject);
        }
    }
    void Update()
    {
        transform.Rotate(new Vector2(0, 60) * Time.deltaTime);

    }
}
