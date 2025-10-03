using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMusicTrigger : MonoBehaviour
{

    public AudioSource combatMusic;


    public bool playerClose; 

    // Start is called before the first frame update
    void Start()
    {

        combatMusic = gameObject.GetComponent<AudioSource>();

        playerClose = false; 
    }

    // Update is called once per frame
    void Update()
    {

        if (playerClose == true)
        {
            MusicActivate();
        }



    }

    void OnTriggerEnter(Collider other )
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player in collider");

            playerClose = true;
        }


    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player in collider");

            playerClose = false;
        }

    }

    public void MusicActivate()
    {
        if (Input.GetKey(KeyCode.E))
        {

            combatMusic.Play();

        }
       
    }

}
