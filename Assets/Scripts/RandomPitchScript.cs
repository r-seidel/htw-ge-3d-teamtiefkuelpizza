using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPitchScript : MonoBehaviour
{
    public float min;
    public float max;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource s = GetComponent<AudioSource>();
        s.pitch = Random.Range(min, max);
        s.Play();
    }

}
