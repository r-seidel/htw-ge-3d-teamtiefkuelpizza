using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCleanUpScript : MonoBehaviour
{
    //this script stops particles from emitting and kills the GameObject
    //as soon as all particles are dead
    public ParticleSystem ps;

    private bool awaitingDestroy = false;

    private void Update()
    {
        if(awaitingDestroy && ps.particleCount == 0)
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
