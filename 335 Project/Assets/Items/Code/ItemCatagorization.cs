using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Items")]
public class ItemCatagorization : ScriptableObject
{
    [Header("Properties")]
    public itemType item;
    public Sprite itemSprite;
}

public enum itemType { Sphere, Cylinder, Cube };
