using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float runspeedtimefactor; //times we want the speed to be increased
    private bool isrunning;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speedup();
        move();
    }
    private void move()
    {

        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        
        //delete those if you don't need them (I wrote this because I need them to see if the camera is tracking the object correctly)
        Debug.Log(speed);
        Debug.Log(gameObject.transform.position);
    }
    private void speedup()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)&&!isrunning) //if user hits left shift in the current frame, multiply the speed by runspeedtimefactor
        {
            isrunning = true; //to avoid the speed gets increased exponentially if the user holds left shift
            speed *= runspeedtimefactor;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)&&isrunning) //if user didn't, restore the original speed by dividing the current speed by runspeedtimefactor
        {
            speed/=runspeedtimefactor;
            isrunning = false;
        }
    }
}
