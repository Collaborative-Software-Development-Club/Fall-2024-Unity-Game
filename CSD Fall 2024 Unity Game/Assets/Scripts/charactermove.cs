using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class charactermove : MonoBehaviour, movement
{
    public float speed;
    public float runspeedtimefactor; //times we want the speed to be increased
    private bool isrunning;
    private SpriteRenderer spriteRenderer;
    public Sprite[] movepics;

    public charactermove(float s, float factor, bool running, SpriteRenderer sr, Sprite[] mp)
    {
        speed = s;
        runspeedtimefactor = factor;
        isrunning = running;
        spriteRenderer = sr;
        movepics = mp;
    }

    public void move()
    {



        //delete those if you don't need them (I wrote this because I need them to see if the camera is tracking the object correctly)
        Debug.Log(speed);
        Debug.Log(gameObject.transform.position);
    }
    public void speedup()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isrunning) //if user hits left shift in the current frame, multiply the speed by runspeedtimefactor
        {
            isrunning = true; //to avoid the speed gets increased exponentially if the user holds left shift
            speed *= runspeedtimefactor;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) && isrunning) //if user didn't, restore the original speed by dividing the current speed by runspeedtimefactor
        {
            speed /= runspeedtimefactor;
            isrunning = false;
        }
    }
    public void speeddown()
    {
    }
}
// Start is called before the first frame update




