using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    /// <summary>
    /// Loads the scene passed as a string
    /// </summary>
    /// <param name="name"></param>
    public void LoadScene(string name)
    {
        Debug.Log("Loading Scene Name -- " + name);
        Brick.breakableCount = 0;
        SceneManager.LoadScene(name);
    }

    // to exit/quit the application/game
    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Loads the Next level (Scene on the next Index in the Build Setting)
    /// </summary>
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Checks if all the brick in the scene are destroyed or not.
    /// Checks if the level is complete or not
    /// If the level is complete loads the next level
    /// </summary>
    public void BrickDestroyed()
    {
        if(Brick.breakableCount <= 0)
        {
            LoadNextLevel();
        }
    }
}
