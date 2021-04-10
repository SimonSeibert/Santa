using System;
using System.Collections.Generic;

public sealed class Data
{
    //Singelton Stuff
    private Data() { }


    public static Data Instance
    {
        get { return lazy.Value; }
    }


    private static readonly Lazy<Data> lazy = new Lazy<Data>(() => new Data());

    //My Stuff
    private int currentScore;
    private int allowedFailures;
    private int currentFailures;
    private float gameSpeed;
    private float timePassed;
    private float timeUntilDawn;
    private List<presentTypes> lastFourPresents = new List<presentTypes>()
    {
        presentTypes.NAUGHTY,presentTypes.NAUGHTY,presentTypes.NAUGHTY,presentTypes.NAUGHTY
    };


    public enum presentTypes
    {
        RED,
        GREEN,
        YELLOW,
        NAUGHTY
    }

    ///LAST-FOUR-PRESENTS/////////////////////////
    public List<presentTypes> getLastFourPresents()
    {
        return lastFourPresents;
    }

    public void addToLastFourPresents(presentTypes t)
    {
        for (int i = lastFourPresents.Count - 1; i > 0; i--)
        {
            lastFourPresents[i] = lastFourPresents[i - 1];
        }
        lastFourPresents[0] = t;
    }

    //public void initLastFourPresents()
    //{
    //    lastFourPresents.Enqueue(presentTypes.NAUGHTY);
    //    lastFourPresents.Enqueue(presentTypes.NAUGHTY);
    //    lastFourPresents.Enqueue(presentTypes.NAUGHTY);
    //    lastFourPresents.Enqueue(presentTypes.NAUGHTY);
    //}


    ///SCORE/////////////////////////
    public int addScore(int addScore)
    {
        currentScore += addScore;
        return currentScore;
    }

    public int getCurrentScore()
    {
        return currentScore;
    }

    public void setCurrentScore(int score)
    {
        currentScore = score;
    }

    ///GAME SPEED////////////////////
    public float getGameSpeed()
    {
        return gameSpeed;
    }

    public void setGameSpeed(float newGameSpeed)
    {
        gameSpeed = newGameSpeed;
    }

    ///TIME ////////////////////////
    public void addTimePassed(float deltaTime)
    {
        timePassed += deltaTime;
    }

    public float getTimePassed()
    {
        return timePassed;
    }

    public float getTimeUntilDawn()
    {
        return timeUntilDawn;
    }

    public void setTimeUntilDawn(float _timeUntilDawn)
    {
        timeUntilDawn = _timeUntilDawn;
    }

    public void setTimePassed(float _timePassed)
    {
        timePassed = _timePassed;
    }
    ///FAILURES////////////////////
    public int getAllowedFailures()
    {
        return allowedFailures;
    }

    public int getCurrentFailures()
    {
        return currentFailures;
    }

    public void failure(int weight)
    {
        currentFailures -= weight;
    }

    public void setAllowedFailures(int failures)
    {
        allowedFailures = failures;
    }

    public void setCurrentFailures(int failures)
    {
        currentFailures = failures;
    }

    //public bool getIsGameRunning()
    //{
    //    return isGameRunning;
    //}
    //
    //public void setIsGameRunning(bool isItRunning)
    //{
    //    isGameRunning = isItRunning;
    //}
}
