using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follows : MonoBehaviour
{

    public Transform Player;
    public float offset;


    void Update()
    {
        if(Player != null)
        transform.position = new Vector3(Player.position.x, offset, -1);
    }
}
