using System;
using UnityEngine;
using Pilgrim.Interaction;
using Pilgrim.Player;

namespace Pilgrim.Controller
{
    public class JumpController : DefaultController
    {
        private float m_LaunchAngle;
        public JumpController(PlayerManager manager, float launchAngle) : base (manager)
        {
            m_LaunchAngle = launchAngle;
        }

        override public void OnClick()
        {
            m_Manager.Jump(m_LaunchAngle);
        }
    }
}

