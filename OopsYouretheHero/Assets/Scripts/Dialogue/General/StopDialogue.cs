using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopDialogue : MonoBehaviour
{
    public GameObject dialogue; 



    // Start is called before the first frame update
    void Start()
    {

       dialogue.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider other)
    {

        if(other.CompareTag("Player"))
        {

            Destroy(dialogue, 0.5f);


        }


    }
}
