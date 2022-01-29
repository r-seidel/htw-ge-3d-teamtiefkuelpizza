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
        sparks.GetComponent<ParticleCleanUpScript>().InitDestroy();
        Destroy(transform.parent.gameObject);
    }
}
