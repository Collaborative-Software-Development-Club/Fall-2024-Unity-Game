using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTrigger : MazeTrigger
{
    [SerializeField]
    float timeLength;

    // Update is called once per frame
    void Update()
    {
        if(timeLength > 0)
        {
            timeLength -= Time.deltaTime;
        }
        if(timeLength < 0)
        {
            TriggerEvent();
        }
    }
}
