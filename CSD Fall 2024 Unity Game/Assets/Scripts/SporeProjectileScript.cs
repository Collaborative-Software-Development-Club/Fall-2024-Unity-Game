using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class SporeProjectileScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private KillPlayer killPlayer;

    [SerializeField]
    [Tooltip("Movement Speed of the Spores")]
    private float moveSpeed;

    [SerializeField]
    [Tooltip("Max time until spore despawns")]
    private float despawnTime;

    private float despawnTimer = 0;

    //The time interval in which the spore will update it's homing on the player, this is for performance
    private const float redirectionInterval = 0.1f;
    
    private float redirectionTimer;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        killPlayer = player.GetComponent<KillPlayer>();
        redirectionTimer = redirectionInterval;
        
    }

    // Update is called once per frame
    void Update()
    {
        redirectSpore();
        if (despawnTimer < despawnTime)
        {
            despawnTimer += Time.deltaTime;
        }
        else 
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Spore"))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                killPlayer.killPlayer();

            }
            Destroy(gameObject);
        }
    }

    private void redirectSpore()
    {
        
        if (redirectionTimer < redirectionInterval)
        {
            redirectionTimer += Time.deltaTime;
        }
        else
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;
            redirectionTimer = 0;

        }
    }
}
