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
            
            GameObject go = Instantiate(effect);
            go.transform.position = transform.position;
            go.GetComponentInChildren<ParticleSystem>().Play();
            
            StartCoroutine(destroy());
        }
    }

    IEnumerator destroy()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSecondsRealtime(1);
        Destroy(gameObject);
    }
}
