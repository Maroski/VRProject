using System;
using UnityEngine;

namespace Pilgrim.Controller
{
    abstract public class PlayerControllerBase
    {
        abstract public void OnClick();                     // User clicks button
        abstract public void OnHold(float delta);           // User Keeps button pressed
        abstract public void OnRelease(float delta);        // User releases button after holding it
        abstract public void OnHover(RaycastHit HitInfo);   // User looks at a selectable
        abstract public void OnHoverOff();                  // User stops looking at a selectable
    }

}
