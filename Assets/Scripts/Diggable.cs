using System;
using System.Collections.Generic;
using UnityEngine;
using Pilgrim.EnumTypes;

public class Diggable : Interactable
{
    override public void Start()
    {
        m_Prereqs = new List<EAbility>();
        m_Prereqs.Add(EAbility.Dig);
    }

    override protected void Respond(PlayerManager m)
    {
        Destroy(gameObject); 
    }
}
