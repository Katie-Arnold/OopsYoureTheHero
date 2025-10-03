using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleBlock : MonoBehaviour
{

    private PlayerController hasStolen;


    // Start is called before the first frame update
    void Start()
    {
        GameObject h = GameObject.FindGameObjectWithTag("Player");


        hasStolen = h.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStolen.hasHeart == true)
        {
            Destroy(this.gameObject);
        }



    }
}
