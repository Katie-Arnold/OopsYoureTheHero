using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainFall : MonoBehaviour
{
    public ParticleSystem rain;
    public ParticleSystem rainSpash;

   // public Light sun;
    int sunIntense;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // sun = GetComponent<Light>(); 
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
          //  sun.intensity = 0.23f;


            rain.Play();
            rainSpash.Play();

            //Change sound ambience to start playing

        }


    }

    public void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            //  sun.intensity = 0.6f;


            rain.Stop();
            rainSpash.Stop();


        }


    }

}
