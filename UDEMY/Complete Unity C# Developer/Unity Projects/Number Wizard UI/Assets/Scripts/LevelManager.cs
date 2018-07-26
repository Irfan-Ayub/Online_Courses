using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {


    public void LoadScene(string name)
    {
        Debug.Log("Scene Name -- " + name);
        SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
