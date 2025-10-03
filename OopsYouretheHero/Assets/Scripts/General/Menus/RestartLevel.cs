using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
  
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            SceneManager.LoadScene("Level1");
        }


    }
}
