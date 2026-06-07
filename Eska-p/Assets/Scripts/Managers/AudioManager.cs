using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioClip[] a;
    public AudioSource musicSource, sfxSource;

    public AudioClip VictoryTheme, MainTheme;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
        float volume = PlayerPrefs.GetFloat("volume", 1f);
        musicSource.volume = volume;
    }
    public void PlayMusic(AudioClip clip)
    {
        if (musicSource.clip == clip)
        {
            return;
        }
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }
    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat("volume", volume);
    }
    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }
    public float GetMusicVolume()
    {
        return musicSource.volume;
    }
    public float GetSFXVolume()
    {
        return sfxSource.volume;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Victoria")
        {
            PlayMusic(VictoryTheme);
        }
        else if (scene.name == "AllLevels")
        {
            PlayMusic(MainTheme);
        }
    }


  

}
