using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariablesAndFunctions : MonoBehaviour {

    // a box ( a Variable ) that contains a integer value
    int myInt = 55; 

	// a Function called when the first tme script is loaded in the Scene
	void Start () {

        // displays the message ( the value of myInt ) on the console.
        Debug.Log(myInt);

        // displays the message ( the value of myInt x 2 ) on the console.
        Debug.Log(myInt * 2);

        // Function Calling with the arguement of variable myInt
        myInt  = MultiplyNumber(myInt); // updating myInt variable after the value is being multiplied
	}

    // A Function which takes a integer arguement.
    // multiplies the number by 2 and then return the value.
    int MultiplyNumber(int number)
    {
        int ret = number * 2; //  multiplying the number and storing the value in a temporary vairable
        return ret; // returning the multiplied value
    }

}
