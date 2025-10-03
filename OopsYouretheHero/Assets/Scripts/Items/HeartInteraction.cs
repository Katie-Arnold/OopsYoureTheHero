using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartInteraction : MonoBehaviour
{
    public bool inTrigger = false;

    public PlayerController takesHeart;

    private bool playerInRange;

    public bool playerhasHeart;

  //  public AudioSource heartBoop;

    public ParticleSystem sparkle; 

    //add sparkle effect or something
    
    // Start is called before the first frame update
    void Start()
    {
        playerInRange = false;

        inTrigger = false;

        GameObject h = GameObject.FindGameObjectWithTag("Player");

        takesHeart = h.GetComponent<PlayerController>();

      //  heartBoop = GetComponent<AudioSource>(); 

    }

    // Update is called once per frame
    void Update()
    {
        if(inTrigger == true)
        {

            PickUp();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player in collider");
            inTrigger = true;

            //Destroy(gameObject);


        }

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("player has left");

       inTrigger = false;
    }



    public void PickUp()
    {
       


            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("item picked up");

                playerhasHeart = true;

                
                AudioManager.instance.PlayOneShot(FMODEvents.instance.itemInteraction, this.transform.position);
                sparkle.Play();
                Destroy(this.gameObject, 1);

                takesHeart.hasHeart = true;

            }
     }

       

    

}
