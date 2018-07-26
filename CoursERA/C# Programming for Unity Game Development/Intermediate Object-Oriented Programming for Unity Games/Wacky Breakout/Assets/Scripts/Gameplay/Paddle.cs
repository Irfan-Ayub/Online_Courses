using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Paddle
/// </summary>

public class Paddle : MonoBehaviour {



    // RigidBody2D attached to Paddle
    Rigidbody2D rb2D;

    // Half of the collider width
    float halfColliderWidth;
    float halfColliderHieght;

    //holds the angle of the ball bounce
    const float BounceAngleHalfRange = 60.0f * Mathf.Deg2Rad;

    //holds if the paddle is frozen of or not
    bool isFrozen = false;

    //holds the Starting time for the Freezing Effect;
    float freezeStartTime;

    Timer freezeTimer;

    // Use this for initialization
    void Start () {

        //Get the RigidBody2D component of the Paddle
        rb2D = gameObject.GetComponent<Rigidbody2D>();

        // Calculate the half of the Collider Width
        halfColliderWidth = gameObject.GetComponent<BoxCollider2D>().size.x / 2;

        // Calculate the half of the Collider Height
        halfColliderHieght = gameObject.GetComponent<BoxCollider2D>().size.y / 2;

        // Adding listener for the HandleFreezerEffectActivatedEvent
        EventManager.AddFreezerEventListener(HandleFreezerEffectActivatedEvent);

        // Gets the Timer component for the freezeTimer
        freezeTimer = gameObject.GetComponent<Timer>();

    }

    // Update is called once per frame
    void Update () {
        if(freezeTimer.Finished)
        {
            isFrozen = false;
        }
		
	}

    // called every fixed time peroid
    private void FixedUpdate()
    {
        if (!isFrozen)
        {
            Vector2 velocity = new Vector2(ConfigurationUtils.PaddleMoveUnitsPerSecond * Input.GetAxis("Horizontal"), 0.0f);
            //rb2D.MovePosition(movePosition);

            rb2D.MovePosition(new Vector2(CalculateClampedX(rb2D.position.x + velocity.x * Time.fixedDeltaTime), rb2D.position.y));
        }
    }

    // Calculate the new possible x-position for the Paddle
    // if the paddle is going out of the screen (clamp it in the screen)
    float CalculateClampedX(float xPosition)
    {
        if ((xPosition - halfColliderWidth) < ScreenUtils.ScreenLeft)
        {
            //Debug.Log("Left");
            return ScreenUtils.ScreenLeft + halfColliderWidth;
        }

        else if ((xPosition + halfColliderWidth) > ScreenUtils.ScreenRight)
        {
            //Debug.Log("Right");
            return ScreenUtils.ScreenRight - halfColliderWidth;
        }

        return xPosition;
    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball") && BallHitOnTop(coll.collider))
        {
            //Debug.Log("Ball Collision");
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                halfColliderWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }

    // Calculates if th eball is hit on the top of the Paddle
    bool BallHitOnTop(Collider2D other)
    {
        float ballPosition = other.transform.position.y - other.gameObject.GetComponent<BoxCollider2D>().size.y;
        //Debug.Log(ballPosition);

        float paddlePosition = gameObject.transform.position.y + halfColliderHieght;
        //Debug.Log(paddlePosition);

        //Debug.Log(paddlePosition - ballPosition);
        if (paddlePosition - ballPosition <= 0.4)
        {
            //Debug.Log("Ball Hit On Top");
            return true;
        }

        return false;
    }

    // Handles the FreezeEffectActivated Event
    void HandleFreezerEffectActivatedEvent(float duration)
    {
        //Debug.Log("Frozen");
        // if the Paddle is not Frozen already
        if(!isFrozen)
        {
            isFrozen = true;
            freezeTimer.Duration = ConfigurationUtils.FreezeDuration;
            freezeTimer.Run();
        }
        else // if the paddle is already frozen (Increases the time for freezeTimer)
        {
            freezeTimer.AddDuration(ConfigurationUtils.FreezeDuration);
        }
    }
}
