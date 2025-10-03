using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyAttack : MonoBehaviour
{
    public PlayerStats playerHealth;


    public int attackDmg;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

    public ParticleSystem whirl;

    bool maskStarted;

    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");

        playerHealth = p.GetComponent<PlayerStats>();

        maskStarted = true;

    }

    public void Attack()
    {
        Vector3 pos = transform.position;


        pos += Vector3.right * attackOffset.x;
        pos += Vector3.up * attackOffset.y;
        pos += Vector3.forward * attackOffset.z;

        Collider[] colInfo = Physics.OverlapSphere(pos, attackRange, attackMask);
      

        foreach (Collider nearbyObj in colInfo)
        {
            if (nearbyObj.CompareTag("Player") && playerHealth != null)
            {
                AudioManager.instance.PlayOneShot(FMODEvents.instance.DummySlash, this.transform.position);
                playerHealth.TakeDamage(attackDmg);
                Debug.Log("player is taking damage");
            }

            else
            {
               
            }

        }

    }

    public void Effect()
    {

        whirl.Play();

    }

    void OnDrawGizmos()
    {
        Vector3 pos = transform.position;
        pos += Vector3.right * attackOffset.x;
        pos += Vector3.up * attackOffset.y;
        pos += Vector3.forward * attackOffset.z;

        Gizmos.color = Color.red;

        if (maskStarted)
        {
            Gizmos.DrawWireSphere(pos, attackRange);
        }
    }
}
