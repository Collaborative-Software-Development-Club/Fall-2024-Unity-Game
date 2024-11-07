using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private Rigidbody2D player;

    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip walkingGrass;

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
            SFXSource.Play();
        }
        else
        {
            SFXSource.Pause();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SFXSource.clip = walkingGrass;
        
        
    }
}
