using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchIn : MonoBehaviour
{
    public float tweenTime = .5f;
    public float startRotation = 10f;
    public float startScalingFactor = 2f;

    void OnEnable()
    {
        tween();
    }

    void Update()
    {

    }

    public void tween()
    {
        transform.localScale = Vector3.one;
        LeanTween.cancel(gameObject);
        LeanTween.rotate(gameObject, Vector3.zero, tweenTime)
            .setFrom(new Vector3(0f, 0f, startRotation))
            .setEaseInOutSine();
        LeanTween.scale(gameObject, Vector3.one, tweenTime)
            .setFrom(Vector3.one * startScalingFactor)
            .setEaseInOutSine();
    }
}