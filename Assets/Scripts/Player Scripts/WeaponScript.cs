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
    public float shootInterval;

    private GameObject pullSpark;
    public GameObject Menu;

    public void Start()
    {
        pullSpark = fireBall.transform.Find("PullSpark Hand").gameObject;
    }

    public void resetTimer()
    {
        timer = 0;
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if (timer > shootInterval) {
            pullSpark.transform.parent = fireBall.transform;
            pullSpark.transform.position = fireBall.transform.position;
            fireBall.SetActive(true);
        }
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.performed && timer > shootInterval && !Menu.activeSelf)
        {
            GameObject go = Instantiate(arrow);
            go.transform.position = fireBall.transform.position;
            go.transform.up = cam.transform.forward;

            go.GetComponent<Rigidbody>().AddForce(go.transform.up * velocity);

            timer = 0;
            pullSpark.transform.parent = null;
            fireBall.SetActive(false);
        }
    }
}
