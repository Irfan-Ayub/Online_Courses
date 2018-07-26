using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {


    static MusicPlayer instance = null;

    #region Singleton Pattern
    private void Awake()
    {
        Debug.Log("Music Player Awake -- " + GetInstanceID());

        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("Destroying duplicate instance");
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    #endregion

    // Use this for initialization
    void Start () {
        Debug.Log("Music Player Start -- " + GetInstanceID());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
