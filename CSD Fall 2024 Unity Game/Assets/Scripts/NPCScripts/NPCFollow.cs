using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    public Transform followCharacter;
    public float distanceFromCharacter = 4f;

    public List<Vector2> followCharacterPositions = new List<Vector2>();
    public float allowableSampleDistance = 0.5f;
    public float removeDistance = 3f;

    private Vector2 movementDirection;

    public Sprite[] spritesArray; // 0 is up, 1 is left, 2 is down, 3 is right
    private SpriteRenderer spriteRenderer;

    public float sampleTimeDifference = 0.02f;
    private float sampleTime;

    public float followSpeed = 30f;

    public bool isFollowing = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        sampleTime = Time.time;
        followCharacterPositions.Add(followCharacter.position);
    }

    void Update()
    {
        //get distance from player
        float distance = Vector2.Distance(transform.position, followCharacter.position);

        //figure out how far a step NPC should take (this line prevents jitter)
        float step = Mathf.Min(followSpeed * Time.fixedDeltaTime, distance - distanceFromCharacter);

        // Calculate movement direction (toward player)
        movementDirection = ((Vector2)followCharacter.position - (Vector2)transform.position).normalized;

        //updates sprite based on position of player (so NPC faces player)
        ChangeSprite();

        //If enough time has passed, update the position the npc will move towards
        if (Time.time > sampleTime)
        {
            sampleTime = Time.time + sampleTimeDifference;
            followCharacterPositions.Clear();
            followCharacterPositions.Add(followCharacter.position);
        }

        //check to see if character should be following
        if (isFollowing)
        {
            //if the player is far away enough to warrant moving
            if (distance > distanceFromCharacter)
            {
                // No obstacles detected, move toward the player
                transform.position = Vector2.MoveTowards(transform.position, followCharacter.position, step);
            }
            else
            {
                // Clear old positions when close to the player
                if (followCharacterPositions.Count > 1)
                {
                    followCharacterPositions.RemoveAt(0);
                }
            }

        }
    }

    private void ChangeSprite()
    {
        // Determine which sprite to display based on movement direction
        if (movementDirection.y > 0.1f)
        {
            spriteRenderer.sprite = spritesArray[0]; // Up
        }
        else if (movementDirection.y < -0.1f)
        {
            spriteRenderer.sprite = spritesArray[2]; // Down
        }
        else if (movementDirection.x > 0.1f)
        {
            spriteRenderer.sprite = spritesArray[3]; // Right
        }
        else if (movementDirection.x < -0.1f)
        {
            spriteRenderer.sprite = spritesArray[1]; // Left
        }

        
    }

    public void shouldFollow(bool f)
    {
        isFollowing = f;
    }
}
