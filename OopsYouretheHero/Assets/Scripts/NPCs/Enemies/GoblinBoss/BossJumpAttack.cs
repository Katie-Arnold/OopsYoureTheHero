using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossJumpAttack : MonoBehaviour
{
    public PlayerStats playerHealth;


    public ParticleSystem crash; 
    
    //allow specific attack damage for individual enemy in the playerHealth.TakeDamage section
    public int attackDmg;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

    public Vector3 soundOffset;
    public float soundRange = 1f;
    public LayerMask soundMask;


    bool m_Started;

    // public ParticleSystem whirl;

    //Start is called before the first frame update
    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");

        playerHealth = p.GetComponent<PlayerStats>();

        m_Started = true;

    }



    public void JumpAttack()
    {
        Vector3 pos = transform.position;


        pos += Vector3.right * attackOffset.x;
        pos += Vector3.up * attackOffset.y;
        pos += Vector3.forward * attackOffset.z;

        //GameObject other = GameObject.FindGameObjectWithTag("Player");
        Collider[] colInfo = Physics.OverlapSphere(pos, attackRange, attackMask);
        //if (colInfo != null)
        //{
        //    playerHealth.TakeDamage(attackDmg);

        //    // colInfo.GetComponent<PlayerStats>().TakeDamage(attackDmg);
        //}

        foreach (Collider nearbyObj in colInfo)
        {
            if (nearbyObj.CompareTag("Player") && playerHealth != null)
            {

                playerHealth.TakeDamage(attackDmg);
                //Debug.Log("player is taking damage");

               // crash.Play();

            }

            //else
            //{
            //    //crash.Stop();
            //}


        }

        
    }
    
    public void JumpEffects()
    {
        Vector3 pos = transform.position;


        pos += Vector3.right * soundOffset.x;
        pos += Vector3.up * soundOffset.y;
        pos += Vector3.forward * soundOffset.z;

        Collider[] colInfo = Physics.OverlapSphere(pos, soundRange, soundMask);

        foreach (Collider nearbyObj in colInfo)
        {
            if (nearbyObj.CompareTag("Player"))
            {
                AudioManager.instance.PlayOneShot(FMODEvents.instance.gobBossJump, this.transform.position);
                crash.Play();
            }

            else
            {
                crash.Stop();
            }


        }

    }


  void OnDrawGizmos()
    {
        Vector3 pos = transform.position;
        pos += Vector3.right * attackOffset.x;
        pos += Vector3.up * attackOffset.y;
        pos += Vector3.forward * attackOffset.z;

        Gizmos.color = Color.red;

        if (m_Started)
        {
            Gizmos.DrawWireSphere(pos, attackRange);
        }
    }

  
}
