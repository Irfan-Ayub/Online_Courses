using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Text scoreText = gameObject.GetComponent<Text>();
        scoreText.text = ScoreScript.currentScore.ToString();
        ScoreScript.ResetScore();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
