using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public float damage;

    public GameObject RobotRabbitMissile;//prefab object/weapon
    // Start is called before the first frame update
    void Start()
    {
        Invoke ("FireEnemyBullet", 1f) ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FireEnemyBullet()
    {
        GameObject Target = GameObject.Find("Player");

        if(Target != null)
        {
            GameObject bullet = (GameObject)Instantiate(RobotRabbitMissile);
            bullet.transform.position = transform.position;
            Vector2 direction = Target.transform.position - bullet.transform.position;
            bullet.GetComponent<EnemyWeapons>().SetDirection(direction);
        }        
    }    
    
}
