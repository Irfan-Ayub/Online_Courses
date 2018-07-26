using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Ball
/// </summary>
public class Ball : IntEventInvoker {

    // RigidBody2D attached to te Ball
    Rigidbody2D rb2D;

    // Timer component for the Life span of the Ball
    Timer lifeTimer;

    // Timer for the Pause in The Ball movement
    Timer moveTimer;

    //Timer for the SpeedupEffect
    Timer speedupTimer;

    // holds if the SpeedUp effect is Activated
    bool isSpeeding = false;

	// Use this for initialization
	void Start () {

        // Gets the Timer Component , Sets the Duration and Runs the Timer
        lifeTimer = gameObject.AddComponent<Timer>();
        lifeTimer.Duration = ConfigurationUtils.BallLifeTime;
        lifeTimer.Run();
        lifeTimer.AddTimerFinishedEventListener(HandleLifeTimeTimerFinishedEvent);

        // Move timer
        moveTimer = gameObject.AddComponent<Timer>();
        moveTimer.Duration = 1.0f;
        moveTimer.Run();
        moveTimer.AddTimerFinishedEventListener(HandleMoveTimerFinishedEvent);

        // Speedup Timer
        speedupTimer = gameObject.AddComponent<Timer>();
        speedupTimer.AddTimerFinishedEventListener(HandleSpeedupTimerFinishedEvent);



        // Gets the RigidBody2D component and Adds the Force to the Ball
        rb2D = gameObject.GetComponent<Rigidbody2D>();

        EventManager.AddSpeedupEventListener(HandleSpeedupEffectActivatedEvent);

        unityEvents.Add(EventName.BallDiappearedEvent, new BallDiappearedEvent());
        EventManager_New.AddInvoker(EventName.BallDiappearedEvent, this);

	}
	
	// Update is called once per frame
	void Update () {

	}

    void StartMoving()
    {
        moveTimer.Stop();
        //Debug.Log("Move Timer Finished");
        //if(rb2D.velocity == Vector2.zero)
        if(EffectUtils.SpeedupEffectIsActive)
        {
            Debug.Log("Speeding is Already active");
            rb2D.AddForce(new Vector2(0.0f, -ConfigurationUtils.BallImpulseForce * 2.0f), ForceMode2D.Impulse);
        }

        else
        {
            rb2D.AddForce(new Vector2(0.0f, -ConfigurationUtils.BallImpulseForce), ForceMode2D.Impulse);
        }

    }

    // Spawns the Ball when ball goes out fo the screen
    private void OnBecameInvisible()
    {
        //Debug.Log("Became Invisible " + gameObject.transform.position.x + "--" + ScreenUtils.ScreenBottom);

        if(gameObject.transform.position.y < ScreenUtils.ScreenBottom)
        {
            //Debug.Log(ScreenUtils.ScreenBottom);
            //Camera.main.GetComponent<BallSpawner>().SpawnBallPrefab(1);
            unityEvents[EventName.BallDiappearedEvent].Invoke(1);
            //HUD.BallDisappeared();
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Sets The Direction of the movement of the ball
    /// </summary>
    /// <param name="direction">a Vector2 as a Direction </param>
    public void SetDirection(Vector2 direction)
    {
        float speed = rb2D.velocity.magnitude;
        Vector2 newVelocity = direction * speed;
        rb2D.velocity = newVelocity;

    }


    void HandleSpeedupEffectActivatedEvent(float duration , float factor)
    {
        if(!isSpeeding)
        {
            //Debug.Log("Speeding Activated");
            isSpeeding = true;
            speedupTimer.Duration = ConfigurationUtils.SpeedupDuration;
            speedupTimer.Run();

            rb2D.velocity *= ConfigurationUtils.SpeedupFactor;
            //Debug.Log(rb2D.velocity);
        }
        else
        {
            //Debug.Log("Speeding Duration Increased");
            speedupTimer.AddDuration(ConfigurationUtils.SpeedupDuration);
        }

    }

    void HandleLifeTimeTimerFinishedEvent()
    {
        //Debug.Log("Life Timer Finished");
        //Camera.main.GetComponent<BallSpawner>().SpawnBallPrefab();
        unityEvents[EventName.BallDiappearedEvent].Invoke(1);
        Destroy(gameObject);
    }

    void HandleMoveTimerFinishedEvent()
    {
        StartMoving();
    }

    void HandleSpeedupTimerFinishedEvent()
    {
        //Debug.Log("Speeding is Over");
        isSpeeding = false;
        rb2D.velocity /= ConfigurationUtils.SpeedupFactor;
    }
}

