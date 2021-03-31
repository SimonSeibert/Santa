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

    void Start()
    {
        StartCoroutine("increaseGameSpeed");
    }

    void Update()
    {

    }

    IEnumerator increaseGameSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(increaseSchedule);
            if (useSpeedLimit)
            {
                if (DataManager.Instance.getGameSpeed() < speedLimit)
                {
                    DataManager.Instance.setGameSpeed(DataManager.Instance.getGameSpeed() + increaseSpeedFactor);
                }
            }
            else
            {
                DataManager.Instance.setGameSpeed(DataManager.Instance.getGameSpeed() + increaseSpeedFactor);
            }
        }
    }
}
