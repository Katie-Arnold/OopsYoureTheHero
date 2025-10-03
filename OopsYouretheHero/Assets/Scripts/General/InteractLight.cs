using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractLight : MonoBehaviour
{
    public Light light;

  //  public int flashSpeed;
    public float timer;



    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;
        //if (timer > flashSpeed)
        //{
        //    timer = 0;
        //    light.enabled = !light.enabled;
        //    light.intensity = Mathf.PingPong(Time.time, 8);

        //}


        light.intensity = Mathf.PingPong(Time.time * timer, 15);

    }
}
