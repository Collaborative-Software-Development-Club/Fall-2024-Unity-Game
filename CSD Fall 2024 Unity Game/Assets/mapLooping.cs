using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapLooping : MonoBehaviour
{
    private GameObject fox;
    private GameObject fogEffect;
    // Start is called before the first frame update
    void Start()
    {
        fox = GameObject.Find("Fox");
        fogEffect = GameObject.Find("FogEffect");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 hittingLeft = new Vector2(28.4f, 0);
        Vector2 hittingRight = new Vector2(-22.5f, 0);
        Vector2 hittingBelow = new Vector2(0, 15);
        Vector2 hittingAbove = new Vector2(0, -14.7f);

        Vector2 originalFogPosition = fogEffect.transform.position; // 保存原来的雾气位置
        Vector2 originalFoxPosition = fox.transform.position; // 先记录狐狸的原始位置

        if (fox.transform.position.x < 0)
        {
            fox.transform.position = hittingLeft;
        }
        else if (fox.transform.position.x > 0)
        {
            fox.transform.position = hittingRight;
        }
        else if (fox.transform.position.y < 0)
        {
            fox.transform.position = hittingBelow;
        }
        else if (fox.transform.position.y > 0)
        {
            fox.transform.position = hittingAbove; 
        }

        Vector2 offset = originalFogPosition - originalFoxPosition; // 计算新位置的偏移量
        fogEffect.transform.position = (Vector2)fox.transform.position+offset; // 更新雾气位置
    }

}
