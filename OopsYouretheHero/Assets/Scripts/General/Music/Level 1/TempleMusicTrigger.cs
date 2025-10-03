using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleMusicTrigger : MonoBehaviour
{
    private PlayerController inTemple;

    private PlayerController hasHeart;

    public bool inside;


    [SerializeField]
    private string parameterName;


    // Start is called before the first frame update
    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");


        inside = true;

        hasHeart = p.GetComponent<PlayerController>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player")
        {
            inside = true;
            hasHeart.hasHeart = false;

            AudioManager.instance.templeAreaInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName(parameterName, 0f);
            // inTemple.inTemple = true; 
        }

    }

    void OnTriggerExit(Collider other)
    {
       // inside = false;
       // AudioManager.instance.templeAreaInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }


}
