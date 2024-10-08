using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HallucinationStatusUI : MonoBehaviour
{
    private Hallucination hallucinationScript;

    // Start is called before the first frame update
    void Start()
    {
        hallucinationScript = GameObject.Find("Fox").GetComponent<Hallucination>();

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Slider>().value = hallucinationScript.sporeCount;

    }
}
