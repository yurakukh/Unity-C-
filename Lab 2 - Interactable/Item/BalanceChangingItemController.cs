using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BalanceChangingItemController : ItemBaseController
{

    protected virtual void ChangeBalance()
    {
        //add value to player`s balance
    }

    public override void Interact()
    {
        ChangeBalance();
    }

}
