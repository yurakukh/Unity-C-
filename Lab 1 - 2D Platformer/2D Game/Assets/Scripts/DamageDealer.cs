using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float timeDelay;

    private PlayerController player;
    private DateTime lastEncounter;
    void OnTriggerEnter2D(Collider2D info)
    {
        if ((DateTime.Now - lastEncounter).TotalSeconds < 0.1f)
            return;

        lastEncounter = DateTime.Now;
        player = info.GetComponent<PlayerController>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
    }

    private void OnTriggerExit2D(Collider2D info)
    {
        if(player == info.GetComponent<PlayerController>())
        {
            player = null;
        }
    }

    private void Update()
    {
        if (player != null && (DateTime.Now - lastEncounter).TotalSeconds > timeDelay)
        {
            player.TakeDamage(damage);
            lastEncounter = DateTime.Now;
        }
    }
}
