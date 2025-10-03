using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerCusceneStop : MonoBehaviour
{
    public PlayerMovement playStop;
    private CharacterController charControl;
    private RopeInHand ropeMove;
    private PlayerCutsceneMove playMove; 


    // Start is called before the first frame update
    void Start()
    {

        playStop = this.GetComponent<PlayerMovement>();
        charControl = this.GetComponent<CharacterController>();
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
        //charControl.enabled = false;
       // playMove.enabled = false; 
    }


    public void MoveStart()
    {
        playStop.enabled = true;
        ropeMove.enabled = true;
        // playStop.enabled = false; 
        DOTween.ClearCachedTweens();
    }


}
