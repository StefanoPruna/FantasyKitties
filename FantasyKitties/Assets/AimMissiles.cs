using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMissiles : MonoBehaviour
{
    [SerializeField]
    private Transform _Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToFace = _Player.position - transform.position;
        transform.rotation = Quaternion.LookRotation(directionToFace);
    }
}
