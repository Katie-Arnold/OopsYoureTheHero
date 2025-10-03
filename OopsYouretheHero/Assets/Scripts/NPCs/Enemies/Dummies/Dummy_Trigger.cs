using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dummy_Trigger : MonoBehaviour
{
    public bool playerClose;
    public bool combatCalled = false; 
    public GameObject sfx;
    public GameObject wizard;
    public ParticleSystem[] enemyRing;
    public Canvas[] healthBars;
    public ExplodableItem exStats; 

    private Animator slide;

    private Animator slide2;

    private Animator slide3;

    private PlayerController playerStateCombat;

    //private Dummy_Trigger triggerEn; 

    private GameObject dumBlock;

    private DummyStats healthNum;
    private DummyStats healthNum2;
    private DummyStats healthNum3;

    private Enemies dumEnemy;
    private Enemies dumEnemy2;
    private Enemies dumEnemy3;


   // [SerializeField] private TempleMusicArea area;

    [SerializeField] private string parameterName;
    // Start is called before the first frame update
    void Start()
    {
       // triggerEn = this.GetComponent<Dummy_Trigger>();
        GameObject p = GameObject.FindGameObjectWithTag("Player");

        playerStateCombat = p.GetComponent<PlayerController>();

        playerClose = false;

        GameObject d = GameObject.FindGameObjectWithTag("Dummy");

        GameObject d2 = GameObject.FindGameObjectWithTag("Dummy2");

        GameObject d3 = GameObject.FindGameObjectWithTag("Dummy3");

        dumBlock = GameObject.FindGameObjectWithTag("DumBlocks");
        //  dumBlock.SetActive(false);

        GameObject ex = GameObject.FindGameObjectWithTag("Explodable4");


        exStats = ex.GetComponent<ExplodableItem>();
        exStats.enabled = true; 

        

        slide = d.GetComponent<Animator>();

        slide2 = d2.GetComponent<Animator>();

        slide3 = d3.GetComponent<Animator>();

        slide.SetBool("IsFighting", false);


        //slide.SetBool("IsFighting", false);

        healthNum = d.GetComponent<DummyStats>();
        healthNum2 = d2.GetComponent<DummyStats>();
        healthNum3 = d3.GetComponent<DummyStats>();

        dumEnemy = d.GetComponent<Enemies>();
        dumEnemy2 = d2.GetComponent<Enemies>();
        dumEnemy3 = d3.GetComponent<Enemies>();

        dumEnemy.enabled = false;
        dumEnemy2.enabled = false;
        dumEnemy3.enabled = false;

        sfx.SetActive(false);
        wizard.SetActive(true);

        for (int i = 0; i < enemyRing.Length; i++)
        {

            // enemyRing[i].Stop(false);

            print(enemyRing.Length);
        }

        for (int i = 0; i < healthBars.Length; i++)
        {

            // enemyRing[i].Stop(false)

            healthBars[i].enabled = false;

            print(healthBars.Length);
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (playerClose == true)
        {
            DummyActivate();
           // combatCalled = true;
           
        }

        

        if (healthNum.isDead == true && healthNum2.isDead == true && healthNum3.isDead == true)
        {
            //FMODUnity.RuntimeManager.StudioSystem.setParameterByName(parameterName, 0f);
            //playerClose = false; 
            //if(combatCalled == true)
            //{
            //    combatCalled = false;
            //}
            Debug.Log("dummys are dead");


            CutCombatMusic();


            dumBlock.SetActive(false);
            
        }

        //CutCombatMusic();
        
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
        playerClose = false;
    }

    //Function for activation
    public void DummyActivate()
    {

        if (Input.GetKey(KeyCode.E))
        {

            exStats.enabled = false;


            if (playerStateCombat.isExploring == true)
            {
                playerStateCombat.isExploring = false;
            }

            playerStateCombat.inCombat = true;
            //playerStateCombat.isExploring = false;


            //FMODUnity.RuntimeManager.StudioSystem.setParameterByName(parameterName, 1f);
            combatCalled = true;

            dumBlock.SetActive(true);

            dumEnemy.enabled = true;
            dumEnemy2.enabled = true;
            dumEnemy3.enabled = true;

            for (int i = 0; i < enemyRing.Length; i++)
            {

                //enemyRing[i].SetActive(true);
                enemyRing[i].Play();
                Debug.Log("rings started");
            }
            // slide.SetTrigger("IsFighting");

            for (int i = 0; i < healthBars.Length; i++)
            {
                
                healthBars[i].enabled = true;
               
            }



            slide.SetBool("IsFighting", true);


            slide2.SetBool("IsFighting", true);

            slide3.SetBool("IsFighting", true);

            sfx.SetActive(true);
            wizard.SetActive(false);
           

        }

    }


    public void CutCombatMusic()
    {
        if (playerStateCombat.inCombat == true)
        {
            playerStateCombat.inCombat = false;
        }

        playerStateCombat.isExploring = true;
       // playerStateCombat.inCombat = false;
        //playerStateCombat.isExploring = true;

    }
}
