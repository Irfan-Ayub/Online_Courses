using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingStone : MonoBehaviour {

    public CharacterController2D characterController2D;
    public int damageAmount = 20;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            if (characterController2D == null)
            {
                Debug.LogWarning("Character Controller in Killing Stone Script is Not Set");
                return;
            }

            characterController2D.ApplyDamage(damageAmount);

            //Debug.Log(characterController2D.playerHealth);

            //Destroy(this.gameObject);
        }
    }
}
