using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torque : MonoBehaviour {

    public Vector3 torque;
    public float torqurTime;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {

        if(torqurTime >= 0)
        {
            rb.AddTorque(torque);
            torqurTime -= Time.deltaTime;
        }

    }
}
