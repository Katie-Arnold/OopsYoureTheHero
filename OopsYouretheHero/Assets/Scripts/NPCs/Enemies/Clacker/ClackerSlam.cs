using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClackerSlam : MonoBehaviour
{
    public PlayerStats playerHealth;
    public PlayerController playControl;

    public bool tieBoss = false;

    public Animator clackAnimator;

    public float ropeCoolDown;
    public Transform ropeSpawnPoint;
    public GameObject ropeObject;
    public ParticleSystem ropeSmoke;

    //allow specific attack damage for individual enemy in the playerHealth.TakeDamage section
    public int attackDmg;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

    public Vector3 soundOffset;
    public float soundRange = 1f;
    public LayerMask soundMask;

    bool m_Started;

    public Vector3 ropeOffset;
    public float ropeRange;
    public LayerMask ropeMask;
    bool layerStarted;

    // public ParticleSystem whirl;

    //Start is called before the first frame update
    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");


        playerHealth = p.GetComponent<PlayerStats>();
        playControl = p.GetComponent<PlayerController>();

        clackAnimator = this.GetComponent<Animator>();

        m_Started = true;
    }

    void Update()
    {
   


        TieDown();


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
            if (nearbyObj.CompareTag("Player") && playerHealth != null)
            {
                //AudioManager.instance.PlayOneShot(FMODEvents.instance.gobBossSlash, this.transform.position);

                playerHealth.TakeDamage(attackDmg);
                Debug.Log("player is taking damage");

                //AudioManager.instance.PlayOneShot(FMODEvents.instance.gobBossSlash, this.transform.position);
            }


        }


    }



    public void TieDown()
    {

        Vector3 ropePos = transform.position;

        ropePos += Vector3.right * ropeOffset.x;
        ropePos += Vector3.right * ropeOffset.y;
        ropePos += Vector3.right * ropeOffset.z;


        Collider[] colliderInfo = Physics.OverlapSphere(ropePos, ropeRange, ropeMask);

        foreach (Collider nearbyObj in colliderInfo)
        {

            if (nearbyObj.CompareTag("Player") && playControl.hasRope == true)
            {
               // Debug.Log("foudn player collider in boss forweach");
                tieBoss = true;

                //if(tieBoss == true)
                //{
                //    bossAnimator.SetTrigger("IsCaught");
                //    Debug.Log("is getting boss collider");
                //}

                if (Input.GetKeyDown(KeyCode.V))
                {


                    clackAnimator.SetTrigger("IsCaught");
                    ropeSmoke.Play();
                    //plya vfxx once here
                    //RopeSpawnBoss();


                }


            }

            //else
            //{ 
            //    tieBoss = false; 
            //}

        }



    }

    public void RopeSpawnBoss()
    {

        GameObject ropeObj = Instantiate(ropeObject, ropeSpawnPoint.transform.position, ropeSpawnPoint.transform.rotation) as GameObject;

        Destroy(ropeObj, ropeCoolDown);

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
