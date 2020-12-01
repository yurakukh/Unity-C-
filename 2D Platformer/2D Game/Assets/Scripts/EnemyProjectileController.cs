using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileController : MonoBehaviour
{
    [SerializeField] private int damage;
    private float lastEncounter;
    void OnTriggerEnter2D(Collider2D info)
    {
        if (Time.time - lastEncounter < 0.2f)
            return;

        lastEncounter = Time.time;
        PlayerController player = info.GetComponent<PlayerController>();
        if (player != null)
            player.TakeDamage(damage);

        Destroy(gameObject);
    }
}
