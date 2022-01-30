using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerToolTipScript : MonoBehaviour, WatchedInterface
{
    public GameObject tooltip;

    private bool watched = false;

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
        else
        {
            tooltip.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        watched = false;
    }

    public void SetWatchedTrue()
    {
        watched = true;
    }
}
