using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Minion_Stand : StateMachineBehaviour
{
    public float speed = 2.5f;
    Transform player;
    Transform goblin;
    Rigidbody rb;

    public float attackRange;

    UnityEngine.AI.NavMeshAgent navAgentMax;
    UnityEngine.AI.NavMeshAgent navAgentMud;

    [SerializeField] private float timer = 5;
    private float arrowTime;


    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody>();

        // goblin = transform.GetComponent<Transform>();

        
        navAgentMax = GameObject.FindGameObjectWithTag("GobMax").GetComponent<UnityEngine.AI.NavMeshAgent>();
        navAgentMud = GameObject.FindGameObjectWithTag("GobMud").GetComponent<UnityEngine.AI.NavMeshAgent>();
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

        if (distance <= navAgentMax.stoppingDistance)
        {
            Vector3 direction = (player.position - player.transform.position).normalized;
            Quaternion lookDirection = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
           // navAgentMax.transform.rotation = Quaternion.Slerp(player.transform.rotation, lookDirection, Time.deltaTime * 10f);
        }


        if (distance <= navAgentMud.stoppingDistance)
        {
            Vector3 direction = (player.position - player.transform.position).normalized;
            Quaternion lookDirection = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            //navAgentMud.transform.rotation = Quaternion.Slerp(player.transform.rotation, lookDirection, Time.deltaTime * 1f);
        }


        //navAgentMax.SetDestination(player.position);
        //navAgentMud.rotation = Quaternion.Slerp(navAgentMud.rotation, player.position, Time.deltaTime * 10f);




        if (Vector3.Distance(player.position, rb.position) <= attackRange)
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
