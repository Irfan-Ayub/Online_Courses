using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {


    public GameObject[] attackerPrefabsArray;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        foreach(GameObject thisAttacker in attackerPrefabsArray)
        {
            if(IsTimeToSpawn(thisAttacker))
            { Spawn(thisAttacker); }
        }
		
	}

    void Spawn(GameObject myGameObject)
    {
        GameObject myAttacker = Instantiate(myGameObject, gameObject.transform.position, Quaternion.identity, gameObject.transform);
    }

    bool IsTimeToSpawn(GameObject attackerGameObject)
    {
        Attacker attackerScript = attackerGameObject.GetComponent<Attacker>();
        float currentTime = Time.deltaTime;

        if(attackerScript)
        {
            float meanSpawnDelay = attackerScript.seenEverySecond;
            float spawnPerSecond = 1 / meanSpawnDelay;

            if (Time.deltaTime > meanSpawnDelay)
            {
                Debug.LogWarning("Spawn Rate Capped by Frame Rate");
            }

            float threshold = spawnPerSecond * Time.deltaTime / 5;

            //Debug.Log("Threshold -- " + threshold);

            return (Random.value < threshold);
          
        }

            return false;
    }
}
