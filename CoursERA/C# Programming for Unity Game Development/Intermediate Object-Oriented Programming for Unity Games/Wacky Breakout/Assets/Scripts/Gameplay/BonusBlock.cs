using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : Block {

	// Use this for initialization
	protected override void Start () {

        blockScore = ConfigurationUtils.BonusBlockScore;
        base.Start();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
