using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public Unit[] enemies;
    public Unit newEnemy;
    public GameObject spawnPosition;

   
    public Unit boss;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
        Spawn();
    }

    


    public void Spawn()
    {

        newEnemy = Instantiate(enemies[Random.Range(0,enemies.Length)]);
        
        
        newEnemy.stats.startPosition = spawnPosition;
        
    }

    public void BossSpawn()
    {

        newEnemy = Instantiate(boss);


        newEnemy.stats.startPosition = spawnPosition;

    }
}
