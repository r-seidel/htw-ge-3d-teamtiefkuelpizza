using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimScript : MonoBehaviour
{
    private Animator animator;
    private GameObject fireBall;

    private void Start()
    {
        animator = GetComponent<Animator>();
        fireBall = transform.Find("FireBall Variant").gameObject;
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
        if (callback.performed && fireBall.activeSelf)
        {
            animator.SetTrigger("Shooting");
        }
    }

    public void triggerFU(InputAction.CallbackContext callback)
    {
        if (callback.performed && !fireBall.activeSelf)
        {
            transform.GetComponent<WeaponScript>().resetTimer();
            animator.SetTrigger("Fuuing"); 
        }
    }
}
