using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraScript : MonoBehaviour
{
    public float sensitivity = 100f;
    public Transform playerBody;

    private float xRotation = 0f;

    private float mouseX;
    private float mouseY;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    public void SetMouseXValue(InputAction.CallbackContext context)
    {
        mouseX = context.ReadValue<float>() * sensitivity * Time.deltaTime;
    }

    public void SetMouseYValue(InputAction.CallbackContext context)
    {
        mouseY = context.ReadValue<float>() * sensitivity * Time.deltaTime;
    }
}
