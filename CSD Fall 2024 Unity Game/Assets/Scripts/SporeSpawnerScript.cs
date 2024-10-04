using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporeSpawnerScript : MonoBehaviour
{
    public GameObject spore;
    public float spawnRate;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnSpore();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnSpore();
            timer = 0;
        }
    }

    void spawnSpore()
    { 
        Instantiate(spore, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        Debug.Log("Spore spawned");
    }
}
