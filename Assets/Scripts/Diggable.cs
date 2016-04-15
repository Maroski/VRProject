using System;
using System.Collections.Generic;
using UnityEngine;

public class Diggable : Interactable
{
    override public void Respond(PlayerManager m)
    {
        Destroy(gameObject); 
    }
}
