using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseController : Interactable
{
    protected string Name{ get; set; }
    protected int HP{ get; set; }
    protected int Damage{ get; set; }
    protected float Speed { get; set; }

    public EnemyBaseController(string name)
    {
        Name = name;
    }

    protected virtual void Attack()
    {
        //attacking player
    }

    protected virtual void Move()
    {
        //moves in specified direction
    }

}

public enum EnemyWeaponType
{
    Bow,
    Sword,
    //another types of weapon
    //...
}
