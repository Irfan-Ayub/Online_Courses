using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : MonoBehaviour {
    
    public float laserProjectileSpeed = 10.0f;
    public float damage = 100f;

    // Use this for initialization
    void Start () {

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, laserProjectileSpeed);

    }

    public float GetDamage()
    { return damage; }

    public void Hit()
    { Destroy(this.gameObject); }

}
