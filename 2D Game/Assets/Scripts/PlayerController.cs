using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private LevelManager levelManager;

    [SerializeField] private int maxHP;
    private int currentHP;
    [SerializeField] private int maxMP;
    private int currentMP;

    [SerializeField] Slider hpSlider;
    [SerializeField] Slider mpSlider;


    CharacterMovement playerMovement;
    Vector2 startPosition;

    private bool canBeDamaged = true;
    void Start()
    {
        playerMovement = GetComponent<CharacterMovement>();
        playerMovement.OnGetHurt += OnGetHurt;
        currentHP = maxHP;
        currentMP = maxMP;
        hpSlider.maxValue = maxHP;
        hpSlider.value = maxHP;
        mpSlider.maxValue = maxMP;
        mpSlider.value = maxMP;
        startPosition = transform.position;
        levelManager = LevelManager.Instance;
    }

   

    public void TakeDamage(int damage, DamageType type = DamageType.Casual, Transform enemy = null)
    {
        if (!canBeDamaged)
            return;

        currentHP -= damage;
        if (currentHP <= 0)
        {
            OnDeath();
        }

        switch (type)
        {
            case DamageType.PowerStrike:
                playerMovement.GetHurt(enemy.position);
                break;
        }
        hpSlider.value = currentHP;
    }

    private void OnGetHurt(bool canBeDamaged)
    {
        this.canBeDamaged = canBeDamaged;
    }
    public void RestoreHP(int hp)
    {
        currentHP += hp;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }

        hpSlider.value = currentHP;
        
    }

    public bool ChangeMP(int value)
    {
        Debug.Log("MP value: " + value);

        if (value < 0 && currentMP < Mathf.Abs(value))
            return false;


        currentMP += value;

        if(currentMP > maxMP)
            currentMP = maxMP;

        mpSlider.value = currentMP;

        return true;
    }


    public void OnDeath()
    {
        levelManager.Restart();
    }

   

}
