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
    private bool firstInCam = true; //ֱ����ҽ��в���֮ǰ��Ϊtrue
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
            // ����� ghost �� fox �ķ��򣬲���һ��Ϊ��λ����
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
                // �����ٶȣ�����׷���ٶ�
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
    void shouldMove() // ghostFox ���ھ�ͷ������ھ�ͷ�ڵ������û���ƶ�ʱ���� fox���������ƶ����Ǿ͸�����ҵ��ƶ����ƶ�
    {
        camVerticalSize = camera.orthographicSize;
        camHorizontalSize = camVerticalSize * camera.aspect;

        camLeft = camera.transform.position.x - camHorizontalSize;
        camRight = camera.transform.position.x + camHorizontalSize;
        camUp = camera.transform.position.y + camVerticalSize;
        camDown = camera.transform.position.y - camVerticalSize; // ��������

        // ����Ƿ��������Ұ��
        if (transform.position.x >= camRight || transform.position.x <= camLeft ||
            transform.position.y >= camUp || transform.position.y <= camDown) // �޸��������
        {
            goToFox = true;
        }
        else // �������Ұ��
        {
            isInCam = true;
            // ��� fox �Ƿ�û���ƶ�
            if (foxRB.velocity.Equals(Vector2.zero)) //foxû�ƶ�
            {
                goToFox = true;
                
            }
            else //fox�ƶ���
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
        if (goToFox&&!isInCam&&!isPlaying) //gotoFox��������û���ŵ�ʱ�򲥷ţ�����ÿһ֡������play�������û����
        {
            ghostAudio.Play();
            isPlaying = true;
        }
        else //û��gotofoxʱ������
        {
            ghostAudio.Pause();
            isPlaying = false;
        }

    }

}
