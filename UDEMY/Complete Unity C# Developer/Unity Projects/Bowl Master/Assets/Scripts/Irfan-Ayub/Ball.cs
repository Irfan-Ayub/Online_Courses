using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Vector3 launchSpeed;
    public bool inPlay = false;

    private Rigidbody rigidBody;
    private AudioSource audioSource;
    private Vector3 ballStartPosition;


	// Use this for initialization
	void Start ()
    {

        ballStartPosition = gameObject.transform.position;
        rigidBody = gameObject.GetComponent<Rigidbody>();
        audioSource = gameObject.GetComponent<AudioSource>();

        rigidBody.useGravity = false;
        //Launch(launchSpeed);

    }

    public void Launch(Vector3 velocity)
    {
        inPlay = true;
        rigidBody.useGravity = true;
        rigidBody.velocity = velocity;
        audioSource.Play();
        
    }

    public void Reset()
    {
        //Debug.Log("Resetting Ball");
        inPlay = false;
        rigidBody.useGravity = false;
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
        gameObject.transform.rotation = Quaternion.identity;
        gameObject.transform.position = ballStartPosition;
    }


}
