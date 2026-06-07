using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioClip golpeSound, iconoDeadSound, lexiDeadSound, checkpointSound, clippoSound;
    public AudioSource musicSource, sfxSource;

    public AudioClip VictoryTheme, MainTheme, PauseTheme, LoseTheme;


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
        else if (scene.name == "Derrota")
        {
            PlayMusic(LoseTheme);
        }
    }
    public void PlayGolpeSound()
    {
        sfxSource.PlayOneShot(golpeSound);
    }

    public void PlayIconoDeadSound()
    {
        sfxSource.PlayOneShot(iconoDeadSound);
    }
    public void PlayLexiDeadSound()
    {
        sfxSource.PlayOneShot(lexiDeadSound);
    }
    public void PlayCheckpointSound()
    {
        sfxSource.PlayOneShot(checkpointSound);
    }


   
}