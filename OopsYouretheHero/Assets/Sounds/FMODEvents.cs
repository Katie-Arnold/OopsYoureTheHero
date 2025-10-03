using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class FMODEvents : MonoBehaviour
{
    
    [field: Header("Dialogue Pop")]

    [field: SerializeField] public EventReference dialoguePop { get; private set; }

    [field: Header("Button Press")]

    [field: SerializeField]  public EventReference buttonPress { get; private set; }


    [field: Header("Ambience")]

    [field: SerializeField] public EventReference ambience { get; private set; }

    [field: Header(" Cave Ambience")]

    [field: SerializeField] public EventReference caveAmbience { get; private set; }

    [field: Header("Lake Ambience")]

    [field: SerializeField] public EventReference lakeAmbience { get; private set; }

    [field: Header("Rain Ambience")]

    [field: SerializeField] public EventReference rainAmbience { get; private set; }


    [field: Header("Main Menu")]
     
    [field: SerializeField] public EventReference mainMenuMusic { get; private set; }


    [field: Header("Lore Music")]

    [field: SerializeField] public EventReference loreMenuMusic { get; private set; }


    [field: Header("Temple Music")]

    [field: SerializeField] public EventReference templeMusic { get; private set; }


    //[field: Header("Temple Escape Music")]

    //[field: SerializeField] public EventReference templeEscapeMusic { get; private set; }


    [field: Header("Exploration Music")]

    [field: SerializeField] public EventReference explorationMusic { get; private set; }

    [field: Header("Cave Exploration Music")]

    [field: SerializeField] public EventReference caveExplorationMusic { get; private set; }

    [field: Header("Lake Exploration Music")]

    [field: SerializeField] public EventReference lakeExplorationMusic { get; private set; }



    [field: Header("Player Sword Swing")]

    [field: SerializeField] public EventReference playerSwordSwing { get; private set; }

    [field: Header("Player Rope Swing")] 

    [field: SerializeField] public EventReference playerRopeSwing { get; private set; }


    [field: Header("Enemy Hit")]

    [field: SerializeField] public EventReference enemyHit { get; private set; }


    [field: Header("Lose Health")]

    [field: SerializeField] public EventReference loseHealth { get; private set; }


    [field: Header("Explosive Barrel")]

    [field: SerializeField] public EventReference explosiveBarrel { get; private set; }


    [field: Header("Alarm Bell")]

    [field: SerializeField] public EventReference alarmBell { get; private set; }


    [field: Header("Fire Burning")]

    [field: SerializeField] public EventReference fireBurning { get; private set; }


    [field: Header("Item Interaction")]

    [field: SerializeField]  public EventReference itemInteraction { get; private set; }


    [field: Header("Fae Chimes")]

    [field: SerializeField] public EventReference faeChimes { get; private set; }


    [field: Header("Waterfall")]

    [field: SerializeField]  public EventReference waterFall { get; private set; }


    [field: Header("Water")]

    [field: SerializeField] public EventReference water { get; private set; }


    [field: Header("Dummy Slash Attack")]

    [field: SerializeField] public EventReference DummySlash { get; private set; }


    [field: Header("Arrow Attack")]

    [field: SerializeField] public EventReference arrowAttack { get; private set; }


    [field: Header("Gob Boss Slash Attack")]

    [field: SerializeField] public EventReference gobBossSlash { get; private set; }


    [field: Header("Gob Boss Jump Attack")]

    [field: SerializeField] public EventReference gobBossJump{ get; private set; }





    public static FMODEvents instance { get; private set;}



    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Found more than one instance of FMOD Events instance in scene"); 
        }

        instance = this;

      
    }
   
    

}
