using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollisionScript : MonoBehaviour
{
    public GameObject effect;
    

    private void OnCollisionEnter(Collision collision)
    {

        if (!collision.gameObject.layer.Equals("Enemy"))
        {
            
            GameObject go = Instantiate(effect, transform.position, new Quaternion ( 0, 0, 0, 0 ));
            go.GetComponentInChildren<ParticleSystem>().Play();

            StartCoroutine(destroy());
        }
    }

    IEnumerator destroy()
    {
        GetComponent<Collider>().enabled = false;
        Destroy(GetComponent<Rigidbody>());
        foreach (Transform child in transform)
        {
            if (child.GetComponent<ParticleSystem>())
            {
                child.GetComponent<ParticleSystem>().Stop();
            }
            else
            {
                Destroy(child.gameObject);
            }
        }
        yield return new WaitForSecondsRealtime(5);
        Destroy(gameObject);
    }
}
