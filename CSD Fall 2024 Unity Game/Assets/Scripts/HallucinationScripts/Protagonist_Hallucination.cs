using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hallucination : MonoBehaviour
{
    public int sporeCount = 0;
    public int sporeStep = 5; // The number of spores to enhance the distortion effect
    public int maxSpore = 20; // Max number of spores, passing means die
    public KillPlayer killplayer;

    // Start is called before the first frame update
    void Start()
    {
        killplayer = GetComponent<KillPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        updateHallucination();
    }

    void updateHallucination()
    {
        if (sporeCount >= maxSpore)
        {
            killplayer.killPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spore"))
        {
            sporeCount++;
        }
    }
}
