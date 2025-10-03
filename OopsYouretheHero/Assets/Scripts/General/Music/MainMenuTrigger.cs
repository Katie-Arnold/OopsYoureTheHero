using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class MainMenuTrigger : MonoBehaviour
{
    [SerializeField]
    private string parameterName;


    // Start is called before the first frame update
    void Start()
    {
        // AudioManager.instance.templeAreaInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        // AudioManager.instance.ambienceEventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

        Invoke("PlayMainMusic", 1.0f);
        
    }

    void Update()
    {
        //PlayMainMusic();
    }

    public void PlayMainMusic()
    {
        Debug.Log("function is called");

        AudioManager.instance.mainMenuMusicEventInstance.start();
       

    }

   
}
