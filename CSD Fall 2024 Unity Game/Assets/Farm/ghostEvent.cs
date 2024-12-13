using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostEvent : MonoBehaviour
{
    public GameObject fox;
    private bool bloodBool;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        bloodBool = fox.GetComponent<overallTriggerControl>().bloodBool;
        if (bloodBool)
        {

        }
    }
}
