using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shuriken : MonoBehaviour
{
    private GameObject player;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        speed = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        if(player.GetComponent<PlayerController>().facingRight)        
            position = new Vector2(position.x + speed * Time.deltaTime, position.y);


        transform.position = position;
        transform.Rotate (new Vector3 (0, 0, -360) * Time.deltaTime);        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.tag == "Enemy")
        {
            Destroy(gameObject.transform.gameObject);
            collision.GetComponent<EnemyDamage>().AddDamage();
        }
    }
}
