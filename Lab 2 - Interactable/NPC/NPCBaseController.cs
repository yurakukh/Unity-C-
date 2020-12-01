using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPCBaseController : Interactable
{
    protected string Name { get; set; }
    protected List<string> Replicas{ get; set; }
    protected bool CanBeKilled { get; set; } = true;
    
    protected virtual void Talk()
    {
        //talking it`s replicas
    }

    protected virtual void Move()
    {
        //moving everywhere, you know 
    }

}


