using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hallucination : MonoBehaviour
{
    public int sporeCount = 0;
    public int sporeStep = 5; // �ﵽŤ��Ч���������������
    public float maxDistortion = 20f; // ���Ť��ֵ

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
