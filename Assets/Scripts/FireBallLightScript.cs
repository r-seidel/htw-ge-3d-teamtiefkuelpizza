using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallLightScript : MonoBehaviour
{
    public float rawLightValue;
    public float multiplier;

    private Light pointlight;

    private void Start()
    {
        pointlight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        pointlight.intensity = rawLightValue * multiplier;
    }
}
