using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseGameMenuController : MonoBehaviour
{
    protected LevelManager levelManager;

    [SerializeField] protected GameObject menu;


    [Header("MainButtons")]
    [SerializeField] protected Button play;
    [SerializeField] protected Button quit;

 

    // Start is called before the first frame update
    protected virtual void Start()
    {
        levelManager = LevelManager.Instance;
        quit.onClick.AddListener(OnQuitClicked);
    }

    protected virtual void OnDestroy()
    {
        quit.onClick.RemoveListener(OnQuitClicked);
    }

    protected virtual void Update() { }

    protected virtual void OnMenuClicked()
    {
        menu.SetActive(!menu.activeInHierarchy);

    }

    private void OnQuitClicked()
    {
        levelManager.Quit();
    }

    protected virtual void ChangeMenuStatus()
    {
        menu.SetActive(!menu.activeInHierarchy);
        Time.timeScale = menu.activeInHierarchy ? 0 : 1;
    }
}
