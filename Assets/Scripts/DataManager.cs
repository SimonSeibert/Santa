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
    int currentScore = 0;
    float gameSpeed = 2f;
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
}
