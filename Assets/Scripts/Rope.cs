using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Rope : MonoBehaviour
{
    public Transform pos1, pos2;

    private LineRenderer rope;

    void Start()
    {
        rope = GetComponent<LineRenderer>();
        rope.positionCount = 2;
        rope.useWorldSpace = true;
    }

    void Update()
    {
        rope.SetPosition(0, pos1.position);
        rope.SetPosition(1, pos2.position);
    }
}
