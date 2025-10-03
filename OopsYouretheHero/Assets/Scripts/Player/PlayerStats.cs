using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : CharacterStats
{
    public string sceneName;

    Animator die;

    void Start()
    {
        health = 100;
        maxHealth = 100;

        stamina = 100;
        maxStamina = 100; 

        damage = 15;

        attackSpeed = 1f;


        die = GetComponent<Animator>();
    }

    public override void Die()
    {
        PlayerMovement move = GetComponent<PlayerMovement>();
        move.enabled = false;

        die.SetTrigger("Die");

      //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}


