using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class Enemies : MonoBehaviour
{
    public float radius = 4f;
    int exDmg = 10;

    GameObject player;

    CharacterStats myStats;
    UnityEngine.AI.NavMeshAgent navAgent;

    public ParticleSystem impactEffect;

    public EnemyHealthBar enHealthBar;

    [SerializeField] private Transform push;

    GameObject[] explodeBarrel;

    public Vector3 exOffset;
    public float enemyRange;
    public LayerMask exMask;

    public bool barrelDestroyed = false;
    public bool explosionCalled = false; 

   


    // Start is called before the first frame update
    void Start()
    {
        player = PlayerManager.instance.player;
        myStats = GetComponent<CharacterStats>();
        navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        push = GetComponent<Transform>();


        enHealthBar.SetMaxHealth(myStats.health);

        barrelDestroyed = false;
        explosionCalled = false;

        //Invoke("ExplosionEffect", 1.0f);

        //explodeCalled = false;

       // StartCoroutine(ExplosionEffect());

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
                    impactEffect.Play();

                    var duration = 0.2f;
                    push.DOPunchPosition(punch: Vector3.back * 1, duration: 0.2f, vibrato: 0, elasticity: 0);
                    push.DOShakePosition(duration: 0.2f, strength: 0.2f, vibrato: 5).SetDelay(duration * 0.5f);

                    if (myStats.health == 0)
                    {
                        push.DOKill();
                        Debug.Log("killed dotween");

                    }
                    //  push.DOKill();
                    //push.DOMove(Vector3.forward, 0.2f);

                    enHealthBar.SetHealth(myStats.health);

                }
            }
        }


        StartCoroutine(CountDown());




    }

    public void ExplosionEffect()
    {
        //Debug.Log("coroutine for explode started");
        Vector3 pos = transform.position;

        pos += Vector3.right * exOffset.x;
        pos += Vector3.up * exOffset.y;
        pos += Vector3.forward * exOffset.z;


        Collider[] hitColl = Physics.OverlapSphere(pos, enemyRange, exMask);

        foreach (Collider enemyObj in hitColl)
        {
            // gotExplode = true;
            //Collider[] hitColl = Physics.OverlapSphere(pos, enemyRange, exMask);

            if (enemyObj.CompareTag("Explosive"))
            {
                //gotExplode = true;

                ExplodingBarrelStats explodeHealth = enemyObj.GetComponent<ExplodingBarrelStats>();

                Debug.Log("found explosion in collider");



                if (explodeHealth.health == 0)
                {
                    Debug.Log("barrel health is at 0");

                    barrelDestroyed = true;

                    if (barrelDestroyed)
                    {
                        if(!explosionCalled)
                        {

                            explosionCalled = true;
                            Debug.Log("enemy taking damage");

                            myStats.TakeDamage(exDmg);

                            impactEffect.Play();

                            var duration = 0.2f;
                            push.DOPunchPosition(punch: Vector3.back * 1, duration: 0.2f, vibrato: 0, elasticity: 0);
                            push.DOShakePosition(duration: 0.2f, strength: 0.2f, vibrato: 5).SetDelay(duration * 0.5f);


                            if (myStats.health == 0)
                            {
                                push.DOKill();
                                Debug.Log("killed dotween");

                            }

                            if (explosionCalled == true)
                            {

                                StartCoroutine("ResetExplode");
                            }



                            enHealthBar.SetHealth(myStats.health);

                        }
          

                    }
                }

            }

        }

      
    }



    IEnumerator CountDown()
    {
        // Debug.Log("explosion coroutine started");
        yield return new WaitForSeconds(0.5f);
        ExplosionEffect();
       // ExplosionDamage();

        //AudioManager.instance.PlayOneShot(FMODEvents.instance.explosiveBarrel, this.transform.position);

    }

    IEnumerator ResetExplode()
    {
        yield return new WaitForSeconds(2f);

        explosionCalled = false; 
    }


}
