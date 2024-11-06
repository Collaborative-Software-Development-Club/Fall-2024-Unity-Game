using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public GameObject player;
    public Transform respawnPoint;
    public GameObject dieMessage;
    public GameObject hallucinationEffect;
    // Start is called before the first frame update
    void Start()
    {
        dieMessage.SetActive(false);
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
        dieMessage.SetActive(true);
        if (hallucinationEffect != null)
        {
            hallucinationEffect.GetComponent<DistortionControl>().clearDistortion();
        }
    }
}