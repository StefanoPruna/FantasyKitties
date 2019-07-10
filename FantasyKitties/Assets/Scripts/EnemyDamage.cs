using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public GameObject enemyDeath;
    public float damage;
    public float damageRate;
    public float pushBackForce;

    float nextDamage;
    public float EnemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        nextDamage = Time.time;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && nextDamage < Time.time)
        {
            PlayerHealth thePlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
            thePlayerHealth.addDamage(damage);
            nextDamage = Time.time + damageRate;
            PushBack(other.transform);
        }

    }
    void PushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized;
        pushDirection *= pushBackForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }

    internal void OnTriggerStay2D(Collision2D collision2D, object other)
    {
        throw new NotImplementedException();
    }
    public void AddDamage()
    {
       if (EnemyHealth == 0)
        {
            Debug.Log("enemyDeath");
            enemyDeath.SetActive(true);
            Destroy(gameObject.transform.root.gameObject);
        }
    }
}