using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelTime;

    private void Start()
    {
        if(autoLoadNextLevelTime <= 0)
        { //Debug.Log("Auto Load Level Disabled -- Use the Positive Number is Seconds");
        }
        else
        { Invoke("LoadNextLevel", autoLoadNextLevelTime); }            
    }

    public void LoadLevel(string name){
		//Debug.Log ("New Level load: " + name);
        SceneManager.LoadScene(name);
	}

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

}
