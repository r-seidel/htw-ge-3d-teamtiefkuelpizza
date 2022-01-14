using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavScript : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;
    public float navRefreshInterval;

    private bool navigating = true;
    private float timer;

    private void Start()
    {
        agent.SetDestination(GetCliffPosition());
    }

    // Update is called once per frame
    void Update()
    {
        if (navigating)
        {
            timer += Time.deltaTime;
            if (timer >= navRefreshInterval)
            {
                timer = 0f;
                agent.SetDestination(GetCliffPosition());
            }
        }
    }

    void OnAnimatorMove()
    {
        if (navigating)
        {
            // set the navAgent's velocity to the velocity of the playing animation clip
            agent.velocity = animator.deltaPosition / Time.deltaTime;
            // smoothly rotate the character in the desired direction of motion
            if (agent.desiredVelocity != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(agent.desiredVelocity);
                transform.rotation = Quaternion.RotateTowards(transform.rotation,
                         lookRotation, agent.angularSpeed * Time.deltaTime);
            }
        }
    }

    public void DisableNavigation()
    {
        navigating = false;
        agent.enabled = false;
    }

    private Vector3 GetCliffPosition()
    {
        Transform cliffTransform = GameObject.Find("SuicideCliff").transform;
        float clampScale = cliffTransform.localScale.z / 2;
        float customZ = Mathf.Clamp(transform.position.z,
            cliffTransform.position.z - clampScale,
            cliffTransform.position.z + clampScale);

        return new Vector3(cliffTransform.position.x, cliffTransform.position.y, customZ);
    }
}