using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.CompilerServices;

public class NPC : MonoBehaviour, InteractableInterface {
    [SerializeField] private string name;

    [Header ("TMPro UI Elements")]

    [Tooltip ("Text element to display dialogue. UI Element Name: DialogueText")]
    [SerializeField] private TextMeshProUGUI textElement;
    [Tooltip ("Background art for dialogue. UI Element Name: DialogueMenuBackground")]
    [SerializeField] private RawImage textBackgroundImg;
    [Tooltip ("Text element telling the user how to interact. UI Element Name: InteractPrompt")]
    [SerializeField] private TextMeshProUGUI popUpPrompt;
    [Tooltip ("Text element telling the user how to cycle through dialogues. UI Elment Name: CycleDialoguesText")]
    [SerializeField] private TextMeshProUGUI nextDialogueInfo;
    [Tooltip ("Text element telling the user how to exit the dialogue menu. UI Element Name: ExitDialogueMenuText")]
    [SerializeField] private TextMeshProUGUI escDialogueMenuInfo;

    [Header ("")]
    [Tooltip ("GameObject for the player")]
    [SerializeField] private GameObject player;

    [Header ("")]
    /*[SerializeField] private int upperDetectionBorder = 1;
    [SerializeField] private int lowerDetectionBorder = 1;
    [SerializeField] private int leftDetectionBorder = 1;
    [SerializeField] private int rightDetectionBorder = 1;*/
    [Tooltip ("Player-NPC detection border radius")]
    [SerializeField] private int detectionRadius = 1;

    [Header ("Dialogue(s)")]
    [TextArea]
    public string Notes = "Do not add text to both variables." +
        "\nIf there is only one dialogue, then add it to the \"dialogue\" variable. " +
        "\nIf there is multiple dialogues, then add them to the \"dialogues\" list.";
    [SerializeField] private string dialogue;
    [SerializeField] private string [] dialogues;

    private int dialogueNum = 0;

    private Dialogue dialogueMenu;

    private bool inPopUp = false;

    private void Start () {
        dialogueMenu = new Dialogue ("", textBackgroundImg, textElement);
    }

    private void Update () {
        Interact ();
    }

    // implementation of popUp method from I_Interactable.cs
    public void Interact () {
        if (dialogue != "") {                                        // pop up if there is a single dialogue
            if (isInDetectionRange ()) {                             // check position of player in relation to the NPC position
                showPromptWhenInRange ();                            // displays text prompting user to click f
                showDialogueOnClick ();
            } else {                                                   // disables prompt to user to click f if he is not in contact with the NPC
                popUpPrompt.gameObject.SetActive (false);
            }

            exitDialogueMenuOnClick (true);
        } else {                                                    // pop up if there is multiple dialogues
            if (isInDetectionRange ()) {                            // check position of player in relation to the NPC position
                showPromptWhenInRange ();
                showDialogueOnClick ();
            } else {                                                 // disables prompt to user to click f if he is not in contact with the NPC
                popUpPrompt.gameObject.SetActive (false);
            }

            exitDialogueMenuOnClick (false);
            cycleDialoguesOnClick ();
        }
    }

    public bool isInDetectionRange () {
        /*return player.transform.position.x < transform.position.x + rightDetectionBorder &&
                player.transform.position.x > transform.position.x - leftDetectionBorder &&
                player.transform.position.y < transform.position.y + upperDetectionBorder &&
                player.transform.position.y > transform.position.y - lowerDetectionBorder;*/
        return Mathf.Sqrt (Mathf.Pow (transform.position.x - player.transform.position.x, 2) +
            Mathf.Pow (transform.position.y - player.transform.position.y, 2)) <= detectionRadius;
    }

    private void showDialogueMenu (bool isSingleDialogue) {
        inPopUp = true;
        popUpPrompt.gameObject.SetActive (false);
        nextDialogueInfo.gameObject.SetActive (true);
        escDialogueMenuInfo.gameObject.SetActive (true);
        dialogueMenu = new Dialogue (dialogues [dialogueNum], textBackgroundImg, textElement);
        dialogueMenu.displayDialogue ();

        if (!isSingleDialogue)
            nextDialogueInfo.gameObject.SetActive (true);
    }

    private void exitDialogueMenuOnClick (bool isSingleDialogue) {
        if (Input.GetKeyDown (KeyCode.Space)) {
            inPopUp = false;
            popUpPrompt.gameObject.SetActive (false);
            escDialogueMenuInfo.gameObject.SetActive (false);
            dialogueMenu.disableDialogue ();

            if (!isSingleDialogue)
                nextDialogueInfo.gameObject.SetActive (false);
        }
    }

    private void cycleDialoguesOnClick () {
        if (Input.GetKeyDown (KeyCode.E)) {
            if (dialogueNum == dialogues.Length - 1) {
                dialogueNum = 0;
                dialogueMenu = new Dialogue (dialogues [dialogueNum], textBackgroundImg, textElement);
                dialogueMenu.displayDialogue ();
            } else {
                dialogueNum++;
                dialogueMenu = new Dialogue (dialogues [dialogueNum], textBackgroundImg, textElement);
                dialogueMenu.displayDialogue ();
            }
        }
    }
    private void showPromptWhenInRange () {
        if (!inPopUp)                                        // checks if the user is in the pop up
            popUpPrompt.gameObject.SetActive (true);
    }
    private void showDialogueOnClick () {
        if (Input.GetKeyDown (KeyCode.F))
            showDialogueMenu (false);
    }
}