using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Ball Spawner
/// </summary>

public class BallSpawner : MonoBehaviour {


    // holds the prefab for Ball GameObject
    [SerializeField]
    GameObject prefabBall;

    // holds the Timer component to Randomly Spawn the ball Prefab
    [SerializeField]
    Timer ballSpawnTimer;

    // tells if it should retry the ball spawn or not
    bool retrySpawn = false;

    // ball spawnig Position fields
    Vector2 minSpawnLocation;
    Vector2 maxSpawnLocation;
    Vector2 spawnPosition;

    // half width and height of the ball collider
    float ballColliderHalfWidth;
    float ballColliderHalfHeight;

    // Use this for initialization
    void Start () {

        SetBallSpawnTimer();

        // Calculating the half Collider Width and Height of the Ball
        GameObject tempBall = Instantiate(prefabBall) as GameObject;
        BoxCollider2D ballCollider = tempBall.GetComponent<BoxCollider2D>();
        ballColliderHalfWidth = ballCollider.size.x / 2;
        ballColliderHalfHeight = ballCollider.size.y / 2;

        // Calculating the corners of the instantiated ball (top right and bottom left)
        minSpawnLocation = new Vector2(tempBall.transform.position.x - ballColliderHalfWidth,
                                        tempBall.transform.position.y - ballColliderHalfHeight);

        maxSpawnLocation = new Vector2(tempBall.transform.position.x + ballColliderHalfWidth,
                                        tempBall.transform.position.y + ballColliderHalfHeight);

        // setting the spawn position
        spawnPosition = tempBall.transform.position;
        // destroying the tempBall GameObject
        Destroy(tempBall);

        // spawning the ball
        SpawnBallPrefab(1);

        EventManager_New.AddListener(EventName.BallDiappearedEvent, SpawnBallPrefab);
    }
	
	// Update is called once per frame
	void Update () {

        // retrying the spawnig if the ball is in a colliding area
        if (retrySpawn)
        {
            //Debug.Log("Retrying Spawning");
            SpawnBallPrefab(1);
        }

        // checking if the spawnTimer is finished and then Spawning the ball
        if (ballSpawnTimer.Finished)
        {
            //Debug.Log("Spawn Timer Finished");
            SpawnBallPrefab(1);
            SetBallSpawnTimer();
        }

    }

    /// <summary>
    /// Spawns the Ball Prefab on the calculated Collision Free position
    /// </summary>
    void SpawnBallPrefab(int unused)
    {
        CalculateSpawningPosition();
        //Debug.Log(spawnPosition + " -- " +minSpawnLocation + " -- " + maxSpawnLocation );
        if(Physics2D.OverlapArea(minSpawnLocation , maxSpawnLocation) == null)
        {
            retrySpawn = false;
            //Debug.Log("Ball Spawning " + Time.time);
            Instantiate(prefabBall , spawnPosition , Quaternion.identity);
        }
        else { retrySpawn = true; }

    }

    /// <summary>
    /// Sets the Spawn timer acording the ConfigurationUtils.MinballSpawntime Property
    /// </summary>
    void SetBallSpawnTimer()
    {
        ballSpawnTimer.Duration = Random.Range(ConfigurationUtils.MinBallSpawnTime, ConfigurationUtils.MaxBallSpawnTime);
        ballSpawnTimer.Run();
    }

    /// <summary>
    /// Calculates the collision free position for the Ball Prefab
    /// </summary>
    void CalculateSpawningPosition()
    {
        spawnPosition = new Vector2(
                                    Random.Range(ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight),
                                    Random.Range(ScreenUtils.ScreenTop, ScreenUtils.ScreenBottom * 0.4f));

        minSpawnLocation = new Vector2(
                                    spawnPosition.x - ballColliderHalfWidth,
                                    spawnPosition.y - ballColliderHalfHeight);

        maxSpawnLocation = new Vector2(
                                    spawnPosition.x + ballColliderHalfWidth,
                                    spawnPosition.y + ballColliderHalfHeight);
    }
}
