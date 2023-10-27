using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject Player;

    // private Vector3 distance = new Vector3(0, 1.8f, -3);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = Player.transform.up * 1.9f + Player.transform.forward * -3;

        transform.position = Player.transform.position + distance; 
        transform.rotation = Player.transform.rotation;
    }
}
