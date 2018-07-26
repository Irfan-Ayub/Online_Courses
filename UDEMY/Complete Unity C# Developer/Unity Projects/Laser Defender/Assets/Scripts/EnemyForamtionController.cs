using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyForamtionController : MonoBehaviour {

    public GameObject enemyPrefab = null;
    public float width = 10.0f;
    public float height = 10.0f;
    public float movementSpeed = 10.0f;
    public float enemySpawnDelay = 0.1f;

    bool movingRight = false;
    float xMinPosition;
    float xMaxPosition;

    // Use this for initialization
    void Start () {

        GetWorldSpaceBourdaries();
        SpawnEnemyOneByOne();
    }
	
	// Update is called once per frame
	void Update () {

        MoveFormation();

        if(AllMembersDead())
        {
            Debug.Log("All Enemies Are Dead");
            SpawnEnemyOneByOne();
        }
	}

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }

    bool AllMembersDead()
    {
        foreach(Transform childPositionGameObject in transform)
        {
            if(childPositionGameObject.childCount > 0)
            { return false; }
        }

        return true;
    }

    void SpawnEnemyFormation()
    {
        foreach (Transform child in transform)
        {
            Instantiate(enemyPrefab, child.position, Quaternion.identity, child);
        }
    }

    void SpawnEnemyOneByOne()
    {
        //Debug.Log("Spawning Enemies");
        Transform freePosition = GetNextFreePosition();
        if(freePosition)
        {
           Instantiate(enemyPrefab, freePosition.position, Quaternion.identity , freePosition);
        }

        if (GetNextFreePosition())
        {
            //Debug.Log("Got a New Position");
            Invoke("SpawnEnemyOneByOne", enemySpawnDelay);
        }
    }

    Transform GetNextFreePosition()
    {
        foreach(Transform childPositionGameObject in transform)
        {
            //Debug.Log("Checking Free Position at " + childPositionGameObject.name);
            if (childPositionGameObject.childCount == 0)
            { return childPositionGameObject; }
        }

        return null;
    }

    void MoveFormation()
    {
        if(movingRight)
        {
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
        }

        float rightMostEdge = transform.position.x + (0.5f * width);
        float leftMostEdge = transform.position.x - (0.5f * width);

        if (leftMostEdge < xMinPosition)
        { movingRight = true; }
        else if (rightMostEdge > xMaxPosition)
        { movingRight = false; }
    }

    void GetWorldSpaceBourdaries()
    {
        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;

        // to calculate the leftMost and the rightMost points (boundaries) of the screen
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));

        xMinPosition = leftMost.x;
        xMaxPosition = rightMost.x;
    }


}
