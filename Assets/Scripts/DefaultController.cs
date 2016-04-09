using System;
using UnityEngine;

namespace Pilgrim.Controller
{
    public class DefaultController : PlayerControllerBase
    {
        [SerializeField] float m_WalkSpeed = 1.0f; // 1 unit per second
        private PlayerManager m_Manager;
        public DefaultController(PlayerManager manager)
        {
            m_Manager = manager;
        }

        override public void OnClick()
        {
            Debug.Log("OnClick");
        }

        override public void OnHold(float delta)
        {
            Vector3 move = m_Manager.GetLookDir() * m_Manager.getWalkSpeed() * Time.deltaTime;
            m_Manager.Move(move);
        }

        override public void OnRelease(float delta)
        {
            Debug.Log("OnRelease");
        }
    }
}

