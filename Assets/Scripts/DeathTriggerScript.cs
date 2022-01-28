using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTriggerScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "EricHead")
        {
            GameObject enemyRoot = GetInContainerRoot(other.gameObject);
            Destroy(enemyRoot);
            GameObject.Find("RoundManager").GetComponent<RoundScript>().DecreaseLifes();

            //if (DayCycle.speed < 0.5) { DayCycle.speed += 0.05f; }
        }
    }

    private GameObject GetInContainerRoot(GameObject go)
    {
        if(go.transform.parent == go.transform.root)
        {
            return go;
        }

        return GetInContainerRoot(go.transform.parent.gameObject);
    }
}
