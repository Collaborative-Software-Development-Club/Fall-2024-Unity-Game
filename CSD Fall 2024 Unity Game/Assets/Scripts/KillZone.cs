using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public KillPlayer killPlayer;

    // Start is called before the first frame update
    void Start()
    {
        killPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<KillPlayer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            killPlayer.killPlayer();
        }
    }
}
