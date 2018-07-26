using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreMaster {

    // returns a list of cumulative scores, like a score card
    public static List<int> ScoreCumulative(List<int> rolls)
    {
        List<int> cumulativeScores = new List<int>();
        int runningTotal = 0;

        foreach(int frameScore in ScoreFrames(rolls))
        {
            runningTotal += frameScore;
            cumulativeScores.Add(runningTotal);
        }

        return cumulativeScores;
    }

    // returns a individual frame scroes, NOT cumulative
    public static List<int> ScoreFrames (List<int> rolls)
    {
        List<int> frameList = new List<int>();
        int sum = 0;
        for(int i=0; i<rolls.Count-1; i+=2)
        {
            if(frameList.Count == 10) // Prevents 1th Frame score
            { break; }

            sum = rolls[i] + rolls[i + 1];
            if(sum < 10) // Normal Open Frame
            {
                frameList.Add(sum);
            }
            else // Calculate Spare Bonus
            {
                if (rolls.Count > i + 2)
                {
                    
                    sum += rolls[i + 2];
                    frameList.Add(sum);

                    if(rolls[i] == 10) // Strike
                    {
                        if(i < 18)
                            i--; // Strike fram has just One bowl
                    }
                }
                    
            }
               
        }
        
        return frameList;
    }

}
