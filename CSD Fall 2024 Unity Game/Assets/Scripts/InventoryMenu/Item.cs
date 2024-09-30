using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite itemIcon;  // For the UI
    public int itemID;

    public Item(string name, Sprite icon, int id)
    {
        itemName = name;
        itemIcon = icon;
        itemID = id;
    }
}
