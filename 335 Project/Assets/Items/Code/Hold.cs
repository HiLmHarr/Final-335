using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hold : MonoBehaviour
{
    public GameObject me;
    public Transform heldArea;

    // Update is called once per frame
    void Update()
    {
        me.transform.position = heldArea.transform.position;
    }
}
