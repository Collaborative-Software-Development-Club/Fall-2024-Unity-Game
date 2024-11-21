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
    public AudioSource walkingSource; // Dedicated source for walking sound

    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip walking;
    public AudioClip treeTalking;

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
            if (!walkingSource.isPlaying)
            {
                walkingSource.Play();
            }
        }
        else
        {
            walkingSource.Pause();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        walkingSource.clip = walking;
        walkingSource.Play(); // Start playing the walking sound when entering the trigger
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        walkingSource.Pause(); // Optional: Stop or pause the walking sound when leaving the trigger
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
