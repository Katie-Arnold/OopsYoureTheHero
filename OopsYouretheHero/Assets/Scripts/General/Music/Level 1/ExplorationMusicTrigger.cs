using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorationMusicTrigger : MonoBehaviour
{

    //[SerializeField]  private TempleMusicArea area;

    [SerializeField] private string parameterName;

    private Collider box;

    private bool isThrough; 

    private PlayerController playerStateCombat;

    // Start is called before the first frame update
    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");

        playerStateCombat = p.GetComponent<PlayerController>();

        box = this.GetComponent<BoxCollider>(); 

    }

    // Update is called once per frame
    void Update()
    {
        if(!isThrough)
        {
            isThrough = true;
            playerStateCombat.isExploring = true;
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            AudioManager.instance.exploreAreaInstance.start();
            //AudioManager.instance.alarmEventInstance.stop();
            //FMODUnity.RuntimeManager.StudioSystem.setParameterByName(parameterName, 0f);
            isThrough = true;
            //have coroutine start here to delete this aspect so player cant restart track
           // playerStateCombat.isExploring = true;
            StartCoroutine("TurnOff");
           

        }
    }

   IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(2);
        box.enabled = false; 

        
    }
}
