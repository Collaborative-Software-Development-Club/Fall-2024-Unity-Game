using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

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


    public void killPlayer()
    {
        Debug.Log("You Died! ");
        if (hallucinationEffect != null)
        {
            hallucinationEffect.GetComponent<DistortionControl>().clearDistortion();
        }
        SceneManager.LoadScene("Main");
    }
}