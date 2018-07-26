using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A ship
/// </summary>
public class Ship : MonoBehaviour
{
    // thrust and rotation support
    Rigidbody2D rb2D;
    Vector2 thrustDirection = new Vector2(1, 0);
    const float ThrustForce = 10;
    const float RotateDegreesPerSecond = 180;

    [SerializeField]
    private GameObject prefabBullet;
 

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
		// saved for efficiency
        rb2D = GetComponent<Rigidbody2D>();

    }
	
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
        // check for rotation input
        float rotationInput = Input.GetAxis("Rotate");
        if (rotationInput != 0) {

            // calculate rotation amount and apply rotation
            float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
            if (rotationInput < 0) {
                rotationAmount *= -1;
            }
            transform.Rotate(Vector3.forward, rotationAmount);

            // change thrust direction to match ship rotation
            float zRotation = transform.eulerAngles.z * Mathf.Deg2Rad;
            thrustDirection.x = Mathf.Cos(zRotation);
            thrustDirection.y = Mathf.Sin(zRotation);
        }

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            // Instantiate the Bullet from the center of the ship
            // Apply force to the Bullet in the direction the ship is facing
            GameObject bullet = Instantiate(prefabBullet, gameObject.transform.position, gameObject.transform.rotation);
            bullet.GetComponent<Bullet>().ApplyForce(thrustDirection);

            //Play the Fire Sound
            AudioManager.Play(AudioClipName.PlayerShot);
        }
	}

    /// <summary>
    /// FixedUpdate is called 50 times per second
    /// </summary>
    void FixedUpdate()
    {
        // thrust as appropriate
        if (Input.GetAxis("Thrust") != 0)
        {
            rb2D.AddForce(ThrustForce * thrustDirection,
                ForceMode2D.Force);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Asteroid")
        {
            GameObject.FindObjectOfType<HUD>().StopGameTimer();
            
            // Play the Death Sound
            AudioManager.Play(AudioClipName.PlayerDeath);
            Destroy(gameObject);
        }
    }

}
