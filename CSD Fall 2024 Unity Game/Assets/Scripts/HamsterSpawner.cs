using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


/*
 * THIS SCRIPT IS TEMPORARY. This is meant to be a framework that allows the player to see
 * what the hamster emerging from the pig's stomach will look like upon defeating the pig
 * boss fight. This script sets the hamster NPC to become active, which triggers their intro animation where
 * they fly out of the pig and get back up.
 * 
 */

public class HamsterSpawner : MonoBehaviour, InteractableInterface
{
    //Object which will be enabled upon pressing F
    public GameObject toBeSpawned; 
    public GameObject player;

    public int detectionRadius;

    public TextMeshProUGUI popUpPrompt;

    //similar interaction to npc dialogue
    public void Interact()
    {
        float fromObject = Mathf.Sqrt(Mathf.Pow(transform.position.x - player.transform.position.x, 2) +
            Mathf.Pow(transform.position.y - player.transform.position.y, 2));

        if (toBeSpawned.activeSelf == false)
        {
            if (fromObject <= detectionRadius)
            {
                popUpPrompt.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    toBeSpawned.SetActive(true);
                    popUpPrompt.gameObject.SetActive(false);
                }
            }
            else
            {
                popUpPrompt.gameObject.SetActive(false);
            }
        }
        else
        {
            popUpPrompt.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Interact();
    }


}
