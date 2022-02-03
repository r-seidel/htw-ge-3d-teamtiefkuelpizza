using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconScript : MonoBehaviour
{
    public void DestroyBeacon()
    {
        Destroy(this.gameObject);
    }
}
