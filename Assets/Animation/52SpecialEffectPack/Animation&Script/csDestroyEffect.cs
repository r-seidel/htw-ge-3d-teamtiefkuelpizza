using UnityEngine;
using System.Collections;

public class csDestroyEffect : MonoBehaviour {

    private float timer;

	void Update ()
    {
        timer += Time.deltaTime;
	    if(timer >= 1f)
        {
            Destroy(gameObject);
        }
	}
}
