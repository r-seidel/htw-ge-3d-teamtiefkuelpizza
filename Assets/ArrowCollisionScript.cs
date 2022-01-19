using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollisionScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.GetComponent<Rigidbody>());
    }
}
