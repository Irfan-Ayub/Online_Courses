using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    /// <summary>
    /// This is the Spawner Script for Asteroid
    /// </summary>

    [SerializeField]
    GameObject prefabAsteroid;

	// Use this for initialization
	void Start () {

        ScreenUtils.Initialize();

        Vector3 asteroidPosition;
        // Spawn Asteroid on Left
        asteroidPosition = new Vector3(ScreenUtils.ScreenLeft, 0, 0);
        SpawnAsteroid(Direction.Right, asteroidPosition);

        // Spawn Asteroid on Right
        asteroidPosition = new Vector3(ScreenUtils.ScreenRight, 0, 0);
        SpawnAsteroid(Direction.Left, asteroidPosition);

        // Spawn Asteroid on Up
        asteroidPosition = new Vector3(0, ScreenUtils.ScreenTop, 0);
        SpawnAsteroid(Direction.Down, asteroidPosition);

        // Spawn Asteroid on Down
        asteroidPosition = new Vector3(0, ScreenUtils.ScreenBottom, 0);
        SpawnAsteroid(Direction.Up, asteroidPosition);
    }

    void SpawnAsteroid(Direction direction , Vector3 position)
    {
        GameObject asteroid = Instantiate(prefabAsteroid, Vector3.zero, Quaternion.identity);
        asteroid.GetComponent<Asteroid>().Initialize(direction, position);
    }

}
