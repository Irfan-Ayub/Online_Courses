using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float standingThreshold;
    public float distanceToRaise = 40f;

    private Rigidbody rigidBody;


    // Use this for initialization
    void Start () {

        rigidBody = gameObject.GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(gameObject.name + " -- " + IsStanding());
		
	}

    public bool IsStanding()
    {

        Vector3 rotationInEuler = gameObject.transform.rotation.eulerAngles;
        float tiltX = Mathf.Abs(270 - rotationInEuler.x);
        float tiltZ = Mathf.Abs(rotationInEuler.z);

        if (tiltX < standingThreshold && tiltZ < standingThreshold)
        { return true; }

        else
        { return false; }

    }

    public void RaiseIfStanding()
    {
        if(IsStanding())
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(270, 0, 0));
            gameObject.transform.Translate(new Vector3(0, distanceToRaise, 0), Space.World);
            rigidBody.useGravity = false;
        }
    }


    public void Lower()
    {
        if (IsStanding())
        {
            gameObject.transform.Translate(new Vector3(0, -distanceToRaise, 0), Space.World);
            rigidBody.useGravity = true;
        }
    }

}
