using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetFogWhenBugged : MonoBehaviour
{
    private Vector2 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.position = originalPosition;
    }
}
