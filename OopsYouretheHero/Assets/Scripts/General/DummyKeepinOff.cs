using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyKeepinOff : MonoBehaviour
{

    private DummyStats healthNum;
    private DummyStats healthNum2;
    private DummyStats healthNum3;

    // Start is called before the first frame update
    void Start()
    {
        GameObject d = GameObject.FindGameObjectWithTag("Dummy");

        GameObject d2 = GameObject.FindGameObjectWithTag("Dummy2");

        GameObject d3 = GameObject.FindGameObjectWithTag("Dummy3");

        healthNum = d.GetComponent<DummyStats>();
        healthNum2 = d2.GetComponent<DummyStats>();
        healthNum3 = d3.GetComponent<DummyStats>();

    }

    // Update is called once per frame
    void Update()
    {

        if (healthNum.isDead == true && healthNum2.isDead == true && healthNum3.isDead == true)
        {
            
            Destroy(this.gameObject);
           
        }



    }
}
