using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTestTrigger : MonoBehaviour
{
    public bool playerClose;

    private Animator slide;

    private Animator slide2;

    private Animator slide3;

    private PlayerController playerStateCombat;

    //private Dummy_Trigger triggerEn; 

    //private GameObject dumBlock;

    private EnemyStats healthNum;
    private EnemyStats healthNum2;
    private EnemyStats healthNum3;

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

        //dumBlock = GameObject.FindObjectWithTag("DumBlocks");

        slide = d.GetComponent<Animator>();

        slide2 = d2.GetComponent<Animator>();

        slide3 = d3.GetComponent<Animator>();

        slide.SetBool("IsFighting", false);

        healthNum = d.GetComponent<EnemyStats>();
        healthNum2 = d2.GetComponent<EnemyStats>();
        healthNum3 = d3.GetComponent<EnemyStats>();

    }

    // Update is called once per frame
    void Update()
    {

        if (playerClose == true)
        {
            DummyActivate();
        }

        //if (healthNum.isDead == true)
        //{
        //    //thought: because this is in update it is saying that explore state is constantly running 
        //    //and wont let the boss trigger overwhelm it 
        //    CutCombatMusic();
        //    Debug.Log("dummy health number is at 0");
        //    //  triggerEn.enabled = false;

        //}




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
            playerStateCombat.inCombat = true;
            playerStateCombat.isExploring = false;

            //dumBlock.SetActive(true);

            // slide.SetTrigger("IsFighting");

            slide.SetBool("IsFighting", true);


            slide2.SetBool("IsFighting", true);

            slide3.SetBool("IsFighting", true);

        }

    }


    public void CutCombatMusic()
    {
        playerStateCombat.inCombat = false;
        playerStateCombat.isExploring = true;
        // playerStateCombat.inCombat = false;



        //if (healthNum.isDead == true /*&& healthNum2.health == 0 && healthNum3.health == 0*/)
        //{
        //    playerStateCombat.isExploring = true;
        //    playerStateCombat.inCombat = false;
        //    Debug.Log("dummy is dead");


        //}

    }
}
