using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    private Vector3 paddleToBallVector;
    private bool hasStarted = false;
    private Rigidbody2D rb2D = null;
    private AudioSource audioSource = null;

	// Use this for initialization
	void Start () {

        paddle = GameObject.FindObjectOfType<Paddle>();

        rb2D = gameObject.GetComponent<Rigidbody2D>();
        audioSource = gameObject.GetComponent<AudioSource>();

        // caluclate the distance between the Ball and the Paddle
        paddleToBallVector = this.transform.position - paddle.transform.position;
        
        //print(paddleToBallVector);
		
	}
	
	// Update is called once per frame
	void Update () {

        if(!hasStarted)
        {
            // Lock the ball relative to the paddle
            this.transform.position = paddle.transform.position + paddleToBallVector;

            // wait for the user to click
            if(Input.GetMouseButtonDown(0))
            {
                print("Mouse Clicked , Launch Ball");
                hasStarted = true;
                rb2D.velocity = new Vector2(5.0f, 10.0f);
            }

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));

        if (hasStarted)
        {
            rb2D.velocity += velocityTweak;
            //Debug.Log("Collision Enter on Ball");
            audioSource.Play();
        }
        
    }
}
