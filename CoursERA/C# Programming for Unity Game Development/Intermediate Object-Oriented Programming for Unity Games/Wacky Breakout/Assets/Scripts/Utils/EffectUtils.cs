using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EffectUtils  {

    #region Fields

    static SpeedupEventMonitor speedupEffectMonitor;

    #endregion

    #region Properties
    
    /// <summary>
    /// Tells if the SpeedupEffect is active or not
    /// </summary>
    public static bool SpeedupEffectIsActive
    {
        get { return speedupEffectMonitor.SpeeupEffectedActivated; }
    }

    public static float SpeedupEffectDuration
    {
        get { return speedupEffectMonitor.SpeedupDuration; }
    }

    public static float SpeedupEffectFactor
    {
        get { return speedupEffectMonitor.SpeedupFactor; }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Initilazes the Speedup Effect Monitor
    /// </summary>
    public static void Initialize()
    {
        speedupEffectMonitor = GameObject.FindObjectOfType<SpeedupEventMonitor>();
    }
    #endregion
}
