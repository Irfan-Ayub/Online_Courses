using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CharController : MonoBehaviour {

    private Animator thisAnimator = null;
    private int horHash = Animator.StringToHash("Horizontal");
    private int verHash = Animator.StringToHash("Vertical");


    private void Awake()
    {
        thisAnimator = gameObject.GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float horz = CrossPlatformInputManager.GetAxis("Horizontal");
        float verc = CrossPlatformInputManager.GetAxis("Vertical");


        thisAnimator.SetFloat(horHash, horz , 0.1f , Time.deltaTime);
        thisAnimator.SetFloat(verHash, verc, 0.1f, Time.deltaTime);


    }

}
