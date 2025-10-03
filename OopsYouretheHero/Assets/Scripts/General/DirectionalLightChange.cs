using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalLightChange : MonoBehaviour
{
    private Light theSun;

    public bool inCol; 
    public bool lightIsOn;
    public bool lightIsOff;

    public Material outsideSky;
    public Material caveSky;

    public int ambientMult; 



    // Start is called before the first frame update
    void Start()
    {
        theSun = GetComponent<Light>();

       // lightIsOn = true; 

        //theSun.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("player in collider");

            inCol = true;

           // theSun.enabled = !theSun.enabled;
           // RenderSettings.skybox = caveSky;
            RenderSettings.ambientIntensity = ambientMult;
        }


    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
        
          
            inCol = false;


        }


    }

    //Coroutine that lerps light up and down 
    //if the player stands inbetween, they can swap the light turning on and off 

    
}
