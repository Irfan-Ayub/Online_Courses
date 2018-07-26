using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour {

    int max;
    int min;
    int guess;

    // Use this for initialization
    void Start () {

        StartGame();
		
	}

    void StartGame()
    {
        max = 1000;
        min = 1;
        guess = 500;
        max = max + 1;
        print("==========================");
        print(" Welcome to Number Wizard ");
        print("Guess a number in your mind and don't tel me");


        print("The highest number you can pick is  -- " + max);
        print("The lowest number you can pick is  -- " + min);

        print("Is the number highr or lower than -- " + guess);
        print("Use Up Arrow for higher -- Down Arrow for lower -- Enter for equals");
    }
	
    void NextGuess()
    {
        guess = (min + max) / 2;
        print("-- Higher or Lower than -- " + guess);
        print("Use Up Arrow for higher -- Down Arrow for lower -- Enter for equals");


    }
    // Update is called once per frame
    void Update () {

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            //print("Up Arrow is Pressed");
            min = guess;
            NextGuess();
        }

        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            //print("Down Arrow is Pressed");
            max = guess;
            NextGuess();
        }

        else if(Input.GetKeyDown(KeyCode.Return))
        {
            print("I Won!");
            StartGame(); 
        }
		
	}
}
