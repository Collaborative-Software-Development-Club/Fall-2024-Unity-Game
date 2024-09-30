using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    // List to store the inventory items
    public List<Item> inventoryItems = new List<Item>();

    // Add an item to the inventory
    public void AddItem(Item item)
    {

        if (inventoryItems.Count >= 12)
        {
            Debug.Log("Inventory is full!");
        }
        else
        {
            inventoryItems.Add(item);
            Debug.Log("Added: " + item.itemName);
        }
        
    }

    // Remove an item from the inventory
    public void RemoveItem(Item item)
    {
        if (inventoryItems.Contains(item))
        {
            inventoryItems.Remove(item);
            Debug.Log("Removed: " + item.itemName);
        }
    }

    // Check if the inventory contains a specific item
    public bool HasItem(Item item)
    {
        return inventoryItems.Contains(item);
    }
}
