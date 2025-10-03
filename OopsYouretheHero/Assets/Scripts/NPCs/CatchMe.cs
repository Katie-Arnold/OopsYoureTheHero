using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchMe : MonoBehaviour
{
    public PlayerController ropeBoolean;

    public GameObject rope;

    public Transform ropeSpawnPoint;

    public bool playerIn; 

    // Start is called before the first frame update
    void Start()
    {
        playerIn = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.V) && playerIn == true)
        {
            if (ropeBoolean == true)
            {
                RopeSpawn();
                SheepTieDown();
                // rope.SetActive(true);
            }

        }

        
    }

    public void RopeSpawn()
    {
        GameObject ropeObj = Instantiate(rope, ropeSpawnPoint.transform.position, ropeSpawnPoint.transform.rotation) as GameObject;
        
    }

    public void SheepTieDown()
    {
        //lock position

    
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIn = true; 
            
        }


    }
}

