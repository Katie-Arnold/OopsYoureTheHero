using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneMove2 : MonoBehaviour
{
    public PlayerMovement playMove;
    private RopeInHand ropeMove;
    //private PlayerCusceneStop playStop;


    // Start is called before the first frame update
    void Start()
    {

        playMove = this.GetComponent<PlayerMovement>();
        ropeMove = this.GetComponent<RopeInHand>();
      //  playStop = this.GetComponent<PlayerCusceneStop>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveStart()
    {
        playMove.enabled = true;
        ropeMove.enabled = true;
        // playStop.enabled = false; 
        //DOTween.ClearCachedTweens();
    }


}
