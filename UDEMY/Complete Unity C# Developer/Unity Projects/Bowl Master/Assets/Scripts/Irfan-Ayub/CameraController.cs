using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Ball ball;

    private Vector3 offset;

	// Use this for initialization
	void Start () {

        offset = gameObject.transform.position - ball.transform.position;

        //Debug.Log("offset -- " + offset);
		
	}
	
	// Update is called once per frame
	void Update () {

        if (ball.transform.position.z <= 1829.0f)
            gameObject.transform.position = ball.transform.position + offset;
		
	}

    public void ResetCamera()
    {

    }
}
