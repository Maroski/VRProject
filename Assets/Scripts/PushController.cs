using System;
using UnityEngine;
using Pilgrim.Controller;

namespace Pilgrim.Controller
{
    public class PushController : PlayerControllerBase
    {
        private GameObject m_PushObject;

        public PushController(PlayerManager manager, GameObject pushObject) : base(manager)
        {
            m_PushObject = pushObject;
        }

        override public void OnHover(float delta)
        {
            Rigidbody mass = m_PushObject.GetComponent<Rigidbody>();
            mass.AddForce(new Vector3(0f, 10f, 0f));
        }

        override public void OnTargetChange(RaycastHit? NewTarget)
        {
            m_Manager.ChangeContext(new DefaultController(m_Manager));
        }
    }
}
