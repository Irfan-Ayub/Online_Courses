using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {


    public CharacterController2D characterController2D;
    public int powerUpAmount = 20;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Player")
        {
            if(characterController2D == null)
            {
                Debug.LogWarning("Character Controller in PowerUp Script is Not Set");
                return;
            }

            characterController2D.playerHealth += powerUpAmount;

            //Debug.Log(characterController2D.playerHealth);

            Destroy(this.gameObject);
        }
    }
}
