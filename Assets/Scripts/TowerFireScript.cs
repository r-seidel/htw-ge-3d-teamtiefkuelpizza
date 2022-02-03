using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFireScript : MonoBehaviour
{
    public float powerUpTime;       // time between finding new target and shooting it
    public float minSearchCoolDown; // random time between min and max sets interval to look for new target
    public float maxSearchCoolDown;
    public float killTime;          // time the laser will shoot a target until it dies
    public float maxRange;          // laser wont shoot if the target is outside of range
    public LayerMask layerMask;     // set layers laser can shoot through

    private LineRenderer laser;
    private Animator orbAnim;
    private GameObject target;
    private float timer = 0f;
    private float searchCoolDown;
    private AttackState attackState = AttackState.Idle;

    private enum AttackState{
        Idle,
        PoweringUp,
        Shooting
    }

    private void Start()
    {
        SetNewRandomSearchCoolDown();
        laser = transform.GetChild(0).GetComponent<LineRenderer>();
        orbAnim = transform.GetChild(1).GetComponent<Animator>();
    }

    private void Update()
    {
        switch (attackState)
        {
            case AttackState.Idle:
                {
                    timer += Time.deltaTime;
                    if(timer >= searchCoolDown)
                    {
                        timer = 0f;

                        if (SetNewTarget())
                        {
                            orbAnim.SetTrigger("PowerUp");
                            attackState = AttackState.PoweringUp;
                        }
                    }
                    break;
                }
            case AttackState.PoweringUp:
                {
                    if (!TargetStillValid())
                    {
                        if(target != null)
                        {
                            target.GetComponent<EnemyHitScript>().claimed = false;
                        }
                        timer = searchCoolDown;
                        orbAnim.SetTrigger("PowerDown");
                        attackState = AttackState.Idle;
                        break;
                    }

                    timer += Time.deltaTime;
                    if(timer >= powerUpTime)
                    {
                        timer = 0f;

                        orbAnim.SetTrigger("PowerDown");
                        GetComponent<AudioSource>().Play();
                        transform.parent.GetComponent<AudioSource>().Play();
                        attackState = AttackState.Shooting;
                    }
                    break;
                }
            case AttackState.Shooting:
                {
                    if (!TargetStillValid())
                    {
                        timer = searchCoolDown;
                        target.GetComponent<EnemyHitScript>().claimed = false;
                        laser.gameObject.SetActive(false);
                        StartCoroutine(AudioFadeOut.FadeOut(GetComponent<AudioSource>(), 1f));
                        attackState = AttackState.Idle;
                        break;
                    }

                    laser.SetPosition(1, target.transform.position - transform.position);
                    laser.gameObject.SetActive(true);

                    timer += Time.deltaTime;
                    if(timer >= killTime)
                    {
                        timer = 0f;

                        target.GetComponent<EnemyHitScript>().InitiateDeath();
                        laser.gameObject.SetActive(false);
                        SetNewRandomSearchCoolDown();
                        StartCoroutine(AudioFadeOut.FadeOut(GetComponent<AudioSource>(), 1f));
                        attackState = AttackState.Idle;
                    }
                    break;
                }
        }
    }

    public bool GetIfShooting()
    {
        return attackState == AttackState.Shooting;
    }

    // find all enemies, cast raycasts to see which this tower can see
    // set the enemy that is farthest away as target
    private bool SetNewTarget()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("EnemyMain");

        List<GameObject> possibleTargets = new List<GameObject>();
        foreach(GameObject enemy in enemies)
        {
            if (IsSeeing(enemy) && !enemy.GetComponent<EnemyHitScript>().claimed)
            {
                possibleTargets.Add(enemy);
            }
        }

        if(possibleTargets.Count == 0)
        {
            return false;
        }
        else
        {
            target = GetFarthest(possibleTargets.ToArray());
            target.GetComponent<EnemyHitScript>().claimed = true;
            return true;
        }
    }

    //returns the game object of the array that is farthest distance away from this game object
    private GameObject GetFarthest(GameObject[] gos)
    {
        GameObject farthest = null;
        float maxDistance = 0f;

        foreach(GameObject go in gos)
        {
            float distance = (go.transform.position - transform.position).magnitude;
            if (distance > maxDistance)
            {
                maxDistance = distance;
                farthest = go;
            }
        }

        return farthest;
    }

    // cast raycast from this position, if it hits given game object return true, else false
    private bool IsSeeing(GameObject go)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, go.transform.position - transform.position);
        if (Physics.Raycast(ray, out hit, maxRange, layerMask))
        {
            if (hit.collider.gameObject == go)
            {
                return true;
            }
        }

        return false;
    }

    // checks if the target is still valid to attack
    private bool TargetStillValid()
    {
        if(target == null)
        {
            return false;
        }
        else if (target.GetComponent<EnemyHitScript>().dying)
        {
            return false;
        }

        return true;
    }

    private void SetNewRandomSearchCoolDown()
    {
        searchCoolDown = Random.Range(minSearchCoolDown, maxSearchCoolDown);
    }
}
