using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager {

    #region Fields

    static List<PickupBlock> invokers = new List<PickupBlock>();
    static List<UnityAction<float>> freezerEffectListeners = new List<UnityAction<float>>();
    static List<UnityAction<float, float>> speedupEffectListeners = new List<UnityAction<float, float>>();

    #endregion


    #region Public Methods

    /// <summary>
    /// Adds the Invoker
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddInvoker(PickupBlock invoker)
    {
        //Debug.Log("Pickup Invoker");
        invokers.Add(invoker);

        foreach (UnityAction<float> listener in freezerEffectListeners)
        { invoker.AddFreezerEffectListener(listener); }
    }

    public static void AddFreezerEventListener(UnityAction<float> listener)
    {
        //Debug.Log(listener);
        freezerEffectListeners.Add(listener);

        foreach(PickupBlock pickupBlock in invokers)
        { pickupBlock.AddFreezerEffectListener(listener); }
    }

    public static void AddSpeedupEventListener(UnityAction<float , float> listener)
    {
        //Debug.Log("Speed Listener -- " + listener);
        speedupEffectListeners.Add(listener);

        foreach (PickupBlock pickupBlock in invokers)
        { pickupBlock.AddSpeedupEffectListener(listener); }
    }


    #endregion
}
