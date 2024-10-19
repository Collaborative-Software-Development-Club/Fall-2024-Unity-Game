using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    public GameObject timeline;

    public void OnTriggerEnter2D(Collider2D other)
    {
        timeline.SetActive(true);
    }
}
