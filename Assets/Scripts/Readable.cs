using System;
using System.Collections.Generic;
using UnityEngine;
using Pilgrim.Controller;

public class Readable : Interactable
{
    [SerializeField] private string m_Message;
    override public void Respond(PlayerManager m)
    {
        GuiOutput.Log("Read it");
        m.ChangeContext(new ReadController(m, m_Message)); 
    }
}
