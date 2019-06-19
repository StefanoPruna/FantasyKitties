using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float aliveTime;

    private void Start()
    {
        Destroy(gameObject, aliveTime);
    }
}
