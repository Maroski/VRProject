using System;
using System.Collections.Generic;
using UnityEngine;
using Pilgrim.Controller;
using Pilgrim.EnumTypes;

public class Readable : Interactable
{
    override public void Start()
    {
        m_Prereqs = new List<EAbility>();
        m_Prereqs.Add(EAbility.Read);
    }

    [SerializeField] private string m_Message;
    override protected void Respond(PlayerManager m)
    {
        m.ChangeContext(new ReadController(m, m_Message)); 
    }
}
