﻿using UnityEngine;
using System.Collections;
using Pilgrim.Player;
using Pilgrim.Controller;
using Pilgrim.EnumTypes;

namespace Pilgrim.Trigger
{
    public class JumpTrigger : MonoBehaviour {
        [SerializeField] private float m_LaunchAngle;
        void OnTriggerEnter(Collider col)
        {
            PlayerManager pm = col.gameObject.GetComponent<PlayerManager>();
            if (pm != null)
            {
                if (pm.HasSkill(EAbility.Jump))
                    pm.ChangeContext(new JumpController(pm, m_LaunchAngle));
            }

        }

        void OnTriggerExit(Collider col)
        {
            PlayerManager pm = col.gameObject.GetComponent<PlayerManager>();
            if (pm != null)
            {
                pm.ChangeContext(new DefaultController(pm));
            }
        }
    }
}
