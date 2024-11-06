using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using System;

public class BigNPC : MonoBehaviour, InteractableInterface
{


    [Tooltip("Name which will be displayed in dialogue.")]
    [SerializeField] private string NPCName;

    [Header("TMPro UI Elements")]
    [Tooltip("Background art for NPC name. UI Element Name: DialogueMenuBackground")]
    [SerializeField] private RawImage nameBackgroundImage;
    [Tooltip("Text element to display NPC name. UI Element Name: DialogueText")]
    [SerializeField] private TextMeshProUGUI nameElement;
    [Tooltip("Text element to display dialogue. UI Element Name: DialogueText")]
    [SerializeField] private TextMeshProUGUI textElement;
    [Tooltip("Background art for dialogue. UI Element Name: DialogueMenuBackground")]
    [SerializeField] private RawImage textBackgroundImg;
    [Tooltip("Text element telling the user how to interact. UI Element Name: InteractPrompt")]
    [SerializeField] private TextMeshProUGUI popUpPrompt;

    [Header("")]
    [Tooltip("GameObject for the player")]
    [SerializeField] private GameObject player;


    [Header("Dialogue(s)")]
    //allDialogue array allows the current cycle of dialogue to switch based on some sort of trigger
    [SerializeField] private string[][] allDialogue;
    //a single grouping of dialogue that the player can cycle through
    [SerializeField] private string[] dialogueArr;

    //The amount of time between each character being rendered in the dialogue box
    [SerializeField] private float textSpeed = 0.02f;

    //boolean which is manipulated based on whether the player is in the area of dialogue
    private bool isInRange = false;

    //tracks the dialouge array to be cycled through
    private int currentDialogueArr = 0;

    //tracks the cycle of the current dialogue array
    private int currentLine = 0;

    //Dialogue menu object to be manipulated by NPC class
    private Dialogue dialogueMenu;

    private bool inPopUp = false;
    private bool dialogueIsOpen = false;

    //if the writing coroutine is in progress
    private bool isWriting = false;

    //coroutine object
    private IEnumerator writingCoroutine;

    //This field does not need to be filled in the inspector, only if the NPC will follow the player after dialogue
    public NPCFollow npcFollow;

    //This field does not need to be filled in the inspector, only if you want a sound effect to play if NPC is interacted with
    public AudioSource interactDialogueSound;

    private void Start()
    {
        dialogueMenu = new Dialogue("", textBackgroundImg, textElement);
        dialogueArr = allDialogue[currentDialogueArr];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            isInRange = false ;
        }
    }

    private void Update()
    {
        Interact();
    }

    // implementation of Interact() method from I_Interactable.cs
    public void Interact()
    {
        //if the player is close enough to the npc
        if (isInRange)
        {
            //if the dialogue is already open
            if (!dialogueIsOpen)
            {
                showPromptWhenInRange();
                cycleDialoguesOnClick();
            }
            else
            {
                popUpPrompt.gameObject.SetActive(false);
                cycleDialoguesOnClick();
            }
        }
        //if out of range, exit dialogue menu
        else
        {
            popUpPrompt.gameObject.SetActive(false);
            exitDialogueMenuOnClick();
        }
    }

    //exits and resets the dialogue menu
    private void exitDialogueMenuOnClick()
    {
        //only exits if there is a dialogue menu open
        if (dialogueIsOpen || inPopUp)
        {
            //will stop writing animation if stil active
            if (writingCoroutine != null)
            {
                StopCoroutine(writingCoroutine);
                writingCoroutine = null;
            }

            if (npcFollow != null)
            {
                npcFollow.isFollowing = true;
            }

            //resets dialogue values
            inPopUp = false;
            dialogueIsOpen = false;
            currentLine = 0;
            isWriting = false;
            nameElement.gameObject.SetActive(false);
            nameBackgroundImage.gameObject.SetActive(false);
            dialogueMenu.disableDialogue();


        }
    }

    //Main controller of dialogue. Opens and closes each line of dialogue
    private void cycleDialoguesOnClick()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

            //if there is no text in the process of animating
            if (!isWriting)
            {
                //if at the start of dialogue, open it and play sound effect (if it exists)
                if (currentLine == 0)
                {
                    inPopUp = true;
                    popUpPrompt.gameObject.SetActive(false);
                    nameElement.text = NPCName;
                    nameElement.gameObject.SetActive(true);
                    nameBackgroundImage.gameObject.SetActive(true);

                    if (interactDialogueSound != null && !interactDialogueSound.isPlaying)
                    {
                        interactDialogueSound.Play();
                    }

                    writingCoroutine = WriteDialogue();

                    StartCoroutine(writingCoroutine);

                }
                //otherwise if it is not at the end of the dialogue, write next line
                else if (currentLine < dialogueArr.Length)
                {
                    writingCoroutine = WriteDialogue();

                    StartCoroutine(writingCoroutine);

                }
                //if it is at the end of the dialogue, begin dialogue exit
                else
                {
                    exitDialogueMenuOnClick();
                }
            }
            //if there is text still being written, end the coroutine and display the text immediately
            else
            {
                StopCoroutine(writingCoroutine);
                dialogueMenu = new Dialogue(dialogueArr[currentLine], textBackgroundImg, textElement);
                dialogueMenu.displayDialogue();

                isWriting = false;
                currentLine++;

            }
        }
    }
    private void showPromptWhenInRange()
    {
        if (!inPopUp && isInRange)
            popUpPrompt.gameObject.SetActive(true);
    }

    //moves to the next cycle of dialogue
    public void newDialogueArray()
    {
        currentDialogueArr++;
        currentLine = 0;
        dialogueArr = allDialogue[currentDialogueArr];
    }

    //coroutine for dialogue animation. Will display each character of dialogue bit by bit,
    //based on textSpeed
    IEnumerator WriteDialogue()
    {
        //updates flag isWriting to indicate that coroutine is in progress
        isWriting = true;

        int index = 0;
        string changingText = "";

        while (index < dialogueArr[currentLine].Length)
        {
            changingText += dialogueArr[currentLine][index];
            dialogueMenu = new Dialogue(changingText, textBackgroundImg, textElement);
            dialogueMenu.displayDialogue();

            index++;

            yield return new WaitForSeconds(textSpeed);
        }

        //updates flag after text animation finishes
        isWriting = false;

        //changes index to next line of dialogue
        currentLine++;
    }
}