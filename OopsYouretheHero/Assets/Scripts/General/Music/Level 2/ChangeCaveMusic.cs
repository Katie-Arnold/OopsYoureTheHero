using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class ChangeCaveMusic : MonoBehaviour
{
    [SerializeField] public string gameparameterState;
    [SerializeField] public string floorparameterState;
    //[SerializeField] public string parameterFloor;
    [SerializeField] public float gameparameterValue;
    [SerializeField] public float floorparameterValue;

    public bool playerHasPassed;



    // Start is called before the first frame update
    void Start()
    {

        playerHasPassed = false;


    }

    // Update is called once per frame
    void FixedUpdate()
    {


        //ChangeCaveParameters();
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //  playerHasPassed = true;


            FMODUnity.RuntimeManager.StudioSystem.setParameterByName(gameparameterState, gameparameterValue);
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName(floorparameterState, floorparameterValue);
            //ChangeCaveParameters();
        }


    }



    //public void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        playerHasPassed = false;


    //    }


    //}


    public void ChangeCaveParameters()
    {
        //if (playerHasPassed == true)
        //{

        //    FMODUnity.RuntimeManager.StudioSystem.setParameterByName(gameparameterState, gameparameterValue);
        //    FMODUnity.RuntimeManager.StudioSystem.setParameterByName(floorparameterState, floorparameterValue);
        //    Debug.Log("changed music");
        //}

       

            FMODUnity.RuntimeManager.StudioSystem.setParameterByName(gameparameterState, gameparameterValue);
           // FMODUnity.RuntimeManager.StudioSystem.setParameterByName(floorparameterState, floorparameterValue);
       

    }
}
