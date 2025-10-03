using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Lvl2ChangeAmb : MonoBehaviour
{
    [SerializeField] public string parameterState;
    //[SerializeField] public string parameterFloor;
    [SerializeField] public float parameterValue;

    public bool playerHasPassed;



    // Start is called before the first frame update
    void Start()
    {

        playerHasPassed = false;


    }

    // Update is called once per frame
    void Update()
    {


        ChangeCaveAmbParameters();
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerHasPassed = true;


        }


    }


    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerHasPassed = false;


        }


    }


    public void ChangeCaveAmbParameters()
    {
        if (playerHasPassed == true)
        {

            FMODUnity.RuntimeManager.StudioSystem.setParameterByName(parameterState, parameterValue);
            Debug.Log("changed cave amb");
        }

    }




}
