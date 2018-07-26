using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidDrag : MonoBehaviour {

    [Range(1f, 2f)]
    public float velocityExponent;

    public float dragConstant;

    private PhysicsEngine physicsEgine;


	// Use this for initialization
	void Start () {

        physicsEgine = gameObject.GetComponent<PhysicsEngine>();
		
	}

    private void FixedUpdate()
    {
        Vector3 velocityVector = physicsEgine.velocityVector;
        float speed = velocityVector.magnitude;

        float dragSize = CalculateDrag(speed);

        Vector3 dragVector = dragSize * -velocityVector.normalized;

        physicsEgine.AddForces(dragVector);
    }

    float CalculateDrag(float speed)
    {
        return dragConstant * Mathf.Pow(speed, velocityExponent);
    }
}