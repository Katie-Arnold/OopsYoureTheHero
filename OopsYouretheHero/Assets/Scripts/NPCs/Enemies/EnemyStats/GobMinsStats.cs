using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobMinsStats : CharacterStats
{
    Animator die;

    private GameObject col;

    public ParticleSystem skulls;

    void Start()
    {
        health = 75;

        maxHealth = 75;

        stamina = 100;
        maxStamina = 100;

        damage = 25;

        attackSpeed = 1f;


        isDead = false;


        die = GetComponent<Animator>();
        col = GameObject.FindGameObjectWithTag("Blocks");
    }

    public override void Die()
    {

        die.SetTrigger("IsDead");
        skulls.Play();
        Destroy(gameObject, 3f);


        isDead = true;

        col.SetActive(false);
    }
}
