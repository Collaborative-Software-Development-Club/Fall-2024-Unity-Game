using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform respawnPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      /*if (Input.GetKeyDown(KeyCode.E))
        {
            killPlayer();
        }
      */
    }

    public void killPlayer()
    {
        player.transform.position = respawnPoint.position;
        Debug.Log("You Died! ");
    }
}