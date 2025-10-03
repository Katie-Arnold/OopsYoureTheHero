using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeMechanic : MonoBehaviour
{

    public PlayerController hasRope;
    public bool inRange = false;
    //public AudioSource pickup; 

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
        GameObject r = GameObject.FindGameObjectWithTag("Player");
        hasRope = r.GetComponent<PlayerController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange == true)
        {

           
            PickUp();

            

        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player in collider");
           inRange = true;

            //Destroy(gameObject);


        }

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("player has left");

        inRange = false;
    }

    public void PickUp()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {


            //hasRope = true;
            // pickup.Play();

            AudioManager.instance.PlayOneShot(FMODEvents.instance.itemInteraction, this.transform.position);
            Destroy(this.gameObject, 1f);

            hasRope.hasRope = true;

        }



    }

}
