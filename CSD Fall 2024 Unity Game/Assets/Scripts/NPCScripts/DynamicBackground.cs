using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Small script meant to allow an image ui background to scale to the length of text
public class DynamicBackground : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI name; // or use Text if you're not using TextMeshPro
    [SerializeField]
    public RectTransform backgroundImage;

    private void Start()
    {
        // Ensure the pivot is set correctly so only the right side grows
        backgroundImage.pivot = new Vector2(0, 0.5f);

        // Adjust the background size initially
        UpdateBackgroundSize();
    }

    private void Update()
    {
        // Continuously adjust the background size based on the text width
        UpdateBackgroundSize();
    }

    private void UpdateBackgroundSize()
    {
        // Get the preferred width of the text
        float preferredWidth = name.preferredWidth;

        // Set the background sizeDelta width, but keep the height the same
        // Add padding if necessary, e.g., 25f
        backgroundImage.sizeDelta = new Vector2(preferredWidth + 30f, backgroundImage.sizeDelta.y);
    }
}


