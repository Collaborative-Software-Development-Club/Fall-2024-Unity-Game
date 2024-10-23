using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueSpawnerScript : MonoBehaviour
{
    public Transform player;
    public GameObject tongue;
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
                spawnTongue();
                timer = 0;
            }
        }
    }

    void spawnTongue()
    {
        Instantiate(tongue, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
    }
}
