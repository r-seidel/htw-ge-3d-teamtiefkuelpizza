using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 8f;
    public float runSpeed = 15f;
    public float jumpSpeed = 2f;
    public float crouchMult = 0.4f;
    public float crouchSpeed = 0.4f;
    public float gravity = 9.81f;

    private Vector3 normalScale;
    private float y = 0f;

    private bool run = false;
    private bool crouch = false;
    private bool jump = false;
    private float horizontal = 0f;
    private float vertical = 0f;

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

    public void SetInputs(bool run, bool crouch, bool jump, float horizontal, float vertical)
    {
        this.run = run;
        this.crouch = crouch;
        this.jump = jump;
        this.horizontal = horizontal;
        this.vertical = vertical;
    }
}
