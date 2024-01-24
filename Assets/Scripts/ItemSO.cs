using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable Objects/Items")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public Sprite image;
    public ItemType type;
    public GameObject prefab;
}

public enum ItemType{
    Sword,
    Clothes,
    Helmet,
    Boots
}
