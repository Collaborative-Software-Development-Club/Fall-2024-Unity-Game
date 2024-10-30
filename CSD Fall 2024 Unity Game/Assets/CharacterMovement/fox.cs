using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class fox : MonoBehaviour
{
    [Header("Character Speed")]
    [SerializeField] private float defaultMoveSpeed;
    [SerializeField] private float runSpeedTimeFactor;
    [SerializeField] private float currentSpeed;

    [SerializeField]
    [Tooltip("Max amount of time the player can sprint for, also dictates how long it takes for them to regain full sprint after using it")]
    private float maxSprintTime;
    private float sprintTimeRemaining;

    private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D body;
    private InputAction action;
    private InputAction sprint;
    private PlayerInputActions playerMap;
    private Animator anim;

    [SerializeField] private PauseMenuScript pauseMenuScript;


    //Variable for placeholder sprint bar UI manager
    [SerializeField]
    private SprintUI sprintUI;

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
        sprintTimeRemaining = maxSprintTime;
        sprintUI.setVisibility(false);
    }

    // Update is called once per frame
    void Update()
    {
        updateSprite();
        speed_Up();
        move();
        recover_Sprint();
        updateSprintBar();
    }

    //Realizing methods in interface charactermove
    public void move()
    {
        Vector2 movement = action.ReadValue<Vector2>();
        body.velocity = movement*currentSpeed;
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

    //Manages sprinting mechanic of the fox
    public void speed_Up()
    {
        if (sprint.ReadValue<float>()>0 && sprintTimeRemaining > 0)
        {
            currentSpeed = defaultMoveSpeed*runSpeedTimeFactor;
            sprintTimeRemaining -= Time.deltaTime;
        }
        else
        {
            currentSpeed = defaultMoveSpeed;
        }
    }


    //Increments SprintTimeRemaining whenever sprint key is not being press
    private void recover_Sprint()
    {
        if(sprintTimeRemaining <= maxSprintTime && Mathf.Approximately(sprint.ReadValue<float>(), 0))
        {
            sprintTimeRemaining += Time.deltaTime;
        }
    }

    //Makes the sprint bar visible when in use, and then displays sprint time remaining in the form of a bar
    private void updateSprintBar()
    {
        if(!sprintUI.getVisibility() && sprintTimeRemaining <  maxSprintTime)
        {
            sprintUI.setVisibility(true);
            
        }
        else if(sprintTimeRemaining >= maxSprintTime)
        {
            sprintUI.setVisibility(false);
        }
        else
        {
            sprintUI.updateSprintBar(sprintTimeRemaining / maxSprintTime);
        }
    }
}
