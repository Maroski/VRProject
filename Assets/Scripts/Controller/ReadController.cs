using System;
using UnityEngine;
using Pilgrim.Player;

namespace Pilgrim.Controller
{
    public class ReadController: PlayerControllerBase
    {
        public ReadController (PlayerManager m, string message) : base(m)
        {
            GuiOutput.DisplayFullText(message);
        }

        override public void OnClick()
        {
            QuitContext();
        }

        public override void OnTargetChange(RaycastHit? NewTarget)
        {
            QuitContext();
        }

        private void QuitContext()
        {
            GuiOutput.HideFullText();
            m_Manager.ChangeContext(new DefaultController(m_Manager));
        }
    }

}
