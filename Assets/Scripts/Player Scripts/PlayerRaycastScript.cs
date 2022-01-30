using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycastScript : MonoBehaviour
{
    public float maxDistance = 5f;  //length of the raycast
    public GameObject cameraObject; //camera game object

    // Update is called once per frame
    void Update()
    {
        //gizmo of raycast
        RaycastHit vis;
        if (Physics.Raycast(cameraObject.transform.position, cameraObject.transform.TransformDirection(Vector3.forward), out vis, maxDistance))
        {
            Debug.DrawRay(cameraObject.transform.transform.position, cameraObject.transform.TransformDirection(Vector3.forward) * vis.distance, Color.yellow);
        }
        else
        {
            Debug.DrawRay(cameraObject.transform.transform.position, cameraObject.transform.TransformDirection(Vector3.forward) * maxDistance, Color.white);
        }
    }

    public GameObject GetLookedAt()
    {
        //casts a raycast and returns the object it 
        RaycastHit hit;
        Physics.Raycast(cameraObject.transform.position, cameraObject.transform.TransformDirection(Vector3.forward), out hit, maxDistance);
        if (hit.collider == null) { return null; } else { return hit.collider.gameObject; }
    }
}
