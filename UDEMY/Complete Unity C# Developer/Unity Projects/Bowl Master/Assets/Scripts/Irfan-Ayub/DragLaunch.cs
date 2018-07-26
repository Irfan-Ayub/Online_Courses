using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour {
    
    private Ball ball;
    private float dragStartTime, dragEndTime;
    private Vector3 dragStartPosition, dragEndPosition;

	// Use this for initialization
	void Start () {

        ball = gameObject.GetComponent<Ball>();
		
	}
	
    public void DragStart()
    {
        // capture time and position of drag start
        dragStartPosition = Input.mousePosition;
        dragStartTime = Time.time;
    }

    public void DragEnd()
    {
        if(!ball.inPlay)
        {
            // launch Ball
            dragEndPosition = Input.mousePosition;
            dragEndTime = Time.time;
            float dragTime = dragEndTime - dragStartTime;

            float currentDragX = (dragEndPosition.x - dragStartPosition.x) / dragTime;
            float currentDragZ = (dragEndPosition.y - dragStartPosition.y) / dragTime;

            Vector3 launchVector = new Vector3(currentDragX, 0.0f, currentDragZ);
            ball.Launch(launchVector);
        }
        
    }

    public void MoveStart(float xNudge)
    {
        if(!ball.inPlay)
        {
            float xPos = Mathf.Clamp(ball.transform.position.x + xNudge, -40, 40);
            float yPos = ball.transform.position.y;
            float zPos = ball.transform.position.z;

            ball.transform.position = new Vector3(xPos, yPos, zPos);
        }
    }
}
