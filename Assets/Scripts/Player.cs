using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player instance;
    public GameStates gameState;
   
    public GameObject st;
    public Unit myUnit;
    

    public List<Stat> stats;
    
    public Unit prefab;


    public int completedLevels;

    private int money;

    public int Money
    {
        get
        {
            Save();
            return money;

        }
        set
        {
            money = value;
            Save();
        }
    }

    


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
        st = GameObject.FindGameObjectWithTag("PlayerStartPosition");
        Load();
        gameState = SceneLoader.instance.gmst;
        myUnit = Instantiate(prefab);
        myUnit.stats.damage = stats[0].amount;
        myUnit.stats.hp = stats[1].amount;
        myUnit.stats.startPosition = st;
        
       
        
        myUnit.gameState = gameState;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            PlayerPrefs.DeleteAll();
        
    }

    public void Save()
    {
        
        PlayerPrefs.SetInt("Damage", stats[0].amount);
        PlayerPrefs.SetInt("Health", stats[1].amount);
        PlayerPrefs.SetInt("Money", money);        
        PlayerPrefs.SetInt("DamageLevel", stats[0].level);
        PlayerPrefs.SetInt("HealthLevel", stats[1].level);
        PlayerPrefs.SetInt("DamageCost", stats[0].cost);
        PlayerPrefs.SetInt("HealthCost", stats[1].cost);
        PlayerPrefs.SetInt("CompletedLevels", completedLevels);

    }

    void Load()
    {


        stats[0].amount = PlayerPrefs.GetInt("Damage",1);
        stats[1].amount = PlayerPrefs.GetInt("Health",3);
        stats[0].level = PlayerPrefs.GetInt("DamageLevel",1);
        stats[1].level = PlayerPrefs.GetInt("HealthLevel",1);
        stats[0].cost = PlayerPrefs.GetInt("DamageCost",4);
        stats[1].cost = PlayerPrefs.GetInt("HealthCost",3);
        money = PlayerPrefs.GetInt("Money",0);
        completedLevels = PlayerPrefs.GetInt("CompletedLevels", 0);

    }


    
}
