using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWait : MonoBehaviour
{
    public CameraFollow camera;


    // Start is called before the first frame update
    void Start()
    {
        camera = this.GetComponent<CameraFollow>();

        camera.enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(WaitForCamera());

    }

    IEnumerator WaitForCamera()
    {

        yield return new WaitForSeconds(5f);
            camera.enabled = true;


    }
}
