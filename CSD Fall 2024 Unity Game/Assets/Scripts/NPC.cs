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
    [SerializeField] private RawImage nameBackgroundImage;
    [Tooltip("Text element to display NPC name. UI Element Name: DialogueText")]
    [SerializeField] private TextMeshProUGUI nameElement;
    [Tooltip ("Text element to display dialogue. UI Element Name: DialogueText")]
    [SerializeField] private TextMeshProUGUI textElement;
    [Tooltip ("Background art for dialogue. UI Element Name: DialogueMenuBackground")]
    [SerializeField] private RawImage textBackgroundImg;
    [Tooltip ("Text element telling the user how to interact. UI Element Name: InteractPrompt")]
    [SerializeField] private TextMeshProUGUI popUpPrompt;

    

    [Header ("")]
    [Tooltip ("GameObject for the player")]
    [SerializeField] private GameObject player;

    [Header ("")]
    [Tooltip ("Player-NPC detection border radius")]
    [SerializeField] private int detectionRadius = 3;

    [Header ("Dialogue(s)")]
    [SerializeField] private string[][] allDialogue;
    [SerializeField] private string [] dialogueArr;


    [SerializeField] private float textSpeed = 1.0f;

    private int currentDialogueArr = 0;
    private int currentLine = 0;

    private Dialogue dialogueMenu;

    private bool inPopUp = false;
    private bool dialogueIsOpen = false;
    private bool isWriting = false;

    private IEnumerator writingCoroutine;


    //This field does not need to be filled in the inspector, only if the NPC will follow the player after dialogue
    public NPCFollow npcFollow;

    //This field does not need to be filled in the inspector, only if you want a sound effect to play if NPC is interacted with
    public AudioSource interactDialogueSound;

    private void Start () {
        dialogueMenu = new Dialogue ("", textBackgroundImg, textElement);
        dialogueArr = allDialogue[currentDialogueArr];
    }

    private void Update () {
        Interact ();
    }

    // implementation of popUp method from I_Interactable.cs
    public void Interact () {                                      // pop up if there is a single dialogue
        if (isInDetectionRange())                                  // check position of player in relation to the NPC position
        {
            if (!dialogueIsOpen)
            {                             
                showPromptWhenInRange();
                cycleDialoguesOnClick();                               // displays text prompting user to click f
            }
            else
            {                                                   // disables prompt to user to click f if he is not in contact with the NPCs
                popUpPrompt.gameObject.SetActive(false);
                cycleDialoguesOnClick();
            }
        } 
        else
        {
            popUpPrompt.gameObject.SetActive(false);
            exitDialogueMenuOnClick();
        }
    }

    public bool isInDetectionRange () {
        /*return player.transform.position.x < transform.position.x + rightDetectionBorder &&
                player.transform.position.x > transform.position.x - leftDetectionBorder &&
                player.transform.position.y < transform.position.y + upperDetectionBorder &&
                player.transform.position.y > transform.position.y - lowerDetectionBorder;*/
        Debug.Log(Mathf.Sqrt(Mathf.Pow(transform.position.x - player.transform.position.x, 2) +
            Mathf.Pow(transform.position.y - player.transform.position.y, 2)));
        return Mathf.Sqrt (Mathf.Pow (transform.position.x - player.transform.position.x, 2) +
            Mathf.Pow (transform.position.y - player.transform.position.y, 2)) <= detectionRadius;
    }

    private void exitDialogueMenuOnClick()
    {
        if (dialogueIsOpen || inPopUp) 
        { 

            if (writingCoroutine != null)
            {
                StopCoroutine(writingCoroutine);
                writingCoroutine = null;
            }

            inPopUp = false;
            dialogueIsOpen = false;
            currentLine = 0;
            isWriting = false;
            nameElement.gameObject.SetActive(false);
            nameBackgroundImage.gameObject.SetActive(false);
            dialogueMenu.disableDialogue();

            if (npcFollow != null)
            {
                npcFollow.isFollowing = true;
            }
        }
    }

    private void cycleDialoguesOnClick () {
        if (Input.GetKeyDown (KeyCode.F)) {
            
            if (!isWriting)
            {
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
                else if (currentLine < dialogueArr.Length)
                {
                    writingCoroutine = WriteDialogue();

                    StartCoroutine(writingCoroutine);

                }
                else
                {
                    exitDialogueMenuOnClick();
                }
            } else
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
        if (!inPopUp && isInDetectionRange())                                        // checks if the user is in the pop up
            popUpPrompt.gameObject.SetActive(true);
    }

    public void newDialogueArray()
    {
        currentDialogueArr++;
        currentLine = 0;
        dialogueArr = allDialogue[currentDialogueArr];
    }

    IEnumerator WriteDialogue()
    {
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

        isWriting = false;
        currentLine++;
    }
}