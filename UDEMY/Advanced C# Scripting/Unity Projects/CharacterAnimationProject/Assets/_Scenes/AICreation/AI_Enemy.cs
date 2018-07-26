using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Enemy : MonoBehaviour {

    NavMeshAgent thisAgent = null;
    public Transform patrolDestination = null;


	// Use this for initialization
	void Start () {

        thisAgent = gameObject.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {

        thisAgent.SetDestination(patrolDestination.position);
		
	}
}
