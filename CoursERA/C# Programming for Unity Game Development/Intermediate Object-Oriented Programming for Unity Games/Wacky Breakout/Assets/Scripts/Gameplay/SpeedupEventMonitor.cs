using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedupEventMonitor : MonoBehaviour {

    #region Fields

    float speedupTime;
    float speedupFactor;
    bool isSpeeding;

    [SerializeField]
    Timer speedEffectTimer;

    #endregion

    #region Properties

    public float SpeedupDuration
    {
        get { return speedupTime; }
    }

    public float SpeedupFactor
    {
        get { return speedupFactor; }
    }

    public bool SpeeupEffectedActivated
    {
        get { return isSpeeding; }
    }

    #endregion


    // Use this for initialization
    private void Start () {

        speedupTime = ConfigurationUtils.SpeedupDuration;
        speedupTime = ConfigurationUtils.SpeedupFactor;

        EventManager.AddSpeedupEventListener(ListenSpeedupEvent);

        EffectUtils.Initialize();
		
	}

    // Update is called once per frame
    private void Update()
    {
        if(speedEffectTimer.Finished && isSpeeding)
        {
            isSpeeding = false;
        }
    }

    void ListenSpeedupEvent(float duration , float factor)
    {
        if(!isSpeeding)
        {
            speedEffectTimer.Duration = ConfigurationUtils.SpeedupDuration;
            speedEffectTimer.Run();
        }
        else
        {
            speedEffectTimer.AddDuration(ConfigurationUtils.SpeedupDuration);
        }

    }





}
