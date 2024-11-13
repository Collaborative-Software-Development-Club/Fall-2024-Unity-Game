
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEditor.UI;
using System;

public class Dialogue : MonoBehaviour
{
    string dialogue;

    private RawImage textBackground;
    private TextMeshProUGUI text;

    public Dialogue(string dialogue, RawImage textBackground, TextMeshProUGUI text)
    {
        this.dialogue = dialogue;
        this.textBackground = textBackground;
        this.text = text;
        textBackground.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }

    // uses Image and text references to show the background and text if the dialogue string is not empty
    public void displayDialogue()
    {
        if (dialogue != null)
        {
            textBackground.gameObject.SetActive(true);
            text.text = dialogue;
            text.gameObject.SetActive(true);
        }
    }

    // disables background and text 
    public void disableDialogue()
    {
        textBackground.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }
}
