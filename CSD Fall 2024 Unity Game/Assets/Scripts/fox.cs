using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class fox : MonoBehaviour, movement
{
    [Header("Character Speed")]
    public float speed;
    [Header("Character Speed Multiplied by this when running")]
    public float runspeedtimefactor;
    private bool isrunning;
    private SpriteRenderer spriteRenderer;
    public Sprite[] movepics; //0is the sprite moving upward£¬1downward£¬2to right£¬3to left
    public Rigidbody2D body;
    public Collider2D coll;

        // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        body=GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speedup();
        move();
    }

    //Realizing methods in interface charactermove
    public void move()
    {
        Vector2 location=body.position;
        if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow))
        {
            location.y += speed * Time.deltaTime;
            spriteRenderer.sprite=movepics[0];
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            location.y -= speed * Time.deltaTime;
            spriteRenderer.sprite = movepics[1];
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            location.x += speed * Time.deltaTime;
            spriteRenderer.sprite = movepics[2];
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            location.x -= speed * Time.deltaTime;
            spriteRenderer.sprite = movepics[3];
        }
        body.position = location;
    }

    public void speeddown()
    {
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

    public void collide()
    {

    }
}
