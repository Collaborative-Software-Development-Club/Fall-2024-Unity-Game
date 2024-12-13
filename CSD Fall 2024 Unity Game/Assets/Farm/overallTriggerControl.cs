using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class overallTriggerControl : MonoBehaviour
{
    public bool bucketBool = false;
    public bool bloodBool = false;
    public bool sandBagBool = false;
    public bool woodBool = false;
    public bool hayBool = false;

    public bool allTriggered;
    public string bucketEventText;
    public string bloodEventText;
    public string vegEventText;
    public string woodEventText;
    public string hayEventText;
    public string sandBagsText;

    private GameObject eventText;
    private GameObject currentTriggerObject;

    // Define the correct order of triggers
    private List<string> correctOrder = new List<string> {
        "BucketTriggerer",
        "BloodTriggerer",
        "SandBagsTriggerer",
        "WoodsTriggerer",
        "HayTriggerer"
    };

    private int currentStep = 0; // Track the player's progress in the sequence

    void Start()
    {
        eventText = GameObject.Find("EventText");
        Debug.Log(eventText);
    }

    void Update()
    {
        boolsControl();
        if (Input.GetKeyDown(KeyCode.F) && currentTriggerObject != null)
        {
            HandleTrigger(currentTriggerObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentTriggerObject = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == currentTriggerObject)
        {
            currentTriggerObject = null;
        }
        ResetTexts();
    }

    void HandleTrigger(GameObject triggerObject)
    {
        string triggerName = triggerObject.name;
        string eventTextContent = GetEventText(triggerName);

        if (currentStep < correctOrder.Count && triggerName == correctOrder[currentStep])
        {
            // Correct trigger in the sequence
            currentStep++;
            eventText.GetComponent<TextMeshProUGUI>().SetText(eventTextContent);
            eventText.GetComponent<TextMeshProUGUI>().color = Color.red;

            // Update the bools based on the trigger
            UpdateBool(triggerName);
        }
        else
        {
            // Incorrect trigger
            eventText.GetComponent<TextMeshProUGUI>().SetText(eventTextContent);
            eventText.GetComponent<TextMeshProUGUI>().color = Color.white;

            // Reset the sequence
            currentStep = 0;
            Debug.Log("Wrong sequence! Resetting...");
        }
    }

    void boolsControl()
    {
        if (bucketBool && bloodBool && sandBagBool && woodBool && hayBool)
        {
            allTriggered = true;
            Debug.Log("All triggered!");
        }
    }

    void ResetTexts()
    {
        eventText.GetComponent<TextMeshProUGUI>().SetText("");
        eventText.GetComponent<TextMeshProUGUI>().color = Color.white;
    }

    string GetEventText(string triggerName)
    {
        if (triggerName == "BucketTriggerer") return bucketEventText;
        if (triggerName == "BloodTriggerer") return bloodEventText;
        if (triggerName == "SandBagsTriggerer") return sandBagsText;
        if (triggerName == "WoodsTriggerer") return woodEventText;
        if (triggerName == "HayTriggerer") return hayEventText;
        return "Unknown Trigger";
    }

    void UpdateBool(string triggerName)
    {
        if (triggerName == "BucketTriggerer") bucketBool = true;
        else if (triggerName == "BloodTriggerer") bloodBool = true;
        else if (triggerName == "SandBagsTriggerer") sandBagBool = true;
        else if (triggerName == "WoodsTriggerer") woodBool = true;
        else if (triggerName == "HayTriggerer") hayBool = true;
    }
}
