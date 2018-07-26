using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

    public AudioClip startAudioClip;
    public AudioClip gameAudioClip;
    public AudioClip endAudioClip;

    private AudioSource audioSource;

    static MusicPlayer instance = null;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void Start () {

		if (instance != null && instance != this) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = startAudioClip;
            audioSource.loop = true;
            audioSource.Play(); 
		}
		
	}
    private void OnSceneLoaded(Scene scene , LoadSceneMode mode)
    {
        Debug.Log("Music Player -  Level Loaded - " + scene.name);
        if (audioSource)
        { audioSource.Stop(); }

        if(scene.name.Equals("Start Screen"))
        { audioSource.clip = startAudioClip; }
        if(scene.name.Equals("Game"))
        { audioSource.clip = gameAudioClip; }
        if(scene.name.Equals("Win Screen"))
        { audioSource.clip = endAudioClip; }

        if(audioSource)
        {
            audioSource.loop = true;
            audioSource.Play();
        }
       

    }
}
