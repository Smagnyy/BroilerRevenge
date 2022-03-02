using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : UnitStats
{
    private void Start()
    {
        fraction = Fraction.enemy;
    }

    public override void Die()
    {
        base.Die();
        Player.instance.Money += moneyAmount;
        BattleStatus.instance.battleState = States.BossDead;
        Destroy(gameObject);
    }
}
