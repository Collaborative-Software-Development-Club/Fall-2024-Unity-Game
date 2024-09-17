using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Dialogue dialogue;
    [SerializeField] RawImage textBackground;
    [SerializeField] TextMeshProUGUI text;

    string[] dialogues = { "Hello World", "Interfaces are simple yet confusing", "How tf do you make an interface" };

    // Start is called before the first frame update
    void Start()
    {
        dialogue = new Dialogue(dialogues[0], textBackground, text);
        dialogue.displayDialogue();
    }
}
