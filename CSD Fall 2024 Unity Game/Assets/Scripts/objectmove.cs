using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectmove : MonoBehaviour
{
    public float movespeed;
    public float runspeedtimefactor;
    private bool isrunning;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speedup();
        move();
        
        
    }

    // A method to move, capturing the inputing character to determine the direction of movement
    void move()
    {
        if (Input.GetKey(KeyCode.W) == true)
        {
            gameObject.transform.Translate(Vector3.up * movespeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) == true)
        {
            gameObject.transform.Translate(Vector3.down * movespeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) == true)
        {
            gameObject.transform.Translate(Vector3.right * movespeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A)==true){
            gameObject.transform.Translate(Vector3.left *movespeed* Time.deltaTime);
        }
    }

    void move2()
    {
        
    }
    void speedup()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)&&!isrunning)
        {
            isrunning = true;
            movespeed *= runspeedtimefactor;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift)&&isrunning) { 
            isrunning = false;
            movespeed/= runspeedtimefactor;
        }
    }
}
