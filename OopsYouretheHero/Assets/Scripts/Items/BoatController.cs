using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public bool onBoat;
    public bool boatMoving;

    public BoatMove moveScpt;

    public PlayerMovement playerMove;
    public CharacterController playerControl;

    public Transform playerTransform;

    public Transform boatStand;


    //public ParticleSystem waterRip;

    //public Vector3 boatOffset;
    //public float boatRange;
    //public LayerMask exMask;
    //bool exMaskStarted;

    // Start is called before the first frame update
    void Start()
    {

        moveScpt = this.GetComponent<BoatMove>();


        GameObject p = GameObject.FindGameObjectWithTag("Player");

        playerTransform = p.GetComponent<Transform>();

        playerMove = p.GetComponent<PlayerMovement>();
        playerControl = p.GetComponent<CharacterController>();

       // exMaskStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        TurnBoatOn();


    }



    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player in collider");
            onBoat = true;

            //Destroy(gameObject);


        }

    }


    //private void OnTriggerExit(Collider other)
    //{
    //    Debug.Log("player has left");

    //    onBoat = false;
    //}


    public void TurnBoatOn()
    {

        if (onBoat == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                boatMoving = true;

                moveScpt.enabled = !moveScpt.enabled;

                PlayerMoveTurnOff();

                if (moveScpt.enabled == false)
                {
                    PlayerMoveTurnOn();
                    onBoat = false;
                }

            }




        }

        //Vector3 pos = transform.position;

        //pos += Vector3.right * boatOffset.x;
        //pos += Vector3.up * boatOffset.y;
        //pos += Vector3.forward * boatOffset.z;

        //Collider[] colInfo = Physics.OverlapSphere(pos, boatRange, exMask);

        //foreach (Collider nearbyObj in colInfo)
        //{


        //    if (nearbyObj.CompareTag("Player"))
        //    {
        //        if (Input.GetKeyDown(KeyCode.E))
        //        {
        //            Debug.Log("player pressing e to turn on and off");


        //            onBoat = true;
        //            boatMoving = true;

        //            moveScpt.enabled = !moveScpt.enabled;

        //            PlayerMoveTurnOff();


        //            if (moveScpt.enabled == true)
        //            {
        //                PlayerMoveTurnOff();
        //                onBoat = false;
        //            }



        //            if (moveScpt.enabled == false)
        //            {
        //                PlayerMoveTurnOn();
        //                onBoat = false;
        //            }

        //        }


        //    }

        //}
    }


        public void PlayerMoveTurnOff()
        {
            playerTransform.transform.parent = boatStand.transform;
            playerTransform.transform.position = boatStand.transform.position;

            playerMove.enabled = false;
            playerControl.enabled = false;



        }

        public void PlayerMoveTurnOn()
        {
            playerTransform.transform.parent = null;

            playerMove.enabled = true;

            playerControl.enabled = true;

        }

    //void OnDrawGizmos()
    //{
    //    Vector3 pos = transform.position;
    //    pos += Vector3.right * boatOffset.x;
    //    pos += Vector3.up * boatOffset.y;
    //    pos += Vector3.forward * boatOffset.z;

    //    Gizmos.color = Color.red;

    //    if (exMaskStarted)
    //    {
    //        Gizmos.DrawWireSphere(pos, boatRange);
    //    }
    //}


}