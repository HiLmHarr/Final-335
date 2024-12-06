using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player movement and camera setup credit goes to Dave / GameDevelopment on Youtube
//https://www.youtube.com/watch?v=f473C43s8nE
public class PlayerCamera : MonoBehaviour
{
    //X and Y sensitivity
    public float xSens;
    public float ySens;

    public Transform orientation;

    //X and Y rotation
    float xRotate;
    float yRotate;

    private void Start()
    {
        //Locks mouse and hides it
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visable = false;
    }

    private void Update()
    {

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xSens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ySens;

        yRotate += mouseX;
        xRotate -= mouseY;

        //Stops Camera when from continuing to rotate when looking straight up/down
        xRotate = Mathf.Clamp(xRotate, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotate, yRotate, 0);
        orientation.rotation = Quaternion.Euler(0, yRotate, 0);

    }
}
