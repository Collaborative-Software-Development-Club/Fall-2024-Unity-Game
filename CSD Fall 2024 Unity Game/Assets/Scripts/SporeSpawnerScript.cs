using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporeSpawnerScript : MonoBehaviour
{
    public Transform player;
    public GameObject spore;
    public float spawnRate;
    private float spawnDelay;
    public float range;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spawnDelay = Random.Range(spawnDelay - 1, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < range)
        {
            if (spawnDelay < spawnRate)
            {
                spawnDelay += Time.deltaTime;
            }
            else
            {
                spawnSpore();
                spawnDelay = 0;
            }
        }
    }

    void spawnSpore()
    { 
        Instantiate(spore, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
    }
}
