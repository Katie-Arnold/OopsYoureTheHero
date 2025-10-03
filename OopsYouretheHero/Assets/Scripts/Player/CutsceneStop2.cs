using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneStop2 : MonoBehaviour
{
    public PlayerMovement playStop;
    private RopeInHand ropeMove;
    private PlayerCutsceneMove playMove;


    // Start is called before the first frame update
    void Start()
    {

        playStop = this.GetComponent<PlayerMovement>();
        ropeMove = this.GetComponent<RopeInHand>();
        playMove = this.GetComponent<PlayerCutsceneMove>();
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void MoveStop()
    {
        playStop.enabled = false;
        ropeMove.enabled = false;
        // playMove.enabled = false; 
    }
}
