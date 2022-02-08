using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimScript : MonoBehaviour
{
    private Animator animator;
    private GameObject fireBall;
    public GameObject Menu;

    private void Start()
    {
        animator = GetComponent<Animator>();
        fireBall = transform.Find("FireBall Hand").gameObject;
    }


    public void toggleWalking(InputAction.CallbackContext callback)
    {
        if (callback.performed)
        {
            animator.SetBool("Walking", true);
        } else
        {
            animator.SetBool("Walking", false);
        }
    }

    public void triggerShooting(InputAction.CallbackContext callback)
    {
        if (callback.performed && fireBall.activeSelf && !Menu.activeSelf)
        {
            animator.SetTrigger("Shooting");
        }
    }

    public void triggerFU(InputAction.CallbackContext callback)
    {
        if (callback.performed && !fireBall.activeSelf && !Menu.activeSelf)
        {
            transform.GetComponent<WeaponScript>().resetTimer();
            animator.SetTrigger("Fuuing"); 
        }
    }
}
