using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonController : MonoBehaviour
{
    private Button _button;
    private TMP_Text lvl;
    private LevelManager levelManager;

    [SerializeField] private Scenes scene;
    

    void Start()
    {
        _button = GetComponent<Button>();
        //if (!PlayerPrefs.HasKey(GamePrefs.LvlPlayed.ToString() + ((int)scene).ToString()))
        //{
        //    _button.interactable = false;
        //    return;
        //}

        _button.onClick.AddListener(OnChangeLvl);

        GetComponentInChildren<TMP_Text>().text = ((int)scene).ToString();
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnChangeLvl()
    {
        LevelManager.Instance.ChangeLvl((int)scene);
    }
}
