using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Camara2D : MonoBehaviour
{
    public Transform targetPlayer; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(targetPlayer.position.x + 1.5f,0,-10);

    }
}
