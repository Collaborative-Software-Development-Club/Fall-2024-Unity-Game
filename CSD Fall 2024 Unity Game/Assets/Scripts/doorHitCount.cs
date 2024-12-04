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
    //每被撞击一次hitCount+1，每多一个hitCount就多一个AudioSource
    //最后门解锁之后门放大沾满整个屏幕，猪在那个里头
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitCount++;
    }
    public int getHitCount()
    {
        return hitCount;
    }
}
