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

    [SerializeField]
    [Tooltip("Default speed of player")]
    private float defaultMoveSpeed;

    [SerializeField]
    [Tooltip("Factor to multiply speed by when sprinting")]
    private float sprintSpeedTimeFactor;

    [SerializeField]
    [Tooltip("Factor to multiply speed by when recovering sprint")] 
    private float tiredSpeedTimeFactor;

    private float currentSpeed;
    //----------------------------------------------------------------------------------------------------------------------------------
    [Header("Sprint Mechanics")]

    [SerializeField]
    [Tooltip("Max amount of time the player sprints for")]
    private float maxSprintTime;

    [SerializeField]
    [Tooltip("The factor by which the recovery time should be multiplied by. When this equals 1, the recovery time will match maxSprintTime.")]
    private float recoverSpeedFactor;
    private float sprintTimeRemaining;
    private bool isSprinting;
    private bool isTired;
    //----------------------------------------------------------------------------------------------------------------------------------
    [Header("Misc")]
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


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        body=GetComponent<Rigidbody2D>();
        sprintTimeRemaining = maxSprintTime;
        isSprinting = false;
        sprintUI.setVisibility(false);
        currentSpeed = 0;
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

    //Controls the speed of the player based off if they're walking or sprinting
    public void speed_Up()
    {

        //Once the sprint button is pressed for the place to continue sprinting until sprintTimeRemaining runs out
        if (isTired)
        {
            currentSpeed = defaultMoveSpeed * tiredSpeedTimeFactor;
        }
        else if ((sprint.ReadValue<float>()>0 && maxSprintTime <= sprintTimeRemaining)||isSprinting)
        {
            currentSpeed = defaultMoveSpeed*sprintSpeedTimeFactor;
            sprintTimeRemaining -= Time.deltaTime;
            isSprinting = sprintTimeRemaining > 0;
        }
        else
        {
            currentSpeed = defaultMoveSpeed;
        }
    }


    //Increments SprintTimeRemaining whenever sprint key is not being press
    private void recover_Sprint()
    {
        if(sprintTimeRemaining <= maxSprintTime && !isSprinting)
        {
            isTired = true;
            sprintTimeRemaining += Time.deltaTime * recoverSpeedFactor;
        }
        else
        {
            isTired = false;
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
