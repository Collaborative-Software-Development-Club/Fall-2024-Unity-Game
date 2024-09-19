using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public KillPlayer KillPlayer;

    // Start is called before the first frame update
    void Start()
    {
        KillPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<KillPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            KillPlayer.killPlayer();
        }
    }
}
