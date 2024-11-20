using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private Rigidbody2D player;

    [Header("Audio Source")]
    public AudioSource musicSource;
    public AudioSource SFXSource;

    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip walking;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        musicSource.clip = background;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.velocity.Equals(Vector2.zero))
        {
            if (!SFXSource.isPlaying)
            {
                SFXSource.Play();
            }
        }
        else
        {
            SFXSource.Pause();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SFXSource.clip = walking;
        SFXSource.Play(); // Start playing the walking sound when entering the trigger
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SFXSource.Pause(); // Optional: Stop or pause the walking sound when leaving the trigger
    }
}
