using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

    public int starCost = 100;

    private StarsCount starsCountDisplay;
    // being used as a tag in attackers class

    private void Start()
    {
        starsCountDisplay = GameObject.FindObjectOfType<StarsCount>();
    }
    void AddStars(int amount)
    {
        starsCountDisplay.AddStars(amount);
    }
}
