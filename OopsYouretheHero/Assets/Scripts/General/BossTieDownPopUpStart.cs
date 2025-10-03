using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTieDownPopUpStart : MonoBehaviour
{
    public PlayerController ropeBool;

    public GameObject tieDownPop; 



    // Start is called before the first frame update
    void Start()
    {
        tieDownPop.SetActive(false);

        GameObject r = GameObject.FindGameObjectWithTag("Player");
        ropeBool = r.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (ropeBool.hasRope == true)
        {
            tieDownPop.SetActive(true);
        }




    }
}
