using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public float health = 150;
    public GameObject laserProjectile;
    public float fireFrequency = 0.5f;
    public int scoreValue = 150;
    public AudioClip laserAudio;
    public AudioClip dieAudio;

    private ScoreScript scoreScript;

	// Use this for initialization
	void Start () {

        scoreScript = GameObject.Find("Score Text").GetComponent<ScoreScript>();
	}
	  
	// Update is called once per frame
	void Update () {

        float probability = Time.deltaTime * fireFrequency;
        if (Random.value < probability)
        { FireLaser(); }
	}

    void FireLaser()
    {
        Instantiate(laserProjectile, gameObject.transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(laserAudio, transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerLaser")
        {
            LaserProjectile laser = collision.gameObject.GetComponent<LaserProjectile>();
            if(laser)
            {
                health -= laser.GetDamage();
                laser.Hit();

                if(health <= 0)
                {
                    Die();
                }
            }
            //Debug.Log("Hit by Player Laser");
        }
    }

    private void Die()
    {
        scoreScript.AddScore(scoreValue);
        AudioSource.PlayClipAtPoint(dieAudio, transform.position);
        Destroy(this.gameObject);
    }
}
