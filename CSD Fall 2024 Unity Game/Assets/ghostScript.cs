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
        //setactive���false֮�󷽷���Ϊ��������ɼ�
        //�������ֻ�ܼ����������Ⱦ�ھ�ͷ��Ķ���
        //debug���ټ�һ������ֵ������invisible֮����жϱ�׼
    }
    private void OnBecameVisible()
    {
        gameObject.SetActive(true);
    }
    void updatePosition()
    {

    }
}
