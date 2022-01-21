using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FallTriggerScript : MonoBehaviour
{
    public float jumpForce = 2f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "EricHead")
        {
            GameObject go = other.transform.parent.gameObject;
            go.GetComponent<Animator>().SetTrigger("Fall");
            go.GetComponent<EnemyNavScript>().enabled = false;
            go.GetComponent<NavMeshAgent>().enabled = false;
            go.GetComponent<IKFootPlacement>().enabled = false;
            go.GetComponentInChildren<EnemyHitScript>().dying = true;
            if (!go.GetComponent<Rigidbody>())
            {
                go.AddComponent<Rigidbody>();
            }
            go.GetComponent<Rigidbody>().AddForce(go.transform.forward * jumpForce);
        }
    }
}
