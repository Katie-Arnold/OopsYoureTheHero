using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayerMovement : MonoBehaviour
{
    public CharacterController player;
    public float speed;
    //public float jiveness;
    public Vector3 direction;

    //public Transform transform; 

    public float targetRotation;

    public Animator animator;

    private bool isMoving;

    public ParticleSystem slash;
    public ParticleSystem tut;

    public AudioSource swordSlashEffect;
    bool swordSound = false;

    //    // private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();

        // swordSlashEffect = GetComponent<AudioSource>();
        // rb = GetComponent<Rigidbody>(); 

        // slash = GameObject.FindGameObjectWithTag("SwordSlash");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Walking();
        //Dodging();
        //Attack();
        //CallTut();

        if(Input.GetButton("Horizontal"))
        {
            WalkingHorizontal(); 
        }


        if (Input.GetButton("Vertical"))
        {
            WalkingHorizontal();
        }


        //if (Input.GetButton("Attack"))
        //{
        //    Attack();
        //}


        //if (Input.GetButton("Dodging"))
        //{
        //    Dodging();
        //}


        //if (input.GetButton("Horizontal"))
        //{
        //    WalkingHorizontal();
        //}
        

        if (swordSound == true)
        {
            swordSlashEffect.Play(1);
            swordSound = false;

        }
        

        if (DialogueManager.isActive == true)
        {
            return;
        }

    }


    public void WalkingHorizontal()
    {
        //horizontalInput = Input.GetAxisRaw("Horizontal");
        //verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.A))
        {
            direction.x = -1;
            //animator.SetTrigger("Moving");
            animator.SetBool("Moving", true);

            transform.rotation = Quaternion.Euler(0, -90, 0);

        }



        if (Input.GetKey(KeyCode.D))
        {
            direction.x = 1;
            //animator.SetTrigger("Moving");
            animator.SetBool("Moving", true);

            transform.rotation = Quaternion.Euler(0, 90, 0);


        }



        if (Input.GetKey(KeyCode.W))
        {
            direction.z = 1;
            //animator.SetTrigger("Moving");
            animator.SetBool("Moving", true);

            transform.rotation = Quaternion.Euler(0, 0, 0);
        }




        if (Input.GetKey(KeyCode.S))
        {
            direction.z = -1;
            //animator.SetTrigger("Moving");
            animator.SetBool("Moving", true);

            transform.rotation = Quaternion.Euler(0, -180, 0);
        }



        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D))
        {
            // isMoving = true;
            animator.SetBool("Moving 0", true);
        }

        else
        {
            //isMoving = false;
            animator.SetBool("Moving 0", false);
            //animator.ResetTrigger("Moving");
        }




        direction.y = 0;
        player.SimpleMove(direction * speed);
        direction = Vector3.zero;


    }


    void Dodging()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Debug.Log("player is dodging");

            // rb.AddForce(transform.forward * thrust);
            animator.SetTrigger("Rolling");


        }

        if (!Input.GetKey(KeyCode.R))
        {
            animator.ResetTrigger("Rolling");
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("player is attacking");

            animator.SetTrigger("Attacking");
            slash.Play();

            swordSound = true;



        }

        if (!Input.GetKeyDown(KeyCode.Space))
        {
            animator.ResetTrigger("Attacking");
            slash.Stop();
            //swordSlashEffect.Stop();

            swordSound = false;

        }
    }

    void CallTut()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("tut");
            tut.Play();
            animator.SetTrigger("Tut");

            //tut.Play();
        }

        if (!Input.GetKeyDown(KeyCode.P))
        {
            //tut.Stop();
            animator.ResetTrigger("Tut");

            //tut.Stop();
        }
    }

}

