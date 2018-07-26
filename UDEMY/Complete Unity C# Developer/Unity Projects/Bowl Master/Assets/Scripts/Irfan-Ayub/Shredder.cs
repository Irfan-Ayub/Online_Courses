using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.gameObject.name + " --Left");
        if (other.GetComponent<Pin>())
        {
            Destroy(other.gameObject);
        }
    }
}
