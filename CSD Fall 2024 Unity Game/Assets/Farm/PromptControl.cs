using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptControl : MonoBehaviour
{
    public GameObject promptObj;
    // Start is called before the first frame update
    void Start()
    {
        promptObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //display this object when a triggerer is triggered 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null&&collision.gameObject.name!="LoopEdges")
        {
            promptObj.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (promptObj != null && collision != null)
        {
            promptObj.SetActive(false);
        }
    }
}
