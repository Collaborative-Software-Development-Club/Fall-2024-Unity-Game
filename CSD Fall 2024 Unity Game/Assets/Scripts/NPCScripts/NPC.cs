using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;

public class NPC : MonoBehaviour, InteractableInterface {


    [Tooltip("Name which will be displayed in dialogue.")]
    [SerializeField] private string NPCName;

    [Header ("TMPro UI Elements")]
    [Tooltip("Background art for NPC name. UI Element Name: DialogueMenuBackground")]
    [SerializeField] private GameObject nameBackgroundImage;
    [Tooltip("Text element to display NPC name. UI Element Name: DialogueText")]
    [SerializeField] private TextMeshProUGUI nameElement;
    [Tooltip ("Text element to display dialogue. UI Element Name: DialogueText")]
    [SerializeField] private TextMeshProUGUI textElement;
    [Tooltip ("Background art for dialogue. UI Element Name: DialogueMenuBackground")]
    [SerializeField] private GameObject textBackgroundImg;
    [Tooltip ("Text element telling the user how to interact. UI Element Name: InteractPrompt")]
    [SerializeField] private GameObject popUpPrompt;

    [Header ("")]
    [Tooltip ("GameObject for the player")]
    [SerializeField] private GameObject player;

    [Header ("")]
    [Tooltip ("Player-NPC detection border radius")]
    [SerializeField] private int detectionRadius = 3;

    
    [Header ("Dialogue(s)")]
    //allDialogue array allows the current cycle of dialogue to switch based on some sort of trigger
    [SerializeField] private string[][] allDialogue;
    //a single grouping of dialogue that the player can cycle through
    [SerializeField] private string [] dialogueArr;

    //The amount of time between each character being rendered in the dialogue box
    [SerializeField] private float textSpeed = 0.02f;

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

    //StoryProgressor stuff man, if you're seeing this just talk to Caleb
    private StoryProgressor storyProgressor;

    private void Start () {
        storyProgressor = gameObject.GetComponent<StoryProgressor> ();

        dialogueMenu = new Dialogue ("", textBackgroundImg, textElement);
        dialogueArr = allDialogue[currentDialogueArr];
        nameBackgroundImage.gameObject.SetActive(false);
    }

    private void Update () {
        Interact ();
    }

    // implementation of Interact() method from I_Interactable.cs
    public void Interact () {
        //if the player is close enough to the npc
        if (isInDetectionRange())
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

    //returns true if player is within detetctionRadius
    public bool isInDetectionRange () {
        return Mathf.Sqrt (Mathf.Pow (transform.position.x - player.transform.position.x, 2) +
            Mathf.Pow (transform.position.y - player.transform.position.y, 2)) <= detectionRadius;
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
    private void cycleDialoguesOnClick () {
        if (Input.GetKeyDown (KeyCode.F)) {
            
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
                    if (storyProgressor != null)
                    {
                        storyProgressor.advanceStory();
                    }
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
    private void showPromptWhenInRange () {
        if (!inPopUp && isInDetectionRange())
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