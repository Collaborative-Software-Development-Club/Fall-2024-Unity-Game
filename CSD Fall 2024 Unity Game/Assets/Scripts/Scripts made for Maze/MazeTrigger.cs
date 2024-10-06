using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MazeTrigger : MonoBehaviour
{
    [Tooltip("The trigger only be triggered once")]
    [SerializeField]
    protected bool oneShot;

    [Tooltip("[OPTIONAL] Wall to be moved if used requires valid wall positions")]
    [SerializeField]
    protected MovingWall wall;
    [Tooltip("The destination position of the wall")]
    [SerializeField]
    protected float wPosX, wPosY;

    [Tooltip("[OPTIONAL] Player to be teleported if used requires valid player displacements")]
    [SerializeField]
    protected fox player;
    [Tooltip("The amount the player is shifted from their current spot")]
    [SerializeField]
    protected float displacementX, displacementY;

    [Tooltip("[OPTIONAL] nextTrigger will be toggled between enabled and disabled on event trigger")]
    [SerializeField]
    protected GameObject nextTrigger;

    [Tooltip("[OPTIONAL] The toggleableObject will be toggled between enabled and disabled on event trigger")]
    [SerializeField]
    protected GameObject toggleableObject;



    bool hasWall, hasPlayer, hasNextTrigger, hasToggleObject;
    // Start is called before the first frame update
    private void Start()
    {
        hasWall = wall != null;
        hasPlayer = player != null;
        hasNextTrigger = nextTrigger != null;
        hasToggleObject = toggleableObject != null;
    }
    protected void TriggerEvent()
    {
        if(hasWall)
        {
            wall.Move(wPosX, wPosY);
        }
        if(hasPlayer)
        {
            player.transform.localPosition = new Vector2(player.transform.localPosition.x + displacementX, player.transform.localPosition.y + displacementY);
        }
        if(hasNextTrigger)
        {
            nextTrigger.SetActive(!nextTrigger.activeSelf);
        }
        if (hasToggleObject)
        {
            toggleableObject.SetActive(!toggleableObject.activeSelf);
        }
        if (oneShot)
        {
            gameObject.SetActive(false);
        }
    }

    
}
