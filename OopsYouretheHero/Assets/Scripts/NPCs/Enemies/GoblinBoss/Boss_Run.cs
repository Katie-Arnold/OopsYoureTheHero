using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss_Run : StateMachineBehaviour
{
    public float speed; 
    Transform player;
    Rigidbody rb;

    public float attackRange = 1f;
    public float jumpRangeMin = 10f;
    public float jumpRangeMax = 20f;

    UnityEngine.AI.NavMeshAgent navAgent;
    
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
       rb =  animator.GetComponent<Rigidbody>();

       

        navAgent = GameObject.FindGameObjectWithTag("Boss").GetComponent<UnityEngine.AI.NavMeshAgent>();
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

            animator.SetTrigger("IsPunching");

        }

        if (jumpRangeMin >=  Vector3.Distance(player.position, rb.position) && Vector3.Distance(player.position, rb.position) <= jumpRangeMax)
        {
            //animator.ResetTrigger("IsPunching");

            animator.SetTrigger("IsJumping");

        }
    }

   // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("IsPunching");

        animator.ResetTrigger("IsJumping");
    }

}
