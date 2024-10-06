using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporeProjectileScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private KillPlayer killPlayer;

    public float moveSpeed;
    public float minDrag;
    public float maxDrag;

    public float despawnTime;
    private float timer = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        killPlayer = player.GetComponent<KillPlayer>();

        Vector3 direction = (player.transform.position - transform.position).normalized;
        rb.velocity = new Vector2 (direction.x, direction.y) * moveSpeed;
        
        rb.drag = Random.Range(minDrag, maxDrag);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 moveDirNormailized = (player.transform.position - transform.position).normalized;
        //transform.position += moveDirNormailized * moveSpeed * Time.deltaTime;
        //transform.position = transform.position + (Vector3.MoveTowards(transform.position, player.transform.position, 10) * moveSpeed * Time.deltaTime);
        //transform.position = transform.position + (Vector2. * moveSpeed * Time.deltaTime);
        //transform.position += transform.position * moveSpeed * Time.deltaTime;

        if (timer < despawnTime)
        {
            timer += Time.deltaTime;
        }
        else 
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            killPlayer.killPlayer();
            Destroy(gameObject);
        }
    }
}
