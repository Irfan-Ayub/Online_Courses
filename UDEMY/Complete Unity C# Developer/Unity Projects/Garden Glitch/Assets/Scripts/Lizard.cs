using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Lizard : MonoBehaviour
{


    private Animator animator;
    private Attacker attacker;

    // Use this for initialization
    void Start()
    {

        animator = gameObject.GetComponent<Animator>();
        attacker = gameObject.GetComponent<Attacker>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        //return if not collided with Defender
        if (!obj.GetComponent<Defender>())
        {
            return;
        }

        animator.SetBool("isAttacking", true);
        attacker.Attack(obj);
    }
}
