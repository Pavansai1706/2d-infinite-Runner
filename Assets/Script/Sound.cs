using UnityEngine.Audio;
using UnityEngine;

public enum SoundName
{
    Jump,
    Land,
    GameOver,
    Coin
}

[System.Serializable]
public class Sound
{
    public SoundName name;
    public AudioClip clip;

    public bool loop;

    [Range(0f, 3f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;

    // Remove [HideInInspector] attribute
    public AudioSource source;
}

