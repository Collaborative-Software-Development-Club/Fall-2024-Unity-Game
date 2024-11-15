using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundSurrounding : MonoBehaviour //��audioһֱ�������һ���
{
    private AudioSource audio;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        audio= GetComponent<AudioSource>();
        audio.panStereo = Random.Range(-1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (audio.panStereo>0) //�����������ȿ�ʼ,��ʱ������������
        {
            if (audio.panStereo != -1)
            {
                audio.panStereo -= moveSpeed;
            }
            else
            {
                audio.panStereo = 1;
            }
        }
        else
        {
            if (audio.panStereo != 1)
            {
                audio.panStereo += moveSpeed;
            }
            else
            {
                audio.panStereo = -1;
            }
        }
       
    }
}
