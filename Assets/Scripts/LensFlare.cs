using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class LensFlare : MonoBehaviour
{
    public GameObject DayNight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<LensFlareComponentSRP>().scale = (DayNight.GetComponent<DayCycle>().timeDay-9)/6;
        
    }
}