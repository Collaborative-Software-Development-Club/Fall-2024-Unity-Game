using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hamster : MonoBehaviour
{
    public Sprite[] spritesArray; // 0 is up, 1 is left, 2 is down, 3 is right
    // These values below control the area the hamster can move to
    public float hamsterSpeed;
    public float upperBound;
    public float lowerBound;
    public float leftBound;
    public float rightBound;
    public int pauseTime;
    public bool isAside;

    private SpriteRenderer spriteRenderer;
    private Vector2 walkingTarget;
    private Rigidbody2D rbhamster;
    private Vector2 hamsterPos;
    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rbhamster = GetComponent<Rigidbody2D>();
        isPaused = false;
        isAside = false;

        // Initialize walking target to a random position within bounds
        SetNewWalkingTarget();

    }

    // Update is called once per frame
    void Update()
    {
        hamsterPos = (Vector2)transform.position;
        rbhamster = GetComponent<Rigidbody2D>();
        ChangeSprite();
        walkToTarget();
    }

    void walkToTarget()
    {
        // If paused, do nothing
        if (isPaused) return;

        // Check distance to target, move towards it if it's far enough
        if (Vector2.Distance(hamsterPos, walkingTarget) > 0.1f)
        {
            // Calculate direction and apply velocity to move the hamster
            Vector2 direction = (walkingTarget - hamsterPos).normalized;
            rbhamster.velocity = direction * hamsterSpeed; // Move the hamster smoothly using velocity

        }
        else
        {
            // If the hamster is close enough to the target, start the pause coroutine
            StartCoroutine(pausehamster());
        }
    }

    private IEnumerator pausehamster()
    {
        isPaused = true;
        rbhamster.velocity = Vector2.zero; // Stop the hamster while paused
        yield return new WaitForSeconds(pauseTime); // Wait for pauseTime

        // After pause, set a new random walking target within bounds
        SetNewWalkingTarget();
        isPaused = false; // Resume walking
    }

    private void SetNewWalkingTarget()
    {
        // Generate a new random target within bounds
        walkingTarget = new Vector2(
            Random.Range(leftBound, rightBound),
            Random.Range(lowerBound, upperBound)
        );
    }

    private void ChangeSprite()
    {
        // Determine which sprite to display based on movement direction
        if (rbhamster.velocity.x > 0.1f)
        {
            spriteRenderer.sprite = spritesArray[3]; // Right
        }
        else if (rbhamster.velocity.x < -0.1f)
        {
            spriteRenderer.sprite = spritesArray[1]; // Left
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isAside = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isAside = false;
    }
}
