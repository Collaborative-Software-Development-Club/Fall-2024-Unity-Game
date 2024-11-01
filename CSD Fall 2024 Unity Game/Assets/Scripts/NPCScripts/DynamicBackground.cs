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
        float preferredWidth = name.preferredWidth;
        backgroundImage.sizeDelta = new Vector2(preferredWidth + 10f, backgroundImage.sizeDelta.y);
    }

    void Update()
    {
        // Get the preferred width of the text
        float preferredWidth = name.preferredWidth;

        // Set the background sizeDelta width, but keep the height the same
        // Add padding if necessary, e.g., 10f
        backgroundImage.sizeDelta = new Vector2(preferredWidth + 10f, backgroundImage.sizeDelta.y);
    }
}

