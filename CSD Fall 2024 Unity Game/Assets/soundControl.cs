using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SoundControl : MonoBehaviour
{
    public AudioSource grassSound;
    public AudioSource windSound;
    public Rigidbody2D fox;
    private Vector2 speed;
    private bool isPlaying;

    void Start()
    {
        windSound.Play();  // ��������Чһֱ����
        grassSound.Stop();  // ȷ���ݵ���Ч����Ϸ��ʼʱ���Ქ��
        isPlaying = false;
    }

    void Update()
    {
        speed = fox.velocity;
        Debug.Log("wind"+windSound.isPlaying);
        Debug.Log("grass"+grassSound.isPlaying);
        playSound();
    }

    void playSound()
    {
        // �����ɫ���ٶȣ��Ҳݵ���Чû�в��ţ��򲥷Ųݵ���Ч
        if (!speed.Equals(Vector2.zero))
        {
            if (!isPlaying)
            {
                grassSound.Play();  // ���Ųݵ���Ч
                isPlaying = true;  // ���ò���״̬Ϊtrue
            }
        }
        else
        {
            // �����ɫֹͣ����ֹͣ�ݵ���Ч
            if (isPlaying)
            {
                grassSound.Stop();  // ֹͣ�ݵ���Ч
                isPlaying = false;  // ���ò���״̬Ϊfalse
            }
        }
    }
}
