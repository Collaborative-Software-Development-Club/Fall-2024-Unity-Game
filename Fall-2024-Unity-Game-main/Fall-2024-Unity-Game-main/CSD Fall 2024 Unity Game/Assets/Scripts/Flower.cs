using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Flower : MonoBehaviour, InteractableInterface
{
    
    [SerializeField]
    private TextMeshPro interactionTip;
    

    private FlowerCounter flowerCounter;
    private bool nearPlayer = false;

    
    //Initializes flowerCounter variable to a flowerCounter in scene then makes the interactionTip invisible
    void Start()
    {
        flowerCounter = FindObjectOfType<FlowerCounter>();
        interactionTip.enabled = false;
    }


    /*
     *Checks every frame to receive input. 
     *If the F key is pressed after a collider entered it's space and before the collider left
     *then the interact function will be called
     */
    void Update()
    {
        
        if (nearPlayer && Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }
        
    }

    //Calls the PickUp() method, added for the sake of having a generalized Interact() method among all Interactable objects
    public void Interact()
    {
            PickUp();
    }

    //Increments the flowerCounter, prints out a message saying so, then deletes the flower
    private void PickUp()
    {
        flowerCounter.incrementFlower();
        Debug.Log("Flower picked up");
        Destroy(gameObject);
    }

    //When the flower's collider collides with another collider it marks that it's near a player and the interactionTip appears
    private void OnTriggerEnter2D(Collider2D collision)
    {
        nearPlayer = true;
        interactionTip.enabled = true;
    }

    /*
     * When the flower's collider stops colliding with another collider it 
     *marks that it's not near a player and the interactionTip disappears
     */
    private void OnTriggerExit2D(Collider2D collision)
    {
        nearPlayer = false;
        interactionTip.enabled = false;
    }
}
