using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TongueProjectileScript : MonoBehaviour
{
    private GameObject spawner;
    private GameObject player;
    private GameObject item;
    private Rigidbody2D rb;
    private Rigidbody2D itemRb;
    private Rigidbody2D playerRb;

    private Vector3 direction;
    public float moveSpeed;
    public float range;
    private float timer = 0;
    private bool toMouth = false;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("TongueSpawner");
        //item = GameObject.FindGameObjectWithTag("Item");
        player = GameObject.FindGameObjectWithTag("Player");
        //itemRb = item.GetComponent<Rigidbody2D>();
        playerRb = player.GetComponent<Rigidbody2D>();
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.Equals(player))
        {
            returnToMouth(playerRb);
            returnToMouth(rb);
        }
        /* if (collision.gameObject.Equals(item))
         {
             returnToMouth(itemRb);
             returnToMouth(rb);
         }
       */
        if (collision.gameObject.Equals(spawner) && toMouth == true)
        {
            Destroy(gameObject);
        }
    }

    public void returnToMouth(Rigidbody2D rb)
    {
        toMouth = true;
        direction = (spawner.transform.position - transform.position).normalized;
        rb.velocity = new Vector3(direction.x, direction.y) * moveSpeed;
        Debug.Log("ToMouth");
    }
}

    
