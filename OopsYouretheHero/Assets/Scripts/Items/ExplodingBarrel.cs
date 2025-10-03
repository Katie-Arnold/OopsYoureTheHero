using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBarrel : MonoBehaviour
{

    //public int bHealth;
    public int exDmg;

   // public AudioSource boomBoop; 

    public ParticleSystem explode;
    public ParticleSystem explodeSmoke;
    public ParticleSystem explodeRangeVFX; 

    public float disRadius; 

    public Vector3 exOffset;
    public float explosionRange;
    public LayerMask exMask;

    bool exMaskStarted;
   public bool playerClose = false; 

    CharacterStats myStats; 
    public PlayerStats playerHealth;
    public DummyStats enemysHealth;

    public DummyStats dummyHealth;
    public DummyStats dummy2Health;
    public DummyStats dummy3Health;
    public GobMinsStats gobMinHealth;
    public GobMinsStats gobMootHealth;
    public GobMinsStats gobMaxHealth;
    public GobMinsStats gobMudHealth;
    public GoblinBossStats gobBossHealth;


    //public GameObject[] explodables;
    //ExplodableItemHealthStat itemsStats;
    //ExplodableItem triggerState; 
    public ExplodableItemHealthStat itemStat;
    public ExplodableItemHealthStat itemStat2;
    public ExplodableItemHealthStat itemStat3;
    public ExplodableItemHealthStat itemStat4;
    public ExplodableItemHealthStat itemStat5;

    public float forceRadius;
    public float forcePower;

    GameObject player;

    //player stats variable 
    //enemy stats variable (dummy and minion and boss separately when those are created

    // Start is called before the first frame update
    void Start()
    {
        playerClose = false;
        exMaskStarted = true;
        
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        GameObject dummy = GameObject.FindGameObjectWithTag("Dummy");
        GameObject dummy2 = GameObject.FindGameObjectWithTag("Dummy2");
        GameObject dummy3 = GameObject.FindGameObjectWithTag("Dummy3");
        GameObject gobMin = GameObject.FindGameObjectWithTag("GobMinion");
        GameObject gobMoot = GameObject.FindGameObjectWithTag("GobMoot");
        GameObject gobMax = GameObject.FindGameObjectWithTag("GobMax");
        GameObject gobMud = GameObject.FindGameObjectWithTag("GobMud");
        GameObject gobBoss = GameObject.FindGameObjectWithTag("Boss");

       // explodables = GameObject.FindGameObjectsWithTag("Explodable");

        GameObject testGroup = GameObject.FindGameObjectWithTag("Explodable");
        GameObject testGroup2 = GameObject.FindGameObjectWithTag("Explodable2");
        GameObject testGroup3 = GameObject.FindGameObjectWithTag("Explodable3");
        GameObject testGroup4 = GameObject.FindGameObjectWithTag("Explodable4");
        GameObject testGroup5 = GameObject.FindGameObjectWithTag("Explodable5");

        //for (int i = 0; i < explodables.Length; i++)
        //{
        //    //itemsStats = explodables[i].GetComponent<ExplodableItemHealthStat>();
        //    Debug.Log("got items health stat");
        //    Debug.Log(explodables.Length);


        //}



        player = PlayerManager.instance.player;

        myStats = GetComponent<CharacterStats>();
        playerHealth = GetComponent<PlayerStats>();
        enemysHealth = GetComponent<DummyStats>();
        //boomBoop = GetComponent<AudioSource>(); 


        playerHealth = p.GetComponent<PlayerStats>();
        enemysHealth = dummy.GetComponent<DummyStats>();
        dummy2Health = dummy2.GetComponent<DummyStats>();
        dummy3Health = dummy3.GetComponent<DummyStats>();
        gobMinHealth = gobMin.GetComponent<GobMinsStats>();
        gobMootHealth = gobMoot.GetComponent<GobMinsStats>();
        gobMaxHealth = gobMax.GetComponent<GobMinsStats>();
        gobMudHealth = gobMud.GetComponent<GobMinsStats>();
        gobBossHealth = gobBoss.GetComponent<GoblinBossStats>();
        itemStat = testGroup.GetComponent<ExplodableItemHealthStat>();
        itemStat2 = testGroup2.GetComponent<ExplodableItemHealthStat>();
        itemStat3 = testGroup3.GetComponent<ExplodableItemHealthStat>();
        itemStat4 = testGroup4.GetComponent<ExplodableItemHealthStat>();
        itemStat5 = testGroup5.GetComponent<ExplodableItemHealthStat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerClose == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                Combat playerCombat = player.GetComponent<Combat>();

                if (playerCombat != null)
                {
                    playerCombat.MeleeAttack(myStats);
                }



                if (myStats.health <= 0)
                {
                    ExplosionSmokeEffect();
                    StartCoroutine("CountDown");

                 
                }


            }
        }
    }


    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerClose = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        playerClose = false;
    }


    public void Explosion()
    {
        //if bHealth is lower than 0 it needs to explode 
        //add force explosion with a sphere collider to any collider inside of it 


        if (myStats.health <= 0)
        {
            //Destroy(this.gameObject);
            //Damage variables
            //Debug.Log("explosion function knows health is down");
            Vector3 pos = transform.position;

            pos += Vector3.right * exOffset.x;
            pos += Vector3.up * exOffset.y;
            pos += Vector3.forward * exOffset.z;

            //Damage Sphere
            Collider[] colInfo = Physics.OverlapSphere(pos, explosionRange, exMask);


            //Explosion force variables 
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, forceRadius);

            //Damage taken code
            foreach (Collider nearbyObj in colInfo)

            {


                if (nearbyObj.CompareTag("Player") && playerHealth != null)
                {

                    playerHealth.TakeDamage(exDmg);
                    Debug.Log("player took explosion damage");


                }

                if (nearbyObj.CompareTag("Dummy") && enemysHealth != null)
                {

                    enemysHealth.TakeDamage(exDmg);
                    Debug.Log("enemy is taking explosion damage");
                }





                //dummy 2 
                if (nearbyObj.CompareTag("Dummy2") && dummy2Health != null)
                {

                    dummy2Health.TakeDamage(exDmg);
                    Debug.Log("enemy is taking explosion damage");
                }
                //dummy 3 
                if (nearbyObj.CompareTag("Dummy3") && dummy3Health != null)
                {

                    dummy3Health.TakeDamage(exDmg);
                    Debug.Log("enemy is taking explosion damage");
                }
                //goblin minion 1
                if (nearbyObj.CompareTag("GobMinion") && gobMinHealth != null)
                {

                    gobMinHealth.TakeDamage(exDmg);
                    Debug.Log("enemy is taking explosion damage");
                }
                //golbin minion 2 
                if (nearbyObj.CompareTag("GobMoot") && gobMootHealth != null)
                {

                   gobMootHealth.TakeDamage(exDmg);
                    Debug.Log("enemy is taking explosion damage");
                }

                //golbin minion 3 
                if (nearbyObj.CompareTag("GobMax") && gobMaxHealth != null)
                {

                    gobMaxHealth.TakeDamage(exDmg);
                    Debug.Log("enemy is taking explosion damage");
                }

                //golbin minion 4 
                if (nearbyObj.CompareTag("GobMud") && gobMudHealth != null)
                {

                    gobMudHealth.TakeDamage(exDmg);
                    Debug.Log("enemy is taking explosion damage");
                }

                //goblin boss
                if (nearbyObj.CompareTag("Boss") && gobBossHealth != null)
                {

                    gobBossHealth.TakeDamage(exDmg);
                    Debug.Log("enemy is taking explosion damage");
                }

                if (nearbyObj.CompareTag("Explodable") && itemStat != null)
                {
                    itemStat.TakeDamage(exDmg);
                    Debug.Log("collider visible");
                }

                if (nearbyObj.CompareTag("Explodable2") && itemStat2 != null)
                {
                    itemStat2.TakeDamage(exDmg);
                    
                }

                if (nearbyObj.CompareTag("Explodable3") && itemStat3 != null)
                {
                    itemStat3.TakeDamage(exDmg);
                    
                }


                if (nearbyObj.CompareTag("Explodable4") && itemStat4 != null)
                {
                    itemStat4.TakeDamage(exDmg);

                }

                if (nearbyObj.CompareTag("Explodable5") && itemStat5 != null)
                {
                    itemStat5.TakeDamage(exDmg);

                }


                //if (nearbyObj.CompareTag("Explodable") && itemsStats != null)
                //{

                //    //itemsStats.TakeDamage(exDmg);
                //    //Debug.Log("items is in collider with health");

                //    //for (int i = 0; i < explodables.Length; i++)
                //    //{
                //    //    itemsStats.TakeDamage(exDmg);
                //    //}

                //}



                //if (nearbyObj.CompareTag("Explodable") && itemStat != null)
                //{

                //    itemStat.TakeDamage(exDmg);
                //    Debug.Log("destroying item");

                //}


                //for (int i = 0; i < explodables.Length; i++)
                //{
                //    itemsStats = explodables[i].GetComponent<ExplodableItemHealthStat>();
                //    itemsStats.TakeDamage(exDmg);
                //}



            }

           

            Destroy(this.gameObject, 0.5f);

        }
    }

    public void ExplosionEffect()
    {

        explode.Play();
    }

    public void ExplosionSmokeEffect()
    {

        explodeSmoke.Play();
        explodeRangeVFX.Play();
    }

    IEnumerator CountDown()
    {
        Debug.Log("explosion coroutine started");
        yield return new WaitForSeconds(2);
        Explosion();
        ExplosionEffect();
        AudioManager.instance.PlayOneShot(FMODEvents.instance.explosiveBarrel, this.transform.position);

    }


    void OnDrawGizmos()
    {
        Vector3 pos = transform.position;
        pos += Vector3.right * exOffset.x;
        pos += Vector3.up * exOffset.y;
        pos += Vector3.forward * exOffset.z;

        Gizmos.color = Color.red;

        if (exMaskStarted)
        {
            Gizmos.DrawWireSphere(pos, explosionRange);
        }
    }

    
}
