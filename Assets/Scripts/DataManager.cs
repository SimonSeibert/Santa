using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataManager : MonoBehaviour
{
    [Header("For setting up, not changing during game")]
    public int currentScore = 0;
    public int allowedFailures = 10;
    public int currentFailures = 10;
    public float gameSpeed = 2f;
    public float timePassed = 0f;
    public float timeUntilDawn = 120f;

    void Start()
    {
        Data.Instance.setCurrentScore(currentScore);
        Data.Instance.setAllowedFailures(allowedFailures);
        Data.Instance.setCurrentFailures(currentFailures);
        Data.Instance.setGameSpeed(gameSpeed);
        Data.Instance.setTimePassed(timePassed);
        Data.Instance.setTimeUntilDawn(timeUntilDawn);
    }
}
