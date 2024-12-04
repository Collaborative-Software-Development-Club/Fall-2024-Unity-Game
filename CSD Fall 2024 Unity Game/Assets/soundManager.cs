using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip grassSound;
    public AudioClip sandSound;
    public AudioClip background;
    public Collider2D sandTrigger;
    public fox fox;

    private AudioSource walkingSource;
    private AudioSource bgAudioSource;
    private Vector2 speed;

    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        walkingSource = audioSources[0];
        bgAudioSource = audioSources[1];

        bgAudioSource.clip = background;
        bgAudioSource.loop = true;
        bgAudioSource.Play();
    }

    void Update()
    {
        speed=fox.GetComponent<Rigidbody2D>().velocity;
        changeSource();
        playSound();
        
    }
    void changeSource()
    {
        if (fox.GetComponent<Collider2D>().IsTouching(sandTrigger))
        {
            walkingSource.clip = sandSound;
        }
        else
        {
            walkingSource.clip = grassSound;
        }
    }
    void playSound()
    {
        if (!speed.Equals(Vector2.zero))
        {
            if (!walkingSource.isPlaying)
            {
                walkingSource.Play();  

            }
        }
        else
        {
            if (walkingSource.isPlaying)
            {
                walkingSource.Stop();  
            }
        }
    }
}
