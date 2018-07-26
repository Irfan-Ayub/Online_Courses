using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public static int currentScore = 0;

    private Text myText = null;

    private void Start()
    {
        myText = gameObject.GetComponent<Text>();
        myText.text = "0";
    }

    public void AddScore(int score)
    {
        currentScore += score;
        myText.text = currentScore.ToString();
    }

    public static void ResetScore()
    {
        currentScore = 0;
    }
}
