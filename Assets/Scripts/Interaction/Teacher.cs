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
            public GameObject bearObject;
            public EAbility m_Type; // To be set in the IDE

            override protected void Respond(PlayerManager manager)
            {
                manager.AcquireSkill(m_Type);

                if (m_Type == EAbility.Walk && bearObject != null)
                {
                    bearController bearScript = (bearController)bearObject.GetComponent(typeof(bearController));
                    bearScript.startRunning();
                }
            }
        }
    }
}
