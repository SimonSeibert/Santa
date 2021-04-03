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

    public enum presentTypes
    {
        RED,
        GREEN,
        YELLOW,
        NAUGHTY
    }

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
