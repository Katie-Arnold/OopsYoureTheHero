using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffTimeline : MonoBehaviour
{
    public GameObject timeline; 



    // Start is called before the first frame update
    void Start()
    {

        timeline.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Player"))
        {

            timeline.SetActive(false);


        }


    }


}
