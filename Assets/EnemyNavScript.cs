using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavScript : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;

    private GameObject player;
    private bool navigating = true;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (navigating)
        {
            agent.SetDestination(player.transform.position);
        }
    }

    void OnAnimatorMove()
    {
        if (navigating)
        {
            // set the navAgent's velocity to the velocity of the playing animation clip
            agent.velocity = animator.deltaPosition / Time.deltaTime;
            // smoothly rotate the character in the desired direction of motion
            Quaternion lookRotation = Quaternion.LookRotation(agent.desiredVelocity);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,
                     lookRotation, agent.angularSpeed * Time.deltaTime);
        }
    }

    public void DisableNavigation()
    {
        navigating = false;
        agent.enabled = false;
    }
}
