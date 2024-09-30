using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemGiverScript : MonoBehaviour
{
    public Item item;
    public Inventory playerInventory;

    void Start()
    {
        if (playerInventory == null)
        {
            Debug.LogError("No Inventory component found on the GameObject tagged 'Inventory'.");
        }
    }
    
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

            playerInventory.AddItem(item);

            Debug.Log("Item sent");
        }
    }
}
