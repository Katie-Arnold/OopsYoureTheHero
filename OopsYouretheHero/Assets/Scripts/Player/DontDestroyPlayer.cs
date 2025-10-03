using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyPlayer : MonoBehaviour
{
   void Awake()
    {

        GameObject target = GameObject.FindGameObjectWithTag("Player");

            //if(target.Length > 1)
            //    {
            //Destroy(this.gameObject);
            //    }

        DontDestroyOnLoad(this.gameObject);

    }
}
