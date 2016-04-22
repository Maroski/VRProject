using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Pilgrim.Player;
using Pilgrim.Interaction;
using Pilgrim.EnumTypes;
using Pilgrim.Controller;

namespace Pilgrim.Trigger
{
    public class ClimbingTrigger : Interactable {
        private bool m_AllowClimb; 

        override protected void Start()
        {
            m_Prereqs = new List<EnumTypes.EAbility>();
            m_AllowClimb = false;
            m_Prereqs.Add(EAbility.Climb);
        }

        protected override bool AllowInteraction(PlayerManager m)
        {
            RaycastHit? HitInfo = m.GetLastTargetHitInfo();
            return m_AllowClimb && (HitInfo != null);
        }

        protected override void Respond(PlayerManager m)
        {
            RaycastHit? HitInfo = m.GetLastTargetHitInfo();
            Vector3 normal = ((RaycastHit)HitInfo).normal;
            m.ChangeContext(new ClimbingController(m, normal));
        }

        void OnTriggerEnter (Collider col)
        {
            PlayerManager pm = col.gameObject.GetComponent<PlayerManager>();
            if (pm != null)
            {
                m_AllowClimb = true;
            }
        }

        void OnTriggerExit (Collider col)
        {
            PlayerManager pm = col.gameObject.GetComponent<PlayerManager>();
            if (pm != null)
            {
                m_AllowClimb = false;
                if (pm.IsClimbing())
                {
                    pm.ChangeContext(new DefaultController(pm));
                }
            }

        }
    }

}