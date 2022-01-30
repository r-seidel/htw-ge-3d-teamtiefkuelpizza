using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerControllerScript : MonoBehaviour, InteractableInterface
{
    public float[,] upgradeStats; //[Level before Upgrading][minSearchCoolDown, maxSearchCoolDown, killTime]
    public GameObject towerPrefab;

    private bool bought = false;
    private int upgradeLevel = 0;
    private GameObject tower;

    private void Start()
    {
        // hard coded because inspector has no native support for 2d arrays and im to lazy to implement it
        upgradeStats = new float[,]{
            { 3, 4, 3 },
            { 2.5f, 3.5f, 2.5f },
            { 2, 3, 2 },
            { 1.5f, 2, 1 }
        };
    }

    public void Interact()
    {
        if (bought)
        {
            TryUpgradeTower();
        }
        else
        {
            PlaceTower();
        }
    }

    public int GetUpgradeLevel()
    {
        return upgradeLevel;
    }

    public bool GetIfMaxLevel()
    {
        return upgradeLevel >= upgradeStats.GetLength(0);
    }

    public bool GetIfBought()
    {
        return bought;
    }

    private bool TryUpgradeTower()
    {
        //if max level was reached
        if(upgradeLevel >= upgradeStats.GetLength(0))
        {
            Debug.Log("Reached MAX level");
            return false;
        }

        //set values of upgradeStats to tower
        tower.GetComponent<TowerFireScript>().minSearchCoolDown = upgradeStats[upgradeLevel, 0];
        tower.GetComponent<TowerFireScript>().maxSearchCoolDown = upgradeStats[upgradeLevel, 1];
        tower.GetComponent<TowerFireScript>().killTime = upgradeStats[upgradeLevel, 2];
        Debug.Log($"Tower upgraded! Now on Level {upgradeLevel+1} with stats: " +
            $"Min Search Cool Down: {upgradeStats[upgradeLevel, 0]} " +
            $"Max Search Cool Down: {upgradeStats[upgradeLevel, 1]} " +
            $"Kill Time: {upgradeStats[upgradeLevel, 2]}");
        upgradeLevel++;
        return true;
    }

    private void PlaceTower()
    {
        bought = true;
        GameObject spawn = transform.GetChild(0).gameObject;
        tower = Instantiate(towerPrefab, spawn.transform.position, new Quaternion(0,0,0,0));
        tower = tower.transform.GetChild(0).gameObject;
    }
}
