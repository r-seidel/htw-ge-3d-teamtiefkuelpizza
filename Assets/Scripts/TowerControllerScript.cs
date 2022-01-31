using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerControllerScript : MonoBehaviour, InteractableInterface
{
    public float[,] upgradeStats; //[Level before Upgrading][minSearchCoolDown, maxSearchCoolDown, killTime]
    public float minSearchTimeMultiplier;
    public float maxSearchTimeMultiplier;
    public float killTimeMultiplier;
    public int maxLevel;            //set to -1 if no max level
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
            //TryUpgradeTower();
            InfiniteUpgrade();
        }
        else
        {
            PlaceTower();
            //GameObject.Find("AudioManager").GetComponent<AudioManager>().Play()
            FindObjectOfType<AudioManager>().Play("TowerAvailable");
        }
    }

    public int GetUpgradeLevel()
    {
        return upgradeLevel;
    }

    public bool GetIfMaxLevel()
    {
        //return upgradeLevel >= upgradeStats.GetLength(0);
        return upgradeLevel == maxLevel;
    }

    public bool GetIfBought()
    {
        return bought;
    }

    //old - for when tower leveling stats are manual and limited
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

    private bool InfiniteUpgrade()
    {
        if(upgradeLevel == maxLevel)
        {
            Debug.Log("Reached MAX level");
            return false;
        }

        //set values of upgradeStats to tower
        tower.GetComponent<TowerFireScript>().minSearchCoolDown *= minSearchTimeMultiplier;
        tower.GetComponent<TowerFireScript>().maxSearchCoolDown *= maxSearchTimeMultiplier;
        tower.GetComponent<TowerFireScript>().killTime *= killTimeMultiplier;
        Debug.Log($"Tower upgraded! Now on Level {upgradeLevel + 1} with stats: " +
            $"Min Search Cool Down: {tower.GetComponent<TowerFireScript>().minSearchCoolDown} " +
            $"Max Search Cool Down: {tower.GetComponent<TowerFireScript>().maxSearchCoolDown} " +
            $"Kill Time: {tower.GetComponent<TowerFireScript>().killTime}");
        upgradeLevel++;
        return true;
    }

    private void PlaceTower()
    {
        bought = true;
        GameObject spawn = transform.parent.Find("TowerSpawnPoint").gameObject;
        tower = Instantiate(towerPrefab, spawn.transform.position, new Quaternion(0,0,0,0));
        tower.transform.parent = transform.parent;
        tower = tower.transform.GetChild(0).gameObject;
    }
}
