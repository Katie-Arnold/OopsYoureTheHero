using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dummy_Move : StateMachineBehaviour
{
    public float speed = 2.5f;
    Transform player;
    // Rigidbody rb;

    Rigidbody rb; 

    public float attackRange = 1f;

    GameObject[] navAgents;
    //UnityEngine.AI.NavMeshAgent navAgent;
    UnityEngine.AI.NavMeshAgent navAgent;
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //rb = animator.GetComponent<Rigidbody>();

       // navAgent = GameObject.FindGameObjectWithTag("Dummy").GetComponent<UnityEngine.AI.NavMeshAgent>();
        navAgents = GameObject.FindGameObjectsWithTag("Dummy");

        for (int i = 0; i < navAgents.Length; i++)
        {
            navAgent = navAgents[i].GetComponent<UnityEngine.AI.NavMeshAgent>();
            rb = navAgents[i].GetComponent<Rigidbody>();
            Debug.Log(navAgents.Length);
        }

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
