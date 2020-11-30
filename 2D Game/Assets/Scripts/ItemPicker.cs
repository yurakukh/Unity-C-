﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    [SerializeField] private int healValue;
   void OnTriggerEnter2D(Collider2D info)
    {
        info.GetComponent<PlayerController>().RestoreHP(healValue);
        Destroy(gameObject);
    }
}
