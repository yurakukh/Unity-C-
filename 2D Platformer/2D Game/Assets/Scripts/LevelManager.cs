using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    #region Singleton
    public static LevelManager Instance;
    
    private void Start()
    {
        Time.timeScale = 1;
        if(SceneManager.GetActiveScene().buildIndex != 0)
            PlayerPrefs.SetInt(GamePrefs.LastPlayedLvl.ToString(), SceneManager.GetActiveScene().buildIndex);
    }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
    public void Restart()
    {
        ChangeLvl(SceneManager.GetActiveScene().buildIndex);
    }

    public void EndLevel()
    {
        ChangeLvl(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ChangeLvl(int lvl)
    {
        SceneManager.LoadScene(lvl);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
    }

}

public enum Scenes
{
    MainMenu,
    first,
    second,
    third,
}

public enum GamePrefs
{
    LastPlayedLvl,
    LvlPlayed
}