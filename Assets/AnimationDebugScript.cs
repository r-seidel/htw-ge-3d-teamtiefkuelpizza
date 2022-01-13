using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDebugScript : MonoBehaviour
{

    public bool positionLocked;

    private bool positionSaved;
    private Vector3 lockPosition;

    private void Update()
    {
        if (positionLocked)
        {
            if (!positionSaved)
            {
                lockPosition = transform.position;
                positionSaved = true;
            }

            this.transform.position = lockPosition;
        }
        else
        {
            positionSaved = false;
        }
    }
}
