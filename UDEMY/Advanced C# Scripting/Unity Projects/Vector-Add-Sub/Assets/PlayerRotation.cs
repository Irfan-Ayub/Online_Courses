using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {

    public Transform thisTransform = null;
    public Transform targetTransform = null;

    public float rotSpeed = 90.0f;

    private void Awake()
    {
        thisTransform = gameObject.GetComponent<Transform>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //thisTransform.rotation = Quaternion.LookRotation(thisTransform.position - targetTransform.position, Vector3.up);
        

    }


}
