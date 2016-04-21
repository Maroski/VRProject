using System;
using System.Collections.Generic;
using UnityEngine;
using Pilgrim.EnumTypes;
using Pilgrim.Player;

namespace Pilgrim.Interaction
{
    public class Diggable : Interactable
    {
        override protected void Start()
        {
            m_Prereqs = new List<EAbility>();
            m_Prereqs.Add(EAbility.Dig);
        }

        override protected void Respond(PlayerManager m)
        {
            Destroy(gameObject);
        }
    }
}
