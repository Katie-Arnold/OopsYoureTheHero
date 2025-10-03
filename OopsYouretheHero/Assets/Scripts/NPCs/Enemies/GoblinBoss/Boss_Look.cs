using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;

public class Boss_Look : MonoBehaviour
{

    public Transform player;

   //public Transform target;

    //UnityEngine.AI.NavMeshAgent navAgent;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

       // navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
       // LookAt();
    }


   public void LookAt()
    {
        //old Look code start 
        //Vector3 direction = (player.position - player.position).normalized;

        //Vector3 direction = player.position - player.position;

        //Quaternion lookDirection = Quaternion.LookRotation(new Vector3(player.position.x, 0, player.position.z));
        //Quaternion lookDirection = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        ////Quaternion lookDirection = Quaternion.LookRotation(direction, Vector3.left);

        //transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, Time.deltaTime * 60f);
        //transform.rotation = lookDirection;
        //transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, Time.deltaTime * 10f);

        //old Look code end 

        //float distance = Vector3.Distance(transform.position, target.position);

        //if (distance <= navAgent.stoppingDistance)
        //{
        //    Vector3 direction = (target.position - transform.position).normalized;
        //    Quaternion lookDirection = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        //    transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, Time.deltaTime * 10f);
        //}

        //navAgent.SetDestination(target.position);
    }
}
