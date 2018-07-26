using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenController : MonoBehaviour {

    public string startSceneName = "";
	// Use this for initialization
	void Start () {
        //print("Scene Count: " + SceneManager.sceneCountInBuildSettings);
        Invoke("LoadStartScene" , 3.0f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadStartScene()
    {
        SceneManager.LoadScene(startSceneName);
    }
}
