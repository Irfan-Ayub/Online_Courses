using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(PhysicsEngine))]
public class RocketEngine : MonoBehaviour {

    PhysicsEngine physicsEngine;

    public float fuelMass; // [kg]
    public float maxThrust; // kN [kg / ms^2 ]

    [Range (0 ,1f)]
    public float thrustPercent; // [none]

    public Vector3 thrustUnitVector; // [none]

    private float currentThrust; // N

	// Use this for initialization
	void Start () {

        physicsEngine = gameObject.GetComponent<PhysicsEngine>();
        physicsEngine.mass += fuelMass;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if(fuelMass > FuelUpdate())
        {
            fuelMass -= FuelUpdate();
            physicsEngine.mass -= FuelUpdate();
            ExtertForce();
        }

        else
        {
            Debug.LogWarning("Out of Rocket Fuel");
        }
        
    }

    float FuelUpdate()
    {
        float exhaustMassFlow;          // [
        float effectiveExhaustVelocity; // [

        effectiveExhaustVelocity = 4462f; // [ m/s ] Liquid H O
        exhaustMassFlow = currentThrust / effectiveExhaustVelocity;

        return exhaustMassFlow * Time.deltaTime; // [kg]
    }

    void ExtertForce()
    {
        currentThrust = thrustPercent * maxThrust * 1000;
        Vector3 thrustVector = thrustUnitVector.normalized * currentThrust; // N
        physicsEngine.AddForces(thrustVector);
    }
}
