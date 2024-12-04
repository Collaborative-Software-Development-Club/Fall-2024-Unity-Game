using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioSpawner : MonoBehaviour
{
    private int hitCount;
    public int maxSoundSpawned;
    public overallTriggerControl overallTriggerControl;
    public GameObject prefabSound;
    private GameObject parentPrefab;
    private int temp;
    private bool turnOffSounds=false;
    // Start is called before the first frame update
    void Start()
    {

        parentPrefab = new GameObject("ParentPrefabSound");
        turnOffSounds=overallTriggerControl.allTriggered;
    }

    // Update is called once per frame
    void Update()
    {
        turnOffSounds = overallTriggerControl.allTriggered;
        if (hitCount > temp&&hitCount<=maxSoundSpawned)
        {
            GameObject prefab = Instantiate(prefabSound);
            prefab.transform.parent=parentPrefab.transform;
            temp = hitCount;
        }

        if (turnOffSounds)
        {
            destroyAllPrefabs();
        }
    }
    public void destroyAllPrefabs()
    {
        Destroy(parentPrefab);
    }
}
