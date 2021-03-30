using System;
using System.Collections.Generic;

public sealed class Manager {
    //Singelton Stuff
    private Manager() { }


    public static Manager Instance {
        get { return lazy.Value; }
    }

    private static readonly Lazy<Manager> lazy = new Lazy<Manager>(() => new Manager());

    //My Stuff
    int currentScore = 0;
    string[] presentTypes = {"red", "green", "yellow", "naughty"};

    public int addScore(int addScore) {
        currentScore += addScore;
        return currentScore;
    }

    public int removeScore(int removeScore) {
        currentScore -= removeScore;
        return currentScore;
    }

    public int getCurrentScore() {
        return currentScore;
    }

    public string[] getPresentTypes()
    {
        return presentTypes;
    }
}
