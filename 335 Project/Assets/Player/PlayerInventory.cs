using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("General")]
    public itemType[] backpack;
    public int selectedItem;

    [Header("Item gameobject")]
    [SerializeField] GameObject sphere;
    [SerializeField] GameObject cube;
    [SerializeField] GameObject cylinder;

    private Dictionary<itemType, GameObject> itemSetActive = new Dictionary<itemType, GameObject>() { };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemSetActive.Add(itemType.Sphere, sphere);
        itemSetActive.Add(itemType.Cube, cube);
        itemSetActive.Add(itemType.Cylinder, cylinder);

        NewItemSelected();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            if (selectedItem == backpack.Length - 1) 
            {
                selectedItem = 0; 
            }
            else
            {
                ++selectedItem;
            }
            NewItemSelected();
        }
        else if (Input.mouseScrollDelta.y < 0) 
        { 
            if (selectedItem == 0)
            {
                selectedItem = backpack.Length - 1;
            }
            else
            {
                --selectedItem;
            }
            NewItemSelected();
        }
    }

    private void NewItemSelected()
    {
        sphere.SetActive(false); 
        cube.SetActive(false);
        cylinder.SetActive(false);

        GameObject selectedItemGameObject = itemSetActive[backpack[selectedItem]];
        selectedItemGameObject.SetActive(true);
    }
}
