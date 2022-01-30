using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractionScript : MonoBehaviour
{
    //function called by input system
    public void InteractButtonPressed(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            HandleInteraction();
        }
    }

    //handles what should happen after player pressed interact button
    private void HandleInteraction()
    {

        //get the GameObject player is looking at from PlayerRaycastScript
        GameObject go = this.GetComponent<PlayerRaycastScript>().GetLookedAt();

        //if player is looking at something
        if (go != null)
        {
            //if looked at object has InteractableInterface
            if (go.GetComponent<InteractableInterface>() != null)
            {
                // call Interact() of InteractableInterface
                go.GetComponent<InteractableInterface>().Interact();
            }
        }
    }
}
