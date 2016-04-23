using System;
using System.Collections.Generic;
using UnityEngine;
using Pilgrim.Controller;
using Pilgrim.EnumTypes;
using Pilgrim.Player;


namespace Pilgrim.Interaction
{
    public class Readable : Interactable
    {
        [SerializeField] private string m_Message;

        override protected void Start()
        {
            m_Prereqs = new List<EAbility>();
            m_Prereqs.Add(EAbility.Read);
        }

        override protected void Respond(PlayerManager m)
        {
            m.ChangeContext(new ReadController(m, m_Message));
        }
    }
}
