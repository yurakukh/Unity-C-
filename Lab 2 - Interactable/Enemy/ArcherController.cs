using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : WarriorController
{
   
    //for example, we can set number of arrows here
    private int NumberOfArrows { get; set; }
    public ArcherController(string name, EnemyWeaponType weaponType, int numberOfArrows)
        :base(name, weaponType)
    {
        this.HP = 50;
        this.Damage = 25;
        this.Speed = 10;
        this.NumberOfArrows = numberOfArrows;
    }

    protected override void Attack()
    {
        //attack using bow and arrows
        if (NumberOfArrows < 5)
            UseBurningArrows();
    }

    protected override void Move()
    {
        base.Move();
    }

    private void UseBurningArrows()
    {
        //implements archer`s ability to shooting burning arrows
    }

    public override void Interact()
    {
        base.Interact();
    }

}
