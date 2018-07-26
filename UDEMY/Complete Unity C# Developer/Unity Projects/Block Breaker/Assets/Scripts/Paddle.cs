using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;
    public float minPosValue, maxPosValue;

    Ball ball;
	// Use this for initialization
	void Start () {

        ball = GameObject.FindObjectOfType<Ball>();
		
	}
	
	// Update is called once per frame
	void Update () {

        if(!autoPlay) { MoveWithMouse(); }
        else { AutoPlay(); }
        
	}

    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, minPosValue, maxPosValue);
        this.transform.position = paddlePos;
    }

    void MoveWithMouse()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        // calculates the MousePositon w.r.t screenWidth
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16; // /16 -> number of total brick can be placed in a row
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, minPosValue, maxPosValue);
        this.transform.position = paddlePos;
    }
}