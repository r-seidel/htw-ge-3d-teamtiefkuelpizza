using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionScript : MonoBehaviour
{
    public GameObject cameraGO;     //camera game object

    private GameObject moveGO;      //object the player is currently moving around
    private bool movingObj = false; //if this player is moving an object
    private float moveDistance;     //initial distance between player and moving object

    private bool interact = false;

    private void Update()
    {
        if (interact)
        {
            HandleInteraction();
        }
    }

    private void LateUpdate()
    {
        //if player is moving an object, move object along camera forward vector
        if (movingObj)
        {
            moveGO.transform.position = Vector3.Lerp(moveGO.transform.position, cameraGO.transform.position + cameraGO.transform.TransformDirection(Vector3.forward) * moveDistance, 0.9f);
            Vector3 camVec = cameraGO.transform.TransformDirection(Vector3.forward);
            moveGO.transform.rotation = transform.rotation = Quaternion.Euler(0, cameraGO.transform.eulerAngles.y, 0);
        }
    }

    //handles what should happen after player pressed interact button
    private void HandleInteraction()
    {
        //if player was moving object
        if (movingObj)
        {
            //let go of object and end function
            EndMove();
            return;
        }

        //get the GameObject player is looking at from PlayerRaycastScript
        GameObject go = this.GetComponent<PlayerRaycastScript>().GetLookedAt();

        //if player is looking at nothing
        if(go == null)
        {
            //end function
            return;
        }

        //decide what to do by object tag
        switch (go.tag)
        {
            case "Moveable":
                //start moving the object
                InititateMove(go);
                break;
            case "Interactable":
                go.GetComponent<InteractableInterface>().Interact();
                break;
        }
    }

    //sets variables so player can move object along forward vector
    private void InititateMove(GameObject go)
    {
        //set moveGO variable to object
        moveGO = go;

        //calculate initial distance between player and object
        Vector3 diff = go.transform.position - this.transform.position;
        moveDistance = diff.magnitude;

        movingObj = true;
    }

    //end the moving of current object
    private void EndMove()
    {
        movingObj = false;
    }

    //if player collides with object hes moving, drop object
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject == moveGO)
        {
            EndMove();
        }
    }

    public void SetInputs(bool interact)
    {
        this.interact = interact;
    }
}
