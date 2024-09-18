using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class fox : MonoBehaviour, movement
{
    [Header("Character Speed")]
    public float speed;
    [Header("Character Speed Multiplied by this when running")]
    public float runSpeedtimefactor;
    public float currentSpeed;
    private bool isRunning;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites_Array; //element 0 is the sprite moving upward£¬1 downward£¬2 to right£¬3 to left
    public Rigidbody2D body;
    public Collider2D foxCollision;
    private InputAction _action;
    private InputAction _sprint;
    private PlayerInputActions _playerMap;

        // Start is called before the first frame update
    void Awake()
    {
        _playerMap = new PlayerInputActions();
    }
    void OnEnable()
    {
        _action = _playerMap.PlayerAction.Movement;
        _sprint = _playerMap.PlayerAction.Sprint;
        _action.Enable();
        _sprint.Enable();
    }
    void OnDisable()
    {
        _sprint.Disable();
        _action.Disable();
    }



    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        body=GetComponent<Rigidbody2D>();
        foxCollision = GetComponent<Collider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        updateSprite();
        speed_Up();
        move();
    }

    //Realizing methods in interface charactermove
    public void move()
    {
        Vector2 movement = _action.ReadValue<Vector2>();
        Vector3 player = new Vector3();
        player.x = movement.x * currentSpeed;
        player.y = movement.y * currentSpeed;
        body.velocity = player;
    }

    public void updateSprite()
    {
        Vector2 movement = _action.ReadValue<Vector2>();
        if (movement.x < 0)
        {
            spriteRenderer.sprite = sprites_Array[3];
        }
        else if (movement.x > 0)
        {
            spriteRenderer.sprite = sprites_Array[2];
        }
        else if (movement.y < 0)
        {
            spriteRenderer.sprite = sprites_Array[1];
        }
        else if (movement.y > 0)
        {
            spriteRenderer.sprite = sprites_Array[0];
        }
    }
    public void speed_Down()
    {
    }

    public void speed_Up()
    {
        if (_sprint.ReadValue<float>()>0)
        {
            currentSpeed = speed*runSpeedtimefactor;
        }
        else
        {
            currentSpeed = speed;
        }
    }
}
