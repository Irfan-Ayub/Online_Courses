using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public float damage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attacker attacked = collision.GetComponent<Attacker>();
        Health health = collision.GetComponent<Health>();

        if (attacked && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
