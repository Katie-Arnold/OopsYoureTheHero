using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClackerTrigger : MonoBehaviour
{
    public bool playerClose;
    private PlayerController playerRopeHold;

    public Collider popUpCom; 

    public GameObject arenaCol;
    public GameObject arenaExit;

    public GameObject interactPop;
    public GameObject ropePop;

    private Animator clackAnim;
    public ClackerStats clackHealth;
    private Enemies clackEnemies;


   public ParticleSystem[] enemyRings;
   public Canvas[] enemyHealthBars;



    //public GameObjects[] pebbles; 
    //private Animator[] pebAnim; 
    //private PebblesStats[]


    public PebblesStats pebHealth;
    private Enemies pebEnem;
    private WebSpawn webAttack;
    private PebblesBite pebBite;
    private Animator pebAnim; 



    // Start is called before the first frame update
    void Start()
    {
        playerClose = false;

        ropePop.SetActive(false);
       
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        GameObject cl = GameObject.FindGameObjectWithTag("Clacker");
        GameObject pb = GameObject.FindGameObjectWithTag("Pebbles");

        playerRopeHold = p.GetComponent<PlayerController>();


        arenaCol.SetActive(false);
       arenaExit.SetActive(true);

        popUpCom = this.GetComponent<BoxCollider>(); 



        clackAnim = cl.GetComponent<Animator>();
        clackHealth = cl.GetComponent<ClackerStats>();
        clackEnemies = cl.GetComponent<Enemies>();



        pebHealth = pb.GetComponent<PebblesStats>();
        pebEnem = pb.GetComponent<Enemies>();
        pebBite = pb.GetComponent<PebblesBite>();
        webAttack = pb.GetComponent<WebSpawn>();
        pebAnim = pb.GetComponent<Animator>(); 

        clackEnemies.enabled = false;
        pebEnem.enabled = false;

        clackAnim.SetBool("isFighting", false);
        pebAnim.SetBool("isFighting", false);


        for (int i = 0; i < enemyRings.Length; i++)
        {

            // enemyRing[i].Stop(false);

            print(enemyRings.Length);
        }

        for (int i = 0; i < enemyHealthBars.Length; i++)
        {

            // enemyRing[i].Stop(false)

            enemyHealthBars[i].enabled = false;

            print(enemyHealthBars.Length);
        }


    }

    // Update is called once per frame
    void Update()
    {

        if (playerClose == true)
        {

            ClackerActivate();

        }


        if (clackHealth.isDead == true /*&& pebHealth.isDead == true*/)
        {

            // Debug.Log("boss music is cut");
           // CutCombatMusic();
            arenaExit.SetActive(false);
            arenaCol.SetActive(false);


            //change music parameters

            Destroy(this, 5);
        }



    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            Debug.Log("player in collider");

            playerClose = true;

        }

    }


    void OnTriggerExit(Collider other)
    {
        {
            playerClose = false;

        }

    }


    public void ClackerActivate()
    {
        if (Input.GetKey(KeyCode.E))
        {
            // look.enabled = true;
            //col.SetActive(true);
            // playerStateCombat.isExploring = false;

           arenaCol.SetActive(true);

           

           


            if (playerRopeHold.hasRope == true)
            {
                ropePop.SetActive(true);
            }


            // col.SetActive(true);
            //Destroy(interactPop);

            interactPop.SetActive(false);
            popUpCom.enabled = false;


            clackEnemies.enabled = true;
            pebEnem.enabled = true;
           

            for (int i = 0; i < enemyRings.Length; i++)
            {

                //enemyRing[i].SetActive(true);
                enemyRings[i].Play();
                Debug.Log("rings started");
            }

            for (int i = 0; i < enemyHealthBars.Length; i++)
            {

                enemyHealthBars[i].enabled = true;

            }

            //  col.SetActive(true);


            clackAnim.SetBool("isFighting", true);


            pebAnim.SetTrigger("IsFighting");
           


            pebBite.isAttack = true;
            webAttack.enabled = true;

        }





    }


}
