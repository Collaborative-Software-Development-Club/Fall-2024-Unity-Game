using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostScript : MonoBehaviour
{
    private GameObject fox;
    private Vector2 foxPos;
    private bool hasAppeared;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        fox = GameObject.Find("Fox");
        foxPos = fox.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        foxPos = fox.transform.position;
    }

    private void OnBecameInvisible()
    {
       gameObject.SetActive (false);
        //setactive变成false之后方法认为相机永不可见
        //这个方法只能检测真正被渲染在镜头里的东西
        //debug：再加一个布尔值来当作invisible之后的判断标准
    }
    private void OnBecameVisible()
    {
        gameObject.SetActive(true);
    }
    void updatePosition()
    {

    }
}
