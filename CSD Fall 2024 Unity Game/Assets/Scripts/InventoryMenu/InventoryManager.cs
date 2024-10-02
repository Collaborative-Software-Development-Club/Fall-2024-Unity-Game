using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject Inventory;  // Reference to the inventory UI panel
    public Transform ItemPanel;  // Reference to the inventory UI panel
    public GameObject ItemSlot;  // Reference to the inventory UI panel
    private bool isInventoryOpen = false;  // Track if the inventory is open

    private void Start()
    {
        Inventory.SetActive(false);
    }

    void Update()
    {
        UpdateInventory();

        // Check if the Tab key is pressed
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Toggle the inventory
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        // Toggle the inventory's open state
        isInventoryOpen = !isInventoryOpen;

        if (isInventoryOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        } else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Enable or disable the inventory panel based on the state
        Inventory.SetActive(isInventoryOpen);
    }

    public void UpdateInventory()
    {
        // Clear existing buttons
        foreach (Transform child in ItemPanel)
        {
            Destroy(child.gameObject);
        }

        foreach (GameObject item in Inventory.GetComponent<Inventory>().inventoryItems)
        {
            GameObject newButton = Instantiate(ItemSlot, ItemPanel);
            InventoryButton inventoryButton = newButton.GetComponent<InventoryButton>();  // Get the InventoryButton script
            inventoryButton.SetItem(item);
        }
    }
}
