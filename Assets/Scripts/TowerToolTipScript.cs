using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerToolTipScript : MonoBehaviour, WatchedInterface
{
    public GameObject tooltip;

    private bool watched = false;
    private float resetTime = 0.05f;
    private float timer = 0f;


    private void Update()
    {
        if (watched)
        {
            tooltip.SetActive(true);
            TextMeshPro tmp = tooltip.GetComponent<TextMeshPro>();
            if (!GetComponent<TowerControllerScript>().GetIfBought())
            {
                tmp.text = "BUILD TOWER \n [E]";
            }
            else if (GetComponent<TowerControllerScript>().GetIfMaxLevel())
            {
                tmp.text = "LEVEL MAX";
            }
            else
            {
                tmp.text = $"LEVEL {GetComponent<TowerControllerScript>().GetUpgradeLevel()} \n [E] Upgrade";
            }
        }

        timer += Time.deltaTime;
        if(timer >= resetTime)
        {
            watched = false;
            tooltip.SetActive(false);
        }
    }

    public void SetWatchedTrue()
    {
        watched = true;
        timer = 0f;
    }
}
