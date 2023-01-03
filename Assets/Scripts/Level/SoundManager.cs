using System;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    public SoundType[] soundTypes;

    [SerializeField]
    private AudioSource music;
    [SerializeField]
    private AudioSource sfx;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic(Sounds.themeMusic);
    }
    public void PlayMusic(Sounds sound)
    {
        SoundType item = Array.Find(soundTypes, i => i.soundName == sound);
        AudioClip clip = item.audioclip;
        if (clip != null)
        {
            music.clip = clip;
            music.Play();
        }
        else
        {
            Debug.Log("Clip not found for sound:" + sound);
        }
    }
    public void Play(Sounds sound)
    {
        SoundType item = Array.Find(soundTypes, i => i.soundName == sound);
        AudioClip clip = item.audioclip;
        if (clip != null)
        {
            sfx.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("Clip not found for sound:" + sound);
        }
    }
}
[Serializable]
public class SoundType
{
    public Sounds soundName;
    public AudioClip audioclip;
}
public enum Sounds
{
    themeMusic,
    buttonClick,
    playerJumpUp,
    playerJumpLand,
    playerDeath,
    enemyDeath,
    wrongButton,
    genericPickUp,
    healthPickUp
}