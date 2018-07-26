using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public AudioClip audioClip;
    /// <summary>
    /// Array of the brick sprites to be loaded when a hit is occured
    /// </summary>
    public Sprite[] hitSprites;
    /// <summary>
    /// Total number of Breakable Bricks currently active in the scene
    /// </summary>
    public static int breakableCount = 0;
    public GameObject smokeParticle;

    private int timesHit; // the hit count on this brick
    private LevelManager levelManager;
    private bool isBreakable; // the flag to check if this brick is breakable or not

    // Use this for initialization
    void Start () {

        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            breakableCount++; // increment for every active Brick loaded in the scene
            //print(breakableCount);
        }

        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    // called when the collision is occured to this GameObject
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(audioClip , transform.position , 0.25f);
        if(isBreakable) { HandleHits(); }
    }

    // To Handle the hits and the funcionality of the hits on this Brick 
    void HandleHits()
    {
        int maxHits = hitSprites.Length + 1;
        timesHit++; // incrementing the hits count on this brick
        if (timesHit >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();

            //print(breakableCount);
            InstantiateSmokeParticles();
            Destroy(gameObject);
        }
        else { LoadSprites(); }
    }

    void InstantiateSmokeParticles()
    {
        GameObject smoke = GameObject.Instantiate(smokeParticle, gameObject.transform.position, Quaternion.identity) as GameObject;
        ParticleSystem.MainModule settings = smoke.GetComponent<ParticleSystem>().main;
        settings.startColor = new ParticleSystem.MinMaxGradient(gameObject.GetComponent<SpriteRenderer>().color);
    }
 
    // To Handle the sprites loaded on every hit on this brick
    void LoadSprites()
    {
        int spriteIndex = timesHit - 1; // minus 1 because the timesHit = hitSprites.Length + 1
        if(hitSprites[spriteIndex])
        {
            // loading the sprite from the hitSprites array 
            // using the hitsCount ad the index for the sprite to be loaded.

            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }

        else { Debug.LogError("Sprite Missing at the Index -- " + spriteIndex); }
        
    }

    // a dummy function to Simlate the WIN funcitonality
    void SimulateWin()
    {
        levelManager.LoadNextLevel();
      
    }


}
