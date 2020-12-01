using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LycanController : EnemyBaseController
{

    public LycanController(string name, float speed)
        :base(name)
    {
        this.HP = 75;
        this.Damage = 15;
        this.Speed = 10;
    }


    protected override void Move()
    {
        //move with certain speed
    }

    protected override void Attack()
    {
        base.Attack();
        BattleRoar();
    }

    protected virtual void Acceleration()
    {
        //increases enemy speed
    }

    protected virtual void BattleRoar()
    {
        //makes a roar that gives damage to a player
    }

    public override void Interact()
    {
        base.Interact();
    }

}
