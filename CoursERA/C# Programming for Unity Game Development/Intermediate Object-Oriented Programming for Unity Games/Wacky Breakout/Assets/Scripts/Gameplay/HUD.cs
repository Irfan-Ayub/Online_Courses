using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    // score support
    [SerializeField]
    Text scoreText;
    int totalScore = 0;

    // balls left support
    [SerializeField]
    Text ballsLeftText;
    int ballsLeft;


	// Use this for initialization
	void Start () {

        EventManager_New.AddListener(EventName.PointsAddedEvent, HandlePointsAddedEvent);
        EventManager_New.AddListener(EventName.BallDiappearedEvent, HandleBallDiappearedEvent);

        totalScore = 0;
        //scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
        scoreText.text = "Score : 0";

        ballsLeft = ConfigurationUtils.TotalBalls;
        //ballsLeftText = GameObject.FindGameObjectWithTag("BallsLeftText").GetComponent<Text>();
        ballsLeftText.text = "Balls Left : " + ballsLeft;

    }

    /// <summary>
    /// handles the ball disappeared event by updating the balls left count
    /// </summary>
    /// <param name="unused">this is an unused variable</param>
    private void HandleBallDiappearedEvent(int unused)
    {
        Debug.Log("Ball Disappear Event");
        ballsLeft--;

        if(ballsLeft < 0)
        {
            MenuManager.GoToMenu(MenuName.GameOver);
            return;
        }

        ballsLeftText.text = "Balls Left : " + ballsLeft;
    }

    /// <summary>
    /// Handles the points added event by updating the displayed score
    /// </summary>
    /// <param name="points">points to add</param>
    private void HandlePointsAddedEvent(int points)
    {
        totalScore += points;
        scoreText.text = "Score: " + totalScore;
    }
}
 