using UnityEngine;
using System.Collections;
using Pilgrim.EnumTypes;
using System;
using Pilgrim.Player;

namespace Pilgrim.Interaction
{
    namespace Pilgrim.Interaction
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
}
