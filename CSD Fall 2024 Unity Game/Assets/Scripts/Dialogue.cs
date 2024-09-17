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
    string[] dialogues;

    private RawImage textBackground;
    private TextMeshProUGUI text;
    private Boolean goToNext;

    public Dialogue(string dialogue, RawImage textBackground, TextMeshProUGUI text) { 
        this.dialogue = dialogue;
        this.textBackground = textBackground;
        this.text = text;
    }
    public Dialogue(string[] dialogues, RawImage textBackground, TextMeshProUGUI text) {
        this.dialogues = dialogues;
        this.textBackground = textBackground;
        this.text = text;
    }
    public void displayDialogue () {
        if (dialogue != null) {
            textBackground.gameObject.SetActive(true);
            text.text = dialogue;
            text.gameObject.SetActive(true);
            Debug.Log(dialogue);
        } else {
            textBackground.gameObject.SetActive(true);
            text.gameObject.SetActive(true);
            for (int i = 0; i < dialogues.Length; i++) {
                goToNext = false;
                text.text = dialogues[i];
                Debug.Log (dialogues[i]);

                while (!goToNext) {
                    if (Input.GetKeyDown(KeyCode.RightArrow)) {
                        goToNext = true;
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            textBackground.gameObject.SetActive(false);
            text.gameObject.SetActive(false);
            Debug.Log("Esc");
        }
    }
}
