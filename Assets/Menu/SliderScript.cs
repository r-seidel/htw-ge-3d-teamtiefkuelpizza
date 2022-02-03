using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider MasterSlider;
    public Slider MusicSlider;
    public Slider FOVSlider;
    public Slider SensitivitySlider;

    public GameObject Camera;
    public GameObject MusicManager;

    private void Start()
    {
        MasterSlider.onValueChanged.AddListener((mvalue) =>
        {
            AudioListener.volume = mvalue;
        });

        MusicSlider.onValueChanged.AddListener((svalue) =>
        {
            MusicManager.GetComponent<AudioSource>().volume = svalue * 0.1f;
        });

        FOVSlider.onValueChanged.AddListener((fvalue) =>
        {
            Camera.GetComponent<Camera>().fieldOfView = fvalue;
        });

        SensitivitySlider.onValueChanged.AddListener((value) =>
        {
            PlayerCameraScript.sensitivity = value * 2 * 8f;
        });
    }
}