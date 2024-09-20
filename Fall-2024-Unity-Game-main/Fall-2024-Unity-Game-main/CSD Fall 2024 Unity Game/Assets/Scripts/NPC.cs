using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Net.Mime.MediaTypeNames;

public class NPC : MonoBehaviour, InteractableInterface
{
    [SerializeField] private string name;
    [SerializeField] private GameObject player;

    [Header("Dialogue U.I. Elements")]
    [SerializeField] private TextMeshProUGUI textElement;
    [SerializeField] private RawImage textBackgroundImg;
    [SerializeField] private TextMeshProUGUI popUpPrompt;
    [SerializeField] private TextMeshProUGUI nextDialogueInfo;
    [SerializeField] private TextMeshProUGUI escDialogueMenuInfo;

    [Header("Dialogues")]
    [TextArea]
    public string NOTES = "ONLY USE ONE OF THE VARIABLES! \nFor one dialogue line, use the dialogue variable, otherwise, use the dialogues list and the dialogues in their respective order.";
    [SerializeField] private string dialogue = "";
    [SerializeField] private string[] dialogues = new string[] {"", ""};


    private int dialogueNum = 0;

    private Dialogue dialogueMenu;

    private bool inPopUp = false;

    private void Start()
    {
        dialogueMenu = new Dialogue("", textBackgroundImg, textElement);
    }

    private void Update()
    {
        Interact();
    }

    // implementation of popUp method from I_Interactable.cs
    public void Interact()
    {
        if (dialogue != "")
        { // pop up if there is a single dialogue
            if (player.transform.position.x < transform.position.x + 1 &&
                player.transform.position.x > transform.position.x - 1 &&
                player.transform.position.y < transform.position.y + 2 &&
                player.transform.position.y > transform.position.y - 2)
            { // check position of player in relation to the NPC position

                if (!inPopUp)
                { // checks if the user is in the pop up
                    popUpPrompt.gameObject.SetActive(true); // displays text prompting user to click f
                }
                if (Input.GetKeyDown(KeyCode.F))
                { // detects keyboard input for the "f" key and enables popup
                    inPopUp = true;
                    popUpPrompt.gameObject.SetActive(false);
                    escDialogueMenuInfo.gameObject.SetActive(true);
                    dialogueMenu = new Dialogue(dialogue, textBackgroundImg, textElement);
                    dialogueMenu.displayDialogue();
                }

            }
            else
            { // disables prompt to user to click f if he is not in contact with the NPC
                popUpPrompt.gameObject.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            { // detects keyboard input for "Esc" key and will proceed to disable everything related to the pop up
                inPopUp = false;
                popUpPrompt.gameObject.SetActive(false);
                escDialogueMenuInfo.gameObject.SetActive(false);
                dialogueMenu.disableDialogue();
            }
        }
        else
        { // pop up if there is multiple dialogues
            if (player.transform.position.x < transform.position.x + 2 &&
                player.transform.position.x > transform.position.x - 2 &&
                player.transform.position.y < transform.position.y + 3 &&
                player.transform.position.y > transform.position.y - 3)
            { // check position of player in relation to the NPC position

                if (!popUpPrompt.gameObject.activeSelf && !inPopUp)
                { // checks if the user is in the pop up
                    popUpPrompt.gameObject.SetActive(true);
                }
                if (Input.GetKeyDown(KeyCode.F))
                { // detects keyboard input for the "f" key and enables popup
                    inPopUp = true;
                    popUpPrompt.gameObject.SetActive(false);
                    nextDialogueInfo.gameObject.SetActive(true);
                    escDialogueMenuInfo.gameObject.SetActive(true);
                    dialogueMenu = new Dialogue(dialogues[dialogueNum], textBackgroundImg, textElement);
                    dialogueMenu.displayDialogue();
                }

            }
            else
            { // disables prompt to user to click f if he is not in contact with the NPC
                popUpPrompt.gameObject.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            { // detects keyboard input for "Esc" key and will proceed to disable everything related to the pop up
                inPopUp = false;
                popUpPrompt.gameObject.SetActive(false);
                escDialogueMenuInfo.gameObject.SetActive(false);
                nextDialogueInfo.gameObject.SetActive(false);
                dialogueMenu.disableDialogue();
            }
            if (Input.GetKeyDown(KeyCode.E) && dialogueNum < dialogues.Length - 1)
            { // detects keyboard input for "E" key and will go to the next dialogue if player isn't at final dialogue
                dialogueNum++;
                dialogueMenu = new Dialogue(dialogues[dialogueNum], textBackgroundImg, textElement);
                dialogueMenu.displayDialogue();
                Debug.Log(dialogueNum);
            }
            else if (Input.GetKeyDown(KeyCode.E) && dialogueNum == dialogues.Length - 1)
            { // detects keyboard input for "E" key and will reset the dialogue shown back to the first one if the dialogue show is the last one
                dialogueNum = 0;
                dialogueMenu = new Dialogue(dialogues[dialogueNum], textBackgroundImg, textElement);
                dialogueMenu.displayDialogue();
            }
        }
    }

}