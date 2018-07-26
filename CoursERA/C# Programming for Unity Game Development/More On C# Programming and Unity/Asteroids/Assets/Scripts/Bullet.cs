using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A Bullet
/// </summary>
public class Bullet : MonoBehaviour {

    float deathTimer = 2.0f;
    Timer timer;

	// Use this for initialization
	void Start () {

        timer = gameObject.AddComponent<Timer>();
        timer.Duration = deathTimer;
        timer.Run();
	}
	
	// Update is called once per frame
	void Update () {

        if(timer.Finished)
        {
            Destroy(gameObject);
        }
		
	}

    public void ApplyForce(Vector2 direction)
    {
        float forceMagnitude = 4.0f;

        gameObject.GetComponent<Rigidbody2D>().AddForce(forceMagnitude * direction, ForceMode2D.Impulse);
    }
}
