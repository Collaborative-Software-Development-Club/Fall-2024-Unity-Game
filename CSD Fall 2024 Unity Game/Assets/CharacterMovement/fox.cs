using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

, movement
{
    [Header("Character Speed")]
    [SerializeField] private float speed;
    [Header("Character Speed Multiplied by this when running")]
    [SerializeField] private float runSpeedtimefactor;
    [SerializeField] private float currentSpeed;
    private bool isRunning;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private Collider2D foxCollision;
    private InputAction action;
    private InputAction sprint;
    private PlayerInputActions playerMap;
    private Animator anim;

    [SerializeField] private PauseMenuScript pauseMenuScript;

        // Start is called before the first frame update
    void Awake()
    {
        playerMap = new PlayerInputActions();
        anim = GetComponent<Animator>();
    }
    void OnEnable()
    {
        action = playerMap.PlayerAction.Movement;
        sprint = playerMap.PlayerAction.Sprint;
        action.Enable();
        sprint.Enable();
    }
    void OnDisable()
    {
        sprint.Disable();
        action.Disable();
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
        Vector2 movement = action.ReadValue<Vector2>();
        Vector3 player = new Vector3();
        player.x = movement.x * currentSpeed;
        player.y = movement.y * currentSpeed;
        body.velocity = player;
    }

    public void updateSprite()
    {
        Vector2 movement = action.ReadValue<Vector2>();
        anim.SetBool("Idle", false);
        // change animation based on direction of movement
        if (movement.x < 0)
        {
            anim.SetInteger("DirectionMoving", 4);
            spriteRenderer.flipX = true;
        }
        else if (movement.x > 0)
        {
            anim.SetInteger("DirectionMoving", 2);
            spriteRenderer.flipX = false;
        }
        else if (movement.y < 0)
        {
            anim.SetInteger("DirectionMoving", 3);
            spriteRenderer.flipX = false;
        }
        else if (movement.y > 0)
        {
            anim.SetInteger("DirectionMoving", 1);
            spriteRenderer.flipX = false;
        } else {
            anim.SetBool("Idle", true);
        }
    }
    public void speed_Down()
    {
    }

    public void speed_Up()
    {
        if (sprint.ReadValue<float>()>0)
        {
            currentSpeed = speed*runSpeedTimeFactor;
        }
        else
        {
            currentSpeed = speed;
        }
    }
}
