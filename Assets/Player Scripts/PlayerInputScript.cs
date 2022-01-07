using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputScript : MonoBehaviour
{
    //this script is pretty unnessecary but i want to have
    //all input handled by one script
    private void Update()
    {
        GetComponent<PlayerMovementScript>().SetInputs(
            Input.GetButton("Run"),
            Input.GetButton("Crouch"),
            Input.GetButton("Jump"),
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"));

        GetComponent<PlayerInteractionScript>().SetInputs(
            Input.GetButtonDown("Interact"));
    }
}
