using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{

    [SerializeField]
    private float timer = 5;
    private float cloudTime;

    public float disappearTime;

    public GameObject cloudObject;
    public Transform spawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void CloudSpawning()
    {
        cloudTime -= Time.deltaTime;

        if (cloudTime > 0)
        {
            return;
        }

        cloudTime = timer;

        GameObject cloudObj = Instantiate(cloudObject, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody cloudRig = cloudObj.GetComponent<Rigidbody>();
        cloudRig.AddForce(cloudRig.transform.forward * 65f);



        Destroy(cloudObj, disappearTime);
    }





    // Update is called once per frame
    public void Update()
    {
        CloudSpawning();
    }
}
