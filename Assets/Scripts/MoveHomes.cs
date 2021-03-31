using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHomes : MonoBehaviour
{
    void Update()
    {
        foreach (Transform child in transform)
        {
            child.Translate(Vector2.left * DataManager.Instance.getGameSpeed() * Time.deltaTime, Space.World);
        }
    }
}
