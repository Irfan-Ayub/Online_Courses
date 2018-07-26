using UnityEngine;
using UnityEditor; // this is needed since this script references the Unity Editor

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor {

    public override void OnInspectorGUI()
    {
        // show the default inspector stuff for this component
        DrawDefaultInspector();

        // get the reference to the GameMAnager script on this target gameObject
        GameManager myGM = (GameManager)target;

        // add a custom button to the Inspector
        if(GUILayout.Button("Reset Player State"))
        {
            PlayerPrefManager.ResetPlayerState(myGM.startLives, false);
        }

        // add a custom button to the Inspector
        if (GUILayout.Button("Reset HighScore"))
        {
            PlayerPrefManager.SetHighscore(0);
        }

        // add a custom button to the Inspector
        if (GUILayout.Button("Output Player State"))
        {
            PlayerPrefManager.ShowPlayerPrefs();

        }
    }
}
