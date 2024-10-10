using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionTrigger : MazeTrigger
{
    

    //Runs the TriggerEvent from the MazeTrigger abstract class
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerEvent();
    }

}
