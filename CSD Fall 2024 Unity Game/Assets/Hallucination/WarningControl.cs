using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WarningControl : MonoBehaviour
{
    public int warningThreshold; //The number of spores required to show the warning sign
    private int sporeCount;
    public GameObject warningText;
    public GameObject sporeObject;
    private Hallucination hallucination;

    // Start is called before the first frame update
    void Start()
    {
        // check if sporeObject is assigned
        if (sporeObject == null)
        {
            
            return;
        }

        hallucination = sporeObject.GetComponent<Hallucination>(); 

        // check if hallucination is assigned
        if (hallucination == null)
        {
            
            return;
        }

        // check if warningText is assigned
        if (warningText == null)
        {
       
            return;
        }

        // setting text to be transparent at the first frame
        warningText.GetComponent<TextMeshProUGUI>().alpha = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        sporeCount = hallucination.sporeCount;

        if (sporeCount >= warningThreshold)
        {
            warningText.GetComponent<TextMeshProUGUI>().alpha = 1f; // set text to be not transparent when reaching warningthreshold
        }
        else
        {
            warningText.GetComponent<TextMeshProUGUI>().alpha = 0f; 
        }

    }
}
