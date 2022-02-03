using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public bool spawning;
    public float interval;
    public int toSpawn;
    public GameObject enemy;
    public GameObject beacon;

    private float timer;

    // Update is called once per frame
    void Update()
    {
        if (spawning)
        {
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                timer = 0f;
                if (toSpawn > 0)
                {
                    toSpawn--;

                    float randomX = Random.Range(transform.position.x - transform.localScale.x / 2,
                                                        transform.position.x + transform.localScale.x / 2);
                    float randomZ = Random.Range(transform.position.z - transform.localScale.z / 2,
                                                            transform.position.z + transform.localScale.z / 2);

                    Vector3 pos = new Vector3(randomX, transform.position.y, randomZ);

                    RaycastHit hit;
                    Ray ray = new Ray(pos, Vector3.down);
                    if (Physics.Raycast(ray, out hit, 100f))
                    {
                        GameObject go = Instantiate(enemy, hit.point, new Quaternion(0, 0, 0, 0), GameObject.Find("EnemyContainer").transform);
                        Instantiate(beacon, hit.point, new Quaternion(0, 0, 0, 0));
                    }
                }
            }
        }
    }
}
