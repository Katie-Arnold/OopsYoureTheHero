using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionPopUp : MonoBehaviour
{

    private bool inTrigger = false;

    public GameObject popUp; 

    // Start is called before the first frame update
    void Start()
    {
        inTrigger = false;

        popUp.SetActive(false);

        GameObject h = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("player in collider");
            inTrigger = true;

            popUp.SetActive(true);

        }

    }

    private void OnTriggerExit(Collider other)
    {
        //ebug.Log("player has left");

        inTrigger = false;

        popUp.SetActive(false);
    }


}
