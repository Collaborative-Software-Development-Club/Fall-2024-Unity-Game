using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioSpawner : MonoBehaviour
{
    private int hitCount;
    public int maxSoundSpawned;
    public GameObject prefabSound;
    private GameObject door;
    private int temp;
    // Start is called before the first frame update
    void Start()
    {
        door = GameObject.Find("Door");
        hitCount=door.GetComponent<doorHitCount>().hitCount;
        temp=hitCount;
    }

    // Update is called once per frame
    void Update()
    {
        hitCount = door.GetComponent<doorHitCount>().getHitCount();
        if (hitCount > temp&&hitCount<=maxSoundSpawned)
        {
            Instantiate(prefabSound);
            temp = hitCount;
        }
        if (door == null)
        {
            Debug.Log("door没有正确赋值");
        }
    }
}
