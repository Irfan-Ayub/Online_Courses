using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour {

    public Image fadePanel;
    public float fadeSpeed = 1.5f;
    public bool sceneStarting = true;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(sceneStarting)
        { StartScene(); }
		
	}

    void FadeToClear()
    {
        // Lerp the colour of the image between itself and transparent.
        fadePanel.color = Color.Lerp(fadePanel.color, Color.clear, fadeSpeed * Time.deltaTime);
    }


    void FadeToBlack()
    {
        // Lerp the colour of the image between itself and black.
        fadePanel.color = Color.Lerp(fadePanel.color, Color.black, fadeSpeed * Time.deltaTime);
    }


    void StartScene()
    {
        // Fade the texture to clear.
        FadeToClear();

        // If the texture is almost clear...
        if (fadePanel.color.a <= 0.05f)
        {
            // ... set the colour to clear and disable the RawImage.
            fadePanel.color = Color.clear;
            fadePanel.enabled = false;

            // The scene is no longer starting.
            sceneStarting = false;
        }
    }
}
