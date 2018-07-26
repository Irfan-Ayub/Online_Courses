using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerVoice : MonoBehaviour {

    public AudioClip whatHappened;
    public AudioClip goodLandingArea;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {

        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = whatHappened;
        audioSource.Play();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnFindClearArea()
    {
        audioSource.clip = goodLandingArea;
        audioSource.Play();

        Invoke("CallHeli", goodLandingArea.length + 1f);
    }

    void CallHeli()
    {
        SendMessageUpwards("OnMakeInitialHeliCall");
    }
}
