using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmBell : MonoBehaviour
{
    
    public bool soundAlarm = false; 


    private PlayerController hasHeart; 
    
    // Start is called before the first frame update
    void Start()
    {
        

        GameObject p = GameObject.FindGameObjectWithTag("Player");

        hasHeart = p.GetComponent<PlayerController>();

        soundAlarm = false;

        //StartCoroutine("SoundAlarm");


        // Invoke("SoundAlarm", 1.0f);

    }

    // Update is called once per frame
    void Update()
    {

        if (hasHeart.hasHeart == true)
        {
            hasHeart.hasHeart = true;
            if (!soundAlarm)
            {
                soundAlarm = true;
                SoundAlarm();
            }
        }

        // StartCoroutine("SoundAlarm");


    }

    public void SoundAlarm()
    {

        //soundAlarm = true;

        //bellSound.Play();
        AudioManager.instance.PlayOneShot(FMODEvents.instance.alarmBell, this.transform.position);
        //AudioManager.instance.alarmEventInstance.start();

    }

    //IEnumerator SoundAlarm()
    //{

    //    Debug.Log("alarm coroutine started");
    //   if (hasHeart.hasHeart == true)
    //    {
    //        soundAlarm = true; 

    //        if(soundAlarm == true)
    //        {
    //            AudioManager.instance.PlayOneShot(FMODEvents.instance.alarmBell, this.transform.position);
    //        }
    //           //AudioManager.instance.PlayOneShot(FMODEvents.instance.alarmBell, this.transform.position);


            
    //    }

    //    //else
    //    //{
    //    //    soundAlarm = false;
            
    //    //}



    //    yield return new WaitForSeconds(2);


    //}

}
