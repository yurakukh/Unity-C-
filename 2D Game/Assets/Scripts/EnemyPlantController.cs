using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlantController : EnemyOrangeController
{
    [SerializeField] private GameObject projectfilePrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float bulletSpeed;
    [SerializeField] protected float angerRange;


    protected bool isAngry;
    protected bool attacking;

    //ref to our player
    protected PlayerController player;

    protected override void Start()
    {
        base.Start();
        player = FindObjectOfType<PlayerController>();
        StartCoroutine(ScanForPlayer());
    }

    protected override void Update()
    {
        if (isAngry)
            return;

        base.Update();
    }

    protected void Shoot()
    {
        GameObject bullet = Instantiate(projectfilePrefab, shootPoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
        Destroy(bullet, 5f);
    }


    protected IEnumerator ScanForPlayer()
    {
        while (true)
        {
            CheckPlayerInRange();
            yield return new WaitForSeconds(1f);
        }
    }

    protected virtual void CheckPlayerInRange()
    {
        if (player == null || attacking)
            return;

        if (Vector2.Distance(transform.position, player.transform.position) < angerRange)
        {
            isAngry = true;
            TurnToPlayer();
            ChangeState(EnemyState.Shoot);
        }
        else
        {
            isAngry = false;
        }
    }

    protected void TurnToPlayer()
    {
        if (player.transform.position.x - transform.position.x > 0 && !faceRight)
            Flip();
        else if (player.transform.position.x - transform.position.x < 0 && faceRight)
            Flip();
    }

    protected override void ChangeState(EnemyState state)
    {
        base.ChangeState(state);
        switch (state)
        {
            case EnemyState.Shoot:
                attacking = true;
                enemyRB.velocity = Vector2.zero;
                break;
        }
         
    } 

    protected virtual void EndState()
    {
        switch (currentState)
        {
            case EnemyState.Shoot:
                attacking = false;
                break;
        }
 
        if(!isAngry)
            ChangeState(EnemyState.Idle);
    }

    protected virtual void DoStateAction()
    {
        switch (currentState)
        {
            case EnemyState.Shoot:
                Shoot();
                break;
        }
    }

}
