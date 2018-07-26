using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    // Array for the audio clips to change when the level is changed
    public AudioClip[] levelMusicArray;

    private AudioSource audioSource;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
       
        AudioClip audio = levelMusicArray[SceneManager.GetActiveScene().buildIndex];
        
        if(audio)
        {
            audioSource.Stop();
            audioSource.clip = audio;
            audioSource.loop = true;
            audioSource.Play();
        }
        
    }

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
