using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Audio Clips")]
    public List<AudioClip> musicClips;
    public List<AudioClip> sfxClips;

    private Dictionary<string, AudioClip> musicDict = new Dictionary<string, AudioClip>();
    private Dictionary<string, AudioClip> sfxDict = new Dictionary<string, AudioClip>();

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeAudioDictionaries();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void InitializeAudioDictionaries()
    {
        foreach (AudioClip clip in musicClips)
        {
            musicDict[clip.name] = clip;
        }

        foreach (AudioClip clip in sfxClips)
        {
            sfxDict[clip.name] = clip;
        }
    }

    public void PlayMusic(string name, bool loop = true)
    {
        if (musicDict.TryGetValue(name, out AudioClip clip))
        {
            musicSource.clip = clip;
            musicSource.loop = loop;
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning($"Music clip '{name}' not found!");
        }
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PlaySFX(string name)
    {
        if (sfxDict.TryGetValue(name, out AudioClip clip))
        {
            sfxSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning($"SFX clip '{name}' not found!");
        }
    }

    public void SetMusicVolume(float value)
    {
        musicSource.volume = Mathf.Clamp01(value);
    }

    public void SetSFXVolume(float value)
    {
        sfxSource.volume = Mathf.Clamp01(value);
    }

    public void SetMusicVolumeFromSlider(float value)
    {
        SetMusicVolume(value);
    }

    public void SetSFXVolumeFromSlider(float value)
    {
        SetSFXVolume(value);
    }
}
