using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpAndDown : MonoBehaviour
{
    public float upAndDownSpeed = 2f;
    public float upAndDownHeight = 0.3f;
    public float delay = 0f;

    private float upAndDownOffsetY;

    void Start()
    {
        upAndDownOffsetY = transform.position.y;
    }

    void Update()
    {
        moveUpAndDown();
    }

    void moveUpAndDown()
    {
        Vector3 pos = transform.position;
        //calculate what the new Y position will be
        float newY = Mathf.Sin((delay + Time.time) * upAndDownSpeed);
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(pos.x, newY * upAndDownHeight + upAndDownOffsetY, pos.z);
    }
}
