using System;
using UnityEngine;
using Pilgrim.Interaction;
using Pilgrim.Player;

namespace Pilgrim.Controller
{
    public class ClimbingController : PlayerControllerBase
    {
        protected GameObject m_LastHit;
        private Vector3 m_Normal;
        public ClimbingController(PlayerManager manager, Vector3 normal) : base (manager)
        {
            m_Normal = normal;
        }

        override public void OnClick()
        {
            Vector3 look = m_Manager.GetLookDir();
            bool lookAway = (m_Normal - Vector3.Project(look, m_Normal)).magnitude < m_Normal.magnitude;
            m_Manager.ChangeContext(new DefaultController(m_Manager));

            if (lookAway)
            {
                m_Manager.Jump(45f);
            }
        }

        override public void OnHold(float delta)
        {
            Vector3 displacement = m_Manager.GetLookDir();
            displacement = displacement - Vector3.Project(displacement, m_Normal);
            m_Manager.Move(displacement);
        }
    }
}

