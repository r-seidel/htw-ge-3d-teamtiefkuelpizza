using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class LensFlare : MonoBehaviour
{
    private GameObject DayCycle;
    // Start is called before the first frame update
    void Start()
    {
        DayCycle = GameObject.Find("DayNightController");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<LensFlareComponentSRP>().scale = 1-Mathf.Abs(DayCycle.GetComponent<DayCycle>().timeDay - 12)/6;
        
    }
}