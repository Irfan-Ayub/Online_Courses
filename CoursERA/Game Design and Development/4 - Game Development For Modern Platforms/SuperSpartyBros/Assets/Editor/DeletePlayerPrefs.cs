using UnityEditor;
using UnityEngine;

public class DeletePlayerPrefs : ScriptableObject {


    [MenuItem("Editor/Delete All Player Prefs")]
    static void DeletePrefs()
    {
        if (EditorUtility.DisplayDialog("Delete All Player Prefs?", "Are You Sure", "Yes", "No"))
            PlayerPrefs.DeleteAll();
    }
}
