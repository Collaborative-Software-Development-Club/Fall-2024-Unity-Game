using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class CutsceneNPC : MonoBehaviour
{

    [Tooltip("Name which will be displayed in dialogue.")]
    [SerializeField] private string NPCName;

    [Header("TMPro UI Elements")]
    [Tooltip("Name which will be displayed in dialogue.")]
    [SerializeField] private TextMeshProUGUI nameElement;
    [Tooltip("Background art for dialogue. UI Element Name: DialogueMenuBackground")]
    [SerializeField] private GameObject nameBackgroundImg;
    [Tooltip("Text element to display dialogue. UI Element Name: DialogueText")]
    [SerializeField] private TextMeshProUGUI textElement;
    [Tooltip("Background art for dialogue. UI Element Name: DialogueMenuBackground")]
    [SerializeField] private GameObject textBackgroundImg;
    
    [Header("")]

    [Header("Dialogue(s)")]
    [TextArea]
    //all of the dialogue that is cycled through the cutscene in a given level
    [SerializeField] private string[] dialogues;

    //The amount of time between each character being rendered in the dialogue box
    [SerializeField] private float textSpeed = 0.05f;

    //if the writing coroutine is in progress
    private bool isWriting = false;

    //tracks the cycle of the current dialogue array
    private int dialogueNum = 0;

    //Dialogue menu object to be manipulated by CutsceneNPC class
    private Dialogue dialogueMenu;

    //coroutine object
    private IEnumerator writingCoroutine;

    //This field does not need to be filled in the inspector, only if you want a sound effect to play if NPC is interacted with
    public AudioSource interactDialogueSound;

    private void Start()
    {
        dialogueMenu = new Dialogue("", textBackgroundImg, textElement);
        nameElement.text = NPCName;
    }

    //exits the dialogue menu
    public void exitDialogueMenu()
    {
        //will stop writing animation if stil active
        if (writingCoroutine != null)
        {
            StopCoroutine(writingCoroutine);
            writingCoroutine = null;
        }

        nameElement.gameObject.SetActive(false);
        nameBackgroundImg.gameObject.SetActive(false);
        dialogueMenu.disableDialogue();

    }

    //Main controller of dialogue. Opens and closes each line of dialogue
    public void cycleDialogues()
    {
            if (dialogueNum == dialogues.Length)
            {
                exitDialogueMenu();
            }
            //if at the start of dialogue, open it and play sound effect (if it exists)
            else if (dialogueNum == 0)
            {
                nameElement.gameObject.SetActive(true);
                nameBackgroundImg.gameObject.SetActive(true);
                nameElement.text = NPCName;

                writingCoroutine = WriteDialogue();

                StartCoroutine(writingCoroutine);
            }
            else
            {
                nameElement.gameObject.SetActive(true);
                nameBackgroundImg.gameObject.SetActive(true);
                nameElement.text = NPCName;

                writingCoroutine = WriteDialogue();

                StartCoroutine(writingCoroutine);
        }
    }

    //coroutine for dialogue animation. Will display each character of dialogue bit by bit,
    //based on textSpeed
    IEnumerator WriteDialogue()
    {
        isWriting = true;

        int index = 0;
        string changingText = "";

        while (index < dialogues[dialogueNum].Length)
        {
            changingText += dialogues[dialogueNum][index];
            dialogueMenu = new Dialogue(changingText, textBackgroundImg, textElement);
            dialogueMenu.displayDialogue();

            index++;

            yield return new WaitForSeconds(textSpeed);
        }

        isWriting = false;
        dialogueNum++;
    }
}