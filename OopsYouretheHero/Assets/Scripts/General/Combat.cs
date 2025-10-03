using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Combat : MonoBehaviour
{
    public CharacterStats myStats;

    public float attackCooldown;
    
    bool canAttack = true;

    public float attackForceRadius;
    public float attackForcPower;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
    bool m_Started;

    // Start is called before the first frame update
    void Start()
    {
        myStats = GetComponent<CharacterStats>();


        m_Started = true;
    }


    void Update()
    {
        if(canAttack == false)
        {
            attackCooldown -= Time.deltaTime;
            if(attackCooldown <= 0)
            {
                canAttack = true;
            }
        }
    }

    public void MeleeAttack(CharacterStats targetStats)
    {
        if (attackCooldown <= 0)
        {
            //targetStats.TakeDamage(myStats.damage);
            //targetStats.TakeDamage(myStats.damage);
            targetStats.TakeDamage(myStats.damage);
            attackCooldown = 1 / myStats.attackSpeed;
            canAttack = false;

            AudioManager.instance.PlayOneShot(FMODEvents.instance.enemyHit, this.transform.position);


            Vector3 pos = transform.position;


            pos += Vector3.right * attackOffset.x;
            pos += Vector3.up * attackOffset.y;
            pos += Vector3.forward * attackOffset.z;


            Vector3 attackPosition = transform.position;
            Collider[] colliders = Physics.OverlapSphere(attackPosition, attackForceRadius); 

            foreach (Collider hit  in colliders)
            {

                Transform rb = hit.GetComponent<Transform>(); 

                if(rb  != null)
                {

                    //var duration = 0.5f;
                    //rb.DOPunchPosition(punch: Vector3.back * 2, duration: 0.5f, vibrato: 0, elasticity: 0);
                    //rb.DOShakePosition(duration: 0.5f, strength: 0.5f, vibrato: 10).SetDelay(duration * 0.5f);

                    //Vector3 push = new Vector3(-1, 0, 0); 
                    //rb.DOMove(Vector3.back, 1);


                    // var duration = 0.5f;
                    // rb.isKinematic = false;
                    //rb.DOPunchPosition(punch: Vector3.back * 2, duration: duration,  vibrato: 0, elasticity: 0);

                    //rb.DOShakePosition(duration: 0.5f, strength: 0.5f, vibrato: 10).SetDelay(duration * 0.5f);


                    //Debug.Log("player push"); 

                    //coroutine for delay time/cooldown to turn inkinematic back on 
                    //need to add effect of being hit 
                }
                

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
