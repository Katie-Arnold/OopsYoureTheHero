using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicManager : MonoBehaviour
{
    //public AudioSource temple;
    //public AudioSource explore;
    //public AudioSource combat;

    public bool templeCalled = false;
    public bool exploreCalled = false;
    public bool combatCalled = false;


    [SerializeField] private string parameterName;

    private PlayerController playerState;

    // Start is called before the first frame update
    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");

        playerState = p.GetComponent<PlayerController>(); 


    }

    // Update is called once per frame
    void Update()
    {

        //Temple calls
            //if (playerState.inTemple == true)
            //{
            //    if(!templeCalled)
            //    {
            //        templeCalled = true;
            //        TemplePlay();
            //    }
                
            //}

            //if (playerState.inTemple == false)
            //{
            //    if (templeCalled)
            //    {
            //        templeCalled = false;

            //        TempleStop();
            //    }

            //}


        //Exploration calls
        if (playerState.isExploring == true && playerState.inCombat == false)
        {
            combatCalled = false;

            //combatCalled = false;
            // Debug.Log("combat turned off");

            if (!exploreCalled)
            {
                Debug.Log("exploration has been called");
                exploreCalled = true;
               // ExplorationPlay();

                FMODUnity.RuntimeManager.StudioSystem.setParameterByName(parameterName, 0f);

            }

        }

        if (playerState.isExploring == false && playerState.inCombat == true)
        {
            combatCalled = true;

            if (exploreCalled)
            {
                exploreCalled = false;

               // ExplorationStop();

                FMODUnity.RuntimeManager.StudioSystem.setParameterByName(parameterName, 1f);
            }

        }


        //Combat calls
        if (playerState.inCombat == true && playerState.isExploring == false)
        {
            exploreCalled = false;

            if (!combatCalled)
            {
                //exploreCalled = false;
                combatCalled = true;

               // CombatPlay();

                FMODUnity.RuntimeManager.StudioSystem.setParameterByName(parameterName, 1f);
            }


        }

        if (playerState.inCombat == false && playerState.isExploring == true)
        {
            exploreCalled = true;

            if (combatCalled)
            {
                combatCalled = false;

               // CombatStop();

                FMODUnity.RuntimeManager.StudioSystem.setParameterByName(parameterName, 0f);
            }

        }

        

    }

    
    //Functions for playing tracks

    //public void TemplePlay()
    //{
    //    temple.Play();
    //}

    //public void ExplorationPlay()
    //{
    //    explore.Play();
    //}

    //public void CombatPlay()
    //{
    //    // AudioSource.PlayClipAtPoint(combat, new Vector3(0,0,0));

    //    combat.Play();
    //}




    ////Functions for stoppuing tracks
    //public void ExplorationStop()
    //{
    //    explore.Stop();
    //}

    //public void CombatStop()
    //{
    //    // AudioSource.PlayClipAtPoint(combat, new Vector3(0,0,0));

    //    combat.Stop();
    //}

    //public void TempleStop()
    //{
    //    temple.Stop();
    //}

}
