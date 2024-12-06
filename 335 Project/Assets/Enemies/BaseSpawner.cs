using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpawner : MonoBehaviour
{
    //For some reason making this public doesn't allow me to add game objects to it from unity
    public HashSet<GameObject> bases;

    //This array will be temporary until I can find out how to add the base templates to the HashSet
    public GameObject[] obligatoryArray;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //HashSet will go through each area a base can spawn, randomly place a base template there,
        //remove the template from the set, and continue until all the base spawns have a base
        //This'll mean there will be more templates than places a base can spawn, adding to replay value
    }
}
