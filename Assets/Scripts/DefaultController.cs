using System;
using UnityEngine;
using Pilgrim.Selectable;

namespace Pilgrim.Controller
{
    public class DefaultController : PlayerControllerBase
    {
        private GameObject m_LastHit;
        public DefaultController(PlayerManager manager) : base (manager)
        {
        }

        override public void OnClick()
        {
            if(m_LastHit != null)
            {
                Interactable interactor = m_LastHit.GetComponent<Interactable>();
                if (interactor != null)
                {
                    interactor.Respond(m_Manager);
                }
            }
        }

        override public void OnHold(float delta)
        {

            Vector3 displacement = m_Manager.GetMoveDir() * m_Manager.getWalkSpeed() * Time.deltaTime;
            m_Manager.Move(displacement);
        }
        
        override public void OnTargetChange(RaycastHit? HitInfo)
        {
            if(HitInfo != null)
            {
                m_LastHit = ((RaycastHit) HitInfo).collider.gameObject;
            }
            else
            {
                m_LastHit = null;
                GuiOutput.ClearDebugDistanceMessage();
                GuiOutput.ClearContextMessage();
            }
        }
    }
}

