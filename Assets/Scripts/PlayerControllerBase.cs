using System;
using UnityEngine;

namespace Pilgrim.Controller
{
    public class PlayerControllerBase
    {
        protected PlayerManager m_Manager;

        private PlayerControllerBase() { }

        protected PlayerControllerBase(PlayerManager manager)
        {
            m_Manager = manager;
        }

        virtual public void OnClick() { }                            // User clicks button
        virtual public void OnHold(float delta) { }                  // User Keeps button pressed
        virtual public void OnRelease(float delta) { }               // User releases button after holding it
        virtual public void OnHover(float delta) { }                 // User looks at an object for an extended period of time
        virtual public void OnTargetChange(RaycastHit? NewTarget) { } // User looks at a new object
    }

}
