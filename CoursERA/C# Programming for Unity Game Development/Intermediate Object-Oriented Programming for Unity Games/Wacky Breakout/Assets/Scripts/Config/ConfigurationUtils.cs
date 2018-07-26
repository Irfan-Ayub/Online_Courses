using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{

    #region Fields

    static ConfigurationData configData;

    #endregion


    #region Properties

    #region Paddle Movement
    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configData.PaddleMoveUnitsPerSecond; }
    }
    #endregion

    #region Ball Properties
    /// <summary>
    /// Gets the Impulse Force to be Applied on the Ball Initially
    /// </summary>
    public static float BallImpulseForce
    {
        get { return configData.BallImpulseForce; }
    }

    /// <summary>
    /// Gets the Life Time of the Ball
    /// </summary>
    public static float BallLifeTime
    {
        get { return configData.BallLifeTime; }
    }

    /// <summary>
    /// Gets the Minimun Value of Ball Spawning Time
    /// </summary>
    public static float MinBallSpawnTime
    {
        get { return configData.MinBallSpawnTime; }
    }

    /// <summary>
    /// Gets the Maximum Value of Ball Spawning Time
    /// </summary>
    public static float MaxBallSpawnTime
    {
        get { return configData.MaxBallSpawnTime; }
    }

    public static int TotalBalls
    {
        get { return configData.TotalBalls; }
    }

    #endregion

    #region Block Scores
    /// <summary>
    /// Gets the Score for the Standard Block type in the game
    /// </summary>
    public static int StandardBlockScore
    {
        get { return configData.StandardBlockScore; }
    }

    /// <summary>
    /// Gets the Score for the Bonus Block type in the game
    /// </summary>
    public static int BonusBlockScore
    {
        get { return configData.BonusBlockScore; }
    }

    /// <summary>
    /// Gets the Score for the Pickup Block type in the game
    /// </summary>
    public static int PickupBlockScore
    { 
        get { return configData.PickupBlockScore; }
    }
    #endregion

    #region Block Probabilities

    /// <summary>
    /// Gets the Score for the Pickup Block type in the game
    /// </summary>
    public static float StandardBlockProbability
    {
        get { return configData.StandardBlockProbability; }
    }

    /// <summary>
    /// Gets the Score for the Pickup Block type in the game
    /// </summary>
    public static float BonusBlockProbability
    {
        get { return configData.BonusBlockProbability; }
    }

    /// <summary>
    /// Gets the Score for the Pickup Block type in the game
    /// </summary>
    public static float PickupBlockProbability
    {
        get { return configData.PickupBlockProbability; }
    }
    #endregion

    #region Block Properties

    /// <summary>
    /// Gets the Freeze Duration in Seconds for the Freeze Effect Block
    /// </summary>
    public static float FreezeDuration
    {
        get { return configData.FreezeDuration; }
    }


    /// <summary>
    /// Gets the SpeedUp Duration in Seconds for the SpeedUp Effect Block
    /// </summary>
    public static float SpeedupDuration
    {
        get { return configData.SpeedupDuration; }
    }

    /// <summary>
    /// Gets the SpeedUp Factor for the SpeedUp Effect Block
    /// </summary>
    public static float SpeedupFactor
    {
        get { return configData.SpeedupFactor; }
    }

    #endregion


    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configData = new ConfigurationData();
    }
}
