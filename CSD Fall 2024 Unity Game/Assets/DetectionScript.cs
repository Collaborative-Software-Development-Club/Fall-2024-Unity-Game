using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionScript : MonoBehaviour
{
    private BearScript bearScript;
    private GameObject bear;
    // Start is called before the first frame update
    void Start()
    {
       bear = GameObject.FindGameObjectWithTag("Bear");
       bearScript = bear.GetComponent<BearScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.Equals(bear))
        {
            return;
        }
        bearScript.respawn();
    }
}
