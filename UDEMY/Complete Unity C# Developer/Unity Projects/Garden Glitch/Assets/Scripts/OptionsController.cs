using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public Slider volumeSLider;
    public Slider difficultySlider;
    public LevelManager levelManager;

    private MusicManager musicManager;

	// Use this for initialization
	void Start () {

        musicManager = GameObject.FindObjectOfType<MusicManager>();
        volumeSLider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
	}
	
	// Update is called once per frame
	void Update () {

        musicManager.ChangeVolume(volumeSLider.value);
		
	}

    public void SaveAndExit(string sceneToLoad)
    {
        PlayerPrefsManager.SetMasterVolume(volumeSLider.value);
        PlayerPrefsManager.SetDifficulty(difficultySlider.value);

        levelManager.LoadLevel(sceneToLoad);
    }

    public void SetDefaults()
    {
        volumeSLider.value = 0.8f;
        difficultySlider.value = 2f;
    }
}
