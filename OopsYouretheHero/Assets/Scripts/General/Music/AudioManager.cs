using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{

    [Header("Volume")]
    [Range(0, 1)]

    public float masterVolume = 1;
    [Range(0, 1)]

    private Bus masterBus;


    private List<EventInstance> eventInstances;

    private List<StudioEventEmitter> eventEmitters;


    public EventInstance mainMenuMusicEventInstance;

    public EventInstance loreMusicEventInstance;

    public EventInstance templeAreaInstance;

    public EventInstance exploreAreaInstance;

    public EventInstance caveAreaInstance;

    public EventInstance lakeAreaInstance;

    public EventInstance ambienceEventInstance;

    public EventInstance caveAmbienceEventInstance;

    public EventInstance lakeAmbienceEventInstance;
    public EventInstance rainAmbienceEventInstance;

    public static AudioManager instance { get; private set; }

    private void Awake ()
    {
        if(instance != null )
        {
            Debug.Log("Found more than one AudioManager in the scene");

        }

        instance = this;

        eventInstances = new List<EventInstance>();
        eventEmitters = new List<StudioEventEmitter>();

        masterBus = RuntimeManager.GetBus("bus:/");
    }

    private void Start()
    {
        // InitializeMainMenuMusic(FMODEvents.instance.mainMenuMusic);
        //InitializeLoreMusic(FMODEvents.instance.loreMenuMusic);
        InitializeAmbience(FMODEvents.instance.ambience);
        InitializecaveAmbience(FMODEvents.instance.caveAmbience);
        InitializelakeAmbience(FMODEvents.instance.lakeAmbience);
        InitializerainAmbience(FMODEvents.instance.rainAmbience);
        InitializeTemple(FMODEvents.instance.templeMusic);
        InitializeMainMenuMusic(FMODEvents.instance.mainMenuMusic);
        InitializeLoreMusic(FMODEvents.instance.loreMenuMusic);

        InitializeExplore(FMODEvents.instance.explorationMusic);
        InitializeCave(FMODEvents.instance.caveExplorationMusic);
        InitializeLake(FMODEvents.instance.lakeExplorationMusic);
    }


    private void Update()
    {
        masterBus.setVolume(masterVolume);
    }

    private void InitializeAmbience(EventReference ambienceEventReference)
    {
        ambienceEventInstance = CreateInstance(ambienceEventReference);
        //ambienceEventInstance.start();
    }

    private void InitializecaveAmbience(EventReference caveAmbienceEventReference)
    {
        caveAmbienceEventInstance = CreateInstance(caveAmbienceEventReference);
        //ambienceEventInstance.start();
    }

    private void InitializelakeAmbience(EventReference lakeAmbienceEventReference)
    {
        lakeAmbienceEventInstance = CreateInstance(lakeAmbienceEventReference);
        //ambienceEventInstance.start();
    }

    private void InitializerainAmbience(EventReference rainAmbienceEventReference)
    {
        rainAmbienceEventInstance = CreateInstance(rainAmbienceEventReference);
        //ambienceEventInstance.start();
    }

    private void InitializeLoreMusic(EventReference loreMusicEventReference)
    {
        loreMusicEventInstance = CreateInstance(loreMusicEventReference);
        //loreMusicEventInstance.start();
    }


    private void InitializeMainMenuMusic(EventReference mainMenuMusicEventReference)
    {
        mainMenuMusicEventInstance = CreateInstance(mainMenuMusicEventReference);
       //mainMenuMusicEventInstance.start();
    }


    private void InitializeTemple(EventReference templeMusicEventReference)
    {
        templeAreaInstance = CreateInstance(templeMusicEventReference);
        //templeAreaInstance.start();
    }

    


    private void InitializeExplore(EventReference exploreMusicEventReference)
    {
        exploreAreaInstance = CreateInstance(exploreMusicEventReference);
       
    }

    private void InitializeCave(EventReference caveMusicEventReference)
    {
        caveAreaInstance = CreateInstance(caveMusicEventReference);

    }

    private void InitializeLake(EventReference lakeMusicEventReference)
    {
        lakeAreaInstance = CreateInstance(lakeMusicEventReference);

    }


    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstances.Add(eventInstance);
        return eventInstance; 
    }

    public StudioEventEmitter InitializeEventEmitter(EventReference eventReference, GameObject emitterObject)
    {
        StudioEventEmitter emitter = emitterObject.GetComponent<StudioEventEmitter>();
        emitter.EventReference = eventReference;
        eventEmitters.Add(emitter);
        return emitter; 
    }

    private void CleanUp()
    {
        foreach(EventInstance eventInstance in eventInstances)
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        }

        foreach (StudioEventEmitter emitter in eventEmitters)
        {
            emitter.Stop();
        }
    }

    private void OnDestroy()
    {
        CleanUp();
    }
}
