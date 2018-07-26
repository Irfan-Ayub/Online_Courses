using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarsCount : MonoBehaviour {

    private Text starsCountText;
    private int currentStarsCount = 100;

    public enum Status { SUCESS, FAILURE };

	// Use this for initialization
	void Start () {

        starsCountText = gameObject.GetComponent<Text>();
        UpdateStarsCountText();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddStars(int amount)
    {
        currentStarsCount += amount;
        UpdateStarsCountText();
    }

    public Status UseStars(int amount)
    {
        if (currentStarsCount >= amount)
        {
            currentStarsCount -= amount;
            UpdateStarsCountText();
            return Status.SUCESS;
        }

        return Status.FAILURE;
    }

    private void UpdateStarsCountText()
    {
        starsCountText.text = currentStarsCount.ToString();
    }
}
