using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    [Tooltip("number of seconds between every appearances")]
    public float seenEverySecond; 

    private GameObject currentTarget;
    private Rigidbody2D rb2D;
    private float currentSpeed = 0.0f;
    private Animator animator;

	// Use this for initialization
	void Start () {

        animator = gameObject.GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if(!currentTarget && animator)
        { animator.SetBool("isAttacking", false); }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Attackers Trigger - " + gameObject.name);
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if(currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if(health)
            { health.DealDamage(damage); }
        }
        //Debug.Log(gameObject.name + " caused " + damage + " damage");
    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }
}
