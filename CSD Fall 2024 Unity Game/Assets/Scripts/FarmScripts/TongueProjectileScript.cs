using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TongueProjectileScript : MonoBehaviour
{
    private GameObject spawner;
    private GameObject player;
    private GameObject[] items;
    private Rigidbody2D rb;

    private Vector3 direction;
    public float moveSpeed;
    public float range;
    private bool playerLicked = false;
    private bool itemLicked = false;
    private int itemNum;
    private bool toMouth = false;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("TongueSpawner");
        items = GameObject.FindGameObjectsWithTag("Item");
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();

        direction = (player.transform.position - transform.position).normalized;
        rb.velocity = new Vector3(direction.x, direction.y) * moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, spawner.transform.position);
        if (distance > range)
        {
            returnToMouth(rb);
        }
        if (playerLicked)
        {
            stickToTongue(player);
        }
        if (itemLicked)
        {
            stickToTongue(items[itemNum]);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.Equals(spawner))
        { 
            returnToMouth(rb);
        }

        if (collision.gameObject.Equals(player))
        {
            playerLicked = true;
        }

        for (int i = 0; i < items.Length; i++)
        {
            if (collision.gameObject.Equals(items[i]))
            {
                itemNum = i;
                itemLicked = true;
            }
        }
       
        if (collision.gameObject.Equals(spawner) && toMouth == true)
        {
            playerLicked = false;
            Destroy(gameObject);
        }
    }

    public void returnToMouth(Rigidbody2D rb)
    {
        toMouth = true;
        direction = (spawner.transform.position - transform.position).normalized;
        rb.velocity = new Vector3(direction.x, direction.y) * moveSpeed;
    }

    public void stickToTongue(GameObject gameObject)
    {
        gameObject.transform.position = transform.position;
    }

}

    
