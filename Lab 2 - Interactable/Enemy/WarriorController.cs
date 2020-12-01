using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WarriorController : EnemyBaseController
{
    protected EnemyWeaponType WeaponType { get; set; }

    public WarriorController(string name, EnemyWeaponType weaponType)
        :base(name)
    {
        this.HP = 100;
        this.Damage = 20;
        this.Speed = 7;
        this.WeaponType = weaponType;
    }

    protected override void Move()
    {
        base.Move();
    }
   


}
