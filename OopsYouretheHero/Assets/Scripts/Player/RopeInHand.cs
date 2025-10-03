using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 



public class RopeInHand : MonoBehaviour
{

    //Call Player Controller for hasRope bool 
    //Call player animator
    public PlayerController ropeBool;
    public PlayerMovement playerMove;
    public Animator swingAnim;

    public bool checkRope = false;


    //public GameObject rope;

    //public Animator playerAnim; 

    public bool canSwing; 
    public bool canSwingLeft;
    public bool canSwingRight;
    


    //swinging variables

    //Line Renderer
    private LineRenderer lineRend;
 


    //DOTween variables for swing
    [SerializeField] public Transform playerPos;  
    [SerializeField] public float ropeSwingLength; 



    public GameObject ropeObject; 
    public float ropeCoolDown;
    public Transform ropeSpawnPoint;


    public Vector3 ropeOffset;
    public float ropeRange;
    public LayerMask ropeMask;
    bool layerStarted; 


    // Start is called before the first frame update
    void Start()
    {
        layerStarted = true;
        //Get player controller component 
        //Get Boss controller 

        GameObject r = GameObject.FindGameObjectWithTag("Player");
        
     //   rope = GameObject.FindGameObjectWithTag("RopeSwingBottom");

        ropeBool = r.GetComponent<PlayerController>();
        playerMove = this.GetComponent<PlayerMovement>();
        swingAnim = r.GetComponent<Animator>();
        lineRend = GetComponent<LineRenderer>();

     

        //canTieDown = false;
        canSwing = false;
        //canTieBoss = false; 

        playerMove.enabled = true;




    }

    // Update is called once per frame
    void Update()
    {
        if (ropeBool.hasRope == true)
        {
            if (!checkRope)
            {
                checkRope = true;
                CheckForRope();

                Debug.Log("ran that bitch once");

            }
        }

        //if (ropeBool.hasRope == true)
        //{

        //        CheckForRope();




        //}


    }

    
    public void CheckForRope()
    {
        if (ropeBool.hasRope == true)
        {
            // canTieDown = true;
            canSwing = true;
        }


    }

    //RopeSpawn should be on boss not Player

    public void RopeSpawn()
    {


        GameObject ropeObjTop = Instantiate(ropeObject, ropeSpawnPoint.transform.position, ropeSpawnPoint.transform.rotation) as GameObject;
       

        Destroy(ropeObjTop, ropeCoolDown);
       
    }

     

    void OnAnimatorMove()
    { 


        if (swingAnim)
        {
            if (Input.GetKeyDown(KeyCode.V) && canSwingLeft == true)
            {
                
                playerMove.enabled = false;
                transform.DOMove(playerPos.position, ropeSwingLength);
                swingAnim.SetTrigger("Swinging");
                AudioManager.instance.PlayOneShot(FMODEvents.instance.playerRopeSwing, this.transform.position);

                RopeSpawn();

            }



            if (Input.GetKeyDown(KeyCode.V) && canSwingRight == true)
            {
                playerMove.enabled = false;
                transform.DOMove(playerPos.position, ropeSwingLength);
                swingAnim.SetTrigger("Swinging");
                AudioManager.instance.PlayOneShot(FMODEvents.instance.playerRopeSwing, this.transform.position);

                RopeSpawn();


            }


        }



    }



    IEnumerator LerpPosition()
    {

        yield return new WaitForSeconds(1f);
        transform.DOKill();
        playerMove.enabled = true;
        

    }

 
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LeftSwing" ))
        {
            if (canSwing)
            {
                canSwingLeft = true;

                Debug.Log("player in rope swing area");

            }
            
        }


        if (other.CompareTag("RightSwing"))
        {
            if (canSwing)
            {
                canSwingRight = true;

                Debug.Log("player in rope swing area");
            }

           
        }

  
    }




    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LeftSwing"))
        {
            canSwingLeft = false;
            //swingAnim.SetTrigger("Swinging");

           // transform.DOKill();

           
        }


        if (other.CompareTag("RightSwing"))
        {
            canSwingRight = false;
            //swingAnim.SetTrigger("Swinging");

          //  transform.DOKill();

            
        }

        StartCoroutine(LerpPosition());

     
    }

}
