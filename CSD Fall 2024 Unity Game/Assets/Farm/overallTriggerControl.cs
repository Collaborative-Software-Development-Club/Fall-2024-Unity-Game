using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class overallTriggerControl : MonoBehaviour
{
    private bool bucketBool = false;
    private bool showBucket = false;
    public bool bloodBool = false;
    private bool showBlood = false;
    private bool vegBool = false;
    private bool showVeg = false;
    private bool sandBagBool = false;
    private bool showSandBag = false;
    private bool doorBool = false;
    private bool showDoor = false;
    private bool woodBool = false;
    private bool showWood = false;
    private bool hayBool = false;
    private bool showHay = false;
    public bool allTriggered;
    public string bucketEventText;
    public string bloodEventText;
    public string vegEventText;
    public string doorEventText;
    public string woodEventText;
    public string hayEventText;
    public string sandBagsText;
    private Rigidbody2D doorRb;
    private GameObject door;
    private GameObject eventText;
    private GameObject radioSoundSource;
    private GameObject currentTriggerObject; // 用于存储当前触发的对象

    void Start()
    {
        door = GameObject.Find("Door");
        eventText = GameObject.Find("EventText");
        doorRb = door.GetComponent<Rigidbody2D>();
        radioSoundSource = GameObject.Find("RadioAudio");
        Debug.Log(eventText);
        radioSoundSource.SetActive(false);
    }

    void Update()
    {
        boolsControl();
        if (Input.GetKeyDown(KeyCode.F) && currentTriggerObject != null)
        {
            HandleTrigger(currentTriggerObject);
        }
        showTexts();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentTriggerObject = collision.gameObject; // 存储当前触发的对象
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == currentTriggerObject)
        {
            currentTriggerObject = null; // 清除当前触发的对象
        }
        ResetTexts();
    }

    void HandleTrigger(GameObject triggerObject)
    {
        if (triggerObject.name == "BucketTriggerer")
        {
            bucketBool = true;
            showBucket = true;
            Debug.Log("Bucket triggered");
        }
        else if (triggerObject.name == "BloodTriggerer")
        {
            bloodBool = true;
            showBlood = true;
            Debug.Log("Blood triggered");
        }
        else if (triggerObject.name == "VegetableTriggerer")
        {
            vegBool = true;
            showVeg = true;
            Debug.Log("Veg triggered");
        }
        else if (triggerObject.name == "SandBagsTriggerer")
        {
            sandBagBool = true;
            showSandBag = true;
            Debug.Log("SandBags triggered");
        }
        else if (triggerObject.name == "DoorTriggerer")
        {
            doorBool = true;
            showDoor = true;
            Debug.Log("Door triggered");
        }
        else if (triggerObject.name == "WoodsTriggerer")
        {
            woodBool = true;
            showWood = true;
            Debug.Log("Woods triggered");
        }
        else if (triggerObject.name == "HayTriggerer")
        {
            hayBool = true;
            showHay = true;
            Debug.Log("Hay triggered");
        }
    }

    void boolsControl()
    {
        if (bucketBool && bloodBool && vegBool && sandBagBool && doorBool && woodBool && hayBool)
        {
            Destroy(door.GetComponent<Collider2D>());
            allTriggered = true;
            Debug.Log("All triggered!");
        }
        if (allTriggered)
        {
            radioSoundSource.SetActive(true);
        }
    }

    void ResetTexts()
    {
        showBucket = false;
        showBlood = false;
        showVeg = false;
        showSandBag = false;
        showDoor = false;
        showWood = false;
        showHay = false;
        eventText.GetComponent<TextMeshProUGUI>().SetText("");
        eventText.GetComponent<TextMeshProUGUI>().color = Color.white;
    }

    void showTexts()
    {
        if (showBucket)
        {
            eventText.GetComponent<TextMeshProUGUI>().SetText(bucketEventText);
        }
        else if (showBlood)
        {
            eventText.GetComponent<TextMeshProUGUI>().SetText(bloodEventText);
            eventText.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        else if (showVeg)
        {
            eventText.GetComponent<TextMeshProUGUI>().SetText(vegEventText);
        }
        else if (showDoor)
        {
            eventText.GetComponent<TextMeshProUGUI>().SetText(doorEventText);
        }
        else if (showWood)
        {
            eventText.GetComponent<TextMeshProUGUI>().SetText(woodEventText);
        }
        else if (showHay)
        {
            eventText.GetComponent<TextMeshProUGUI>().SetText(hayEventText);
        }
        else if (showSandBag)
        {
            eventText.GetComponent<TextMeshProUGUI>().SetText(sandBagsText);
        }
    }
}
