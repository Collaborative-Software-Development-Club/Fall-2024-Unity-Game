using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorHitCount : MonoBehaviour
{
    public int hitCount=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //ÿ��ײ��һ��hitCount+1��ÿ��һ��hitCount�Ͷ�һ��AudioSource
    //����Ž���֮���ŷŴ�մ��������Ļ�������Ǹ���ͷ
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitCount++;
    }
    public int getHitCount()
    {
        return hitCount;
    }
}
