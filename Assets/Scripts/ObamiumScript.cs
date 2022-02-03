using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObamiumScript : MonoBehaviour
{
    public GameObject obamium;

    public void AmericaFuckYeah()
    {
        GameObject go = transform.parent.parent.GetComponent<PlayerRaycastScript>().GetLookedAt();
        if(go != null && go.name == "BaseModel")
        {
            GameObject obama = Instantiate(obamium, go.transform.parent.position, new Quaternion(0,0,0,0), go.transform.parent);
            Destroy(go);
        }
    }
}
