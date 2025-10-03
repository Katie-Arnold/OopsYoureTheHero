using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathMenu : MonoBehaviour
{
    public PlayerStats pStats;

    public static bool GameIsPaused = false;

    public GameObject deathMenuUI;

    public bool playerIsDead; 

    // Start is called before the first frame update
    void Start()
    {
        playerIsDead = false;

        pStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

    }

    // Update is called once per frame

    //bruh is probably freezing up on the death screen right here
    void Update()
    {
        if (pStats.health == 0)
        {
            // Stop();

            

            if (playerIsDead == false)
            {
               
                playerIsDead = true;

                DeathScreen();
            }

            //SceneManager.LoadScene("DeathScreen");

            //DeathScreen();
        }

    }


    public void DeathScreen()
    {

        if (playerIsDead == true)
        {
            SceneManager.LoadScene("DeathScreen");

           
        }


       // SceneManager.LoadScene("DeathScreen");

    }

}
