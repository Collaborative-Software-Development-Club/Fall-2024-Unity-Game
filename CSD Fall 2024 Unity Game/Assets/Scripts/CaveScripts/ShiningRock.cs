using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiningRock : MonoBehaviour, InteractableInterface
{

    [SerializeField] private List<Sprite> rockSprites = new List<Sprite>();
    [SerializeField] private SpriteRenderer rockRenderer = new SpriteRenderer();

    [Tooltip("Text element telling the user how to interact. UI Element Name: InteractPrompt")]
    [SerializeField] private GameObject popUpPrompt;

    [Tooltip("GameObject for the player")]
    [SerializeField] private GameObject player;

    public int detectionRadius = 4;


    //returns true if player is within detetctionRadius
    public bool isInDetectionRange()
    {
        return Mathf.Sqrt(Mathf.Pow(transform.position.x - player.transform.position.x, 2) +
            Mathf.Pow(transform.position.y - player.transform.position.y, 2)) <= detectionRadius;
    }

    public void Interact()
    {
        if (isInDetectionRange())
        {
            popUpPrompt.SetActive(true);
            ChangeSprite();
        }
        else
        {
            popUpPrompt.SetActive(false);
        }
    }

    public void ChangeSprite()
    {

    }


    void Start()
    {
        popUpPrompt.SetActive(false);
    }


    void Update()
    {
        Interact();
    }
}
