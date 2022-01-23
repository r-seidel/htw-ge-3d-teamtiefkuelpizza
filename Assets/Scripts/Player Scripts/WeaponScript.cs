using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponScript : MonoBehaviour
{
    public GameObject arrow;
    public GameObject cam;
    public GameObject fireBall;
    public float velocity;
    private float timer = 0;

    public void resetTimer()
    {
        timer = 0;
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2) {
            fireBall.SetActive(true);
        }
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.performed && timer > 2)
        {
            GameObject go = Instantiate(arrow);
            go.transform.position = fireBall.transform.position;
            go.transform.up = cam.transform.forward;

            go.GetComponent<Rigidbody>().AddForce(go.transform.up * velocity);

            timer = 0;
            fireBall.SetActive(false);
        }
    }
}
