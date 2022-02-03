using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathScript : MonoBehaviour
{
    public GameObject sparks;

    public void InitiateDeath()
    {
        sparks.transform.parent = null;
        sparks.GetComponent<ParticleSystem>().Play();

        //stop enemy from navigating to point
        GetComponent<EnemyNavScript>().DisableNavigation();
    }

    public void DestroyEnemy()
    {
        CleanUpParticle();
        Destroy(transform.parent.gameObject);
    }

    public void CleanUpParticle()
    {
        sparks.GetComponent<ParticleCleanUpScript>().InitDestroy();
    }
}
