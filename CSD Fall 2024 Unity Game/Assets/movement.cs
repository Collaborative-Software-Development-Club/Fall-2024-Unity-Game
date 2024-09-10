using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float runspeedtimefactor;
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
        Debug.Log(speed);
        Debug.Log(gameObject.transform.position);
    }
    private void speedup()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)&&!isrunning)
        {
            isrunning = true;
            speed *= runspeedtimefactor;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)&&isrunning)
        {
            speed/=runspeedtimefactor;
            isrunning = false;
        }
    }
}
