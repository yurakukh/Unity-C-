using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBaseController : Interactable
{
    protected string Name { get; set; }
    protected ItemType Type { get; set; }
    protected string Description { get; set; }


}

public enum ItemType
{
    HPHealer,
    MPHealer,
    DamageDealer,
    BalanceChanger
}