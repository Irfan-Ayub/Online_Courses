using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {

    int max;
    int min;
    int guess;
    public int maxGuessedAllowed = 10;

    public Text guessText; // the text used to display the guess number

    // Use this for initialization
    void Start () {

        StartGame();
		
	}

    void StartGame()
    {
        max = 1000;
        min = 1;
        guess = Random.Range(min, max+1);
        guessText.text = "" + guess;
    }
	
    void NextGuess()
    {
        guess = Random.Range(min , max+1);
        guessText.text = "" + guess;
        maxGuessedAllowed--;
        if(maxGuessedAllowed <= 0)
        {
            SceneManager.LoadScene("Win");
        }
    }
    
    public void GuessHigher()
    {
        min = guess;
        NextGuess();
    }

    public void GuessLower()
    {
        max = guess;
        NextGuess();
    }
}
