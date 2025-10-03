using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionLightTrigger : MonoBehaviour
{

    private Light theSun;
    
    // Start is called before the first frame update
    void Start()
    {
        theSun = GetComponent<Light>();

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

            theSun.enabled = true;

            Destroy(this.GetComponent<Collider>().GetComponent<BoxCollider>());

        }


    }
}
