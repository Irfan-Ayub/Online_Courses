using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour {


    // holds the Paddle Prefab
    [SerializeField]
    GameObject prefabPaddle;

    // holds the prefab for the Standard Block
    [SerializeField]
    GameObject prefabStandardBlock;
    // holds the prefab for the Standard Block
    [SerializeField]
    GameObject prefabBonusBlock;
    // holds the prefab for the Standard Block
    [SerializeField]
    GameObject prefabPickupBlock;


    // holds the Width and the Height of the Block Sprite
    float blockWidth;
    float blockHeight;


    // holds the ofset from the Top and the Left Right of the Screen
    float topOffset;
    float leftRightOffset;

	// Use this for initialization
	void Start () {

        // Instantiating the Paddle Prefab
        Instantiate(prefabPaddle);

        // Getting the Height and Width of the Block
        // Using the SpriteRenderer bounds for calculation;
        GameObject tempBlock =  Instantiate(prefabStandardBlock) as GameObject;
        SpriteRenderer renderer = tempBlock.GetComponent<SpriteRenderer>();
        blockWidth = renderer.bounds.size.x;
        blockHeight = renderer.bounds.size.y;

        // Destroying the temporary block
        Destroy(tempBlock);

        // Generating the Blocks for the level
        GenerateBlocks();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Generates the Blocks in a particular Patter (3-Rows)
    /// </summary>
    void GenerateBlocks()
    {
        topOffset = 0.75f;
        Vector2 initialPosition = new Vector2(ScreenUtils.ScreenLeft * leftRightOffset, ScreenUtils.ScreenTop * topOffset);

        for (int i=0; i<3; i++)
        {
            leftRightOffset = Random.Range(0.6f, 0.85f);

            initialPosition.x = ScreenUtils.ScreenLeft * leftRightOffset;

            GenerateRow(initialPosition);
            initialPosition.y -= blockHeight;
        }
        
    }

    /// <summary>
    /// Generates a Single Row of Blocks
    /// </summary>
    /// <param name="startingPosition">the Right most point to Start the Row</param>
    void GenerateRow(Vector2 startingPosition)
    {
        for (float xPosition = startingPosition.x; xPosition <= ScreenUtils.ScreenRight * leftRightOffset; xPosition += blockWidth )
        {
            Instantiate(GetRandomBlock(), new Vector2(xPosition, startingPosition.y), Quaternion.identity);
            //Instantiate(prefabPickupBlock, new Vector2(xPosition, startingPosition.y), Quaternion.identity).
            //GetComponent<PickupBlock>().BlockPickupEffect = PickupEffect.Speedup;
        }
    }

    /// <summary>
    /// Generates a Random Block based on the probabilities
    /// </summary>
    /// <returns></returns>
    GameObject GetRandomBlock()
    {
        float probability = Random.value;

        //Debug.Log(probability);
        if (probability <= ConfigurationUtils.BonusBlockProbability)
        { return prefabBonusBlock; }

        else if (probability <= ConfigurationUtils.PickupBlockProbability)
        {
            float random = Random.value;
            if (random < 0.5)
            { prefabPickupBlock.GetComponent<PickupBlock>().BlockPickupEffect = PickupEffect.Freezer; }
            else
            { prefabPickupBlock.GetComponent<PickupBlock>().BlockPickupEffect = PickupEffect.Speedup; }

            return prefabPickupBlock;
        }
        
        else if (probability <= ConfigurationUtils.StandardBlockProbability)
        { return prefabStandardBlock; }

        return prefabStandardBlock;
    }
}
