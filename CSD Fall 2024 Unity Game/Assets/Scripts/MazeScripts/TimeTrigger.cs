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
        /*
         * Decrements the time left by the amount of time that has passed and once it reaches zero 
         * it runs the TriggerEvent from the MazeTrigger abstract class
         */
        if (timeLength > 0)
        {
            timeLength -= Time.deltaTime;
        }
        if(timeLength < 0)
        {
            TriggerEvent();

        }
    }
}
