using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerCutsceneMove : MonoBehaviour
{


    public PlayerMovement playMove;
    private CharacterController charControl;
    private RopeInHand ropeMove;
    private PlayerCusceneStop playStop; 
    


// Start is called before the first frame update
void Start()
    {

        playMove = this.GetComponent<PlayerMovement>();
        charControl = this.GetComponent<CharacterController>();
        ropeMove = this.GetComponent<RopeInHand>();
        playStop = this.GetComponent<PlayerCusceneStop>();

    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void MoveStart()
    {
       // charControl.enabled = true;
        playMove.enabled = true;
        ropeMove.enabled = true;
       
        // playStop.enabled = false; 
        DOTween.ClearCachedTweens();
    }

    
}
