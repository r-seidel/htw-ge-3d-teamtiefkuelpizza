using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponScript : MonoBehaviour
{
    public GameObject arrow;
    public GameObject cam;
    public float velocity;

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameObject go = Instantiate(arrow);
            go.transform.position = cam.transform.position;
            go.transform.up = cam.transform.forward;

            go.GetComponent<Rigidbody>().AddForce(go.transform.up * velocity);
        }
    }
}
