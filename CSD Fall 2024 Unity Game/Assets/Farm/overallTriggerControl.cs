using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class overallTriggerControl : MonoBehaviour
{
    private bool bucketBool = false;
    private bool showBucket = false;
    private bool bloodBool = false;
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
    private GameObject pigHead;

    void Start()
    {
        door = GameObject.Find("Door");
        eventText = GameObject.Find("EventText");
        doorRb = door.GetComponent<Rigidbody2D>();
        radioSoundSource = GameObject.Find("RadioAudio");
        pigHead = GameObject.Find("pigHead");
        Debug.Log(eventText);
        radioSoundSource.SetActive(false);
        pigHead.SetActive(false);
    }

    void Update()
    {
        if (bucketBool && bloodBool && vegBool && sandBagBool && doorBool && woodBool && hayBool && !allTriggered)
        {
            Destroy(door.GetComponent<Collider2D>());
            allTriggered = true;
            Debug.Log("All triggered!");
        }
        if (allTriggered)
        {
            radioSoundSource.SetActive(true);
        }
        if (allTriggered && showBucket && Input.GetKeyDown(KeyCode.F))
        {
            pigHead.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (collision.gameObject.name == "BucketTriggerer")
            {
                bucketBool = true;
                showBucket = true;
                Debug.Log("Bucket triggered");
            }
            else if (collision.gameObject.name == "BloodTriggerer")
            {
                bloodBool = true;
                showBlood = true;
                Debug.Log("Blood triggered");
            }
            else if (collision.gameObject.name == "VegetableTriggerer")
            {
                vegBool = true;
                showVeg = true;
                Debug.Log("Veg triggered");
            }
            else if (collision.gameObject.name == "SandBagsTriggerer")
            {
                sandBagBool = true;
                showSandBag = true;
                Debug.Log("SandBags triggered");
            }
            else if (collision.gameObject.name == "DoorTriggerer")
            {
                doorBool = true;
                showDoor = true;
                Debug.Log("Door triggered");
            }
            else if (collision.gameObject.name == "WoodsTriggerer")
            {
                woodBool = true;
                showWood = true;
                Debug.Log("Woods triggered");
            }
            else if (collision.gameObject.name == "HayTriggerer")
            {
                hayBool = true;
                showHay = true;
                Debug.Log("Hay triggered");
            }
            showTexts();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
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
        pigHead.SetActive(false);
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
    void showItem(Collider2D collision)
    {
        if (allTriggered && collision.gameObject.name == "BucketTriggerer")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                pigHead.SetActive(true);
            }
        }
    }
   
}