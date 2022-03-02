using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : UnitStats
{


    // Start is called before the first frame update
    void Start()
    {
        fraction = Fraction.ally;
        
    }

   

    public override void Die()
    {
        base.Die();
        Time.timeScale = 0;
        BattleStatus.instance.battleState = States.PlayerDead;
        
    }
}
