using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    public int enemyBaseline;
    public float exponent;
    public int[] addSiteAt;
    public float waveLength;
    public float pauseLenght;
    public float checkCooldown;

    private GameObject[] spawners;
    private int addSiteAtPointer = 0;
    private int siteAmount = 1;
    private int waveNum = 0;
    private float timer = 0;
    private WaveState waveState = WaveState.Waiting;

    public void resetValues()
    {
        addSiteAtPointer = 0;
        siteAmount = 1;
        waveNum = 0;
        timer = 0;
        waveState = WaveState.Waiting;
        foreach(GameObject go in spawners)
        {
            go.GetComponent<SpawnerScript>().toSpawn = 0;
        }
    }

    private enum WaveState
    {
        Waving,
        Waiting
    }

    private void Start()
    {
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
    }

    private void Update()
    {
        switch (waveState)
        {
            case WaveState.Waiting:

                timer += Time.deltaTime;
                if(timer >= pauseLenght)
                {
                    timer = 0f;
                    StartNextWave();
                    waveState = WaveState.Waving;
                    
                    
                }

                break;
            case WaveState.Waving:

                timer += Time.deltaTime;
                if (timer >= checkCooldown)
                {
                    timer = 0f;
                    if (CheckIfEnemiesCleared())
                    {
                        Debug.Log("All enemies cleared. Initiating Pause.");
                        waveState = WaveState.Waiting;
                    }
                }

                break;
        }
    }

    private void StartNextWave()
    {
        //count up wave if wave defined as site adder by "addSiteAt"
        waveNum++;
        if(addSiteAtPointer < addSiteAt.Length)
        {
            if (waveNum == addSiteAt[addSiteAtPointer])
            {
                siteAmount++;
                addSiteAtPointer++;
            }
        }

        //calculate number of enemies in next wave
        int enemyAmount = (int)(Mathf.Pow(waveNum, exponent) + enemyBaseline);
        GameObject[] selectedSpawners = GetRandomSpawners(siteAmount);
        int perSpawnerAmount = enemyAmount / selectedSpawners.Length;

        //set spawner values
        foreach (GameObject spawner in selectedSpawners)
        {
            
            spawner.GetComponent<SpawnerScript>().toSpawn = perSpawnerAmount;
            spawner.GetComponent<SpawnerScript>().interval = waveLength / perSpawnerAmount;
        }
       

        Debug.Log($"Starting Wave {waveNum}: {enemyAmount} Enemies on {selectedSpawners.Length} spawners");

        FindObjectOfType<AudioManager>().Play("EnemyWave01");
        FindObjectOfType<AudioManager>().Play("EnemyHorn01");
    }

    private GameObject[] GetRandomSpawners(int amount)
    {
        //create array with shuffled spawners
        GameObject[] tempSpawners = spawners;
        for (int i = 0; i < tempSpawners.Length - 1; i++)
        {
            int rnd = Random.Range(i, tempSpawners.Length);
            GameObject temp = tempSpawners[rnd];
            tempSpawners[rnd] = tempSpawners[i];
            tempSpawners[i] = temp;
        }

        //return first {amount} elemts of array
        return tempSpawners.Take<GameObject>(amount).ToArray();
    }

    private bool CheckIfEnemiesCleared()
    {
        //check if spawner have finished spawning
        foreach(GameObject spawner in spawners)
        {
            if(spawner.GetComponent<SpawnerScript>().toSpawn > 0)
            {
                return false;
            }
        }

        //check if there are still enemies alive
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("EnemyMain");
        if(enemies.Length > 0)
        {
            return false;
        }

        return true;
    }
}
