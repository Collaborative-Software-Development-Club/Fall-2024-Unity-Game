using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hallucination : MonoBehaviour
{
    public int sporeCount = 0;
    public int sporeStep = 5; // 达到扭曲效果所需的孢子数量
    public float maxDistortion = 20f; // 最大扭曲值

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        updateHallucination();
    }

    void updateHallucination()
    {
        if (sporeCount >= sporeStep)
        {
           
        }
        else
        {
           
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
