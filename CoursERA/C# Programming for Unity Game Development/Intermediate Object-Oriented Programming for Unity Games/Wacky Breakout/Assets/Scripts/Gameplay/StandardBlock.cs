using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBlock : Block {

    // holds the available Sprites for this Block
    [SerializeField]
    Sprite[] blockSprites;

	// Use this for initialization
	override protected void Start () {

        blockScore = ConfigurationUtils.StandardBlockScore;
        gameObject.GetComponent<SpriteRenderer>().sprite = blockSprites[Random.Range(0, blockSprites.Length)];

        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
