using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimalBaseController : NPCBaseController
{ 
    public AnimalBaseController()
    {
        this.CanBeKilled = false;
    }

    protected virtual void Eat() { }//this method can be overrided in child classes, because animals prefer different food

}
