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

    public TextMeshProUGUI MusicValue;
    public TextMeshProUGUI SFXValue;
    public TextMeshProUGUI FOVValue;
    public TextMeshProUGUI SensivityValue;


    private void Start()
    {
        MusicSlider.onValueChanged.AddListener((mvalue) =>
        {
            MusicValue.text = ((int) (mvalue*100)).ToString() + " %";
        });

        SFXSlider.onValueChanged.AddListener((svalue) =>
        {
            SFXValue.text = ((int)(svalue * 100)).ToString() + " %";
        });

        FOVSlider.onValueChanged.AddListener((fvalue) =>
        {
            FOVValue.text = ((int) fvalue).ToString() + "°";
        });

        SensivitySlider.onValueChanged.AddListener((value) =>
        {
            SensivityValue.text = value.ToString("0.00");
        });
    }
}