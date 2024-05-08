using UnityEngine;
using System;


[System.Serializable]
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

    private void Start()
    {
        PlaySound(SoundName.Jump); // Example: playing Jump sound
    }

    public void PlaySound(SoundName soundName)
    {
        Sound s = GetSound(soundName);

        if (s == null)
        {
           
            return;
        }

        s.source.Play();
    }

    public void StopSound(SoundName soundName)
    {
        Sound s = GetSound(soundName);

        if (s == null)
        {
            
            return;
        }

        s.source.Stop();
    }

    private Sound GetSound(SoundName soundName)
    {
        return Array.Find(sounds, sound => sound.name == soundName);
    }
}
