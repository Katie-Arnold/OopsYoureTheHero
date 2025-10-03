using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebStick : MonoBehaviour
{

    
    public PlayerMovement playSpeed;
    public bool isStuck; 



    public float stuckTimer;
    public float stickTimer; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");

        playSpeed = p.GetComponent<PlayerMovement>();

        isStuck = false;

       // randomTimer = Random.Range(15f, 30f);
    }

   public void Update()
    {
      //  StartCoroutine(Sticky());
      
        Sticky();

    }


    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player slowed");

            isStuck = true;

            

        }


    }


    public void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            isStuck = false;
            playSpeed.speed = 9;

        }


    }

   

    public void Sticky()
    {


        if (isStuck == true)
        {
            playSpeed.speed = 2;

           StartCoroutine(Unstick());
            stickTimer -= Time.deltaTime;

            if (stickTimer > 0)
            {
                return;

                // isStuck = false;

               
            }

            stickTimer = stuckTimer;

            if (stickTimer == 0)
            {


                Destroy(this);


            }
        }


    }

    IEnumerator Unstick()
    {
        Debug.Log("unstick started");
        yield return new WaitForSeconds(5f);
        isStuck = false;
        playSpeed.speed = 9;
        
    }

}
