using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    public float volume;
    public bool loop;
    [HideInInspector] public AudioSource source;
}