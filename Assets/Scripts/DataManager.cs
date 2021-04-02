using System;
using System.Collections.Generic;

public sealed class DataManager
{
    //Singelton Stuff
    private DataManager() { }


    public static DataManager Instance
    {
        get { return lazy.Value; }
    }


    private static readonly Lazy<DataManager> lazy = new Lazy<DataManager>(() => new DataManager());

    //My Stuff
    private int currentScore = 0;
    private float gameSpeed = 2f;
    private float timePassed = 0f;
    private float timeUntilDawn = 120f;
    //private int missesUntilGameOver = 10;
    //private int housesUntilDawn = 50;
    //private int presentsUntilDawn = 20;

    public enum presentTypes
    {
        RED,
        GREEN,
        YELLOW,
        NAUGHTY
    }

    public int addScore(int addScore)
    {
        currentScore += addScore;
        return currentScore;
    }

    public int removeScore(int removeScore)
    {
        currentScore -= removeScore;
        return currentScore;
    }

    public int getCurrentScore()
    {
        return currentScore;
    }

    public float getGameSpeed()
    {
        return gameSpeed;
    }

    public void setGameSpeed(float newGameSpeed)
    {
        gameSpeed = newGameSpeed;
    }

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
}
