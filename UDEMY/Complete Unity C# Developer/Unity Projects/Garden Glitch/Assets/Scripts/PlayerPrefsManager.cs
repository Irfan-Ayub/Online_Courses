using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUMER_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";
    

    public static void SetMasterVolume(float volume)
    {
        if(volume >= 0 && volume <= 1.0f)
        { PlayerPrefs.SetFloat(MASTER_VOLUMER_KEY, volume); }
        else
        { Debug.LogError("Master Volume out of Range"); }
    }

    public static float GetMasterVolume()
    {
       return PlayerPrefs.GetFloat(MASTER_VOLUMER_KEY);
    }

    public static void UnlockLevel(int level)
    {
        if(level <= SceneManager.sceneCountInBuildSettings-1)
        { PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); } // using 1 for true
        else
        { Debug.LogError("Invalid Level Number -- Cannot Unlock Level Number"); }
    }

    public static bool IsLevelUnlock(int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        { return (PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()) == 1); }

        else
        {
            Debug.LogError("Invalid Level Number -- Cannot any Results for this level");
            return false;
        }
    }

    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= 1.0f && difficulty <= 3.0f)
        { PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty); }
        else
        { Debug.LogError("Difficulty out of Range"); }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
}
