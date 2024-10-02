using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    // List to store the inventory items
    public List<GameObject> inventoryItems = new List<GameObject>();

    // Add an item to the inventory
    public void AddItem(GameObject item)
    {

        if (inventoryItems.Count >= 12)
        {
            Debug.Log("Inventory is full!");
        }
        else
        {
            inventoryItems.Add(item);
            Debug.Log("Added: " + item.name);
        }
        
    }

    // Remove an item from the inventory
    public void RemoveItem(GameObject item)
    {
        if (inventoryItems.Contains(item))
        {
            inventoryItems.Remove(item);
            Debug.Log("Removed: " + item.name);
        }
    }

    // Check if the inventory contains a specific item
    public bool HasItem(GameObject item)
    {
        return inventoryItems.Contains(item);
    }
}
