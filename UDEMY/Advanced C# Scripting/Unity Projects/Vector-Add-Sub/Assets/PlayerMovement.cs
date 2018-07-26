using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerMovement : MonoBehaviour {

    public float maxSpeed = 10.0f;
    public float rotSpeed = 5.0f;
    public Transform thisTransform = null;

    void Awake()
    {
        thisTransform = gameObject.GetComponent<Transform>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float horz = CrossPlatformInputManager.GetAxis("Horizontal");
	}
}
