using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearArea : MonoBehaviour {

    float timeSinceLastTrigger;
    bool foundClearArea = false;

	// Update is called once per frame
	void Update () {

        timeSinceLastTrigger += Time.deltaTime;

        if (timeSinceLastTrigger > 1.0f && Time.realtimeSinceStartup > 10 && !foundClearArea)
        {
            SendMessageUpwards("OnFindClearArea");
            foundClearArea = true;
        }
		
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.tag != "Player")
        {
            Debug.Log("Clear Area Trigger");
            timeSinceLastTrigger = 0.0f;
        }
            
    }
}
