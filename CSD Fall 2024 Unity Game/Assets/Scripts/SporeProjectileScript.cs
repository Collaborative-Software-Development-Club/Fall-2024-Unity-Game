using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporeProjectileScript : MonoBehaviour
{
    public KillPlayer killPlayer;
    public GameObject mushroom;
    public float moveSpeed;
    public float deadZone;

    // Start is called before the first frame update
    void Start()
    {

        killPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<KillPlayer>();
        mushroom = GameObject.FindGameObjectWithTag("MushroomEnemy");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.down * moveSpeed) * Time.deltaTime;

        if (transform.position.y - mushroom.transform.position.y <= deadZone)
        {
            Debug.Log("Spore Deleted");
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            killPlayer.killPlayer();
        }
    }
}
