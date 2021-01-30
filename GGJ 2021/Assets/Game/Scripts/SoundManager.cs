using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource[] AudioSources;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySFX(int index)
    {
        AudioSources[index].Play();
    }

    public void Stop(int index)
    {
        AudioSources[index].Stop();
    }

    public void PlayBGM(int index)
    {
        AudioSources[index].loop = true;
        AudioSources[index].Play();
    }

    public void StopAllSound()
    {
        foreach(AudioSource audio in AudioSources)
        {
            audio.Stop();
        }
    }

}
