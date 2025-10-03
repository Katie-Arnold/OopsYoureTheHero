using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    [SerializeField]
    public GameObject respawnObject;
    public Transform spawnPoint; 

    public bool inCol;

    public float timer = 5;
    private float respTimer; 
    // Start is called before the first frame update
    void Start()
    {

       // inCol = true; 

    }

    // Update is called once per frame
    void Update()
    {
        
        if(inCol == false)
        {
          Respawn();
        }
        
    }

     void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Explosive"))
        {
            inCol = true; 
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (inCol == true)
        {

                inCol = false;
           
        }
    }

    public void Respawn()
    {

        if (inCol == false)
        {
            respTimer -= Time.deltaTime;


            if (respTimer > 0)
            {
                return;
            }

            respTimer = timer;

          GameObject respObj = Instantiate(respawnObject, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;

        }

    }
}
