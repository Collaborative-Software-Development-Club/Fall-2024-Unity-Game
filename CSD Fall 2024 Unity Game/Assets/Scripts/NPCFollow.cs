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

    private Vector2 previousPosition;
    private Vector2 movementDirection;

    public Sprite[] spritesArray; // 0 is up, 1 is left, 2 is down, 3 is right
    private SpriteRenderer spriteRenderer;

    public float sampleTimeDifference = 0.02f;
    private float sampleTime;

    private Vector2 velocity = Vector2.zero;
    public float followSpeed = 30f;

    public float obstacleAvoidanceDistance = 1f;
    public float avoidanceStrength = 0.5f;
    public LayerMask obstacleLayer; // Set the layer for obstacles

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

        // Calculate movement direction (toward player)
        movementDirection = ((Vector2)followCharacter.position - (Vector2)transform.position).normalized;

        // Raycasting forward (toward the player)
        RaycastHit2D hitCenter = Physics2D.Raycast(transform.position, movementDirection, obstacleAvoidanceDistance, obstacleLayer);

        // Optional: cast rays to the sides (forward-left, forward-right)
        Vector2 leftDir = Quaternion.Euler(0, 0, 30) * movementDirection;  // Rotate direction by 30 degrees
        Vector2 rightDir = Quaternion.Euler(0, 0, -30) * movementDirection; // Rotate direction by -30 degrees
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, leftDir, obstacleAvoidanceDistance, obstacleLayer);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, rightDir, obstacleAvoidanceDistance, obstacleLayer);

        // Update the previous position for the next frame
        previousPosition = transform.position;

        changeSprite();

        if (Time.time > sampleTime)
        {
            sampleTime = Time.time + sampleTimeDifference;
            followCharacterPositions.Clear();
            followCharacterPositions.Add(followCharacter.position);
        }

        // Check if an obstacle is hit (center, left, or right rays)
        if (hitCenter.collider != null || hitLeft.collider != null || hitRight.collider != null)
        {
            // Handle obstacle avoidance
            Vector2 avoidanceDirection = movementDirection;  // Default to moving toward the player

            if (hitCenter.collider != null)
            {
                // Move perpendicular to the hit normal (to the side of the obstacle)
                avoidanceDirection = Vector2.Perpendicular(hitCenter.normal).normalized;
            }
            else if (hitLeft.collider != null)
            {
                // Avoid on the right side if left ray hits
                avoidanceDirection = Quaternion.Euler(0, 0, -90) * movementDirection;
            }
            else if (hitRight.collider != null)
            {
                // Avoid on the left side if right ray hits
                avoidanceDirection = Quaternion.Euler(0, 0, 90) * movementDirection;
            }

            // Blend between the direction to the player and the avoidance direction
            Vector2 newDirection = Vector2.Lerp(movementDirection, avoidanceDirection, avoidanceStrength).normalized;

            // Move in the smoothed direction
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + newDirection, followSpeed * Time.deltaTime);
        }
        else if (distance > distanceFromCharacter)
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

    private void changeSprite()
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
}
