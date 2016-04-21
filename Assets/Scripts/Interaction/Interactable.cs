using System;
using UnityEngine;
using Pilgrim.EnumTypes;
using System.Collections.Generic;
using Pilgrim.Player;

namespace Pilgrim.Interaction
{
    abstract public class Interactable : MonoBehaviour
    {
        protected List<EAbility> m_Prereqs;

        virtual protected void Start()
        {
            m_Prereqs = new List<EAbility>();
        }

        private bool MeetsPrereqs(PlayerManager m)
        {
            foreach (EAbility skill in m_Prereqs)
            {
                if (!m.HasSkill(skill))
                {
                    GuiOutput.Log(String.Format("{0} is required to interact!", skill));
                    return false;
                }
            }
            return true;
        }

        public void Interact(PlayerManager m)
        {
            // If the character has the skill prereqs and meets any additional requirements
            // set by the object, then the object will respond to the character.
            if (MeetsPrereqs(m) && AllowInteraction(m))
            {
                Respond(m);
            }
        }

        // The object may have additional requirements before an interaction is possible
        virtual protected bool AllowInteraction(PlayerManager m)
        {
            return true;
        }

        // The actual interaction code goes in here.
        abstract protected void Respond(PlayerManager m);
    }
}
