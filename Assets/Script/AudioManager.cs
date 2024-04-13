using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
   [SerializeField] private Sound[] sounds;

    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }


        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;


            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    public void Start()
    {
        //Play("Theme");
        Play("WindTheme");

    }


    public void Play(string name)
    {
        Sound s = Array.Find(sounds, Sound => Sound.name == name);

        if (s == null)
        {
            
            return;
        }

        s.source.Play();
    }

    private void Stop(string name)
    {
        Sound s = Array.Find(sounds, Sound => Sound.name == name);

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

    public void RestartAllSounds()
    {
        foreach (Sound s in sounds)
        {
            s.source.Play();
        }
    }

}