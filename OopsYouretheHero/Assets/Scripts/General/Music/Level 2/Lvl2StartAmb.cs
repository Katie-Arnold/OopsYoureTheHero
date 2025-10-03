using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Lvl2StartAmb : MonoBehaviour
{
    //private PlayerController playerState;

    public Transform pos;


    // Start is called before the first frame update
    void Start()
    {



        // GameObject p = GameObject.FindGameObjectWithTag("Player");
        // playerState = p.GetComponent<PlayerController>();

        //  playerState.isExploring = true;

        pos = this.GetComponent<Transform>();


    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            Invoke("StartCave", 1.0f);
           // Destroy(gameObject);


        }


    }

    //public void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {

    //        AudioManager.instance.caveAmbienceEventInstance.release();
    //        Destroy(gameObject);

    //    }


    //}

    public void StartCave()
    {
        AudioManager.instance.caveAmbienceEventInstance.start();

       //wwww AudioManager.instance.caveAmbienceEventInstance.set3DAttributes(RuntimeUtils.To3DAttributes(pos));
    }

}
