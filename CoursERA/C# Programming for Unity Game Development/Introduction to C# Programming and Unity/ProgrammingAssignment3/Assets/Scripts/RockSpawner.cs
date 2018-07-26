using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour {


    [SerializeField]
    GameObject prefabRock;

    [SerializeField]
    Sprite[] rockSprites;

    [SerializeField]
    float rockSpawnTime;

    Timer spawnTimer;

    // Use this for initialization
    void Start () {

        // Set and start the Timer
        spawnTimer = gameObject.GetComponent<Timer>();
        spawnTimer.Duration = rockSpawnTime;
        spawnTimer.Run();
		
	}
	
	// Update is called once per frame
	void Update () {

        if(spawnTimer.Finished)
        {
            Debug.Log("Time Out!");
            if(CanSpawnRock)
            {
                SpawnRock();
            }
            
            spawnTimer.Duration = rockSpawnTime;
            spawnTimer.Run();
        }
		
	}

    void SpawnRock()
    {
        GameObject rock = Instantiate(prefabRock) as GameObject;
        rock.transform.position = new Vector3(0, 0, -Camera.main.transform.position.z);

        SpriteRenderer rockSpriteRenderer = rock.GetComponent<SpriteRenderer>();
        rockSpriteRenderer.sprite = rockSprites[Random.Range(0, 3)];
        
    }

    bool CanSpawnRock
    {
        get
        {
            return (GameObject.FindGameObjectsWithTag("Rock").Length) < 3;
        }
    }
}
