using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : IntEventInvoker {

    protected int blockScore;

	// Use this for initialization
	protected virtual void Start () {

        unityEvents.Add(EventName.PointsAddedEvent, new PointsAddedEvent());
        EventManager_New.AddInvoker(EventName.PointsAddedEvent, this);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            //HUD.AddScore(blockScore);
            AudioManager.Play(AudioClipName.BockHit);
            unityEvents[EventName.PointsAddedEvent].Invoke(blockScore);
            if(GameObject.FindGameObjectsWithTag("Block").Length == 1)
            {
                MenuManager.GoToMenu(MenuName.GameOver);
            }

            Destroy(gameObject);
        }
    }
}
