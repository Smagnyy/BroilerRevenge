using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Fraction { none, ally, enemy }

public abstract class UnitStats : MonoBehaviour
{

    public GameObject startPosition;
    

    public Fraction fraction;
    public int damage;
    public int hp;          
    public int moneyAmount;

   

    public virtual void Die()
    {
        Debug.Log("Смерть!");
    }
}
