using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class GameTimer : MonoBehaviour {

    public int levelTime;

    private AudioSource winSound;
    private Slider gameTimerSlider;
    private LevelManager levelManager;
    private bool isLevelEnded = false;
    private bool timeIsUp = false;
    private GameObject winText;
    
	
    // Use this for initialization
	void Start () {

        gameTimerSlider = gameObject.GetComponent<Slider>();
        gameTimerSlider.value = 0f;

        levelManager = GameObject.FindObjectOfType<LevelManager>();
        winSound = gameObject.GetComponent<AudioSource>();
        winText = GameObject.Find("You Win");
        winText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        gameTimerSlider.value = Time.timeSinceLevelLoad / levelTime;

        timeIsUp = (Time.timeSinceLevelLoad >= levelTime);
        if(timeIsUp && !isLevelEnded)
        {
            HandleWinCondition();

        }

    }

    private void HandleWinCondition()
    {
        DestroyAllTaggedObjects();
        isLevelEnded = true;
        winSound.Play();
        winText.SetActive(true);
        Invoke("LevelComplete", winSound.clip.length);
    }

    void DestroyAllTaggedObjects()
    {
        GameObject[] taggedGameObjects = GameObject.FindGameObjectsWithTag("destoryOnWin");
        foreach (GameObject tag in taggedGameObjects)
            Destroy(tag);
    }

    void LevelComplete()
    {
        levelManager.LoadNextLevel();
    }
}
