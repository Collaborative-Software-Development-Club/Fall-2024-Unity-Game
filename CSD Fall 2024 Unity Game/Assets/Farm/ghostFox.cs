using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class ghostFox : MonoBehaviour
{
    public GameObject fox;
    public Camera camera;
    public bool goToFox;
    public bool isInCam=false;
    private bool firstInCam = true; //直到玩家进行操作之前都为true
    [SerializeField] private Rigidbody2D foxRB;
    [SerializeField] private Rigidbody2D ghostFoxRB;
    private Vector2 foxSpeed;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Collider2D ghostFoxCollision;
    private Vector2 offsetToFox;
    [Header("Speed to chase Fox when invisible")]
    public float chaseSpeed;
    public float chaseSpeedInCam;
    private Animator anim;
    private float camLeft;
    private float camRight;
    private float camUp;
    private float camDown;
    private float camVerticalSize;
    private float camHorizontalSize;
    private AudioSource ghostAudio;
    private bool isPlaying = false;

    // Start is called before the first frame update

    void Start()
    {
        foxRB = fox.GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ghostFoxCollision = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        foxSpeed=foxRB.velocity;
        gameObject.SetActive(false);
        ghostAudio = GetComponent<AudioSource>();
        ghostAudio.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        shouldMove();
        Debug.Log("gotofox:"+goToFox);
        updateSprite();
        playSound();
        move();
    }

    //Realizing methods in interface charactermove
    public void move()
    {
        if (goToFox) 
        {
            // 计算从 ghost 到 fox 的方向，并归一化为单位向量
            offsetToFox = (fox.transform.position - transform.position).normalized;
            if (isInCam)
            {
                if (firstInCam)
                {
                    ghostFoxRB.velocity = Vector2.zero;
                }
                else
                {
                    ghostFoxRB.velocity = offsetToFox * chaseSpeedInCam;
                }
            }
            else
            {
                // 设置速度，乘以追逐速度
                ghostFoxRB.velocity = offsetToFox * chaseSpeed;
            }
        }
        else
        {
            ghostFoxRB.velocity = foxRB.velocity * 2;
        }
    }


    public void updateSprite()
    {
        Vector2 movement = ghostFoxRB.velocity;
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
        }
        else
        {
            anim.SetBool("Idle", true);
        }
    }
    void shouldMove() // ghostFox 会在镜头外或者在镜头内但是玩家没有移动时靠近 fox，如果玩家移动了那就跟随玩家的移动而移动
    {
        camVerticalSize = camera.orthographicSize;
        camHorizontalSize = camVerticalSize * camera.aspect;

        camLeft = camera.transform.position.x - camHorizontalSize;
        camRight = camera.transform.position.x + camHorizontalSize;
        camUp = camera.transform.position.y + camVerticalSize;
        camDown = camera.transform.position.y - camVerticalSize; // 修正这里

        // 检查是否在相机视野外
        if (transform.position.x >= camRight || transform.position.x <= camLeft ||
            transform.position.y >= camUp || transform.position.y <= camDown) // 修改条件组合
        {
            goToFox = true;
        }
        else // 在相机视野内
        {
            isInCam = true;
            // 检查 fox 是否没有移动
            if (foxRB.velocity.Equals(Vector2.zero)) //fox没移动
            {
                goToFox = true;
                
            }
            else //fox移动了
            {
                if (firstInCam)
                {
                    firstInCam = false;
                }
                goToFox = false;
            }
        }
    }
    void playSound()
    {
        if (goToFox&&!isInCam&&!isPlaying) //gotoFox并且声音没播放的时候播放，避免每一帧都调用play导致最后没声音
        {
            ghostAudio.Play();
            isPlaying = true;
        }
        else //没有gotofox时不播放
        {
            ghostAudio.Pause();
            isPlaying = false;
        }

    }

}
