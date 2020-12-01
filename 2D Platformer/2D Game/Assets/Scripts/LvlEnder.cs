using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlEnder : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        LevelManager.Instance.EndLevel();
    }
}
