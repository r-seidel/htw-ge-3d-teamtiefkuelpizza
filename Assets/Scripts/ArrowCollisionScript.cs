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

            Destroy(gameObject);
        }
    }
}
