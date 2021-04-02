using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class PunchInText : MonoBehaviour
{
    public float tweenTime = .5f;
    public float startRotation = 10f;
    public float startScalingFactor = 2f;
    public bool fadeOut = true;
    public float fadeOutTime = 3f;

    void Start()
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

        if (fadeOut)
        {
            LeanTween.value(gameObject, 1f, 0f, fadeOutTime)
           .setOnUpdate((value) =>
           {
               gameObject.GetComponent<TextMeshProUGUI>().alpha = value;
           })
           .setDelay(tweenTime)
           .setEaseInOutSine()
           .setDestroyOnComplete(gameObject);
        }
    }
}
