using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameActive = true;
    public int gold = 1000;

    void Start()
    {
        
    }
    void Update()
    {
      
    }

    public void PlayGame()
    {
        DontDestroyOnLoad(transform.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.MergeScenes(SceneManager.GetSceneByName("My Game") , SceneManager.GetSceneByName("DontDestroyOnLoad"));

    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
