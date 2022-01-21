using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitScript : MonoBehaviour
{
    public bool dying;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Arrow")
        {
            InitiateDeath();
        }
    }

    public void InitiateDeath()
    {
        dying = true;
        transform.parent.GetComponent<Animator>().SetTrigger("Death");
    }
}
