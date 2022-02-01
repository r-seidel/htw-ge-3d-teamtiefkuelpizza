using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCleanUpScript : MonoBehaviour
{
    //this script stops particles from emitting and kills the GameObject
    //as soon as all particles are dead
    public ParticleSystem ps;

    private bool awaitingDestroy = false;
    private float timer = 0;


    private void Update()
    {
        timer += Time.deltaTime;
        if ((awaitingDestroy && ps.particleCount == 0) || timer >= 10f)
        {
            Destroy(this.gameObject);
        }
    }

    public void InitDestroy()
    {
        ps.Stop();
        awaitingDestroy = true;
    }
}
