using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    [SerializeField] private int hp;

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            OnDeath();
        }
        Debug.Log("Damage: " + damage);
        Debug.Log("Current enemy hp: " + hp);
    }

    public void OnDeath()
    {
        Destroy(gameObject);
    }
}
