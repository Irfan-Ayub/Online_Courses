using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupBlock : Block {

    // holds the available Sprites for this Block
    [SerializeField]
    Sprite[] blockSprites;


    // holds the PickupupEffect for the Block
    public PickupEffect blockPickupEffect; // HAS TO BE PRIVATE

    // holds the effect duration for the pcikup block
    float freezerEffectDuration;
    float speedupEffectDuration;
    float speedupEffectFactor;

    //freezer effect event
    FreezerEffectActivated freezerEffectActivated = new FreezerEffectActivated();

    // Speedup effect event;
    SpeedupEffectActivated speedupEffectActivated = new SpeedupEffectActivated();

    #region Properties
    public PickupEffect BlockPickupEffect
    {
        get { return blockPickupEffect; }
        set
        {

            blockPickupEffect = value;

            if (value == PickupEffect.Speedup)
            {
                Debug.Log("SpeedUp Block");
                gameObject.GetComponent<SpriteRenderer>().sprite = blockSprites[0];
                speedupEffectDuration = ConfigurationUtils.SpeedupDuration;
                speedupEffectFactor = ConfigurationUtils.SpeedupFactor;

            }
                

            else if(value == PickupEffect.Freezer)
            {
                Debug.Log("Freezer Block");
                gameObject.GetComponent<SpriteRenderer>().sprite = blockSprites[1];
                freezerEffectDuration = ConfigurationUtils.FreezeDuration;
            }

        }
    }

    #endregion

    // Use this for initialization
    protected virtual void Start () {

        blockScore = ConfigurationUtils.PickupBlockScore;
        //gameObject.GetComponent<SpriteRenderer>().sprite = blockSprites[Random.Range(0, blockSprites.Length)];

        // Add Self as an invoker
        //EventManager.AddInvoker(this);
        base.Start();
    }

    // Update is called once per frame
    void Update () {
		
	}

    /// <summary>
    /// Overriden Method for the Special Effect for the Pickup Block
    /// </summary>
    /// <param name="collision"></param>
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if(blockPickupEffect == PickupEffect.Freezer)
        {
            //Debug.Log("Freezer Block Collision");
            freezerEffectActivated.Invoke(ConfigurationUtils.FreezeDuration);
        }
        if(blockPickupEffect == PickupEffect.Speedup)
        {
            //Debug.Log("SpeedUp Block Collision");
            speedupEffectActivated.Invoke(ConfigurationUtils.SpeedupDuration, ConfigurationUtils.SpeedupFactor);
        }
        
        base.OnCollisionEnter2D(collision);
    }

    /// <summary>
    /// Adds Listener to the FreezerEffect Event
    /// </summary>
    /// <param name="freezerEffectListener"> A Listener with type UnityAction<float> </param>
    public void AddFreezerEffectListener(UnityAction<float> freezerEffectListener)
    {
        freezerEffectActivated.AddListener(freezerEffectListener);
    }

    /// <summary>
    /// Adds the Listener to the SpeedupEffect Event
    /// </summary>
    /// <param name="speedupEffectListener"> A Listener with type UnityAction<float , float> </param>
    public void AddSpeedupEffectListener(UnityAction<float , float> speedupEffectListener)
    {
        //Debug.Log("adding SpeedUp Effect Listener");
        speedupEffectActivated.AddListener(speedupEffectListener);
    }
}
