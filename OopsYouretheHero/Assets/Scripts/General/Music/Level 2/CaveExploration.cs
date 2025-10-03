using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity; 

public class CaveExploration : MonoBehaviour
{
    private PlayerController playerState;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartCaveMusic", 1.0f);

        GameObject p = GameObject.FindGameObjectWithTag("Player");
        playerState = p.GetComponent<PlayerController>();

        playerState.isExploring = true;
    }

   


    public void StartCaveMusic()
    {
        AudioManager.instance.caveAreaInstance.start();


    }



}
