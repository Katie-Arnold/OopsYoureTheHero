using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwingInteractPopUp : MonoBehaviour
{
    private bool inTrigger = false;

    public GameObject ropePopUp;
    public GameObject noRopePopUp;

    private PlayerController hasRopeBool; 

    // Start is called before the first frame update
    void Start()
    {
        inTrigger = false;

        ropePopUp.SetActive(false);
        noRopePopUp.SetActive(false);

        GameObject h = GameObject.FindGameObjectWithTag("Player");

        hasRopeBool = h.GetComponent<PlayerController>(); 
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && hasRopeBool.hasRope == true)
        {
            //Debug.Log("player in collider");
            inTrigger = true;

            ropePopUp.SetActive(true);

        }

        if (other.gameObject.CompareTag("Player") && hasRopeBool.hasRope == false)
        {
            //Debug.Log("player in collider");
            inTrigger = true;

            noRopePopUp.SetActive(true);

        }

    }

    private void OnTriggerExit(Collider other)
    {
        //ebug.Log("player has left");

        inTrigger = false;

        ropePopUp.SetActive(false);
        noRopePopUp.SetActive(false);
    }
}
