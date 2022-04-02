using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public List<AudioSource> sounds = new List<AudioSource>();

    private void Awake()
    {
        instance = this;
    }

    public void PlayBasamakStepAudio()
    {
        PlayAudio(0);
    }

    public void PlayAudio(int x)
    {
        sounds[x].Play();
    }


}
