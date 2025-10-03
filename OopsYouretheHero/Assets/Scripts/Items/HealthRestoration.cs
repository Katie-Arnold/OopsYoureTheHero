using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HealthRestoration : MonoBehaviour
{


    public CharacterStats myStats;
   // public AudioSource saveBoop;
    public TextMeshProUGUI saveNotif;

    private float countDown = 3;
    private float timer = 0; 

    private bool playerInRange;


    //bool healthSound = false; 

    // Start is called before the first frame update
    void Start()
    {
        myStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        

      //  saveBoop = GetComponent<AudioSource>(); 

        playerInRange = false;

        saveNotif.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        

        if (playerInRange)
        {

            HealthRestore();

        }

        //if (healthSound == true)
        //{
        //   // saveBoop.Play(1);
        //   // healthSound = false;

        //}



        if (saveNotif.enabled == true)
        {
            timer += Time.deltaTime;

            if (timer > countDown)
            {
                saveNotif.enabled = false;

            }

            //else
            //{
            //    timer = 3;
            //    //saveNotif.enabled = true;
            //}

        }

      
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player in collider");
            playerInRange = true;

        }

    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("player has left");

        playerInRange = false;
    }


    public void HealthRestore()
    {


        if (Input.GetKeyDown(KeyCode.E))
        {
           // healthSound = true;
            if (myStats.health < 100)
                myStats.health = 100;
            //timer -= Time.deltaTime;

            AudioManager.instance.PlayOneShot(FMODEvents.instance.itemInteraction, this.transform.position);

            saveNotif.enabled = true;


        }

    }

    //public void CheckpointSave()
    //{

    //    //set current scene 
    //    //current scene == place to respawn to
    //}

}
