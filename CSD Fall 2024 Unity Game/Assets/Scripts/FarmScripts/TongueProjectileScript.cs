using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueProjectileScript : MonoBehaviour
{
    private GameObject spawner; // Reference to the pig (tongue spawner)
    private Rigidbody2D rb;

    private Vector3 direction;
    public float moveSpeed;
    public float range;

    private GameObject lickedItem; // Reference to the currently licked item
    private bool toMouth = false;

    // Item order sequence
    private List<string> itemOrder = new List<string> { "Bucket", "Sand", "Wood", "Hay" };
    private int currentOrderIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("TongueSpawner");
        rb = GetComponent<Rigidbody2D>();

        direction = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, spawner.transform.position);
        if (distance > range)
        {
            ReturnToMouth();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (toMouth)
        {
            if (collision.gameObject.Equals(spawner))
            {
                HandleReturnToPig();
            }
            return;
        }

        if (collision.CompareTag("Item"))
        {
            if (collision.name == itemOrder[currentOrderIndex])
            {
                // Correct item
                lickedItem = collision.gameObject;
                currentOrderIndex++;
                StickToTongue(lickedItem);
                ReturnToMouth();

                if (currentOrderIndex == itemOrder.Count)
                {
                    EndLevel();
                }
            }
            else
            {
                // Incorrect item
                Debug.Log("Incorrect item. Resetting sequence.");
                ResetSequence();
            }
        }
    }

    private void ReturnToMouth()
    {
        toMouth = true;
        direction = (spawner.transform.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }

    private void StickToTongue(GameObject item)
    {
        // Attach the item to the tongue's position
        item.transform.position = transform.position;
        item.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private void HandleReturnToPig()
    {
        if (lickedItem != null)
        {
            Destroy(lickedItem); // Destroy the licked item
            lickedItem = null;
        }
        Destroy(gameObject); // Destroy the tongue projectile
    }

    private void ResetSequence()
    {
        currentOrderIndex = 0;
        ReturnToMouth();
    }

    private void EndLevel()
    {
        Debug.Log("All items eaten in the correct order. Pig dies!");
        Destroy(spawner); // Or trigger a level-end event
    }
}
