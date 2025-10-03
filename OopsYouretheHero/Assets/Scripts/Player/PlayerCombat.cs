using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public PlayerStats myStats;


    // Start is called before the first frame update
    void Start()
    {
        myStats = GetComponent<PlayerStats>();
    }

   public void MeleeAttack (PlayerStats targetStats)
    {
        targetStats.TakeDamage(myStats.damage);

        
       
    }
}
