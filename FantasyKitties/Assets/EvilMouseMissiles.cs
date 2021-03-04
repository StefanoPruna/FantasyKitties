using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilMouseMissiles : MonoBehaviour
{
    public GameObject Missiles;
    // public GameObject shurikens;
    [SerializeField]
    private Transform _Player;
    public Transform missiles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject missile = Instantiate(Missiles, missiles.position);//(GameObject)Instantiate(Shuriken);
        //missile.transform.position = missiles.transform.position;
        Vector2 directionToFace = _Player.position - transform.position;
        transform.rotation = Quaternion.LookRotation(directionToFace);
    }
}
