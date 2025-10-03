using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleToEscapeChange : MonoBehaviour
{
    [Header ("Temple Music Parameter Change")]

    [SerializeField] private string parameterName;
   

    private PlayerController hasHeart;


    // Start is called before the first frame update
    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");

        hasHeart = p.GetComponent<PlayerController>();
        Invoke("TempleStart", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

        if (hasHeart.hasHeart == true)
        {
            
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName(parameterName, 1f);
        }

    }

    public void TempleStart()
    {
        AudioManager.instance.templeAreaInstance.start();
        AudioManager.instance.ambienceEventInstance.start();
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName(parameterName, 0f);



    }
    

}
