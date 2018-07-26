using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Time.timeScale = 0;
        AudioManager.Play(AudioClipName.GameOver);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Handles the on click event from the Quit button
    /// </summary>
    public void HandleQuitButtonOnClickEvent()
    {
        // unpause game, destroy menu, and go to main menu
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }
}
