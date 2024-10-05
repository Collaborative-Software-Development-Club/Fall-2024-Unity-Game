using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO.IsolatedStorage;
using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    public Transform followCharacter;
    public float distanceFromCharacter;
    public List<Vector2> followCharacterPositions = new List<Vector2>();
    public float allowableSampleDistance;
    public float removeDistance;

    public float sampleTimeDifference;
    float sampleTime;

    public float followSpeed;
    public float walkSpeed;
    public float jogSpeed;
    public float runSpeed;
    
    public float fastDistance;
    public float jogDistance;

    void Start()
    {
        sampleTime = Time.time;
        followCharacterPositions.Add(followCharacter.position);
        followSpeed = runSpeed;
    }

    void Update()
    {
        if (Time.time > sampleTime)
        {
            sampleTime = Time.time + sampleTimeDifference;
            
            //if the player has moved enough from the last position
            if (Vector2.Distance(transform.position, followCharacter.position) > distanceFromCharacter &&
                Vector2.Distance(followCharacter.position, followCharacterPositions[followCharacterPositions.Count- 1])
                > allowableSampleDistance) 
            {
                followCharacterPositions.Add(followCharacter.position);
            }
        }

        if (Vector2.Distance(transform.position, followCharacter.position) > fastDistance)
        {
            followSpeed = runSpeed;
        }
        else if (Vector2.Distance(transform.position, followCharacter.position) > jogDistance)
        {
            followSpeed = jogSpeed;
        }
        else
        {
            followSpeed = walkSpeed;
        }
        if (Vector2.Distance(transform.position, followCharacter.position) > distanceFromCharacter)
        {
            transform.position = Vector2.MoveTowards(transform.position, followCharacterPositions[0], Time.deltaTime * followSpeed);
            if (Vector2.Distance(transform.position, followCharacterPositions[0]) < removeDistance)
            {
                if (followCharacterPositions.Count > 1)
                {
                    followCharacterPositions.RemoveAt(0);
                }
            }
        }

    }


}
