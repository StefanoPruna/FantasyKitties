using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    
    public float offset = 16f;
    float speed;   
    private Rigidbody2D body2d;

    // Start is called before the first frame update
    void Start()
    {
        speed = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x + speed * Time.deltaTime, position.y);
        transform.position = position;
        transform.Rotate(new Vector3(0, 0, 360) * Time.deltaTime);//cool effect to move objects
    }


}
