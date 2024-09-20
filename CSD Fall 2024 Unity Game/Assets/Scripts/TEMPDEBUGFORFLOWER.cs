using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUGPROOFREPLACESOON : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Syncs the fake player with the mouse's position
    void Update()
    {
        Vector3 mousePosition = Camera.main.WorldToScreenPoint(Input.mousePosition);
        mousePosition.z = 0;
        gameObject.transform.position = mousePosition;
    }



}
