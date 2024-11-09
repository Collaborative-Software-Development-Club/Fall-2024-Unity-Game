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
        windSound.Play();  // 背景风音效一直播放
        grassSound.Stop();  // 确保草地音效在游戏开始时不会播放
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
        // 如果角色有速度，且草地音效没有播放，则播放草地音效
        if (!speed.Equals(Vector2.zero))
        {
            if (!isPlaying)
            {
                grassSound.Play();  // 播放草地音效
                isPlaying = true;  // 设置播放状态为true
            }
        }
        else
        {
            // 如果角色停止，则停止草地音效
            if (isPlaying)
            {
                grassSound.Stop();  // 停止草地音效
                isPlaying = false;  // 设置播放状态为false
            }
        }
    }
}
