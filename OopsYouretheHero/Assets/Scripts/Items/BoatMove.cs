using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour
{
    public CharacterController boat; 
   // public PlayerMovement playerMove;
    public BoatController boatCon; 

  //  public Transform playerTransform; 

   // public Transform boatStand; 

    public int boatSpeed;
    public Vector3 direction;




    // Start is called before the first frame update
    void Start()
    {
        boatCon = this.GetComponent<BoatController>();
        boat = this.GetComponent<CharacterController>();

      

    }

    // Update is called once per frame
    void Update()
    {

        if(boatCon.onBoat == true)
        {
            BoatDrive();
            //PlayerMoveTurnOff();
        }

      
    }


    public void BoatDrive()
    {
        if (Input.GetKey(KeyCode.A))
        {
            direction.x = -1;
            //animator.SetTrigger("Moving");
            //animator.SetBool("Moving", true);

            transform.rotation = Quaternion.Euler(0, -90, 0);

        }



        if (Input.GetKey(KeyCode.D))
        {
            direction.x = 1;
            //animator.SetTrigger("Moving");
            //animator.SetBool("Moving", true);

            transform.rotation = Quaternion.Euler(0, 90, 0);


        }



        if (Input.GetKey(KeyCode.W))
        {
            direction.z = 1;
            //animator.SetTrigger("Moving");
            //animator.SetBool("Moving", true);

            transform.rotation = Quaternion.Euler(0, 0, 0);
        }




        if (Input.GetKey(KeyCode.S))
        {
            direction.z = -1;
            //animator.SetTrigger("Moving");
          //  animator.SetBool("Moving", true);

            transform.rotation = Quaternion.Euler(0, -180, 0);
        }


        direction.y = 0;
        boat.SimpleMove(direction * boatSpeed);
        direction = Vector3.zero;
    }


}