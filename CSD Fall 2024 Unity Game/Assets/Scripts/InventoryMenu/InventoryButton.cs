using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    public Button button;           // Reference to the UI Button
    public Image iconImage;         // Reference to the Image component to show the icon

    // Method to set up the button with the item's sprite
    public void SetItem(Item item)
    {
        if (iconImage != null && item != null)
        {
            iconImage.sprite = item.itemIcon;  // Set the icon to the item's sprite
        }
        else
        {
            Debug.LogError("Icon image or item is null!");
        }
    }
}
