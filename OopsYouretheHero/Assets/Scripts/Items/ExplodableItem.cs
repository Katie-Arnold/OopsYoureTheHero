using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodableItem : MonoBehaviour
{
    //call character stats 

    //call this game object rigidbody 
    public bool inTriggerArea; 

   public CharacterStats itemStats;

    Rigidbody rb; 

    // Start is called before the first frame update
    void Start()
    {
        itemStats = GetComponent<CharacterStats>();

        inTriggerArea = false; 

        //rb = GetComponent<Rigidbody>();


        //rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if stats is less than 0 turn off the kinematic boolean 

        if(itemStats.health <= 0)
        {
            //rb.isKinematic = false; 
            Destroy(this.gameObject);
            
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Explosive"))
        {
            Debug.Log("explosive is in collider"); 
        }

    }
}
