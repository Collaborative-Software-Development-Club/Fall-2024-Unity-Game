using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SporeSpawnerScript : MonoBehaviour
{
    //Animator component of the mushroom for the sake of animation stuff
    private Animator animator;

    private Transform playerTransform;
    public GameObject spore;

    //The frequency which spores are shot
    public float spawnRate;
    
    //Tracks how much time is remaining until next spore is spawned
    private float spawnDelay;

    //Tracks whether the mushroom is currently on cooldown or not
    bool onCooldown;

    //The range in which the mushroom will start firing
    public float range;

    private Ray sightRay;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        spawnDelay = spawnRate;
        sightRay.origin = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector3.Distance(transform.position, playerTransform.position);

        /*
         * Fires a spore when the player enters into the mushroom's range, it then goes on cooldown for as long as the
         * spawnRate dictates. After the time passes, the next time the player is in range, the mushroom will fire again.
         */
        if (distanceFromPlayer < range && !onCooldown)
        {
            sightRay.direction = (playerTransform.position - transform.position);
            sightRay.direction.Normalize();
            RaycastHit2D hit = Physics2D.Raycast(sightRay.origin,sightRay.direction);
            if (hit.collider.CompareTag("Player"))
            {
                spawnSpore();
                animator.Play("Shoot");
                onCooldown = true;
            }
        }
        else if (onCooldown)
        {
            if (spawnDelay > 0)
            {
                spawnDelay -= Time.deltaTime;
            }
            else
            {
                onCooldown = false;
                spawnDelay = spawnRate;
            }
        }

        
    }

    void spawnSpore()
    { 
        Instantiate(spore, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
    }

}
