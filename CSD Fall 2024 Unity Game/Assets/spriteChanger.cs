using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteChanger : MonoBehaviour
{
    public List<Sprite> sprites;
    public GameObject ghostFox;
    private bool isNotInCamera;
    public float firstDelay;
    public float timeStep;
    private SpriteRenderer spriteRenderer;
    private int i;
    private float timer=0f;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite=sprites[0];
        isNotInCamera = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (ghostFox != null)
        {
            isNotInCamera = ghostFox.GetComponent<ghostFox>().goToFox;
        }
        timer += Time.deltaTime; //��ʱ��
        if (isNotInCamera) //��������ھ�ͷ����ʱ��ʼ�滻sprite
        {
            if (timer > timeStep) 
            {
                changeSprite();
                timer = 0f; //���ü�ʱ��
            }
        }
    }
    void changeSprite()
    {
        if (i == 6)
        {
            i = 0;
        }
        i++;
        spriteRenderer.sprite=sprites[i];
    }
}
