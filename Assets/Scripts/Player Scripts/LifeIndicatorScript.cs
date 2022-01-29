using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeIndicatorScript : MonoBehaviour
{
    public Color healthColor;
    public Color deathColor;

    public float healthSmooth;
    public float deathSmooth;

    private Material mat;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;

        SetHealthPercentage(1f);
    }

    public void SetHealthPercentage(float percent)
    {
        Mathf.Clamp(percent, 0, 1);
        mat.color = Color.Lerp(deathColor, healthColor, percent);
        mat.SetFloat("_Smoothness", Mathf.Lerp(deathSmooth, healthSmooth, percent));
    }
}
