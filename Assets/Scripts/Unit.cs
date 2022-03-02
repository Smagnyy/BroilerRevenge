using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, IDamageable
{
    
    protected Rigidbody2D rb;
    protected Animator anim;
    
    UnitBars bars;

    
    
    public UnitStats stats;    
    public GameStates gameState;
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<UnitStats>();
        bars = GetComponentInChildren<UnitBars>();
        bars.SetMaxValue(bars.healthBar, stats.hp);        
        transform.position = stats.startPosition.transform.position;              
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       
      
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameStates.Hub:                
                bars.gameObject.SetActive(false);                
                break;
            case GameStates.Location:
                bars.gameObject.SetActive(true);               
                break;
        }
       
    }

  

   
    
      
    public void GetDamage(int damage)
    {
        stats.hp -= damage;
        Debug.Log(stats.hp);
        bars.SetValue(bars.healthBar, stats.hp);
        anim.SetTrigger("Hit");
        if(stats.hp<= 0)
        {
            stats.Die();
        }
    }

   
}
