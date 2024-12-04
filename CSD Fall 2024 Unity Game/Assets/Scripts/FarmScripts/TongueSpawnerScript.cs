using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueSpawnerScript : MonoBehaviour
{
    private Transform player;
    public GameObject tonguePrefab;
    public float spawnRate;
    private float timer = 0;
    public float spawnRange;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < spawnRange)
        {
            if (timer < spawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                SpawnTongue();
                timer = 0;
            }
        }
    }

    void SpawnTongue()
    {
        GameObject tongue = Instantiate(tonguePrefab, transform.position, Quaternion.identity);

        // Set a timeout to destroy tongue clones if they persist
        Destroy(tongue, 5f);
    }
}
