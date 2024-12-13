using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entranceOpeningTrigger : MonoBehaviour
{
    public NPCFollow following = new NPCFollow();
    public GameObject barrier = new GameObject();


    // Update is called once per frame
    void Update()
    {
        if (following.enabled = true)
        {
            barrier.SetActive(false);
        }
    }
}
