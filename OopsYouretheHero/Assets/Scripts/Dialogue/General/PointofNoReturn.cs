using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointofNoReturn : MonoBehaviour
{

    public Collider pastPoint;

    // Start is called before the first frame update
    void Start()
    {


        pastPoint.enabled = false;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            pastPoint.enabled = true;
        }

    }
}
