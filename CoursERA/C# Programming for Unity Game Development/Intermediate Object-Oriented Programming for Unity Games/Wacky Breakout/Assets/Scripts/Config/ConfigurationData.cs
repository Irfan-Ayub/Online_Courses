using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationDataFile.csv";

    // configuration data

    // Paddle Movement
    static float paddleMoveUnitsPerSecond = 10.0f;

    // Ball properties
    static float ballImpulseForce = 10.0f;
    static float ballLifeTime = 10.0f;
    static float minBallSpawnTime = 5.0f;
    static float maxBallSpawnTime = 10.0f;
    static int totalBalls = 15;

    // Block Scores
    static int standardBlockScore = 5;
    static int bonusBlockScore = 20;
    static int pickupBlockScore = 10;

    // Block Probabilities
    static float standardBlockProbability = 0.9f;
    static float pickupBlockProbability = 0.5f;
    static float bonusBlockProbability = 0.25f;

    //Block Properties
    static float freezeDuration = 2.0f;
    static float speedupDuration = 2.0f;
    static float speedupFactor = 2.0f;

    #endregion

    #region Properties

    #region Paddle Movement
    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    #endregion

    #region Ball Properties
    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

    /// <summary>
    /// Gets the Life Time of Ball to be in the game
    /// </summary>
    public float BallLifeTime
    {
        get { return ballLifeTime; }
    }

    /// <summary>
    /// Gets the Minimun Value of Ball Spawning Time
    /// </summary>
    public float MinBallSpawnTime
    {
        get { return minBallSpawnTime; }
    }

    /// <summary>
    /// Gets the Maximum Value of Ball Spawning Time
    /// </summary>
    public float MaxBallSpawnTime
    {
        get { return maxBallSpawnTime; }
    }

    public int TotalBalls
    {
        get { return totalBalls; }
    }

    #endregion

    #region Block Scores
    /// <summary>
    /// Gets the score for the Standard Block
    /// </summary>
    public int StandardBlockScore
    {
        get { return standardBlockScore; }
    }

    /// <summary>
    /// Gets the score for the Bonus Block
    /// </summary>
    public int BonusBlockScore
    {
        get { return bonusBlockScore; }
    }

    /// <summary>
    /// Gets the score for the Pickup Block
    /// </summary>
    public int PickupBlockScore
    {
        get { return pickupBlockScore; }
    }
    #endregion

    #region BLock Probabilities

    /// <summary>
    /// Gets the Probability for the Pickup Block
    /// </summary>
    public float StandardBlockProbability
    {
        get { return standardBlockProbability; }
    }

    /// <summary>
    /// Gets the Probability for the Pickup Block
    /// </summary>
    public float BonusBlockProbability
    {
        get { return bonusBlockProbability; }
    }

    /// <summary>
    /// Gets the Probability for the Pickup Block
    /// </summary>
    public float PickupBlockProbability
    {
        get { return pickupBlockProbability; }
    }

    #endregion

    #region Block Properties

    /// <summary>
    /// Gets the Freeze Duration in Seconds for the Freeze Effect Block
    /// </summary>
    public float FreezeDuration
    {
        get { return freezeDuration; }
    }

    /// <summary>
    /// Gets the SpeedUp Duration in Seconds for the SpeedUp Effect Block
    /// </summary>
    public float SpeedupDuration
    {
        get { return speedupDuration; }
    }

    /// <summary>
    /// Gets the SpeedUp Factor for the SpeedUp Effect Block
    /// </summary>
    public float SpeedupFactor
    {
        get { return speedupFactor; }
    }

    #endregion

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        StreamReader input = null;
        try
        {
            input = File.OpenText(Path.Combine(Application.streamingAssetsPath , ConfigurationDataFileName));

            string names = input.ReadLine();
            string values = input.ReadLine();

            SetConfigurationDateValues(values);
        }

        catch(Exception e)
        {
            Debug.Log(e.Message);
        }

        finally
        {
            if(input != null)
            {
                input.Close();
            }
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Sets the values of the data Fields from the privided CSV Values
    /// </summary>
    /// <param name="csvValues"> csv String of values</param>
    void SetConfigurationDateValues(string csvValues)
    {
        Debug.Log("Setting Values " + csvValues);
        string[] values = csvValues.Split(',');

        // Parsing values from the csv Values String
        paddleMoveUnitsPerSecond = float.Parse(values[0]);

        //Debug.Log("Ball Impulse Force - " + values[1]);
        ballImpulseForce = float.Parse(values[1]);
        ballLifeTime = float.Parse(values[2]);
        minBallSpawnTime = float.Parse(values[3]);
        maxBallSpawnTime = float.Parse(values[4]);

        standardBlockScore = int.Parse(values[5]);
        bonusBlockScore = int.Parse(values[6]);
        pickupBlockScore = int.Parse(values[7]);

        standardBlockProbability = float.Parse(values[8]);
        bonusBlockProbability = float.Parse(values[9]);
        pickupBlockProbability = float.Parse(values[10]);

        totalBalls = int.Parse(values[11]);

        freezeDuration = float.Parse(values[12]);

        speedupDuration = float.Parse(values[13]);
        speedupFactor = float.Parse(values[14]);

    }

    #endregion
}
