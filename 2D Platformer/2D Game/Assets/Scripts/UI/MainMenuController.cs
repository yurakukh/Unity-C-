using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : BaseGameMenuController
{
    [Header("MainMenu")]
    [SerializeField] private Button _chooseLvl;
    [SerializeField] private Button _reset;
    [SerializeField] private Button _quit;

    [SerializeField] private GameObject _lvlMenu;
    [SerializeField] private Button closeLvlMenu;
    private TMP_Text playButtonText;

    private int lvl = 1;

    protected override void Start()
    {
        base.Start();
        _chooseLvl.onClick.AddListener(useLvlMenu);
        closeLvlMenu.onClick.AddListener(useLvlMenu);

        playButtonText = play.GetComponentInChildren<TMP_Text>();
        if (PlayerPrefs.HasKey(GamePrefs.LastPlayedLvl.ToString()))
        {
            play.GetComponentInChildren<TMP_Text>().text = "Resume";
            lvl = PlayerPrefs.GetInt(GamePrefs.LastPlayedLvl.ToString());
        }
        play.onClick.AddListener(Play);
        _reset.onClick.AddListener(OnResetClicked);
        
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
        _chooseLvl.onClick.RemoveListener(useLvlMenu);
        closeLvlMenu.onClick.RemoveListener(useLvlMenu);
        play.onClick.RemoveListener(Play);
        _reset.onClick.RemoveListener(levelManager.ResetProgress);
    }

    private void useLvlMenu()
    {
        _lvlMenu.SetActive(!_lvlMenu.activeInHierarchy);
        ChangeMenuStatus(); 
    }

    private void Play()
    {
        levelManager.ChangeLvl(lvl);
    }

    private void OnResetClicked()
    {
        play.GetComponentInChildren<TMP_Text>().text = "PLAY";
        lvl = PlayerPrefs.GetInt(GamePrefs.LastPlayedLvl.ToString());
        levelManager.ResetProgress();
    }

}
