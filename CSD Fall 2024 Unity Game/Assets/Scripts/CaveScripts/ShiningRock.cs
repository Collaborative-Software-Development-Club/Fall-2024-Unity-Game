using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class ShiningRock : MonoBehaviour, InteractableInterface
{

    [SerializeField] private List<Sprite> dimRockSprites = new List<Sprite>();
    [SerializeField] private List<Sprite> glowRockSprites = new List<Sprite>();
    [SerializeField] private SpriteRenderer rockRenderer;
    [SerializeField] private GameObject light;

    [Tooltip("Text element telling the user how to interact. UI Element Name: InteractPrompt")]
    [SerializeField] private GameObject popUpPrompt;

    [Tooltip("GameObject for the player")]
    [SerializeField] private GameObject player;

    public Transform transform;
    public Collider2D collider;


    public int detectionRadius = 4;

    public bool hasLight = false;

    //0 is facing front, 1 is facing left, 2 is up, 3 is right
    public int orientation;


    //returns true if player is within detetctionRadius
    public bool isInDetectionRange()
    {
        return Mathf.Sqrt(Mathf.Pow(base.transform.position.x - player.transform.position.x, 2) +
            Mathf.Pow(base.transform.position.y - player.transform.position.y, 2)) <= detectionRadius;
    }

    public void Interact()
    {
        if (isInDetectionRange())
        {
            popUpPrompt.SetActive(true);
            ChangeSprite(true);
        }
        else
        {
            popUpPrompt.SetActive(false);
            ChangeSprite(false);
        }
    }

    public void ChangeSprite(bool inRange)
    {
        if (Input.GetKeyDown(KeyCode.F) && inRange)
        {
            Debug.Log("Change attempted");
            orientation = (orientation + 1) % dimRockSprites.Count;
        }

        if (hasLight)
        {
            rockRenderer.sprite = glowRockSprites[orientation];
        }
        else
        {
            rockRenderer.sprite = dimRockSprites[orientation];
        }
    }

    public void UpdateIsLit()
    {
        if (hasLight)
        {
            light.SetActive(true);
        }
        else
        {
            light.SetActive(false);
        }

        Debug.Log("Still checking");
    }

    void Start()
    {
        popUpPrompt.SetActive(false);
        orientation = 0;
        rockRenderer.sprite = dimRockSprites[orientation % dimRockSprites.Count];
    }


    void Update()
    {
        Interact();
        UpdateIsLit();
    }
}
