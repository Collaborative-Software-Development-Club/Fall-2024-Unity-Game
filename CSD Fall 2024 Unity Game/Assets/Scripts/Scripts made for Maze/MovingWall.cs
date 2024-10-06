using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    [Tooltip("The speed at which the wall will move to it's destination position")]
    [SerializeField]
    float wallSpeed;

    //targetX and targetY represent the destination coordinate
    float targetX, targetY;

    /*
     * isObjectMoving tracks if the player is moving or not
     * 
     * isIncreasingX and isIncreasingY checks to see if the destination position is less than or greater than current position
     * this is then used to make sure that the wall doesn't overshoot it's location
     */
    bool isObjectMoving, isIncreasingX, isIncreasingY;

    //Stores the rigidBody component for the purpose of changing it's velocity later
    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        //Initializing needed variables
        isObjectMoving = false;
        body = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Ensures the wall stops where it needs to
        if (isObjectMoving)
        {
            boundWallPosition();

            //Stops the wall from trying to move any more once it reaches it's destination x or y
            if (targetX - gameObject.transform.localPosition.x == 0)
            {
                body.velocity = new Vector2(0, body.velocity.y);
            }

            if (targetY - gameObject.transform.localPosition.y == 0) 
            {
                
                body.velocity = new Vector2(body.velocity.x,0);
            }
            
            //Once it isn't moving at all, declare the wall not moving
            isObjectMoving = body.velocity.magnitude != 0;

            
        }
    }


    public void Move(float x, float y)
    {
        //Set goal location
        targetX = x;
        targetY = y;

        //Initialize then set the velocity of X and Y
        int velocityDirectionX = 0;
        int velocityDirectionY = 0;

        //Before setting velocity make sure that it actually needs to move in that direction
        if (!Mathf.Approximately(targetX, gameObject.transform.localPosition.x))
        {
            velocityDirectionX = MathF.Sign(targetX - gameObject.transform.localPosition.x);
        }

        if (!Mathf.Approximately(targetY, gameObject.transform.localPosition.x))
        {

            velocityDirectionY = MathF.Sign(targetY - gameObject.transform.localPosition.y);
        }

        //Determine if the new position is greater or less than it's current position for the sake of clamping it later
        isIncreasingX = targetX > gameObject.transform.localPosition.x;
        isIncreasingY = targetY > gameObject.transform.localPosition.y;

        //Change the body's velocity then declare the object moving
        body.velocity = new Vector2(velocityDirectionX * wallSpeed, velocityDirectionY * wallSpeed);
        isObjectMoving = true;
    }

    private void boundWallPosition()
    {
        float boundedX;
        float boundedY;

        /*
         *Clamp the position of the wall between the bounds of it's current position and the target position 
         *to ensure it doesn't over shoot
         */
        if (isIncreasingX)
        {
            boundedX = Mathf.Clamp(gameObject.transform.localPosition.x, gameObject.transform.localPosition.x, targetX);

        }
        else
        {
            boundedX = Mathf.Clamp(gameObject.transform.localPosition.x, targetX, gameObject.transform.localPosition.x);
        }


        if (isIncreasingY)
        {
            boundedY = Mathf.Clamp(gameObject.transform.localPosition.y, gameObject.transform.localPosition.y, targetY);

        }
        else
        {
            boundedY = Mathf.Clamp(gameObject.transform.localPosition.y, targetY, gameObject.transform.localPosition.y);
        }

        //Apply the clamped position to the wall
        gameObject.transform.localPosition = new Vector3(boundedX, boundedY);
    }




}
