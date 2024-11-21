using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    [Header("")]
    [Tooltip("Player-NPC detection border radius")]
    [SerializeField] private int detectionRadius = 3;

    [Header("")]
    [Tooltip("GameObject for the player")]
    [SerializeField] private GameObject player;

    [Tooltip("GameObject for the player")]
    [SerializeField] private GameObject item;

    [SerializeField]
    Inventory inventoryTest = new Inventory();


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isInDetectionRange())
        {

            if (Input.GetKeyDown(KeyCode.F))
            {
                inventoryTest.AddItem(item);
                item.SetActive(false);
            }
        }
    }

    //returns true if player is within detetctionRadius
    public bool isInDetectionRange()
    {
        return Mathf.Sqrt(Mathf.Pow(transform.position.x - player.transform.position.x, 2) +
            Mathf.Pow(transform.position.y - player.transform.position.y, 2)) <= detectionRadius;
    }
}
