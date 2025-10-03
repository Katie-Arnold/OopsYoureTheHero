using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int health;
    public int maxHealth;


    public int stamina;
    public int maxStamina;

    public int damage;

    public float attackSpeed;

    public bool isDead = false;

    public void TakeDamage(int damage)
    {
        health -= damage;
        CheckHealth();
    }

    public virtual void Die()
    {
        
    }


    void CheckHealth()
    {
        if (health <= 0)
        {
            health = 0;
            isDead = true;
            Die();
        }

        if (health >= maxHealth)
        {
            health = maxHealth;
        }

    }


    void CheckStamina()
    {
        if (stamina <= 0)
        {
            stamina = 0;
        }

        if (stamina >= maxStamina)
        {
            stamina = maxStamina;
        }


    }
}
