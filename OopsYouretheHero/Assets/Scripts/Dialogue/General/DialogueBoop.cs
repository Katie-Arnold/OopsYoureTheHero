using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBoop : MonoBehaviour
{
   
    public void PlayDialogueSound()
    {

        AudioManager.instance.PlayOneShot(FMODEvents.instance.dialoguePop, this.transform.position);
    }


}
