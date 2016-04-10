using System;
using UnityEngine;

namespace Pilgrim.Controller
{
    public class DefaultController : PlayerControllerBase
    {
        private GameObject m_LastHit;
        private PlayerManager m_Manager;
        public DefaultController(PlayerManager manager)
        {
            m_Manager = manager;
        }

        override public void OnClick()
        {
            if(m_LastHit != null)
            {
                Teacher SkillTeacher = m_LastHit.GetComponent<Teacher>();
                if (SkillTeacher != null)
                {
                    SkillTeacher.TeachAbility(m_Manager);
                }
            }
        }

        override public void OnHold(float delta)
        {
            Vector3 move = m_Manager.GetMoveDir() * m_Manager.getWalkSpeed() * Time.deltaTime;
            m_Manager.Move(move);
        }

        override public void OnRelease(float delta)
        {
            Debug.Log("OnRelease");
        }


        override public void OnHover(RaycastHit HitInfo)
        {
            m_LastHit = HitInfo.collider.gameObject;
        }

        override public void OnHoverOff()
        {
            m_LastHit = null;
        }
    }
}

