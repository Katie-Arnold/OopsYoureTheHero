using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Minion_Move : StateMachineBehaviour
{

    public float speed = 2.5f;
    Transform player;
    Transform goblin; 
    Rigidbody rb;

    public float attackRange;

    UnityEngine.AI.NavMeshAgent navAgent;
    UnityEngine.AI.NavMeshAgent navAgentMoot;

    [SerializeField] private float timer = 5;
    private float arrowTime;


    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody>();

       // goblin = transform.GetComponent<Transform>();

        navAgent = GameObject.FindGameObjectWithTag("GobMinion").GetComponent<UnityEngine.AI.NavMeshAgent>();
        navAgentMoot = GameObject.FindGameObjectWithTag("GobMoot").GetComponent<UnityEngine.AI.NavMeshAgent>();
        //  boss = animator.GetComponent<Boss_Look>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


        //arrowTime -= Time.deltaTime;

        //if (arrowTime > 0)
        //{
        //    return;
        //}

        //arrowTime = timer;

        //Vector3 target = new Vector3(player.position.x, rb.position.y, player.position.z);
        //Vector3 newPos = Vector3.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        //rb.MovePosition(newPos);



        float distance = Vector3.Distance(player.position, player.position);

        //if (distance <= navAgent.stoppingDistance)
        //{
        //    Vector3 direction = (player.position - player.transform.position).normalized;
        //    Quaternion lookDirection = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        //    player.transform.rotation = Quaternion.Slerp(player.transform.rotation, lookDirection, Time.deltaTime * 10f);
        //}

        //if (distance <= navAgentMoot.stoppingDistance)
        //{
        //    Vector3 direction = (player.position - player.transform.position).normalized;
        //    Quaternion lookDirection = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        //    player.transform.rotation = Quaternion.Slerp(player.transform.rotation, lookDirection, Time.deltaTime * 10f);
        //}

        navAgent.SetDestination(player.position);
        navAgentMoot.SetDestination(player.position);


        if (Vector3.Distance(player.position, rb.position) >= attackRange)
        {
            animator.SetTrigger("IsShooting");
            //navAgent.SetDestination(rb.position);
            
        }

        //navAgent.SetDestination(player.position);

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("IsShooting");
      //  navAgent.SetDestination(player.position);
    }
}
