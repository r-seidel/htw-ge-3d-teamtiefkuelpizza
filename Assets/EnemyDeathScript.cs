using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathScript : MonoBehaviour
{
    public GameObject sparks;

    public void StartSparks()
    {
        sparks.GetComponent<ParticleSystem>().Play();
    }

    public void DestroyEnemy()
    {
        Destroy(transform.parent.gameObject);
    }
}
