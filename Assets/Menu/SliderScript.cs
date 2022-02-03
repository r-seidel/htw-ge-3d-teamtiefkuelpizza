using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider MusicSlider;
    public Slider SFXSlider;
    public Slider FOVSlider;
    public Slider SensivitySlider;

   

    private void Start()
    {
        MusicSlider.onValueChanged.AddListener((mvalue) =>
        {
            
        });

        SFXSlider.onValueChanged.AddListener((svalue) =>
        {
            
        });

        FOVSlider.onValueChanged.AddListener((fvalue) =>
        {
            
        });

        SensivitySlider.onValueChanged.AddListener((value) =>
        {
            
        });
    }
}