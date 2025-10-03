using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineTrigger : MonoBehaviour
{
    public PlayableDirector timeline;

    public bool inTimeline;

    public float timerStop; 

   // private PlayerMovement control;

    public Animator animator;

    void Start()
    {
        timeline = GetComponent<PlayableDirector>();

        GameObject playerBody = GameObject.FindGameObjectWithTag("Player");

        animator = playerBody.GetComponent<Animator>();
    }


    void Update()
    {
       
       

    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

           Debug.Log("player in collider");

            //control.enabled = false;
            inTimeline = true; 

            timeline.Play();

            animator.SetBool("Moving 0", false);



        }

    }



   private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
           // Debug.Log("player out of collider");

            timeline.Stop();

            inTimeline = false;


            // Destroy(this.GetComponent<Collider>().GetComponent<BoxCollider>());
            Destroy(this.gameObject);
        }

    }


 


}
