using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMOD.Studio;

public class ChangeScene : MonoBehaviour
{
    FMOD.Studio.Bus MasterBus; 

    void Start()
    {
        MasterBus = FMODUnity.RuntimeManager.GetBus("Bus:/");
    }

    public void LoadScene(string sceneName)
    {

        SceneManager.LoadScene(sceneName);
        MasterBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

     }
    
}
