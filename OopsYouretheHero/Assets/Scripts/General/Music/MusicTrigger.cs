using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{

    public AudioSource soundEffect;
    // Start is called before the first frame update
    void Start()
    {
        soundEffect = gameObject.GetComponent<AudioSource>();


    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            soundEffect.Play();

            Debug.Log("player entered sound collider");
        }

    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            soundEffect.Stop();
            Debug.Log("player left sound collider");
        }
    }
}
