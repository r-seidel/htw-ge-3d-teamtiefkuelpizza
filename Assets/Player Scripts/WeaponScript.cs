using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject arrow;
    public GameObject cam;
    public float velocity;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire"))
        {
            GameObject go = Instantiate(arrow);
            go.transform.position = cam.transform.position;
            go.transform.up = cam.transform.forward;

            go.GetComponent<Rigidbody>().AddForce(go.transform.up * velocity);
        }
    }
}
