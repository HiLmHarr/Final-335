using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public GameObject reference;
    public float foraward;
    public float down;
    public float right;

    //This has all objects in the players hand float forward and to the bottom right of the camera
    //I would like to point out that there isn't a transform.down, it's -transform.up
    void Update()
    {
        transform.position = reference.transform.position + 
            reference.transform.forward * foraward + 
            -reference.transform.up * down +
            reference.transform.right * right;
        transform.rotation = reference.transform.rotation;
    }
}
