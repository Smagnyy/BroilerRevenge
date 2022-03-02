using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum GameStates { Hub, Location }

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;

    public GameStates gmst;

    void Start()
    {
        instance = this;
        Time.timeScale = 1;
    }


    public void LoadScene(int index)
    {
        
        SceneManager.LoadScene(index);
        
    }
}
