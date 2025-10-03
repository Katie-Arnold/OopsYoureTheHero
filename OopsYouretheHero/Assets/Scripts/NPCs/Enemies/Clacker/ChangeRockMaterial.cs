using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRockMaterial : MonoBehaviour
{
    public ClackerStats clackHealth;
    public Animator clackAnim; 

    public  Material rockMaterial;

    Color hotPink = new Color(185f, 0f, 90f, 255f);
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject clack = GameObject.FindGameObjectWithTag("Clacker");

        clackHealth = clack.GetComponent<ClackerStats>();

        rockMaterial = this.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(clackHealth.health < 100)
        {
            //Color emisColor = Color.red * 1000.0f;
            //rockMaterial.material.SetColor("_EmissiveColor", emisColor);

            rockMaterial.color = hotPink;

            Debug.Log("changes color in theory");
        }


    }

    
}
