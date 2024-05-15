using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;




public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    //private float currentVolume = 1f;
     
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

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.Play();
        }
        
    }
    private void Start()
    {
        StopAllSounds();        
        Play("Theme");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound._name == name);
        if (s == null)
        {
            return;
        }
            
        s.source.Play();
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound._name == name);
        if (s == null)
        {
            return;
        }

        s.source.Stop();
    }
    public void StopAllSounds()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
    }

}
