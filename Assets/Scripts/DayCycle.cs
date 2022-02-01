using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    [Range(0,24)]
    public float timeDay;
    private float newTime = 0;
    public static float speed = 5f;
    public Light sun;
    public Light moon;

    public bool isDay;
    public bool isNight;
    private bool reset;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(reset && timeDay>9)
        {
            speed = 10f;
            timeDay -= Time.deltaTime * speed;
        }
        else if (timeDay < 9) // intro sequence
        {
            speed = 5f;
            reset = false;
            timeDay += Time.deltaTime * speed;
        }
        
        if(timeDay< newTime)
        {
            speed = (newTime-timeDay)*0.15f;
            timeDay += Time.deltaTime * speed;
        }
        

        if (timeDay > 24) // game over
        {
            timeDay = 0;
        }

        SunPos();
       // print(timeDay);
    }
    private void OnValidade()
    {
        SunPos();
    }

    private void SunPos()
    {
        float hour = timeDay / 24.0f;
        float sunRotation = Mathf.Lerp(-90, 270, hour);
        float moonRotation = Mathf.Lerp(-90, 90, hour);
        sun.transform.rotation = Quaternion.Euler(sunRotation, -150.0f, 0);
        moon.transform.rotation = Quaternion.Euler(moonRotation, -150.0f, 0);
        NightDayTransition();

    }
     private void NightDayTransition() 
     {
         if (moon.transform.rotation.eulerAngles.x > 180)
         {
             Day();
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

    public void setDayTime(float newTime)
    {
        this.newTime = newTime;
    }

    public void resetDayTime()
    {
        reset = true;
        this.newTime = 9;
        speed = 10f;
    }

}
