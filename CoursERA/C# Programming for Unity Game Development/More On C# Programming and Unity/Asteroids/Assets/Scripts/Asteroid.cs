using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    /// <summary>
    /// this is the script for Asteroid GameObject
    /// </summary>

    [SerializeField]
    Sprite[] asteroidSprites = new Sprite[3];

	// Use this for initialization
	void Start () {

        //// pick a random sproite for the asteroid and assign it to Asteroid
        //Sprite randomSprite = asteroidSprites[Random.Range(0, 3)];
        //gameObject.GetComponent<SpriteRenderer>().sprite = randomSprite;    


        //// apply impulse force to get game object moving
        //const float MinImpulseForce = 3f;
        //const float MaxImpulseForce = 5f;

        //float angle = Random.Range(0, 2 * Mathf.PI);

        //Vector2 direction = new Vector2(
        //    Mathf.Cos(angle), Mathf.Sin(angle));
        
        //float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);

        //GetComponent<Rigidbody2D>().AddForce(
        //    direction * magnitude,
        //    ForceMode2D.Impulse);
		
	}

    public void Initialize(Direction direction , Vector3 position)
    {
        // Set the position of the asteroid
        gameObject.transform.position = position;

        // pick a random sproite for the asteroid and assign it to Asteroid
        Sprite randomSprite = asteroidSprites[Random.Range(0, 3)];
        gameObject.GetComponent<SpriteRenderer>().sprite = randomSprite;
    

        float angle = Random.Range(0, 30 * Mathf.Deg2Rad);
        
        // set the anlge according to the direction
        switch(direction)
        {
            case Direction.Up:
                angle += 75 * Mathf.Deg2Rad;
                break;
            case Direction.Down:
                angle += -75 * Mathf.Deg2Rad;
                break;
            case Direction.Left:
                break;
            case Direction.Right:
                angle += 165 * Mathf.Deg2Rad;
                break;

        }

        StartMoving(angle);

        
    }

    // to move the Asteroids in a given angle
    public void StartMoving(float angle)
    {

        // apply impulse force to get game object moving
        const float MinImpulseForce = 2f;
        const float MaxImpulseForce = 4f;


        Vector2 moveDirection = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));

        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);

        // Add force to the asteroid gameObject
        GetComponent<Rigidbody2D>().AddForce(
            moveDirection * magnitude,
            ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            // Play the Asteroid Hit Sound
            AudioManager.Play(AudioClipName.AsteroidHit);

            if (transform.localScale.x <= 0.5f)
            {
                //Debug.Log("If condition is True");
                Destroy(gameObject);
            }

            else
            {
                // cut the localScale into half (both x and y)
                Vector3 halfCutScale = transform.localScale;
                halfCutScale.x /= 2;
                halfCutScale.y /= 2;

                transform.localScale = halfCutScale;

                // cut the radius of the collider in half
                gameObject.GetComponent<CircleCollider2D>().radius /= 2;

                // instantiating the gmaeobject twice (for two smaller asteroids)
                GameObject newAsteroid1 = Instantiate(gameObject);
                GameObject newAsteroid2 = Instantiate(gameObject);

                // Start Moving Smaller Asteroids
                newAsteroid1.GetComponent<Asteroid>().StartMoving(Random.Range(0, 2) * Mathf.Deg2Rad);
                newAsteroid2.GetComponent<Asteroid>().StartMoving(Random.Range(0, 2) * Mathf.Deg2Rad);

                // Destroy the original GameObject
                Destroy(gameObject);
            }
            
            

        }


    }

}
