using UnityEngine;
using System.Collections;
using Pilgrim.EnumTypes;
using System;

namespace Pilgrim.Selectable
{
    public class Teacher : Interactable
    {
        public EAbility m_Type; // To be set in the IDE
        
        override protected void Respond(PlayerManager manager)
        {
            manager.AcquireSkill(m_Type);
        }
    }
}