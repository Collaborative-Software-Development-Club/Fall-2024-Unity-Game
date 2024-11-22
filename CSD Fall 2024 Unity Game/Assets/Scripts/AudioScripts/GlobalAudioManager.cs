using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalAudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] ambientSounds;

    // Start is called before the first frame update
    void Start()
    {
        playAllSounds();
    }

    public void playSound(string name)
    {
        findSound(name).Play();
    }

    public void stopSound(string name)
    {
        findSound(name).Stop();
    }

    public void pauseSound(string name)
    {
        findSound(name).Pause();
    }

    private AudioSource findSound(string name)
    {
        return Array.Find(ambientSounds, x => x.name == name);
    }

    public void playAllSounds()
    {
        for (int i = 0;i < ambientSounds.Length;i++) 
        { 
            ambientSounds[i].Play(); 
        } 
    }

    public void pauseAllSounds()
    {
        for (int i = 0; i < ambientSounds.Length; i++)
        {
            ambientSounds[i].Pause();
        }
    }

    public void changePitchOfAllSounds(float newPitch)
    {
        for (int i = 0; i < ambientSounds.Length; i++)
        {
            ambientSounds[i].pitch = newPitch;
        }
    }

    public void changePitchOfSound(string name, float newPitch)
    {
        findSound(name).pitch = newPitch;
    }
}


