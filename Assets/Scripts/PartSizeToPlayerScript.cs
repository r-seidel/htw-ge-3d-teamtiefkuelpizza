using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartSizeToPlayerScript : MonoBehaviour
{
    private float origSize;
    // Start is called before the first frame update
    void Start()
    {
        origSize = GetComponent<ParticleSystem>().main.startSizeMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<ParticleSystem>().startSize = origSize * (transform.position - GameObject.Find("Player").transform.position).magnitude;
    }
}
