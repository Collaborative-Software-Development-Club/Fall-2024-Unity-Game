using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterDeath : MonoBehaviour
{
    public GameObject player;
    private Vector2 respawnPoint;
    public GameObject dieMessage;
    public GameObject respawnPrompt;
    public GameObject killingFoxObj;
    public audioSpawner audioSpawner;
    private Collider2D colliderKillingFox;
    private bool died = false;
    private float tempSpeed;
    // Start is called before the first frame update
    void Start()
    {
        dieMessage.SetActive(false);
        respawnPrompt.SetActive(false);
        respawnPoint=transform.position;
        colliderKillingFox=killingFoxObj.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        respawn();
    }

    private void OnCollisionEnter2D(Collision2D collision) //killing fox
    {
        if (collision.gameObject == killingFoxObj)
        {
            Debug.Log("You Died! ");
            dieMessage.SetActive(true);
            respawnPrompt.SetActive(true);
            died = true;
            tempSpeed=player.GetComponent<fox>().speed;
            player.GetComponent<fox>().speed=0;
        }
    }
    void respawn()
    {
        if (Input.GetKeyDown(KeyCode.F)&&died)
        {
            transform.position = respawnPoint;
            dieMessage.SetActive(false);
            respawnPrompt.SetActive(false);
            player.GetComponent<fox>().speed = tempSpeed;
            audioSpawner.destroyAllPrefabs();
        }
    }
}