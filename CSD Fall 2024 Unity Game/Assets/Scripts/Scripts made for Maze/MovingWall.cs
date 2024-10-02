using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    [SerializeField]
    float wallSpeed;


    float stoppingTolerance;
    float targetX, targetY;
    bool isObjectMoving;
    Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        stoppingTolerance = 0.5f;
        targetX = gameObject.transform.localPosition.x;
        targetY = gameObject.transform.localPosition.y;
        isObjectMoving = false;
        body = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isObjectMoving)
        {
            
            if (Mathf.Abs(targetX - gameObject.transform.localPosition.x) < stoppingTolerance)
            {
                body.velocity = new Vector2(0, body.velocity.y);
            }

            if (Mathf.Abs(targetY - gameObject.transform.localPosition.y) < stoppingTolerance) 
            {
                
                body.velocity = new Vector2(body.velocity.x,0);
            }
            
            isObjectMoving = body.velocity.magnitude != 0;


        }
    }


    public void Move(float x, float y)
    {
        targetX = x;
        targetY = y;
        int velocityDirectionX = 0;
        int velocityDirectionY = 0;
        if (!Mathf.Approximately(targetX, gameObject.transform.localPosition.x))
        {
            velocityDirectionX = MathF.Sign(targetX - gameObject.transform.localPosition.x);
        }

        if (!Mathf.Approximately(targetY, gameObject.transform.localPosition.x))
        {

            velocityDirectionY = MathF.Sign(targetY - gameObject.transform.localPosition.y);
        }
        
        body.velocity = new Vector2(velocityDirectionX * wallSpeed, velocityDirectionY * wallSpeed);
        isObjectMoving = true;
    }




}
