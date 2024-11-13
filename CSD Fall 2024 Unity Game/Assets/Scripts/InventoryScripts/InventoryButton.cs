using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    [SerializeField] private Button button;           // Reference to the UI Button
    [SerializeField] private Image iconImage;         // Reference to the Image component to show the icon

    // Method to set up the button with the item's sprite
    public void SetItem(GameObject item)
    {
        // Get the SpriteRenderer from the item GameObject
        SpriteRenderer itemSpriteRenderer = item.GetComponent<SpriteRenderer>();
        
        if (itemSpriteRenderer != null) {

            // Set the icon to the item's sprite by assigning it to the UI Image component
            iconImage.sprite = itemSpriteRenderer.sprite;

            item.transform.localScale = new Vector3(0.1f, 0.1f, 1f);
        }
        else
        {
            Debug.LogError("The item GameObject does not have a SpriteRenderer component!");
        }
    }
}
