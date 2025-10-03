using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy2_Move : StateMachineBehaviour
{
    public float speed = 2.5f;
    Transform player;
    Rigidbody rb;

    public float attackRange = 1f;

    UnityEngine.AI.NavMeshAgent navAgent;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody>();

        navAgent = GameObject.FindGameObjectWithTag("Dummy2").GetComponent<UnityEngine.AI.NavMeshAgent>();



    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        float distance = Vector3.Distance(player.position, player.position);

        //if (distance <= navAgent.stoppingDistance)
        //{
        //    Vector3 direction = (player.position - player.transform.position).normalized;
        //    Quaternion lookDirection = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        //    player.transform.rotation = Quaternion.Slerp(player.transform.rotation, lookDirection, Time.deltaTime * 10f);


        //}

        navAgent.SetDestination(player.position);

        if (Vector3.Distance(player.position, rb.position) <= attackRange)
        {

            animator.SetTrigger("IsAttacking");

        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        animator.ResetTrigger("IsAttacking");

    }
}
