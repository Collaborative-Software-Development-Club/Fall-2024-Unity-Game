using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO.IsolatedStorage;
using UnityEngine;

public class NPCFollow : MonoBehaviour
{

    public Transform followCharacter;
    public float distanceFromCharacter = 4;
    public List<Vector2> followCharacterPositions = new List<Vector2>();
    public float allowableSampleDistance = 0.5f;
    public float removeDistance = 3;

    Vector2 previousPosition;
    Vector2 movementDirection;

    public Sprite[] spritesArray; //0 is up, 1 is left, 2 is down, 3 is right
    private SpriteRenderer spriteRenderer;

    public float sampleTimeDifference = 0.02f;
    float sampleTime;

    private Vector2 velocity = Vector2.zero;

    public float followSpeed = 30;

    void Start()
    {
        previousPosition = transform.position;

        spriteRenderer = GetComponent<SpriteRenderer>();
        sampleTime = Time.time;
        followCharacterPositions.Add(followCharacter.position);
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, followCharacter.position);
        float step = Mathf.Min(followSpeed * Time.fixedDeltaTime, distance - distanceFromCharacter);

        // Calculate movement direction
        movementDirection = (Vector2)transform.position - previousPosition;

        // Update the previous position for the next frame
        previousPosition = transform.position;

        changeSprite();

        if (Time.time > sampleTime)
        {
            sampleTime = Time.time + sampleTimeDifference;

            followCharacterPositions.Clear();
            followCharacterPositions.Add(followCharacter.position);
        }

        if (distance > distanceFromCharacter)
        {
            transform.position = Vector2.MoveTowards(transform.position, followCharacter.position, step);

        }
        else
        {
            if (followCharacterPositions.Count > 1)
            {
                followCharacterPositions.RemoveAt(0);
            }
        }
    }

    private void changeSprite()
    {

        //face upward
        if (movementDirection.y > 0.1f)
        {
            spriteRenderer.sprite = spritesArray[0];
        }
        //face downward
        else if (movementDirection.y < -0.1f)
        {
            spriteRenderer.sprite = spritesArray[2];
        }
        //face right
        else if (movementDirection.x > 0.1f)
        {
            spriteRenderer.sprite = spritesArray[3];
        }
        //face left
        else if (movementDirection.x < -0.1f)
        {
            spriteRenderer.sprite = spritesArray[1];
        }
    }


}
