using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningControl : MonoBehaviour
{
    public int warningThreshold;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Fox").GetComponent<Hallucination>().sporeCount == warningThreshold)
        {
            gameObject.SetActive(true);
        }
        Debug.Log(GameObject.Find("Fox").GetComponent<Hallucination>().sporeCount == warningThreshold);
    }
}
