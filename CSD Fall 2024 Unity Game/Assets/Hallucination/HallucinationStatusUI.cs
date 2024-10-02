using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HallucinationStatusUI : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Slider>().value = GameObject.Find("Fox").GetComponent<Hallucination>().sporeCount;

    }
}
