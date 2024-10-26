using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class CutsceneNPC : MonoBehaviour
{
    public PlayableDirector director;

    [Tooltip("Name which will be displayed in dialogue.")]
    [SerializeField] private string NPCName;

    [Header("TMPro UI Elements")]
    [Tooltip("Name which will be displayed in dialogue.")]
    [SerializeField] private TextMeshProUGUI nameElement;
    [Tooltip("Background art for dialogue. UI Element Name: DialogueMenuBackground")]
    [SerializeField] private RawImage nameBackgroundImg;
    [Tooltip("Text element to display dialogue. UI Element Name: DialogueText")]
    [SerializeField] private TextMeshProUGUI textElement;
    [Tooltip("Background art for dialogue. UI Element Name: DialogueMenuBackground")]
    [SerializeField] private RawImage textBackgroundImg;
    
    [Header("")]

    [Header("Dialogue(s)")]
    [TextArea]
    [SerializeField] private string[] dialogues;
    [SerializeField] private float textSpeed = 0.05f;

    private bool isWriting = false;

    private int dialogueNum = 0;


    private Dialogue dialogueMenu;

    private IEnumerator writingCoroutine;


    //This field does not need to be filled in the inspector, only if you want a sound effect to play if NPC is interacted with
    public AudioSource interactDialogueSound;

    private void Start()
    {
        dialogueMenu = new Dialogue("", textBackgroundImg, textElement);
        nameElement.text = NPCName;
    }

    public void showDialogueMenu()
    {
        nameElement.gameObject.SetActive(true);
        nameBackgroundImg.gameObject.SetActive(true);

        dialogueMenu = new Dialogue(dialogues[dialogueNum], textBackgroundImg, textElement);
        nameElement.text = NPCName;
        dialogueMenu.displayDialogue();

        if (interactDialogueSound != null && !interactDialogueSound.isPlaying)
        {
            interactDialogueSound.Play();
        }
    }

    public void exitDialogueMenu()
    {
        if (writingCoroutine != null)
        {
            StopCoroutine(writingCoroutine);
            writingCoroutine = null;
        }

        nameElement.gameObject.SetActive(false);
        nameBackgroundImg.gameObject.SetActive(false);
        dialogueMenu.disableDialogue();

    }

    public void cycleDialogues()
    {
            if (dialogueNum == dialogues.Length)
            {
                exitDialogueMenu();
            }
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