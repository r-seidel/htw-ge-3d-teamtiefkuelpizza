using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWatchScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //get the GameObject player is looking at from PlayerRaycastScript
        GameObject go = this.GetComponent<PlayerRaycastScript>().GetLookedAt();

        //if player is looking at something
        if (go != null)
        {
            //if looked at object has WatchedInterface
            if (go.GetComponent<WatchedInterface>() != null)
            {
                // call Interact() of InteractableInterface
                go.GetComponent<WatchedInterface>().SetWatchedTrue();
            }
        }
    }
}
