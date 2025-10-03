using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDamage : MonoBehaviour
{
    public PlayerStats playerHealth;



    //allow specific attack damage for individual enemy in the playerHealth.TakeDamage section
    public int attackDmg;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;


    // Start is called before the first frame update
    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");

        if(p != null)
        {
            Debug.Log("found player");
        }

        playerHealth = p.GetComponent<PlayerStats>();

        if(playerHealth != null)
        {
            Debug.Log("found stats");
        }
    }

  

    public void Attack()
    {
        Vector3 pos = transform.position;


        pos += Vector3.right * attackOffset.x;
        pos += Vector3.up * attackOffset.y;
        pos += Vector3.forward * attackOffset.z;

        //GameObject other = GameObject.FindGameObjectWithTag("Player");
        Collider[] colInfo = Physics.OverlapSphere(pos, attackRange, attackMask);
        foreach (Collider nearbyObj in colInfo)
        {

            Debug.Log("another collider seen here");


            if (nearbyObj.CompareTag("Player") && playerHealth != null)
            {
                Debug.Log("hit player");
                playerHealth.TakeDamage(attackDmg);
            }



        }


    }


    void OnDrawGizmos()
    {
        Vector3 pos = transform.position;
        pos += Vector3.right * attackOffset.x;
        pos += Vector3.up * attackOffset.y;
        pos += Vector3.forward * attackOffset.z;

        Gizmos.color = Color.blue;

        
            Gizmos.DrawWireSphere(pos, attackRange);
        
    }

}
