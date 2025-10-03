using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    float radius = 2f;

    GameObject player;

    public CharacterStats myStats;
    UnityEngine.AI.NavMeshAgent navAgent;


    // Start is called before the first frame update
    void Start()
    {
        player = PlayerManager.instance.player;
        myStats = GetComponent<CharacterStats>();
        navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);


        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (distance <= radius)
            {
                Combat playerCombat = player.GetComponent<Combat>();

                if (playerCombat != null)
                {
                    playerCombat.MeleeAttack(myStats);
                }
            }
        }

        if (distance <= navAgent.stoppingDistance)
        {
            Combat myCombat = GetComponent<Combat>();
            CharacterStats playerStats = player.GetComponent<CharacterStats>();

            myCombat.MeleeAttack(playerStats);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
