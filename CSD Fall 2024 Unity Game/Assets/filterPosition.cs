using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class filterPosition : MonoBehaviour
{
    private GameObject fox;
    // Start is called before the first frame update
    void Start()
    {
        fox = GameObject.Find("Fox");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = fox.transform.position;
    }
}
