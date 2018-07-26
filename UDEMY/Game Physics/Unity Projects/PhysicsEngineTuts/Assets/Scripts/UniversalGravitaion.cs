using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalGravitaion : MonoBehaviour {

    private PhysicsEngine[] physicsEngineArray;
    private const float bigG = 6.673e-11f; // N .(m / kg)    [m^3 / kg s^2 ]


    // Use this for initialization
    void Start () {

        physicsEngineArray = GameObject.FindObjectsOfType<PhysicsEngine>();


    }

    private void FixedUpdate()
    {
        CalculateGravity();
    }

    void CalculateGravity()
    {
        foreach (PhysicsEngine physicsEnigineA in physicsEngineArray)
        {
            foreach (PhysicsEngine physicsEngineB in physicsEngineArray)
            {
                if (physicsEnigineA != physicsEngineB && physicsEnigineA != this)
                {
                    Vector3 offset = physicsEnigineA.transform.position - physicsEngineB.transform.position;
                    float rSquared = Mathf.Pow(offset.magnitude, 2f);
                    float gravityMagnitude = bigG * physicsEnigineA.mass * physicsEngineB.mass / rSquared;
                    Vector3 gravityFeltVector = gravityMagnitude * offset.normalized;

                    physicsEnigineA.AddForces(-gravityFeltVector);
                }
            }
        }
    }
}
