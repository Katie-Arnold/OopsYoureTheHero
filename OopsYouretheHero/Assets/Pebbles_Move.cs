using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Pebbles_Move : StateMachineBehaviour
{

    public float speed;
    Transform player;
    Rigidbody rb;

    public float attackRange = 1f;

    UnityEngine.AI.NavMeshAgent navAgent;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody>();

        navAgent = GameObject.FindGameObjectWithTag("Pebbles").GetComponent<UnityEngine.AI.NavMeshAgent>();


        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        //Navmesh move start
        float distance = Vector3.Distance(player.position, player.position);

        if (distance <= navAgent.stoppingDistance)
        {
            Vector3 direction = (player.position - player.transform.position).normalized;
            Quaternion lookDirection = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            // player.transform.rotation = Quaternion.Slerp(player.transform.rotation, lookDirection, Time.deltaTime * 1f);
        }

        navAgent.SetDestination(player.position);
        //navmesh move end

        if (Vector3.Distance(player.position, rb.position) <= attackRange)
        {
            // animator.ResetTrigger("IsJumping");

            animator.SetTrigger("IsBiting");

        }



    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("IsBiting");



    }



}
