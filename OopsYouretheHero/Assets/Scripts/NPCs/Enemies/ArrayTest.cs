using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayTest : MonoBehaviour
{
    GameObject[] dummyObj;

     public Animator slideMove;

   
    EnemyStats healthNum;


    public bool playerClose; 

    // Start is called before the first frame update
    void Start()
    {

        playerClose = false; 
        dummyObj = GameObject.FindGameObjectsWithTag("Dummy");
        GameObject p = GameObject.FindGameObjectWithTag("Player");

      

        for (int i = 0; i< dummyObj.Length; i++)
        {
            slideMove = dummyObj[i].GetComponent<Animator>();
          
           // healthNum = dummyObj[i].GetComponent<EnemyStats>();
            Debug.Log("got animator from all dummys");
           // Debug.Log("got health stats from all dummys");
        }

        Debug.Log(dummyObj.Length);
        

    }

    // Update is called once per frame
    void Update()
    {

        if (playerClose == true)
        {
            
            DummyActivateTest();
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
        playerClose = false;
    }


    public void DummyActivateTest()
    {

        if (Input.GetKey(KeyCode.E))
        {
            //playerStateCombat.inCombat = true;
            //playerStateCombat.isExploring = false;

            //foreach (Animator anim in slideMove)
            //{
            //    slideMove[i].SetBool("IsFighting", true);
            //    slideMove[i].SetTrigger(true);
            //    slideMove.SetBool("IsFighting", true);
            //}
            slideMove.SetBool("IsFighting", true);

        }

    }
}
