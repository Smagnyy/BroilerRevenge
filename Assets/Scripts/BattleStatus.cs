using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum States { Start, EnemyDead, PlayerDead, Attack, Boss, BossAttack, BossDead }

public class BattleStatus : MonoBehaviour
{
    public static BattleStatus instance;
    public GameObject loseMenu;
    public GameObject winMenu;
    public GameObject prizePanel;


    public Text killCounter;

    public int enemyKilledCount;
    public int maxEnemyKilledCount;
    public States battleState;
    public float timer;
    public Text textTimer;
    public float battleTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        prizePanel.SetActive(false);
        killCounter.text = $"Убито {enemyKilledCount} из {maxEnemyKilledCount}";
        loseMenu.SetActive(false);
        winMenu.SetActive(false);
        instance = this;
        timer = 3;
        battleState = States.Start;
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (battleState)
        {
            case States.Start:
                
                timer -= Time.deltaTime;
                
                textTimer.text = $"{Mathf.Round(timer)}";
                if(timer<=0)
                {
                    StartCoroutine(StartGame());
                    battleState = States.Attack;
                }
                break;
            case States.EnemyDead:
                
                enemyKilledCount++;
                killCounter.text = $"Убито {enemyKilledCount} из {maxEnemyKilledCount}";
                
                if (enemyKilledCount>= maxEnemyKilledCount)
                {
                    battleState = States.Boss;
                    
                }
                else
                {
                    EnemyManager.instance.Spawn();
                    battleState = States.Attack;
                }          
                break;

            case States.PlayerDead:
                Time.timeScale = 0;
                killCounter.gameObject.SetActive(false);
                loseMenu.SetActive(true);
                break;

            case States.Attack:
                SpawnNotes();


                break;

            case States.Boss:
                killCounter.text = "Boss";
                EnemyManager.instance.BossSpawn();
                battleState = States.BossAttack;
                break;

            case States.BossAttack:
                SpawnNotes();

                break;
            case States.BossDead:

                killCounter.gameObject.SetActive(false);
                winMenu.SetActive(true);
                Time.timeScale = 0;
                if (Player.instance.completedLevels < SceneManager.GetActiveScene().buildIndex)
                {
                    Player.instance.completedLevels = SceneManager.GetActiveScene().buildIndex;
                    prizePanel.SetActive(true);
                }


                Player.instance.Save();

                break;
            default:
                break;
        }
    }


    IEnumerator StartGame()
    {
        textTimer.text = "Start";
        yield return new WaitForSeconds(0.5f);
        textTimer.gameObject.SetActive(false);
    }


    public void SpawnNotes()
    {
        if (battleTimer > 2)
        {
            int number = Random.Range(2, 6);
            StartCoroutine(NoteSpawner.instance.Spawn(number));
            battleTimer = 0;
        }
        else
        {
            battleTimer += Time.deltaTime;
        }
    }
}
