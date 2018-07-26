using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A Heads up Display for UI
/// </summary>
public class HUD : MonoBehaviour {

    [SerializeField]
    Text timerText;

    // time passed since the game is started
    float elapsedSeconds;
    // checks if the timer is running or not
    bool timerRunning = true;


	// Use this for initialization
	void Start () {

        timerText.text = "0";
		
	}
	
	// Update is called once per frame
	void Update () {

        if(timerRunning)
        {
            elapsedSeconds += Time.deltaTime;
            timerText.text = ((int)elapsedSeconds).ToString();
        }
	}


    public void StopGameTimer()
    {
        timerRunning = false;
    }
}
