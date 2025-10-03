using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{

    public Light light;

    public int flashSpeed;
    public float timer;

  
    //public AudioSource audio;

    private PlayerController hasStolen; 

   

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();

        GameObject h = GameObject.FindGameObjectWithTag("Player");


        hasStolen = h.GetComponent<PlayerController>();

        light.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(hasStolen.hasHeart == true)
        {
            Blaring();
        }
    }


    public void Blaring()
    {
        timer += Time.deltaTime;
        if(timer > flashSpeed)
        {
            timer = 0;
            light.enabled = !light.enabled;
          //  audio.Play();
        }

    }
}
