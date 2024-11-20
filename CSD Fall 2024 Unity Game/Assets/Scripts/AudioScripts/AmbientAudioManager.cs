using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientAudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] ambientSounds;

    // Start is called before the first frame update
    void Start()
    {
        playAllAmbientSounds();
    }

    public void playAmbientSound(string name)
    {
        findAmbientSound(name).Play();
    }

    public void stopAmbientSound(string name)
    {
        findAmbientSound(name).Stop();
    }

    public void pauseAmbientSound(string name)
    {
        findAmbientSound(name).Pause();
    }

    private AudioSource findAmbientSound(string name)
    {
        return Array.Find(ambientSounds, x => x.name == name);
    }

    public void playAllAmbientSounds()
    {
        for (int i = 0;i < ambientSounds.Length;i++) 
        { 
            ambientSounds[i].Play(); 
        } 
    }
    }


