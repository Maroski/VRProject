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
            m_Manager.ChangeContext(new DefaultController(m_Manager));
        }

        override public void OnHold(float delta)
        {
            Vector3 displacement = m_Manager.GetLookDir();
            displacement = displacement - Vector3.Project(displacement, m_Normal);
            m_Manager.Move(displacement);
        }
    }
}

