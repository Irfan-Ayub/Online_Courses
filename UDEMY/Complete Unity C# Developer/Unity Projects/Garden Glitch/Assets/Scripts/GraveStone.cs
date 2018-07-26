using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveStone : MonoBehaviour {

    private Animator animator;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();
        if(attacker)
        {
            Debug.Log("is under Attack");
            animator.SetTrigger("underAttackTrigger");
        }
    }

}
