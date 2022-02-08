using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    public CharacterController controller;

    public PlayerInput input;
    private InputMaster master;

    public float speed = 8f;
    public float runSpeed = 15f;
    public float jumpSpeed = 2f;
    public float crouchMult = 0.4f;
    public float crouchSpeed = 0.4f;
    public float gravity = 9.81f;

    private Vector3 normalScale;
    private float y = 0f;

    private bool jump;
    private bool crouch;
    private bool run;
    private float horizontal;
    private float vertical;

    private void Start()
    {
        normalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (crouch) {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(normalScale.x, normalScale.y * crouchMult, normalScale.z), crouchSpeed);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, normalScale, crouchSpeed);
        }

        float realSpeed;
        if (run) { realSpeed = runSpeed; } else { realSpeed = speed; }

        float x = horizontal * realSpeed;
        float z = vertical * realSpeed;

        if (controller.isGrounded)
        {
            y = 0f;
            if (jump)
            {
                y = jumpSpeed;
            }
        }

        y -= gravity * Time.deltaTime;

        Vector3 move = transform.right * x + transform.forward * z;
        move.y = y;

        controller.Move(move * Time.deltaTime);
    }

    public void SetJumpTrigger(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            jump = true;
        }
        else if (context.canceled)
        {
            jump = false;
        }
    }

    public void SetCrouchTrigger(InputAction.CallbackContext context)
    {
        /*
        if (context.performed)
        {
            crouch = true;
        }
        else if (context.canceled)
        {
            crouch = false;
        }
        */
    }

    public void SetRunTrigger(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            run = true;
        }
        else if (context.canceled)
        {
            run = false;
        }
    }

    public void SetMoveValue(InputAction.CallbackContext context)
    {
        Vector2 temp = context.ReadValue<Vector2>();

        horizontal = temp.x;
        vertical = temp.y;
    }
}
