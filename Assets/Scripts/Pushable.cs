using System;
using UnityEngine;
using Pilgrim.Controller;
using Pilgrim.EnumTypes;

public class Pushable: Interactable
{
    override public void Respond(PlayerManager manager)
    {
        //TODO: put checks in here to handle skill prerequisites
        manager.ChangeContext(new PushController(manager, this.gameObject));
    }
}
