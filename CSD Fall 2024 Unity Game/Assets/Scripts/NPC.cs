using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.CompilerServices;

public class NPC : MonoBehaviour, InteractableInterface
{
    [SerializeField] private string npcName;

    [Header("TMPro UI Elements")]

    [Tooltip("Text element to display dialogue. UI Element Name: DialogueText")]
    [SerializeField] private TextMeshProUGUI textElement;
    [Tooltip("Background art for dialogue. UI Element Name: DialogueMenuBackground")]
    [SerializeField] private RawImage textBackgroundImg;
    [Tooltip("Text element telling the user how to interact. UI Element Name: InteractPrompt")]
    [SerializeField] private TextMeshProUGUI popUpPrompt;
    [Tooltip("Text element telling the user how to cycle through dialogues. UI Elment Name: CycleDialoguesText")]
    [SerializeField] private TextMeshProUGUI nextDialogueInfo;
    [Tooltip("Text element telling the user how to exit the dialogue menu. UI Element Name: ExitDialogueMenuText")]
    [SerializeField] private TextMeshProUGUI escDialogueMenuInfo;

    [Header("")]
    [Tooltip("GameObject for the player")]
    [SerializeField] private GameObject player;

    [Header("Player-NPC detection border values")]
    [SerializeField] private int upperDetectionBorder = 1;
    [SerializeField] private int lowerDetectionBorder = 1;
    [SerializeField] private int leftDetectionBorder = 1;
    [SerializeField] private int rightDetectionBorder = 1;

    [Header("Dialogue(s)")]
    [TextArea]
    public string Notes = "Do not add text to both variables." +
        "\nIf there is only one dialogue, then add it to the \"dialogue\" variable. " +
        "\nIf there is multiple dialogues, then add them to the \"dialogues\" list.";
    [SerializeField] private string dialogue;
    [SerializeField] private string[] dialogues;

    //private string dialogue;
    //private string[] dialogues = new string[] { "Hello World", "Why is collision detection so annoying?", "I gave up on collision detection...", "Nevermind, Github merging is even more annoying." };
    private int dialogueNum = 0;

    private Dialogue dialogueMenu;

    private bool inPopUp = false;

    private void Start() {
        dialogueMenu = new Dialogue("", textBackgroundImg, textElement);
    }

    private void Update() {
        Interact();
    }

    // implementation of popUp method from I_Interactable.cs
    public void Interact() {
        if (dialogue != "") { // pop up if there is a single dialogue

            if (isInDetectionRange ()) { // check position of player in relation to the NPC position

                if (!inPopUp)  // checks if the user is in the pop up
                    popUpPrompt.gameObject.SetActive (true); // displays text prompting user to click f
                showDialogueMenu (true);

            } else  // disables prompt to user to click f if he is not in contact with the NPC
                popUpPrompt.gameObject.SetActive (false);

            exitDialogueMenu (true);

        } else { // pop up if there is multiple dialogues

            if (isInDetectionRange ()) { // check position of player in relation to the NPC position

                if (!popUpPrompt.gameObject.activeSelf && !inPopUp) // checks if the user is in the pop up
                    popUpPrompt.gameObject.SetActive (true);
                showDialogueMenu (false);

            } else // disables prompt to user to click f if he is not in contact with the NPC
                popUpPrompt.gameObject.SetActive (false);

            exitDialogueMenu (false);
            if (Input.GetKeyDown (KeyCode.E) && dialogueNum < dialogues.Length - 1)
                cycleDialogues (false);
            else if (Input.GetKeyDown (KeyCode.E) && dialogueNum == dialogues.Length - 1)
                cycleDialogues (true);
        }
    }

    public bool isInDetectionRange() { // check to see if the player is within the defined detection range of the NPC
        return player.transform.position.x < transform.position.x + rightDetectionBorder &&
                player.transform.position.x > transform.position.x - leftDetectionBorder &&
                player.transform.position.y < transform.position.y + upperDetectionBorder &&
                player.transform.position.y > transform.position.y - lowerDetectionBorder;
    }

    private void showDialogueMenu(bool isSingleDialogue) { // detects input for the interact key and enables all UI elements related to the dialogue menu if clicked
        if (Input.GetKeyDown(KeyCode.F)) { 
            inPopUp = true;
            popUpPrompt.gameObject.SetActive(false);
            nextDialogueInfo.gameObject.SetActive(true);
            escDialogueMenuInfo.gameObject.SetActive(true);
            dialogueMenu = new Dialogue(dialogues[dialogueNum], textBackgroundImg, textElement);
            dialogueMenu.displayDialogue();

            if (!isSingleDialogue)
                nextDialogueInfo.gameObject.SetActive(true);
        }
    }
    // detects keyboard input for "Esc" key and will proceed to disable everything related to the pop up
    private void exitDialogueMenu(bool isSingleDialogue) {
        // detects keyboard input for "Esc" key and will proceed to disable everything related to the pop up
        if (Input.GetKeyDown(KeyCode.Escape)) { 
            inPopUp = false;
            popUpPrompt.gameObject.SetActive(false);
            escDialogueMenuInfo.gameObject.SetActive(false);
            dialogueMenu.disableDialogue();

            if (!isSingleDialogue) 
                nextDialogueInfo.gameObject.SetActive(false);
        }
    }
    private void cycleDialogues(bool isFinalDialogue) {
        if (isFinalDialogue) {
            dialogueNum = 0;
            dialogueMenu = new Dialogue (dialogues [dialogueNum], textBackgroundImg, textElement);
            dialogueMenu.displayDialogue ();
        } else {
            dialogueMenu = new Dialogue (dialogues [dialogueNum], textBackgroundImg, textElement);
            dialogueMenu.displayDialogue ();
            Debug.Log (dialogueNum);
        }
    }

}