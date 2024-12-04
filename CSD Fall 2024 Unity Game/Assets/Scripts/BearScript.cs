using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class BearScript : MonoBehaviour
{
    BearUIScript scriptUI;
    private GameObject player;
    private Rigidbody2D rb;
    private GameObject[] respawnPos;
    private int spawnIndex = 0;

    private Vector3 direction;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        scriptUI = GameObject.Find("Logic Manager").GetComponent<BearUIScript>();
        rb = GetComponent<Rigidbody2D>();
        respawnPos = GameObject.FindGameObjectsWithTag("BearSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        // In light script, call chargePlayer() once when collides with bear. Shouldn't call every frame.
        if (Input.GetKeyDown(KeyCode.E))
        {
            chargePlayer();
        }
    }

    public void chargePlayer()
    {
        direction = (player.transform.position - transform.position).normalized;
        rb.velocity = new Vector3(direction.x, direction.y) * moveSpeed;
        scriptUI.lockScene();
        scriptUI.numLocks = spawnIndex + 1;
    }

    public void respawn()
    {
        transform.position = respawnPos[spawnIndex].transform.position;
        spawnIndex++;
        rb.velocity = new Vector2(0, 0);
        Debug.Log("respawn");
    }

}
