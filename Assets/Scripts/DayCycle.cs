using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class DayCycle : MonoBehaviour
{
    [Range(0,24)]
public float timeDay;
public float speed = 1.0f;
public Light sun;
public Light moon;
public Volume skyVolume;
public AnimationCurve starsEmission;

public bool isDay;
public bool isNight;
private PhysicallyBasedSky sky;


    // Start is called before the first frame update
    void Start()
    {
        skyVolume.profile.TryGet(out sky);

    }

    // Update is called once per frame
    void Update()
    { 
        timeDay += Time.deltaTime * speed;
        if (timeDay > 24)
        timeDay = 0;

        SunPos();        
    }
    private void OnValidade()
    {
        skyVolume.profile.TryGet(out sky);
        SunPos();
    }

    private void SunPos()
    {
        float hour = timeDay / 24.0f;
        float sunRotation = Mathf.Lerp(-90, 270, hour);
        float moonRotation = sunRotation - 180;
        float spaceRotation = Mathf.Lerp(hour/4, 0, 0);
        sun.transform.rotation = Quaternion.Euler(sunRotation, -150.0f, 0);
        moon.transform.rotation = Quaternion.Euler(moonRotation, -150.0f, 0);
        
        //sky.spaceRotation.x = myVector;
        sky.spaceEmissionMultiplier.value = starsEmission.Evaluate(hour);

        NightDayTransition();

    }
     private void NightDayTransition() 
     {
         if (isNight)
         {
         if (moon.transform.rotation.eulerAngles.x > 180)
         {
             Day();
         }
         }
         else 
         {
             if (sun.transform.rotation.eulerAngles.x > 180)
         {
         Night();
     }
         }
     }

    public void Day()
         { 
        isNight = false;
         sun.shadows = LightShadows.Soft;
         moon.shadows = LightShadows.None;
         }
    
    public void Night()
         {
             isDay = false;
             sun.shadows = LightShadows.None;
             moon.shadows = LightShadows.Soft;
         }

        

}
