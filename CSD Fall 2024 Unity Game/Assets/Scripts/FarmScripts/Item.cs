using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName; // "Bucket", "Sand", etc.

    private void Start()
    {
        // Ensure the name matches the required item order
        gameObject.name = itemName;
    }
}
