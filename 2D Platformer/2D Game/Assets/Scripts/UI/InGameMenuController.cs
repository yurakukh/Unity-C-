using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenuController : BaseGameMenuController
{
    LevelManager levelManager;

    [SerializeField] private Button restart; 
    [SerializeField] private Button mainMenu; 
   
    
    // Start is called before the first frame update
    void Start()
    {
        levelManager = LevelManager.Instance;
        play.onClick.AddListener(ChangeMenuStatus);
        restart.onClick.AddListener(levelManager.Restart);
        mainMenu.onClick.AddListener(GoToMainMenu);
        quit.onClick.AddListener(levelManager.Quit);
    }

    private void OnDestroy()
    {
        play.onClick.RemoveListener(ChangeMenuStatus);
        play.onClick.RemoveListener(ChangeMenuStatus);
        restart.onClick.RemoveListener(levelManager.Restart);
        mainMenu.onClick.RemoveListener(GoToMainMenu);
        quit.onClick.RemoveListener(levelManager.Quit);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            ChangeMenuStatus();
        }
    }
   

    public void GoToMainMenu()
    {
        LevelManager.Instance.ChangeLvl((int)Scenes.MainMenu);
    }
}
