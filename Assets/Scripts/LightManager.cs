using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    public Light2D skyLight;
    public Light2D backgroundLight;
    [Range(0f, 1f)]
    public float startIntensity = .2f;
    private bool lightenUp = true;

    void Start()
    {

    }

    void Update()
    {
        //Goes from startIntensity to 1 in timeUntilDawn seconds
        float intensity = DataManager.Instance.getTimePassed() / (DataManager.Instance.getTimeUntilDawn() + (DataManager.Instance.getTimeUntilDawn() * startIntensity)) + startIntensity;
        if (lightenUp)
        {
            skyLight.intensity = intensity;
            backgroundLight.intensity = intensity;
        }
        if(intensity > 1)
        {
            lightenUp = false;
        }
    }
}
