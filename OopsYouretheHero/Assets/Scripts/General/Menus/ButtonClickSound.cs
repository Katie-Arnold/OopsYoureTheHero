using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{


    public void PlaySound()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.buttonPress, this.transform.position);

    }
}
