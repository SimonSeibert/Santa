using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float increaseSpeedFactor = .3f;
    [Tooltip("After what time (in s) the increaseSpeedFactor will be added")]
    public float increaseSchedule = 5f;
    public bool useSpeedLimit;
    public float speedLimit = 5f;

    void OnEnable()
    {
        StartCoroutine("increaseGameSpeed");
    }

    void Update()
    {
        Data.Instance.addTimePassed(Time.deltaTime);
    }

    IEnumerator increaseGameSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(increaseSchedule);
            if (useSpeedLimit)
            {
                if (Data.Instance.getGameSpeed() < speedLimit)
                {
                    Data.Instance.setGameSpeed(Data.Instance.getGameSpeed() + increaseSpeedFactor);
                }
            }
            else
            {
                Data.Instance.setGameSpeed(Data.Instance.getGameSpeed() + increaseSpeedFactor);
            }
        }
    }
}
