using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthWarning : MonoBehaviour
{

    public CharacterStats myStats;
    public Image redScreen;
    public int flashSpeed;
    public float timer;
 
    // Start is called before the first frame update
    void Start()
    {
        myStats = GetComponent<CharacterStats>();

        redScreen = GameObject.FindGameObjectWithTag("HurtOverlay").GetComponent<Image>();
        

        redScreen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(myStats.health < 40)
        {
            HurtFlash();
        }

        else
        {
            YoureFine();
        }


    }


    public void HurtFlash ()
    {
        timer += Time.deltaTime;
        if (timer > flashSpeed)
        {
            timer = 0;
            redScreen.enabled = !redScreen.enabled;
            //audio.Play();
        }




    }

    public void YoureFine()
    {
        redScreen.enabled = false;
    }

}
