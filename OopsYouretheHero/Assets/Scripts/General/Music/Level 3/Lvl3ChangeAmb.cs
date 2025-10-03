using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Lvl3ChangeAmb : MonoBehaviour
{
    //private PlayerController playerState;


    // Start is called before the first frame update
    void Start()
    {

        

       // GameObject p = GameObject.FindGameObjectWithTag("Player");
       // playerState = p.GetComponent<PlayerController>();

      //  playerState.isExploring = true;


    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            Invoke("StartRain", 1.0f);
            //Destroy(gameObject);


        }


    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            AudioManager.instance.rainAmbienceEventInstance.release();


        }


    }

    public void StartRain()
    {
        AudioManager.instance.rainAmbienceEventInstance.start();


    }
}
