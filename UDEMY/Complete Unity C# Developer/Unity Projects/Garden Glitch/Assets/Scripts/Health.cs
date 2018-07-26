using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float health = 100.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DealDamage (float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            // Trigger the Death Animation (if you have one)
            DestoryObject();
        }
    }

    // can be called in the death animation event
    public void DestoryObject()
    {
        Destroy(gameObject);
    }
}
