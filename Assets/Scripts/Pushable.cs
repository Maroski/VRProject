using System;
using UnityEngine;
using System.Collections.Generic;
using Pilgrim.Controller;
using Pilgrim.EnumTypes;

public class Pushable: Interactable
{
    override public void Start()
    {
        m_Prereqs = new List<EAbility>();
        m_Prereqs.Add(EAbility.Push);
    }
    override protected void Respond(PlayerManager manager)
    {
        manager.ChangeContext(new PushController(manager, this.gameObject));
    }
}
