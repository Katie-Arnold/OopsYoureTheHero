using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleDoorTrigger : MonoBehaviour
{

    private Animation doors;

    // Start is called before the first frame update
    void Start()
    {
        doors = GetComponent<Animation>();
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

            doors.Play();

            Destroy(this.GetComponent<Collider>().GetComponent<BoxCollider>());

        }
    }
     
}
