using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BetterWin : MonoBehaviour
{
    public float heightThreshold;

    int itemsBelowThreshold;
    int itemsInScene;

    void Start()
    {
        foreach (Transform child in transform)
        {
            itemsInScene++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        CheckItemsHeight();
    }

    private void CheckItemsHeight()
    {
        itemsBelowThreshold = 0;

        foreach (Transform child in transform) 
        { 
            if (child.transform.position.y < heightThreshold)
            {
                itemsBelowThreshold++;
            }
        }

        if (itemsBelowThreshold == itemsInScene) 
        {
            VicRoyale();
        }
    }

    private void VicRoyale()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
