using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {

    public float maxLaunchSpeed;
    public AudioClip windUpSound, launchSound;
    public PhysicsEngine ballToLaunch;

    public float launchSpeed;

    private AudioSource audioSource;
    private float extraSpeedPerFrame;


	// Use this for initialization
	void Start () {

        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = windUpSound; // to know the length of the clip;
        extraSpeedPerFrame = (maxLaunchSpeed * Time.fixedDeltaTime) / audioSource.clip.length;
        	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        // Increase Ball speed to max over a few seconds //
        launchSpeed = 0;
        InvokeRepeating("IncreaseLauchSpeed", 0.5f, Time.fixedDeltaTime);
        audioSource.clip = windUpSound;
        audioSource.Play();
    }

    private void OnMouseUp()
    {
        // Launch the Ball
        CancelInvoke();

        audioSource.Stop();
        audioSource.clip = launchSound;
        audioSource.Play();

        PhysicsEngine newBall = Instantiate(ballToLaunch) as PhysicsEngine;
        newBall.transform.SetParent(GameObject.Find("Launched Balls").transform);
        Vector3 launchVelocity = new Vector3(1, 1, 0).normalized * launchSpeed;
        newBall.velocityVector = launchVelocity;
    }

    void IncreaseLauchSpeed()
    {
        if(launchSpeed <= maxLaunchSpeed)
        {
            launchSpeed += extraSpeedPerFrame;
        }
    }
}
